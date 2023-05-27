using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Not_Solid_Trigger : MonoBehaviour
{
    public GameObject Platform;
    private BoxCollider2D boxCol;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Igrac")
        {
            boxCol = Platform.GetComponent<BoxCollider2D>();
            boxCol.isTrigger = true;
        }
    }
}
