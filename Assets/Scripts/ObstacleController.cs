// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : GameEntityController
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        // zé≤Ç∆ïΩçsÇ…à⁄ìÆÇ∑ÇÈ
        transform.position -= transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CurrentHP = 0;
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            PlayerController.score += 10000;
            CurrentHP = 0;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
