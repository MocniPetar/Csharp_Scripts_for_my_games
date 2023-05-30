using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private BoxCollider2D boxCol;
    public GameObject Platform; 

    private void Update()
    {
        boxCol = Platform.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Igrac")
            boxCol.isTrigger = false;
    }
}