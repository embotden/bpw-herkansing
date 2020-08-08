using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePiece : MonoBehaviour //Tutorial Youtube by: Design and Deploy - How to make a Jigsaw puzzle game
{

    public string pieceStatus = "Idle";
    public string checkPlacement = "";

    public KeyCode placePiece;

    private Rigidbody2D rb;

    public float restartDelay = 1f;

    bool gameHasEnded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //Press R to restart level
        {
            EndGame();
        }
        //Physics2D.gravity = Vector2.zero;

        if (pieceStatus == "PickedUp") //If piece is picked up, follow mouse movement
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }

        if(Input.GetKeyDown(placePiece))
        {
            checkPlacement = "y";
        }
    }

    private void OnTriggerStay2D(Collider2D other) //Snap to node grid
    {
        if (other.gameObject.tag == "Nodes" && checkPlacement == "y") //Make sure all spots are tagged with Nodes!
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezePosition;   
            GetComponent<Renderer>().sortingOrder = 0;
            transform.position = other.gameObject.transform.position; //lock into position
            checkPlacement = "n";
            pieceStatus = "Idle";
        }
    }

    private void OnMouseDown() //Pick piece up on Click
    {
        pieceStatus = "PickedUp";
        checkPlacement = "n";
        GetComponent<Renderer>().sortingOrder = 10;
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;

            //Restart Level
            Invoke("Restart", restartDelay);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
