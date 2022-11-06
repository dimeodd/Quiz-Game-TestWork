using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetCurrScoreScript : MonoBehaviour
{
    private void OnEnable()
    {
        var txt = GetComponent<Text>();
        txt.text = SaveService.Score.ToString();
    }
}
