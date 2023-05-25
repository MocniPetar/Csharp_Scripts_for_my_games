using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    public float playerJumpForce = 10.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") {
            other.gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.up * playerJumpForce);
            other.gameObject.GetComponent<Rigidbody>().mass = 5.0f;
        }
    }
}
