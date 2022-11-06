using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneData : MonoBehaviour
{
    public GameObject GameWinPanel;
    public GameObject LevelWinPanel;
    public FailPanelProvider FailPanel;

    public Text ScoreCount;
    public Text TryCount;
    public RectTransform LetterGrid;
    public RectTransform WordSpace;
}
