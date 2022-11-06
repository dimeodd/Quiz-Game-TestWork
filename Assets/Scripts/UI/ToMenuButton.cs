using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ToMenuButton : MonoBehaviour
{
    void Start()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadMenu);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
