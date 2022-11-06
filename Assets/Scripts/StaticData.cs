using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StaticData", menuName = "Quiz-Game-TestWork/StaticData", order = 0)]
public class StaticData : ScriptableObject
{
    public TextAsset SourceText;
    public int MinWordLength;
    public int TryCount;

    [Header("Prefabs")]
    public GameObject LetterPrefab;
    public GameObject WordPrefab;

    [Header("Graphic")]
    public Color RightColor;
    public Color WrongColor;
    public float LetterSpacing;
    public float WordSpacing;

    public const float gridWidth = 5;
    public const float gridHeight = 6;
}