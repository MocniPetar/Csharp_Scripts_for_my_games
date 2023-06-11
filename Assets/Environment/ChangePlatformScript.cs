using Unity.VisualScripting;
using UnityEngine;

public class ChangePlatformScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Platform;

    private bool change = true;

    private bool changeToPosOne = false; // changing the players and platform position to the next stage pos
    private bool changeToPosZero = false; // chaning the players and platform position to their original pos

    private changeGameObjectPos obj;

    void Start()
    {
        obj = gameObject.AddComponent<changeGameObjectPos>();
        obj.SetGameObjects(Player, Platform);
    }

    void Update()
    {
        if (changeToPosOne == true)
        {
            if (obj.state.stateX == true && obj.state.stateY == true && obj.state.stateZ == true && obj.state.stateZrot == true && obj.state.playerStateY == true && obj.state.playerStateYrot == true) {
                changeToPosOne = false;
                obj.doOnlyOnce = false;
                obj.state.stateX = obj.state.stateY = obj.state.stateZ = obj.state.stateZrot = obj.state.playerStateY = obj.state.playerStateYrot = false;
            }
            else
                obj.ChangePos(true);
        }

        else if (changeToPosZero == true)
        {
            if (obj.state.stateX == true && obj.state.stateY == true && obj.state.stateZ == true && obj.state.stateZrot == true && obj.state.playerStateY == true && obj.state.playerStateYrot == true) {
                changeToPosZero = false;
                obj.doOnlyOnce = false;
                obj.isPlayerDown = false;
                obj.state.stateX = obj.state.stateY = obj.state.stateZ = obj.state.stateZrot = obj.state.playerStateY = obj.state.playerStateYrot = false;
            }
            else
                obj.ChangePos(false);
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
                Player.GetComponent<PlayerControls>().PlayerChangingPos = true;
                Debug.Log("Going up");
            }

            else if (change == false)
            {
                changeToPosOne = false;
                changeToPosZero = true;

                change = true;
                Player.GetComponent<PlayerControls>().PlayerChangingPos = false;
                Debug.Log("Going down");
            }
        }
    }
}

    /*
    xPos 10.39f --> 0.0f -- 0.0f --> 10.39f
    yPos 4.31f --> 10.0f -- 10.0f --> 4.31f
    zPos 41.9f --> 35.0f -- 35.0f --> 41.9f
    playerYPos 1.5f --> 8.5f -- 8.5f --> 1.5f
    
    playerZRotation 0.0f --> 180.0f -- 180.0f --> 0.0f
    zRotation 45.0f --> 0.0f -- 0.0f --> 45.0f
    */

public class changeGameObjectPos : MonoBehaviour
{

    public GameObject Player { get; set; }
    public GameObject Platform { get; set; }

    // variables for changing the platforms and players position
    public float XPosForPlatform { get; set; }
    public float YPosForPlatform { get; set; }
    public float ZPosForPlatform { get; set; }
    public float YPosForPlayer { get; set; }

    // variables for the Z rotation
    public float ZPlatformRot { get; set; }
    public float ZPlayerRot { get; set; }

    // bools
    public bool _changePosOfPlatformToNewPos = false;
    public bool _changePosOfPlatformToPreviousPos = false;
    public bool doOnlyOnce = false;
    public bool isPlayerDown = false;

    public stateOfPosition state;

