using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    public GameObject RightClickHelp; //UI right click

    public Animator animator;

    public GameObject door;

    public bool oneButton = false;
    public bool bothButtons = false;


    private void Start()
    {
        RightClickHelp.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(bothButtons) //Open door if both buttons are being pressed at the same time
        {
            door.GetComponent<Door>().OpenTheDoor();
        }
    }

    //Enemy walked over button
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
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
