using MyEcs;
using EcsStructs;

namespace EcsSystems
{
    public class TryCounterSystem : IInit, IUpd
    {
        Filter<RemoveTryTag> removefilter = null;
        Filter<TryCounterData> tryFilter = null;

        StaticData _stData = null;
        SceneData _scene = null;
        EcsWorld _world = null;

        public void Init()
        {
            var ent = _world.NewEntity();
            ref var counter = ref ent.Get<TryCounterData>();

            counter.tryLeft = _stData.TryCount;
            counter.Text = _scene.TryCount;

            counter.Text.text = counter.tryLeft.ToString();
        }

        public void Upd()
        {
            removefilter.GetEnumerator();
            if (removefilter.Count == 0) return;

            foreach (var i in tryFilter)
            {
                ref var counter = ref tryFilter.Get1(i);
                counter.tryLeft--;

                if (counter.tryLeft >= 0)
                {
                    counter.Text.text = counter.tryLeft.ToString();
                }
                else
                {
                    var ent = _world.NewEntity();
                    ent.Get<FailTag>();
                }
            }

        }
    }
}