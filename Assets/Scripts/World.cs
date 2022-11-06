using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEcs;
using EcsSystems;

public class World : MonoBehaviour
{
    public StaticData StaticData;
    public LevelData Level;
    public SceneData Scene;

    EcsWorld _world;
    EcsSystem _allSys, _upd, _fixUpd;

    void Start()
    {
        _world = new EcsWorld();

        _upd = new EcsSystem(_world)
            .Add(new InitLettersSystem())
            .Add(new InitWordSystem());

        _fixUpd = new EcsSystem(_world);

        _allSys = new EcsSystem(_world)
            .Add(_upd)
            .Add(_fixUpd)
            .Inject(StaticData)
            .Inject(Level)
            .Inject(Scene);
        _allSys.Init();
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
