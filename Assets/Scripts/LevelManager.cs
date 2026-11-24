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

        LoadLevel(level); //Loads level1 to begin the game.
    }

    public void RetryLevel()
    { //Called when the retry button is clicked.
        LoadLevel(level);
    }

    public void LoadLevel(int level)
    {
        if (level == 1)
        {
            Player.transform.position = new Vector2 (-10, -7); //The player's starting position in level1...
        }
        else
        {
            Player.transform.position = new Vector2 (11, -6); //...and level2.
        }
        gameOverScript.Hide();
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("Level" + level);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level" + level);
        LoadLevel(level);
    }
    
    public void Died()
    {
        gameOverScript.Setup_died(); //Activates the overlay to show the game over screen.
        Time.timeScale = 0.0f;
    }

    public void Completed()
    {
        level ++;
        Debug.Log("End reached!");
        gameOverScript.Setup_win(); //Activates the overlay to show the win screen.
        Time.timeScale = 0.0f;   
    }
}
