using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderDestroy : MonoBehaviour
{

    public GameObject Green;
    public GameObject Blue;
    public GameObject DarkGreen;
    public GameObject Purple;

    public GameObject BeamGreenSpawn;
    public GameObject BeamDarkGreenSpawn;
    public GameObject BeamPurpleSpawn;
    public GameObject BeamBlueSpawn;

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BeamB" || other.gameObject.tag == "BeamG" || other.gameObject.tag == "BeamDG" || other.gameObject.tag == "BeamP")
        {
            Destroy(gameObject);
            Debug.Log("Hit!");
        }

        if(other.gameObject == Green)
        {
            Destroy(Green);
        }

    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Green)
        {
            Green.GetComponent<LaserMovement>().StartPositionLaser();

            //Destroy(Green);

        }

        if (collision.gameObject == Blue)
        {
            Blue.GetComponent<LaserMovement>().StartPositionLaser();

            //Destroy(Blue);
        }

        if (collision.gameObject == DarkGreen)
        {
            DarkGreen.GetComponent<LaserMovement>().StartPositionLaser();

            //Destroy(DarkGreen);
        }

        if (collision.gameObject == Purple)
        {
            Purple.GetComponent<LaserMovement>().StartPositionLaser();

            //Destroy(Purple);
        }
    }


}
