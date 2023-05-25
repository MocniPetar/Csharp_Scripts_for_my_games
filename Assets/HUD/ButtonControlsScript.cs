using UnityEngine;

public class ButtonControlsScript : MonoBehaviour
{
    // Main GameObjects
    public GameObject startButton;
    public GameObject obstacleCube;
    public GameObject largeObstacleCube;
    public GameObject ground;
    public GameObject RestartGame;
    public GameObject Player;
    public GameObject JumpPad;

    // In this gameobject we store the instance of a obstacle
    private GameObject clone;
    private GameObject clone_2;
    private GameObject largeClone;
    private GameObject JumpPadClone;

    public Rigidbody playerRB;
    public float zForce = 200.0f;
    public bool SpawningObstacles = false;

    void Awake()
    {
        RestartGame.SetActive(false);
    }

    void FixedUpdate()
    {

        if(SpawningObstacles == true)
        {
            if (Time.time % 1 == 0)
            {

                float xPos = Random.Range(-ground.transform.localScale.x / 2 + 1, ground.transform.localScale.x / 2 - 1);

                clone = Instantiate(obstacleCube, new Vector3(xPos, 1.5f, 75.0f), Quaternion.identity);
                clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * -zForce);
                clone.name = "Single_Cube";

                if (Time.time % 3 == 0)
                {

                    int offset;

                    if (xPos > 0) offset = -1;
                    else offset = 1;

                    clone_2 = Instantiate(obstacleCube, new Vector3(xPos + offset, 1.5f, 75.0f), Quaternion.identity);
                    clone_2.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * -zForce);
                    clone_2.name = "Second_Cube";
                }
                else if (Time.time % 5 == 0)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        if (i < 2)
                        {
                            clone = Instantiate(obstacleCube, new Vector3(-4.0f * i, 1.5f, 80.0f), Quaternion.identity);
                            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * -zForce);
                            clone.name = "Single_Cube";
                        }
                        else
                        {
                            clone = Instantiate(obstacleCube, new Vector3(4.0f, 1.5f, 80.0f), Quaternion.identity);
                            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * -zForce);
                            clone.name = "Single_Cube";
                        }
                    }
                }
                else if (Time.time % 7 == 0) {

                    float currentXpos = 0.0f;
                    float xOffsetOfJumPad = Random.Range(-4.0f, 4.0f);

                    if (xOffsetOfJumPad < 0) xOffsetOfJumPad += 0.5f;
                    else if (xOffsetOfJumPad > 0) xOffsetOfJumPad -= 0.5f;

                    largeClone = Instantiate(largeObstacleCube, new Vector3(currentXpos, 1.5f, 85.0f), Quaternion.identity);
                    largeClone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * -zForce);
                    largeClone.name = "Large_Single_Cube";

                    JumpPadClone = Instantiate(JumpPad, new Vector3(xOffsetOfJumPad, 1.0f, 81.0f), Quaternion.identity);
                    JumpPadClone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * -zForce);
                    JumpPadClone.name = "Jump_Pad_Clone";
                }
            }
        }
    }

    public void SpawnObstacles()
    {
        SpawningObstacles = true;
        Player.GetComponent<PlayerControls>().GameStart = true;
        startButton.SetActive(false);
    }
}
