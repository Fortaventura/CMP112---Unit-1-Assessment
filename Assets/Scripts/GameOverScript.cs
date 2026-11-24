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

    public void Setup_died()
    { //Shows the overlay, but cancels winMessage.
        gameObject.SetActive(true);
        deathMessage.SetActive(true);
        winMessage.SetActive(false);
    }

    public void Setup_win()
    { //Shows the overlay, but cancels deathMessage.
        gameObject.SetActive(true);
        deathMessage.SetActive(false);
        winMessage.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    //public void Retry()
    //{
    //    LevelManager.RetryLevel();
    //    Debug.Log("This reloads the level");
    //}
}
