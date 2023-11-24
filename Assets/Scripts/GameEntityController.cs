using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameEntityController : MonoBehaviour
{
    public float speed;                 // �ړ����x
    public int maxHP;                   // �ő�HP
    private int currentHP;              // ����HP
    public Slider hpSlider;             // HP�X���C�_�[

    public GameObject bulletPrefab;     // �e�̃v���n�u
    public float bulletSpeed;           // �e�̑��x
    // public int bulletDamage;            // �e�̃_���[�W
    public float fireInterval;          // �e�̔��ˊԊu
    public float nextFireTime;          // ���ɒe�𔭎˂ł��鎞��

    public GameObject explosionPrefab;  // �����̃v���n�u

    public int CurrentHP
    {
        get => currentHP;
        set
        {
            currentHP = value;

            if (currentHP <= 0)
            {
                try
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);  // �����̐���
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    return;
                }
                finally
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
