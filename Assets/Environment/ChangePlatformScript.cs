using UnityEngine;

public class ChangePlatformScript : MonoBehaviour
{

    public GameObject SecondPlatform;
    public GameObject Player;

    private bool ChangePlatform = false;
    private bool ChangePlayerPos = false;

    private float xPos = 10.39f; // --> 0.0f
    private float yPos = 4.31f; // --> 10.0f
    private float zPos = 41.9f; // --> 35.0f
    private float playerYPos = 1.5f; // --> 8.5f

    private float zRotation = 45.0f; // --> 0.0f 

    // Update is called once per frame
    void Update()
    {
        if (ChangePlatform == true) {


            // These if statements icrement the pos and rot values

            if (xPos >= 0.0f) xPos -= 0.1f;

            if (yPos <= 10.0f) yPos += 0.1f;

            if (zPos >= 35.0f) zPos -= 0.1f;

            if (zRotation >= 0.0f) zRotation -= 0.1f * 3.0f;

            // These if statements set the position and rotation to the wanted values
            // Becaues the games runtime you cannot set the values to the corret numbers
            // with the first if statements

            if (xPos < 0.0f) xPos = 0.0f;
            if (yPos > 10.0f) yPos = 10.0f;
            if (zPos < 35.0f) zPos = 35.0f;
            if (zRotation < 0.0f) zRotation = 0.0f;
                
            SecondPlatform.transform.position = new Vector3(xPos, yPos, zPos);
            SecondPlatform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, zRotation);
        }

        if (ChangePlayerPos == true)
            if (zRotation == 0.0f) {

                if (playerYPos <= 8.5f) playerYPos += 0.1f;
                if (playerYPos > 8.5f) playerYPos = 8.5f;

                Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Player.GetComponent<Rigidbody>().useGravity = false;
                Player.transform.position = new Vector3(0.0f, playerYPos, 2.0f);

                Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

                if (playerYPos == 8.5f) ChangePlayerPos = false;
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ChangePlatform = true;
            ChangePlayerPos = true;
        }
    }

}
