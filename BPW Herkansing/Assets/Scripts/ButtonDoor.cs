using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    public GameObject RightClickHelp;

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
        if(bothButtons)
        {
            Debug.Log("Door opening");

            door.GetComponent<Door>().OpenTheDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy pressed buttons");

            oneButton = true;

            StartCoroutine(OneButtonIsPressed());

            //Deur bij laten houden of er op beide knoppen gedrukt is
        }
    }

    //Bijhouden of er op beide knoppen gedrukt is
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player in the zone");

            if (oneButton)
            {
                //Right Mouse click UI
                RightClickHelp.gameObject.SetActive(true);

                //Right click
                if (Input.GetMouseButtonDown(1) && oneButton)
                {
                    Debug.Log("Buttons pressed");

                    //Play interact animation
                    animator.SetTrigger("Interact");

                    bothButtons = true;

                    //Deur bij laten houden of er op beide knoppen gedrukt is

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

        Debug.Log("Button no longer pressed");
    }
        
    }
