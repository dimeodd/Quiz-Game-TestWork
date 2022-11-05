using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEcs;

public class World : MonoBehaviour
{
    public StaticData StaticData;
    public LevelData Level;
    public SceneData Scene;

    EcsWorld _world;
    EcsSystem _allSys, _upd, _fixUpd;

    void Start()
    {
        var parcer = new TextParcer(StaticData.SourceText.text, StaticData.MinWordLength);
        Scene.Words = parcer.GetResult();

        _world = new EcsWorld();

        _upd = new EcsSystem(_world);

        _fixUpd = new EcsSystem(_world);

        // _allSys = new EcsSystem(_world)
        //     .Add(_upd)
        //     .Add(_fixUpd)
        //     .Inject(StaticData)
        //     .Inject(Level)
        //     .Inject(Scene);
    }

    void Update()
    {
        // _upd.Upd();
    }

    void FixedUpdate()
    {
        // _fixUpd.Upd();
    }
}
