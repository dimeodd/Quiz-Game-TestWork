using MyEcs;
using EcsStructs;
using UnityEngine;

namespace EcsSystems
{
    public class OpenCharSystem : IUpd
    {
        Filter<OpenCharTag, WordCharData> filter = null;
        public void Upd()
        {
            foreach (var i in filter)
            {
                var ent = filter.GetEntity(i);
                ref var charData = ref filter.Get2(i);

                charData.provider.Text.enabled = true;
                charData.provider.Image.color = Color.white;

                ent.Destroy();
            }

        }
    }
}