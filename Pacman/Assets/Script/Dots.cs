using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dots : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("pacman"))
        {
            Debug.Log("is trigger");
            Destroy(gameObject);
        }
    }

   
   
}
