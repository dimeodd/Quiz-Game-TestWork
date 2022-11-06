using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    void Start()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadMenu);
    }

    void LoadMenu()
    {
        var level = new LevelData();
        level.Word = "TODOwordFromSaveService"; //TODO получить из сохранениея следующее слово
        World.Level = level;

        SceneManager.LoadScene(1);
    }
}
