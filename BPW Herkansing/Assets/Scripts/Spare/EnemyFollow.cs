using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;

    public Transform[] moveSpots;
    private int randomSpot;

    public float waitTime;
    public float startWaitTime;

    public bool facingRight = true;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Find player
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < 2)  // if enemy isn't close to the player then start follow
        {
            StartCoroutine(FollowPlayer());  
        }
        else
        {
            StartCoroutine(Patrol());
        }

        /*if (facingRight == false && moveInput > 0) //facing left while moving right, solution
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        { //facing right while moving left, solution
            Flip();
        }*/
    }

    IEnumerator Patrol()
    {
        Debug.Log("Patrol Switch");

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            yield return new WaitForSecondsRealtime(3);

        } else {
           
            yield return null;

        }
    }

    IEnumerator FollowPlayer()
    {
        Debug.Log("I see you...");
        yield return new WaitForSeconds(1);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //Follow player
    }

    //Mirror sprite when running left
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
