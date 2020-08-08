using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private CharacterController player;

    private bool top;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //If player hits space, change gravity
        {
            StartCoroutine(GravitySwitching());
            
        }
    }

    //Rotating player body when changing gravity
    IEnumerator GravitySwitching()
    {
        yield return null;

        Debug.Log("Switching Gravity!");

        rb.gravityScale *= -1;

        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);

        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        
        player.facingRight = !player.facingRight;
        top = !top;
    }
}
