using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Diagnostics;
public class GameOverScript : MonoBehaviour
{

    public LevelManager LevelManager;

    public GameObject deathMessage;
    public GameObject winMessage;

    //public GameOverScript gameOverScript;
    void Awake()
    {
        //DontDestroyOnLoad(this.GameObject);
    }
    //public LevelManager LevelManager;

    public void setup_died()
    {
        deathMessage.SetActive(true);
        winMessage.SetActive(false);
        gameObject.SetActive(true);
    }

    public void setup_win()
    {
        deathMessage.SetActive(false);
        winMessage.SetActive(true);
        gameObject.SetActive(true);
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }

    public void Retry()
    {

        //gameObject.SetActive(false);
        LevelManager.retryLevel();
        Debug.Log("This reloads the level");
    }
}
