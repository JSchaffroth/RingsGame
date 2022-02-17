using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    private int score;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text itemsText;
    private int lives;
    private string itemstr1;
    private string itemstr2;

    public GameObject[] items;


    // Start is called before the first frame update
    void Start()
    {
        items = new GameObject[2];
        score = 0;
        lives = 1;
    }

    public void insertItem(GameObject obj)
    {
        Debug.Log("Inserting item: " + obj.name);
        if (items[0] == null)
        {
            items[0] = obj;
        }
        else if (items[1] == null)
        {
            items[1] = obj;
        }
        else
            Destroy(obj);
    }

    public void increaseScore()
    {
        score++;
    }

    public void decreaseHealth()
    {
        lives--;
    }

    public void increaseHealth()
    {
        if (lives < 3)
        {
            lives++;
        }
    }

    private void useItem(string name, int index)
    {
        GameObject obj = items[index];
        if (name.Equals("heart(Clone)"))
        {
            increaseHealth();
        }
        if (name.Equals("gas(Clone)"))
        {
        }
        if (name.Equals("shield(Clone)"))
        {
        }
        Destroy(items[index]);
        //items[index] = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            GameObject obj = items[0];
            if (obj == null)
            {
                Debug.Log("There is nothing in items[0]");
            }
            else if (obj.name.Equals("heart(Clone)"))
            {
                useItem(obj.name, 0);
            }
        }

        if (Input.GetKeyDown("2"))
        {
            GameObject obj = items[1];
            if (obj == null)
            {
                Debug.Log("There is nothing in items[1]");
            }
            else if (obj.name.Equals("heart(Clone)"))
            {
                useItem(obj.name, 1);
            }
        }

        if (lives == 0)
        {
            endgame(score);
        }


        livesText.text = "Health: " + lives;
        scoreText.text = "Score: " + score;
        if (items[0] == null)
        {
            itemstr1 = "";
        }
        else
        {
            itemstr1 = items[0].name.Substring(0, items[0].name.Length-7);  //substracting the last 7 digits deletes the '(Clone)' substring from the name
        }
        if (items[1] == null)
        {
            itemstr2 = "";
        }
        else
            itemstr2 = items[1].name.Substring(0, items[1].name.Length-7);  //substracting the last 7 digits deletes the '(Clone)' substring from the name
        itemsText.text = "Item 1: " + itemstr1 + "\nItem 2: " + itemstr2;
    }

    void endgame(int score)
    {
        Singleton.Instance.score = this.score;
        SceneManager.LoadScene("GameOverScene");
    }
}
