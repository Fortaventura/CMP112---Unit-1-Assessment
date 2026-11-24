//using System.Diagnostics;
using TMPro;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public PlayerMovement PlayerMovement;

    public GameObject winMessage;
    
    
    public GameObject deathMessage;
    
    
    public GameObject retryButton;

    public GameObject Player;

    //void Start()
    //{
      //  deathMessage.SetActive(false);
      //  winMessage.SetActive(false);
    //}
 
}
