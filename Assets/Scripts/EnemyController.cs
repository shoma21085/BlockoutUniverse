using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class EnemyController : GameEntityController
{
    public Transform playerPosition;  // �v���C���[�̈ʒu
    public Vector3 playerDirection;   // �v���C���[�̕���

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = maxHP;

        try
        {
            // �v���C���[�̈ʒu���擾����
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            // ��]���Ȃ���v���C���[��ǐՂ���
            playerDirection = (playerPosition.position - transform.position).normalized;
            transform.position += playerDirection * speed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(0, 3, 3);
            Quaternion q = transform.rotation;
            transform.rotation = q * rotation;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CurrentHP = 0;
        }
        else if(other.gameObject.CompareTag("Bullet"))
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
