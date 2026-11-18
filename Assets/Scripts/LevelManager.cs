
using System.Diagnostics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private ClickDetection ClickDetection;

    public int Level = 1;

    void Start()
    {
        
    }

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameobject);

    }


    public void LoadLevel(int level)
    {
        //this.level = level;

        if (level > 2)
        {
            //LevelManager.LoadScene("WinScreen");
        }   else 
        {   
            //LevelManager.LoadScene("Level" + level);
        }

        /*
        public TMP_Text scoreText;
        public TMP_Text livesText;

        */
        
        

    }


    public void LoadScene()
    {
        int number = 0;
        number++;
    }
    // Update is called once per frame
    void Update()
    {
        
}
    }



