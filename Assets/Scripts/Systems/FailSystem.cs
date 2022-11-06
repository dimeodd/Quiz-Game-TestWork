using MyEcs;
using EcsStructs;

namespace EcsSystems
{
    public class FailSystem : IUpd
    {
        Filter<FailTag> failFilter = null;
        SceneData _scene = null;

        public void Upd()
        {
            failFilter.GetEnumerator();
            if (failFilter.Count == 0) return;

            _scene.FailPanel.SetActive(true);
            //TODO сравнить с максимальным счётом, и возможно перезаписать его;
            //TODO удаление сохранение;
        }
    }
}