//using System.Diagnostics;
//using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//using System.Numerics;

public class LevelManager : MonoBehaviour
{
    public GameOverScript gameOverScript;
    public GameObject Player;

    public int level = 1;

     
    //private new Vector2 startPos2 = (11,-6);


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        LoadLevel(1);
    }

    public void retryLevel()
    {
        LoadLevel(level);
    }

    public void LoadLevel(int level)
    {
        if (level == 1)
        {
        Player.transform.position = new Vector2 (-10, -7);
        }
        else
        {
         Player.transform.position = new Vector2 (11, -6);   
        }
        gameOverScript.hide();
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("Level" + level);


    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level" + (level + 1));
    }
    
    public void Died()
    {
        gameOverScript.setup_died();
        Time.timeScale = 0.0f;
    }

    public void Completed()
    {
        level ++;
        Debug.Log("End reached!");
        gameOverScript.setup_win();
        Time.timeScale = 0.0f;   
    }

    
}
