using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ //Brackeys tutotial GAME OVER- How to make a video game in unity (E08)
    
    public float restartDelay = 1f;

    bool gameHasEnded = false;

   public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver");

            //Restart Level
            Invoke("Restart", restartDelay);
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
