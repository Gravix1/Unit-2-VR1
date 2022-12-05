using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraStuff : MonoBehaviour
{
    Transform camera;
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.transform;
        move = new Vector2(0.0f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        camera.Translate(move * Time.deltaTime);
    }
}
