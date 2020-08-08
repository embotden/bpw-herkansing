using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelInteraction : MonoBehaviour
{
    public GameObject RightClickHelp;

    public Animator animator;

    private void Start()
    {
        RightClickHelp.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Panels")
        {
            //Right Mouse click UI
            RightClickHelp.gameObject.SetActive(true);

            if(Input.GetMouseButtonDown(1))
            {
            Debug.Log("Start puzzle");

                //Play attack animation
                animator.SetTrigger("Interact");

                //Start Puzzle
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
