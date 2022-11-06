using MyEcs;
using EcsStructs;

namespace EcsSystems
{
    public class WinSystem : IUpd
    {
        Filter<WordCharData> wordCharFilter = null;
        SceneData _scene = null;
        LevelData _level = null;

        bool _isWin = false;

        public void Upd()
        {
            wordCharFilter.GetEnumerator();
            if (wordCharFilter.Count > 0) return;
            if (_isWin) return;

            _isWin = true;

            //TODO запись в SaveData;
            //текущее слово и прибавить очки

            if (false)
            {
                _scene.GameWinPanel.SetActive(true);
            }
            else
            {
                _scene.LevelWinPanel.SetActive(true);
            }
        }
    }
}