using MyEcs;
using EcsStructs;
using UnityEngine;

namespace EcsSystems
{
    public class FailSystem : IUpd
    {
        Filter<FailTag> failFilter = null;
        SceneData _scene = null;
        LevelData _level = null;

        bool isFail = false;

        public void Upd()
        {
            failFilter.GetEnumerator();
            if (failFilter.Count == 0) return;
            if (isFail) return;

            isFail = true;

            var provider = _scene.FailPanel;

            var currScore = SaveService.Score;
            var hightScore = SaveService.GetHightScore();
            if (currScore > hightScore)
            {
                SaveService.SetHightScore(currScore);
                hightScore = currScore;
                provider.NewHightScore.SetActive(true);
            }

            provider.wordText.text = _level.Word;
            provider.gameObject.SetActive(true);

            SaveService.NewGame(0);

        }
    }
}