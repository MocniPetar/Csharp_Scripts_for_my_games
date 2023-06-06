using UnityEngine;

public class ChangePlatformScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Platform;

    private bool change = true;

    private bool changeToPosOne = false; // changing the players and platform position to the next stage pos
    private bool changeToPosZero = false; // chaning the players and platform position to their original pos

    private float xPos; // 10.39f --> 0.0f -- 0.0f --> 10.39f
    private float yPos; // 4.31f --> 10.0f -- 10.0f --> 4.31f
    private float zPos; // 41.9f --> 35.0f -- 35.0f --> 41.9f
    private float playerYPos; // 1.5f --> 8.5f -- 8.5f --> 1.5f

    private float playerZRotation; // 0.0f --> 180.0f -- 180.0f --> 0.0f
    private float zRotation; // 45.0f --> 0.0f -- 0.0f --> 45.0f

    private changeGameObjectPos obj;

    void Start()
    {
        obj = gameObject.AddComponent<changeGameObjectPos>();
        obj.SetGameObjects(Player, Platform);
    }
    

    void FixedUpdate()
    {
        if (changeToPosOne == true && changeToPosZero == false)
        {
            if (obj.xPosForPlatform == 0.0f && obj.yPosForPlatform == 10.0f && obj.zPosForPlatform == 35.0f && obj.zPlatformRot == 0.0f) {
                Debug.Log("Platform has changed the position to new pos");
                changeToPosOne = false;
                changeToPosZero = false;
            }
            obj.ChangePos(true, false);
        }

        else if (changeToPosOne == false && changeToPosZero == true)
        {
            if (obj.xPosForPlatform == 10.39f && obj.yPosForPlatform == 4.31f && obj.zPosForPlatform == 41.9f && obj.zPlatformRot == 45.0f) {
                Debug.Log("Platform has changed the position to original pos");
                changeToPosOne = false;
                changeToPosZero = false;
            }
            obj.ChangePos(false, true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (change == true)
            {
                changeToPosOne = true;
                changeToPosZero = false;

                change = false;
                Debug.Log("Initiating new pos");
            }

            else if (change == false)
            {
                changeToPosOne = false;
                changeToPosZero = true;

                change = true;
                Debug.Log("Initiating old pos");
            }
        }
    }

    /*
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

           // if (playerYPos == 8.5f && playerZRotation == 180.0f) changePlayerPosToBottom = false;

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

        //if (playerYPos == 1.5f && playerZRotation == 0.0f) changePlayerPosToTop = false;
    }
    */

}

public class changeGameObjectPos : MonoBehaviour
{

    public GameObject Player { get; set; }
    public GameObject Platform { get; set; }

    // variables for changing the platforms and players position
    public float xPosForPlatform { get; set; }
    public float yPosForPlatform { get; set; }
    public float zPosForPlatform { get; set; }
    public float yPosForPlayer { get; set; }

    // variables for the Z rotation
    public float zPlatformRot { get; set; }
    public float zPlayerRot { get; set; }

    // bools
    public bool _changePosOfPlatformToNewPos = false;
    public bool _changePosOfPlatformToPreviousPos = false;

    private bool doOnlyOnce = false;

    public changeGameObjectPos(GameObject player, GameObject platform) {
        xPosForPlatform = 0.0f;
        yPosForPlatform = 0.0f;
        zPosForPlatform = 0.0f;
        yPosForPlayer = 0.0f;

        zPlatformRot = 0.0f;
        yPosForPlayer = 0.0f;
    }

    public void SetGameObjects(GameObject player, GameObject platform) { 
        Player = player;
        Platform = platform;
    }

