using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject redLight;
    public GameObject greenLight;

    public GameObject door;


    public void OpenTheDoor()
    {
        redLight.gameObject.SetActive(false);
        greenLight.gameObject.SetActive(true);

        Destroy(door);
    }
}
