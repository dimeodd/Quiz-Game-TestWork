using MyEcs;
using EcsStructs;
using UnityEngine;

namespace EcsSystems
{
    public class InitLettersSystem : IInit
    {
        StaticData _stData = null;
        SceneData _scene = null;
        EcsWorld _world = null;

        public void Init()
        {
            var rect = _scene.LetterGrid.rect;
            var space = _stData.LetterSpacing;

            var z = space * (StaticData.gridWidth - 1);
            var w = (rect.width - z) / StaticData.gridWidth;
            var h = (rect.height - z) / StaticData.gridHeight;


            for (int i = 0, ch = 'A'; i < 26; i++, ch++)
            {
                var x = i % (int)StaticData.gridWidth * (w + space);
                var y = (StaticData.gridWidth - i / (int)StaticData.gridWidth) * (h + space);

                var go = MonoBehaviour.Instantiate(_stData.LetterPrefab, _scene.LetterGrid);
                var rTf = go.GetComponent<RectTransform>();
                var provider = go.GetComponent<LetterProvider>();

                rTf.sizeDelta = new Vector2(w, h);
                rTf.localPosition = new Vector3(x, y);
                provider.Text.text = ((char)ch).ToString();
            }
        }
    }
}