    public void SetGameObjects(GameObject player, GameObject platform) { 

        Player = player;
        Platform = platform;

        state.stateX = false;
        state.stateY = false;
        state.stateZ = false;
        state.stateZrot = false;
        state.playerStateY = false;
        state.playerStateYrot = false;

    }
    public void SetState() {

        state.stateX = true;
        state.stateY = true;
        state.stateZ = true;
        state.stateZrot = true;
    }
    public void ChangePos(bool SetToPos) {

        if (SetToPos == true) {

            if (doOnlyOnce == false)
            {
                if (state.stateX == false && state.stateY == false && state.stateZ == false && state.stateZrot == false && state.playerStateY == false && state.playerStateYrot == false)
                {
                    XPosForPlatform = 10.39f;
                    YPosForPlatform = 4.31f;
                    ZPosForPlatform = 41.9f;
                    YPosForPlayer = 1.5f;

                    ZPlatformRot = 45.0f;
                    ZPlayerRot = 0.0f;

                    _changePosOfPlatformToNewPos = true;
                    _changePosOfPlatformToPreviousPos = false;
                    doOnlyOnce = true;


                    Debug.Log("Changing player boxcollider");
                    Player.GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.0f, 0.0f);
                    Player.GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
            else if (doOnlyOnce == true)
            {
                changePlatformPos();
                changePlayerPos();
            }
        }

        else if(SetToPos == false) {

            if (doOnlyOnce == false)
            {
                if (state.stateX == false && state.stateY == false && state.stateZ == false && state.stateZrot == false && state.playerStateY == false && state.playerStateYrot == false)
                {
                    XPosForPlatform = 0.0f;
                    YPosForPlatform = 10.0f;
                    ZPosForPlatform = 35.0f;
                    YPosForPlayer = 8.5f;

                    ZPlatformRot = 0.0f;
                    ZPlayerRot = 180.0f;

                    _changePosOfPlatformToNewPos = false;
                    _changePosOfPlatformToPreviousPos = true;
                    doOnlyOnce = true;
                }
            }
            else if (doOnlyOnce == true)
            {
                changePlatformPos();
                changePlayerPos();
            }
        }
    }
    void changePlayerPos()
    {
        if (_changePosOfPlatformToNewPos == true)
        {
            if (YPosForPlayer <= 8.5f) YPosForPlayer += 0.05f;
            if (ZPlayerRot <= 180.0f) ZPlayerRot += 2.5f;

            if (YPosForPlayer > 8.5f)
            {
                YPosForPlayer = 8.5f;
                state.playerStateY = true;
            }
            if (ZPlayerRot !>= 180.0f)
            {
                ZPlayerRot = 180.0f;
                state.playerStateYrot = true;
            }

            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Player.GetComponent<Rigidbody>().useGravity = false;
            Player.transform.position = new Vector3(0.0f, YPosForPlayer, 2.0f);
            Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, ZPlayerRot);

            if (YPosForPlayer == 8.5f)
            {
                Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
        }

        else if (_changePosOfPlatformToPreviousPos == true) {

            if (YPosForPlayer >= 1.5f)
            {
                if (YPosForPlayer >= 5.0f && YPosForPlayer <= 5.5f)
                {
                    isPlayerDown = true;
                    Debug.Log("Player is going down");
                }

                YPosForPlayer -= 0.05f;
            }
            if (ZPlayerRot >= 0.0f) ZPlayerRot -= 2.5f;

            if (YPosForPlayer < 1.5f)
            {
                YPosForPlayer = 1.5f;
                state.playerStateY = true;
            }
            if (ZPlayerRot < 0.0f)
            {
                ZPlayerRot = 0.0f;
                state.playerStateYrot = true;
            }

            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Player.GetComponent<Rigidbody>().useGravity = false;
            Player.transform.position = new Vector3(0.0f, YPosForPlayer, 0.0f);
            Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, ZPlayerRot);

            if (YPosForPlayer == 1.5f)
            {
                Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
        }
    }
    void changePlatformPos() {

        if (_changePosOfPlatformToNewPos == true)
        {
            if (XPosForPlatform >= 0.0f) XPosForPlatform -= 0.1f;
            if (YPosForPlatform <= 10.0f) YPosForPlatform += 0.1f;
            if (ZPosForPlatform >= 35.0f) ZPosForPlatform -= 0.1f;
            if (ZPlatformRot >= 0.0f) ZPlatformRot -= 0.3f;

            if (XPosForPlatform < 0.0f)
            {
                XPosForPlatform = 0.0f;
                state.stateX = true;
            }
            if (YPosForPlatform > 10.0f)
            {
                YPosForPlatform = 10.0f;
                state.stateY = true;
            }
            if (ZPosForPlatform < 35.0f)
            {
                ZPosForPlatform = 35.0f;
                state.stateZ = true;
            }
            if (ZPlatformRot < 0.0f)
            {
                ZPlatformRot = 0.0f;
                state.stateZrot = true;
            }

            Platform.transform.position = new Vector3(XPosForPlatform, YPosForPlatform, ZPosForPlatform);
            Platform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, ZPlatformRot);
        }

        else if (_changePosOfPlatformToPreviousPos == true && isPlayerDown == true)
        {
            if (XPosForPlatform <= 10.39f) XPosForPlatform += 0.1f;
            if (YPosForPlatform >= 4.31f) YPosForPlatform -= 0.1f;
            if (ZPosForPlatform <= 41.9f) ZPosForPlatform += 0.1f;
            if (ZPlatformRot <= 45.0f) ZPlatformRot += 0.3f;

            if (XPosForPlatform > 10.39f)
            {
                XPosForPlatform = 10.39f;
                state.stateX = true;
            }
            if (YPosForPlatform < 4.31f)
            {
                YPosForPlatform = 4.31f;
                state.stateY = true;
            }
            if (ZPosForPlatform > 41.9f)
            {
                ZPosForPlatform = 41.9f;
                state.stateZ = true;
            }
            if (ZPlatformRot > 45.0f)
            {
                ZPlatformRot = 45.0f;
                state.stateZrot = true;
            }

            Platform.transform.position = new Vector3(XPosForPlatform, YPosForPlatform, ZPosForPlatform);
            Platform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, ZPlatformRot);
        }
    }
}

public struct stateOfPosition {

    public bool stateX { get; set; }
    public bool stateY { get; set; }
    public bool stateZ { get; set; }
    public bool stateZrot { get; set; }
    public bool playerStateY { get; set; }
    public bool playerStateYrot { get; set; }

    public stateOfPosition(bool stateOne, bool stateTwo, bool stateThree, bool stateFour, bool stateFive, bool stateSix)
        => (stateX, stateY, stateZ, stateZrot, playerStateY, playerStateYrot) = (stateOne, stateTwo, stateThree, stateFour, stateFive, stateSix);
}