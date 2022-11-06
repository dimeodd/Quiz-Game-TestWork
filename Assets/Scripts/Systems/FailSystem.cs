using MyEcs;
using EcsStructs;
using UnityEngine;

namespace EcsSystems
{
    public class FailSystem : IUpd
    {
        Filter<FailTag> failFilter = null;
        SceneData _scene = null;

        bool isFail = false;

        public void Upd()
        {
            failFilter.GetEnumerator();
            if (failFilter.Count == 0) return;
            if (isFail) return;

            isFail = true;

            var currScore = SaveService.Score;
            var hightScore = PlayerPrefs.GetInt("HightScore", 0);
            if (currScore > hightScore)
            {
                PlayerPrefs.SetInt("HightScore", currScore);
                hightScore = currScore;
                _scene.FailPanelNewHightScore.SetActive(true);
            }

            SaveService.NewGame(0);

            _scene.FailPanel.SetActive(true);
        }
    }
}