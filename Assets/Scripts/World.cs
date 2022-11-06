using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEcs;
using EcsSystems;
using EcsStructs;

public class World : MonoBehaviour
{
    public static LevelData Level;

    public StaticData stData;
    public LevelData level;
    public SceneData scene;

    EcsWorld _world;
    EcsSystem _upd;

    // *** Тому кто будет проверять этот код ***
    // Сюда дублируется список всех слов, которые были получены из текста
    public string[] AllWords;

    void Start()
    {
        AllWords = SaveService.GetAllWords();

        if (Level != null)
        {
            level = Level;
        }

        _world = new EcsWorld();

        _upd = new EcsSystem(_world)
            .Add(new InitLettersSystem())
            .Add(new InitWordSystem())

            .Add(new PlayerSelectSystem())
            .Add(new TryCounterSystem())
            .Add(new OpenCharSystem())
            .Add(new WinSystem())
            .Add(new FailSystem())

            .OneFrame<OpenCharTag>()
            .OneFrame<RemoveTryTag>()

            .Inject(stData)
            .Inject(level)
            .Inject(scene);
        _upd.Init();
    }

    void Update()
    {
        _upd.Upd();
    }
}
