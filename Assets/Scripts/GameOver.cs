using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public TMP_Text scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = Singleton.Instance.score;
        AudioManager.instance.playSound("GameOver"); ;
        //FindObjectOfType<AudioManager>().playSound("GameOver");
        scoreText.text = "Score: " + Singleton.Instance.score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
