using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBlocks : MonoBehaviour
{
    public GameObject FinishBlock; //Add the right finish block
    public LaserMovement movement; //Referencing laser movement

    public float startScore = 0f;
    public float currentScore;

    //public ProgressBar progressBar;


    private void Start()
    {
        currentScore = startScore;
        ProgressBar.progressvalue = 0;
        //progressBar.SetProgress(startScore);
    }

    private void Update()
    {
        if(currentScore == 3f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //If laserbeam hits finish
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag == FinishBlock.tag)
        {

            //Stop movement
            other.GetComponent<LaserMovement>().EndPositionLaser();

            //Light turns on
            //currentScore = currentScore + 1.0f;
            //progressBar.SetProgress(20);

            ProgressBar.progressvalue = ProgressBar.progressvalue + 1.0f;
            //p.progressvalue = p.progressvalue + 1.0f;
            if(ProgressBar.progressvalue >= 4.0)
                {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        } else
        {
            Debug.Log("Short Circuit!");
            
            //Reset Position
            other.GetComponent<LaserMovement>().StartPositionLaser();

            //Light crash fx
        }
    }
}
