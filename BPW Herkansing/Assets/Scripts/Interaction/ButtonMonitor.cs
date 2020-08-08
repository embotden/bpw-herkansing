using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMonitor : MonoBehaviour
{
    public GameObject RightClickHelp; //UI Right click

    public Animator animator;

    public bool oneButton = false;
    public bool bothButtons = false;


    private void Start()
    {
        RightClickHelp.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (bothButtons) //Load next scene if both buttons are being pressed
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //Enemy walked over button
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy pressed buttons");

            oneButton = true;

            StartCoroutine(OneButtonIsPressed());
        }
    }

    //Bijhouden of er op beide knoppen gedrukt is
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (oneButton)
            {
                //Right Mouse click UI
                RightClickHelp.gameObject.SetActive(true);

                //Right click
                if (Input.GetMouseButtonDown(1) && oneButton)
                {
                    //Play interact animation
                    animator.SetTrigger("Interact");

                    bothButtons = true;
                }
            }
        }
    }

    IEnumerator OneButtonIsPressed()
    {
        yield return new WaitForSeconds(4f);

        oneButton = false;

        //Right Mouse click UI
        RightClickHelp.gameObject.SetActive(false);
    }
}
