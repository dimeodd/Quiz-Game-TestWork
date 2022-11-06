using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveService
{
    static SaveData _save;
    static string[] _words;

    static string savePath = Application.persistentDataPath + "/1.save";

    [RuntimeInitializeOnLoadMethod]
    public static void Init()
    {
        var stData = Resources.Load<StDataProvider>("StDataProvider").staticData;
        var parcer = new TextParcer(stData.SourceText.text, stData.MinWordLength);
        _words = parcer.GetResult();

        var file = new FileInfo(savePath);

        if (file.Exists)
            Load();
        else
            NewGame(0);

        Debug.Log("SaveService: Сохранение успешно загружено");
    }

    public static string[] GetAllWords() => _words;
    public static int AllWordsCount => _words.Length;
    public static int WordsCompleted => _save.CompletedWords.Length;
    public static int Score => _save.Score;

    public static void NewGame(int seed)
    {
        _save = new SaveData();
        _save.Seed = seed;
        _save.CompletedWords = new int[0];
        Save();
    }
    public static void AddCompletedWord(string word, int tryLeft)
    {
        var wordId = Array.FindIndex(_words, 0, _words.Length, x => x == word);

        Array.Resize(ref _save.CompletedWords, _save.CompletedWords.Length + 1);
        _save.CompletedWords[_save.CompletedWords.Length - 1] = wordId;

        Array.Sort(_save.CompletedWords);
        Save();
    }

    public static string GetNextWord()
    {
        var max = _words.Length;
        var currCount = _save.CompletedWords.Length;
        UnityEngine.Random.InitState(_save.Seed);

        for (int i = 0; i < currCount; i++)
        {
            UnityEngine.Random.Range(0, max);
        }

        var index = UnityEngine.Random.Range(0, max);

        while (Array.Exists(_save.CompletedWords, x => x == index))
        {
            index++;
            if (index >= max)
                index = 0;
        }

        return _words[index];
    }

    static void Load()
    {
        var formatter = new BinaryFormatter();
        using (var fs = new FileStream(savePath, FileMode.OpenOrCreate))
        {
            _save = (SaveData)formatter.Deserialize(fs);
        }
    }

    static void Save()
    {
        var formatter = new BinaryFormatter();
        using (var fs = new FileStream("people.dat", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fs, _save);
        }
    }
}
