// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int flightTime;  // íeÇÃîÚçséûä‘

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, flightTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
