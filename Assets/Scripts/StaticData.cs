using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StaticData", menuName = "Quiz-Game-TestWork/StaticData", order = 0)]
public class StaticData : ScriptableObject
{
    public TextAsset SourceText;
    public int MinWordLength;
    public int TryCount;
}