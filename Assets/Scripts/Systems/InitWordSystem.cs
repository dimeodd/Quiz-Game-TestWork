using MyEcs;
using EcsStructs;
using UnityEngine;

namespace EcsSystems
{
    public class InitWordSystem : IInit
    {
        StaticData _stData = null;
        LevelData _level = null;
        SceneData _scene = null;
        EcsWorld _world = null;

        public void Init()
        {
            var word = _level.Word.ToLower();
            var count = word.Length;
            var rect = _scene.WordSpace;
            var spacing = _stData.WordSpacing;

            var charWidth = _stData.WordPrefab.GetComponent<RectTransform>().rect.width;
            var wordWidt = (charWidth + spacing) * count - spacing;
            var offset = wordWidt * -0.5f;

            _scene.WordSpace.localScale *= 720 / wordWidt;

            for (int i = 0; i < count; i++)
            {
                var go = MonoBehaviour.Instantiate(_stData.WordPrefab, _scene.WordSpace);
                var tf = go.GetComponent<RectTransform>();

                tf.localPosition = new Vector3(offset + i * (charWidth + spacing), 0);
                var provider = go.GetComponent<WordProvider>();
                provider.Text.text = word[i].ToString();
                provider.Text.enabled = false;

                var ent = _world.NewEntity();
                ref var data = ref ent.Get<WordCharData>();
                data.letter = word[i];
                data.provider = provider;
            }
        }
    }
}