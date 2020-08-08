using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButton : MonoBehaviour
{
    public GameObject RightClickHelp;

    public Animator animator;

    private void Start()
    {
        RightClickHelp.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Buttons")
        {
            //Right Mouse click UI
            RightClickHelp.gameObject.SetActive(true);

            //Right click
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Player pressed button");

                //Play interact animation
                animator.SetTrigger("Interact");

                //Deur bij laten houden of er op beide knoppen gedrukt is
                
            }
        }
    }
}
