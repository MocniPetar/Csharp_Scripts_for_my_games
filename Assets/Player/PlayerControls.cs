using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    // Game Objects
    public GameObject RestartButton;
    public GameObject SpawningControl;

    // Player RigidBody Component
    public Rigidbody PlayerRb;

    // Forces added to the player
    public float StrafeForce = 1.5f;
    public float ForwardForce = 200.0f;

    // Player status booleans
    public bool GameStart = false;
    public bool PlayerChangingPos = false;

    // Camera
    public Camera MainCamera;

    // Private variables
    private Touch touch;

    private void Update()
    {
        if (GameStart == true)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * StrafeForce, transform.position.y, transform.position.z);

            }
        }

        if(transform.position.y >= 4.0f && PlayerChangingPos == false){
            gameObject.GetComponent<BoxCollider>().center = new Vector3(0.0f, -0.25f, 0.0f);
            gameObject.GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.5f, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Large_Single_Cube" || collision.gameObject.name == "Single_Cube" || collision.gameObject.name == "Second_Cube")
        {
            RestartButton.SetActive(true);
            this.gameObject.GetComponent<PlayerControls>().GameStart = false;
            this.gameObject.GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.0f, 0.0f);
            this.gameObject.GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, 1.0f);
            SpawningControl.GetComponent<ButtonControlsScript>().SpawningObstacles = false;
            PlayerRb.useGravity = false;
        }

        else if (collision.gameObject.name == "Ground")
        {
            this.gameObject.GetComponent<Rigidbody>().mass = 1.0f;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}