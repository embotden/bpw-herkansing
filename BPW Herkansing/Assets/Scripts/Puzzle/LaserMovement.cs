using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //Movement speed of the beam

    UnityEngine.Vector3 moveDirection; //Current direction

    //Move directions
    UnityEngine.Vector3 moveNorth;
    UnityEngine.Vector3 moveEast;
    UnityEngine.Vector3 moveSouth;
    UnityEngine.Vector3 moveWest;
    
    bool Moving = false;
    
    //Laser Spawnpoints
    public GameObject GreenSpawn;
    public GameObject DarkGreenSpawn;
    public GameObject PurpleSpawn;
    public GameObject BlueSpawn;

    //Lasers
    public GameObject GreenLaser;
    public GameObject BlueLaser;
    public GameObject DarkGreenLaser;
    public GameObject PurpleLaser;

    public float startDirX; //In what direction the beam moves at the start on the x axis
    public float startDirY; //In what direction the beam moves at the start on the y axis

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartPositionLaser();
        
        moveNorth = new UnityEngine.Vector3(0.0f * moveSpeed, 1.0f * moveSpeed, 0.0f).normalized;
        moveEast = new UnityEngine.Vector3(1.0f * moveSpeed, 0.0f * moveSpeed, 0f).normalized;
        moveSouth = new UnityEngine.Vector3(0.0f * moveSpeed, -1.0f * moveSpeed, 0.0f).normalized;
        moveWest = new UnityEngine.Vector3(-1.0f * moveSpeed, 0.0f * moveSpeed, 0f).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed; //Start moving

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (!Moving)
            {
                GetComponent<SpriteRenderer>().enabled = true;

                moveDirection = new UnityEngine.Vector3(startDirX * moveSpeed, startDirY * moveSpeed, 0f).normalized; //Aanpassen per beam in Unity

                Moving = true;
            }
            else
            {
                StartPositionLaser();
            }
        }
    }

    //If laser hits puzzle piece, change direction 
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Triangles right slope down
        if (other.gameObject.CompareTag("LeftDown"))
        {
            if (moveDirection == moveEast)
            {
                moveDirection = moveSouth;
            }
            else if (moveDirection == moveNorth)
            {
                moveDirection = moveWest;
            }
            else
            {
                StartCoroutine(ShortCircuit());
            }
        }

        //Triangles right slope up
        if (other.gameObject.CompareTag("LeftUp"))
        {
            if (moveDirection == moveEast)
            {
                moveDirection = moveNorth;
            }
            else if (moveDirection == moveSouth)
            {
                moveDirection = moveWest;
            }
            else
            {
                StartCoroutine(ShortCircuit());
            }
        }

        //Triangles left slope down
        if (other.gameObject.CompareTag("RightDown"))
        {
            if (moveDirection == moveWest)
            {
                moveDirection = moveSouth;
            }
            else if (moveDirection == moveNorth)
            {
                moveDirection = moveEast;
            }
            else
            {
                StartCoroutine(ShortCircuit());
            }
        }

        //Triangles left slope up
        if (other.gameObject.CompareTag("RightUp"))
        {
            if (moveDirection == moveWest)
            {
                moveDirection = moveNorth;
            }
            else if (moveDirection == moveSouth)
            {
                moveDirection = moveEast;
            }
            else
            {
                StartCoroutine(ShortCircuit());
            }
        }
    }

    //If beam hits wrong side: Short circuit
    IEnumerator ShortCircuit()
    {
        Debug.Log("Crash!");

        yield return new WaitForEndOfFrame();
        ProgressBar.progressvalue = 0;
        StartPositionLaser();
    }

    //Reset to start position
    public void StartPositionLaser()
    {
        moveDirection = new UnityEngine.Vector3(0f, 0f, 0f).normalized;

        GetComponent<SpriteRenderer>().enabled = false;

        GreenLaser.transform.position = GreenSpawn.transform.position;
        BlueLaser.transform.position = BlueSpawn.transform.position;
        DarkGreenLaser.transform.position = DarkGreenSpawn.transform.position;
        PurpleLaser.transform.position = PurpleSpawn.transform.position;

        Moving = false;
    }

    //Finish reached
    public void EndPositionLaser()
    {
        moveDirection = new UnityEngine.Vector3(0f, 0f, 0f).normalized;

        GetComponent<SpriteRenderer>().enabled = false;
    }
}
