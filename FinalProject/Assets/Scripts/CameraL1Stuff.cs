using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraL1Stuff : MonoBehaviour
{
    Transform camera;
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.transform;
        move = new Vector2(0.3f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        camera.Translate(move * Time.deltaTime);
    }
}
