using System.Runtime.CompilerServices;
using UnityEngine;

public class ChangePlatformScript : MonoBehaviour
{
    public GameObject SecondPlatform;
    public GameObject Player;

    private bool change = false;

    private bool changePlatformToNextPos = false;
    private bool changePlayerPosToTop = false;

    private bool changePlatformToPreviosPos = false;
    private bool changePlayerPosToBottom = false;

    private float xPos; // 10.39f --> 0.0f -- 0.0f --> 10.39f
    private float yPos; // 4.31f --> 10.0f -- 10.0f --> 4.31f
    private float zPos; // 41.9f --> 35.0f -- 35.0f --> 41.9f
    private float playerYPos; // 1.5f --> 8.5f -- 8.5f --> 1.5f

    private float playerZRotation; // 0.0f --> 180.0f -- 180.0f --> 0.0f
    private float zRotation; // 45.0f --> 0.0f -- 0.0f --> 45.0f 

    // Update is called once per frame
    void FixedUpdate()
    {
        if (changePlatformToNextPos == true)
            ChangePlatformPosToNextPos();
        else if (changePlatformToPreviosPos == true)
            ChangePlatformPosToPreviousPos();

        if (changePlayerPosToTop == true)
            ChangePlayerPosToTopPlatform();
        else if(changePlayerPosToBottom == true)
            ChangePlayerPosToBottomPlatform();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (change == false) {

                xPos = 10.39f;
                yPos = 4.31f;
                zPos = 41.9f;
                playerYPos = 1.5f;

                playerZRotation = 0.0f;
                zRotation = 45.0f;

                changePlatformToNextPos = true;
                changePlayerPosToTop = true;

                changePlatformToPreviosPos = false;
                changePlayerPosToBottom = false;

                Player.GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.0f, 0.0f);
                Player.GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, 1.0f);

                change = true;
            }
            else if (change == true) {

                xPos = 0.0f;
                yPos = 10.0f;
                zPos = 35.0f;
                playerYPos = 8.5f;

                playerZRotation = 180.0f;
                zRotation = 0.0f;

                changePlatformToPreviosPos = true;
                changePlayerPosToBottom = true;

                changePlatformToNextPos = false;
                changePlayerPosToTop = false;

                Player.GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.0f, 0.0f);
                Player.GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, 1.0f);

                change = false;
            }
        }
    }

    void ChangePlatformPosToNextPos() {

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

    void ChangePlayerPosToTopPlatform()
    {
        if (zRotation == 0.0f)
        {
            if (playerYPos <= 8.5f) playerYPos += 0.1f;
            if (playerYPos > 8.5f) playerYPos = 8.5f;
            if (playerZRotation <= 180.0f) playerZRotation += 2.5f;

            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Player.GetComponent<Rigidbody>().useGravity = false;
            Player.transform.position = new Vector3(0.0f, playerYPos, 2.0f);
            Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, playerZRotation);

            if (playerYPos == 8.5f)
            {
                Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }

            if (playerYPos == 8.5f && playerZRotation == 180.0f) changePlayerPosToBottom = false;

            if (Player.transform.rotation.z < 0.0f)
                Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }
    }

    void ChangePlatformPosToPreviousPos()
    {
        if (playerZRotation == 0.0f)
        {
            if (xPos <= 10.39f) xPos += 0.1f;

            if (yPos >= 4.31f) yPos -= 0.1f;

            if (zPos <= 41.9f) zPos += 0.1f;

            if (zRotation <= 45.0f) zRotation += 0.1f * 3.0f;

            if (xPos > 10.39f) xPos = 10.39f;
            if (yPos < 4.31f) yPos = 4.31f;
            if (zPos > 41.9f) zPos = 41.9f;
            if (zRotation > 45.0f) zRotation = 45.0f;

            SecondPlatform.transform.position = new Vector3(xPos, yPos, zPos);
            SecondPlatform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, zRotation);
        }
    }

    void ChangePlayerPosToBottomPlatform()
    {
        if (playerYPos >= 1.5f) playerYPos -= 0.1f;
        if (playerYPos < 1.5f) playerYPos = 1.5f;
        if (playerZRotation >= 0.0f) playerZRotation -= 2.5f;
        if (playerZRotation < 0.0f) playerZRotation = 0.0f;

        Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Player.GetComponent<Rigidbody>().useGravity = false;
        Player.transform.position = new Vector3(0.0f, playerYPos, 2.0f);
        Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, playerZRotation);

        if (playerYPos == 1.5f)
        {
            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }

        if (playerYPos == 1.5f && playerZRotation == 0.0f) changePlayerPosToTop = false;
    }

}


