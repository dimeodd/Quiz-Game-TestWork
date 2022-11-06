using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelsTotalScript : MonoBehaviour
{
    private void OnEnable()
    {
        var txt = GetComponent<Text>();
        txt.text = string.Format(
            "{0}/{1}",
            SaveService.WordsCompleted,
            SaveService.AllWordsCount
        );
    }
}