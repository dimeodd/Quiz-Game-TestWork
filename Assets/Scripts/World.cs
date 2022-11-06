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

    [Header("Все слова")]
    //Специально оставил тут для того, чтобы можно было проверить список всех слов из текста в редакторе
    public string[] Words;

    EcsWorld _world;
    EcsSystem _allSys, _upd, _fixUpd;

    void Start()
    {
        var parcer = new TextParcer(StaticData.SourceText.text, StaticData.MinWordLength);
        Words = parcer.GetResult();

        _world = new EcsWorld();

        _upd = new EcsSystem(_world)
            .Add(new InitLettersSystem())
            ;

        _fixUpd = new EcsSystem(_world);

        _allSys = new EcsSystem(_world)
            .Add(_upd)
            .Add(_fixUpd)
            .Inject(StaticData)
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
