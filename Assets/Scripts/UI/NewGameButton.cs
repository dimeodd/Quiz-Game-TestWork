using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public Button PlayButton;
    public Button NewSeedButton;
    public InputField SeedField;

    System.Random _rnd;

    void Start()
    {
        var seed = (int)System.DateTime.UtcNow.Ticks;
        _rnd = new System.Random(seed);
        SeedField.text = seed.ToString();

        PlayButton.onClick.AddListener(Play);
        NewSeedButton.onClick.AddListener(NewSeed);
    }

    void Play()
    {
        if (!int.TryParse(SeedField.text, out var seed)) return;

        SaveService.NewGame(seed);

        var level = new LevelData();
        level.Word = SaveService.GetNextWord();
        World.Level = level;

        SceneManager.LoadScene(1);
    }

    void NewSeed()
    {
        var seed = _rnd.Next();
        SeedField.text = seed.ToString();
    }
}
