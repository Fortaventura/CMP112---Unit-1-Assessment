using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Diagnostics;
public class GameOverScript : MonoBehaviour
{

    public LevelManager LevelManager;

    public GameObject deathMessage;
    public GameObject retryButton;
    public GameObject winMessage;

    void Awake()
    {
        //DontDestroyOnLoad(this.GameObject);
    }

    public void Setup_died()
    {
        deathMessage.SetActive(true);
        retryButton.SetActive(true);
        winMessage.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Setup_win()
    {
        deathMessage.SetActive(false);
        retryButton.SetActive(false);
        winMessage.SetActive(true);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Retry()
    {

        //gameObject.SetActive(false);
        LevelManager.RetryLevel();
        Debug.Log("This reloads the level");
    }
}
