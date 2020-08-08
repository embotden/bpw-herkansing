using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Buttons")
        {
            Debug.Log("Enemy pressed buttons");
            
            //Deur bij laten houden of er op beide knoppen gedrukt is
        }
    }
}
