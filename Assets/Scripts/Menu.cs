using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void options()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void quit() =>
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
}
