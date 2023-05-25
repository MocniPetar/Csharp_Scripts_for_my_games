using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int DefalutLayer = LayerMask.NameToLayer("Default");
        int PostProcessingLayer = LayerMask.NameToLayer("Post Processing");

        if (gameObject.layer == DefalutLayer)
            gameObject.layer = PostProcessingLayer;
    }
}
