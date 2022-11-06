using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelsTotalScript : MonoBehaviour
{
    void Start()
    {
        var txt = GetComponent<Text>();
        txt.text = SaveService.GetLevelsCounterLabel();
    }
}