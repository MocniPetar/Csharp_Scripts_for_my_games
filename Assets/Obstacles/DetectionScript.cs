using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Single_Cube")
            Destroy(other.gameObject);

        else if (other.gameObject.name == "Second_Cube")
            Destroy(other.gameObject);

        else if (other.gameObject.name == "Large_Single_Cube")
            Destroy(other.gameObject);

        else if (other.gameObject.name == "Jump_Pad_Clone")
            Destroy(other.gameObject);

    }
}