    public void ChangePos(bool SetToPosOne, bool SetToPosZero) {

        if (SetToPosOne == true && SetToPosZero == false) {

            if (doOnlyOnce == false)
            {
                if (xPosForPlatform == 0.0f && yPosForPlatform != 10.0f && zPosForPlatform != 35.0f && zPlatformRot == 0.0f)
                {
                    xPosForPlatform = 10.39f;
                    yPosForPlatform = 4.31f;
                    zPosForPlatform = 41.9f;
                    yPosForPlayer = 1.5f;

                    zPlatformRot = 45.0f;
                    yPosForPlayer = 0.0f;

                    _changePosOfPlatformToNewPos = true;
                    _changePosOfPlatformToPreviousPos = false;
                    doOnlyOnce = true;
                }
            }
            else if (doOnlyOnce == true)
            {
                changePlatformPos();
                if (xPosForPlatform == 0.0f && yPosForPlatform == 10.0f && zPosForPlatform == 35.0f && zPlatformRot == 0.0f)
                    doOnlyOnce = false;

            }
        }

        else if(SetToPosOne == false && SetToPosZero == true) {

            if (doOnlyOnce == false)
            {
                if (xPosForPlatform != 10.39f && yPosForPlatform != 4.31f && zPosForPlatform != 41.9f && zPlatformRot != 45.0f)
                {
                    xPosForPlatform = 0.0f;
                    yPosForPlatform = 10.0f;
                    zPosForPlatform = 35.0f;
                    yPosForPlayer = 8.5f;

                    zPlatformRot = 0.0f;
                    yPosForPlayer = 180.0f;

                    _changePosOfPlatformToNewPos = false;
                    _changePosOfPlatformToPreviousPos = true;
                    doOnlyOnce = true;
                }
            }
            else if (doOnlyOnce == true)
            {
                Debug.Log("Calling function inside class");
                changePlatformPos();
                if (xPosForPlatform == 10.39f && yPosForPlatform == 4.31f && zPosForPlatform == 41.9f && zPlatformRot == 45.0f)
                {
                    doOnlyOnce = false;
                    Debug.Log("Old pos set");
                }
            }
        }
    }

    void changePlayerPos()
    {

    }

    void changePlatformPos() {

        if (_changePosOfPlatformToNewPos == true && _changePosOfPlatformToPreviousPos == false)
        {
            if (xPosForPlatform >= 0.0f) xPosForPlatform -= 0.1f;
            if (yPosForPlatform <= 10.0f) yPosForPlatform += 0.1f;
            if (zPosForPlatform >= 35.0f) zPosForPlatform -= 0.1f;
            if (zPlatformRot >= 0.0f) zPlatformRot -= 0.1f * 3.0f;

            if (xPosForPlatform < 0.0f) xPosForPlatform = 0.0f;
            if (yPosForPlatform > 10.0f) yPosForPlatform = 10.0f;
            if (zPosForPlatform < 35.0f) zPosForPlatform = 35.0f;
            if (zPlatformRot < 0.0f) zPlatformRot = 0.0f;

            Platform.transform.position = new Vector3(xPosForPlatform, yPosForPlatform, zPosForPlatform);
            Platform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, zPlatformRot);
        }

        else if (_changePosOfPlatformToNewPos == false && _changePosOfPlatformToPreviousPos == true)
        {
            if (xPosForPlatform <= 10.39f) xPosForPlatform += 0.1f;
            if (yPosForPlatform >= 4.31f) yPosForPlatform -= 0.1f;
            if (zPosForPlatform <= 41.9f) zPosForPlatform += 0.1f;
            if (zPlatformRot <= 45.0f) zPlatformRot += 0.1f * 3.0f;

            if (xPosForPlatform > 10.39f) xPosForPlatform = 10.39f;
            if (yPosForPlatform < 4.31f) yPosForPlatform = 4.31f;
            if (zPosForPlatform > 41.9f) zPosForPlatform = 41.9f;
            if (zPlatformRot > 45.0f) zPlatformRot = 45.0f;

            Platform.transform.position = new Vector3(xPosForPlatform, yPosForPlatform, zPosForPlatform);
            Platform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, zPlatformRot);
        }
    }
}