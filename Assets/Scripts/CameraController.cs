// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 difference;
    private float differenceX;
    private float differenceY;

    // Start is called before the first frame update
    void Start()
    {
        difference = transform.localPosition;
        differenceX = difference.x;
        differenceY = difference.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == true)
        {
            Vector3 startVec = GameObject.FindGameObjectWithTag("Player").transform.localPosition;
            transform.localPosition = new Vector3(differenceX, differenceY, startVec.z + difference.z);
        }
    }
}
