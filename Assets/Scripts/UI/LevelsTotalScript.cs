using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelsTotalScript : MonoBehaviour
{
    private void OnEnable()
    {
        var txt = GetComponent<Text>();
        txt.text = SaveService.GetLevelsCounterLabel();
    }
}