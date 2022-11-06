using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetHightScoreScript : MonoBehaviour
{
    void Start()
    {
        var txt = GetComponent<Text>();
        txt.text = SaveService.GetHightScore().ToString();
    }
}
