using MyEcs;
using EcsStructs;
using UnityEngine;

namespace EcsSystems
{
    public class WinSystem : IUpd
    {
        Filter<WordCharData> wordCharFilter = null;
        Filter<TryCounterData> tryFilter = null;
        SceneData _scene = null;
        LevelData _level = null;

        bool _isWin = false;

        public void Upd()
        {
            wordCharFilter.GetEnumerator();
            if (wordCharFilter.Count > 0) return;
            if (_isWin) return;

            _isWin = true;
            int tryLeft = 0;

            foreach (var i in tryFilter)
            {
                ref var item = ref tryFilter.Get1(i);
                tryLeft = item.tryLeft;
                break;
            }

            SaveService.AddCompletedWord(_level.Word, tryLeft);
            var isEndOfGame = SaveService.WordsCompleted == SaveService.AllWordsCount;

            var currScore = SaveService.Score;
            var hightScore = SaveService.GetHightScore();
            if (currScore > hightScore)
            {
                PlayerPrefs.SetInt("HightScore", currScore);
                hightScore = currScore;
            }

            if (isEndOfGame)
            {
                _scene.GameWinPanel.SetActive(true);
                SaveService.NewGame(0);
            }
            else
            {
                _scene.LevelWinPanel.SetActive(true);
            }
        }
    }
}