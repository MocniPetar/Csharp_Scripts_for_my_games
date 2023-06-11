using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    public float playerJumpForce = 10.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.up * playerJumpForce);
            other.gameObject.GetComponent<Rigidbody>().mass = 5.0f;
            other.gameObject.GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.0f, 0.0f);
            other.gameObject.GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, 1.0f);
            Debug.Log("Jumping now");
        }
    }
}
