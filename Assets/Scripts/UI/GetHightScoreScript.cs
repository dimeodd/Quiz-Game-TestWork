using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetHightScoreScript : MonoBehaviour
{
    private void OnEnable()
    {
        var txt = GetComponent<Text>();
        txt.text = SaveService.GetHightScore().ToString();
    }
}
