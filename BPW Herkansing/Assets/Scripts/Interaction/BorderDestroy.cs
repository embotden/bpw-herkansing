using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderDestroy : MonoBehaviour
{
    //Laserbeams
    public GameObject Green;
    public GameObject Blue;
    public GameObject DarkGreen;
    public GameObject Purple;

    //Laserbeam spawnpoint
    public GameObject BeamGreenSpawn;
    public GameObject BeamDarkGreenSpawn;
    public GameObject BeamPurpleSpawn;
    public GameObject BeamBlueSpawn;

    //If beam collides with player, return to spawnpoint
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Green)
        {
            Green.GetComponent<LaserMovement>().StartPositionLaser();
        }

        if (collision.gameObject == Blue)
        {
            Blue.GetComponent<LaserMovement>().StartPositionLaser();
        }

        if (collision.gameObject == DarkGreen)
        {
            DarkGreen.GetComponent<LaserMovement>().StartPositionLaser();
        }

        if (collision.gameObject == Purple)
        {
            Purple.GetComponent<LaserMovement>().StartPositionLaser();
        }
    }


}
