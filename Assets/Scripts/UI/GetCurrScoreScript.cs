using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetCurrScoreScript : MonoBehaviour
{
    void Start()
    {
        var txt = GetComponent<Text>();
        txt.text = SaveService.Score.ToString();
    }
}
