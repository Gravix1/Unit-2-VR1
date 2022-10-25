using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMath : MonoBehaviour
{
    int num = 7;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Product();
        Debug.Log(num);
    }

    void Product()
    {
        num = num * 2;
    }
}