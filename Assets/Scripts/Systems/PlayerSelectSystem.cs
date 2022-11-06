using MyEcs;
using EcsStructs;

namespace EcsSystems
{
    public class PlayerSelectSystem : IUpd
    {
        Filter<SelectedTag, LetterData> selectFilter = null;
        Filter<WordCharData> wordFilter = null;

        StaticData _stData = null;
        SceneData _scene = null;
        EcsWorld _world = null;

        public void Upd()
        {
            foreach (var j in selectFilter)
            {
                var ent = selectFilter.GetEntity(j);
                ref var select = ref selectFilter.Get2(j);
                bool contain = false;

                foreach (var i in wordFilter)
                {
                    var wordEnt = wordFilter.GetEntity(i);
                    ref var wordChar = ref wordFilter.Get1(i);
                    if (wordChar.letter == select.letter)
                    {
                        contain = true;
                        wordEnt.Get<OpenCharTag>();
                    }
                }

                select.provider.Button.enabled = false;
                if (contain)
                {
                    select.provider.gameObject.SetActive(false);
                    // select.provider.Text.color = _stData.RightColor;
                    // select.provider.Image.color = _stData.RightColor;
                }
                else
                {
                    select.provider.gameObject.SetActive(false);
                    // select.provider.Text.color = _stData.WrongColor;
                    // select.provider.Image.color = _stData.WrongColor;

                    var removeEnt = _world.NewEntity();
                    removeEnt.Get<RemoveTryTag>();
                }

                ent.Destroy();
                break;
            }

        }
    }
}