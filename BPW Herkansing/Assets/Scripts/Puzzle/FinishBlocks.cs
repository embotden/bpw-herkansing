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

    private void Start()
    {
        currentScore = startScore;
        ProgressBar.progressvalue = 0;
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

            ProgressBar.progressvalue = ProgressBar.progressvalue + 1.0f;
            if(ProgressBar.progressvalue >= 4.0)
                {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        } else
        {
            //Reset Position
            other.GetComponent<LaserMovement>().StartPositionLaser();
        }
    }
}
