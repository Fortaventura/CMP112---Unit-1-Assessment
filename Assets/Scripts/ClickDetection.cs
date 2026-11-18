//using System.Diagnostics;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    LevelManager LevelManager;

    public GameObject DeathMessage;
    public GameObject WinMessage;
    public GameObject retryButton;

    void Start()
    {
        
    }
    
    public void ResetLevel()
    {
        //retryButton.onClick(ResetLevel());
        
        Debug.Log("The level is reset");
        DeathMessage.SetActive(false);
        WinMessage.SetActive(false);
        retryButton.SetActive(false);

        //Reset pakyerpos
        

       
        /*
        gameManager.score = 0;
        gameManager.lives = 3;
        gameManager.ballDamage = 1;
        gameManager.paddleScale = 1;
        gameManager.ballSpeed = 8;
        gameManager.currency = 0;

        gameManager.LoadLevel(1);
        */
    }



}
