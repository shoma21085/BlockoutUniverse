using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameEntityController : MonoBehaviour
{
    public float speed;                 // 移動速度
    public int maxHP;                   // 最大HP
    private int currentHP;              // 現在HP
    public Slider hpSlider;             // HPスライダー

    public GameObject bulletPrefab;     // 弾のプレハブ
    public float bulletSpeed;           // 弾の速度
    // public int bulletDamage;            // 弾のダメージ
    public float fireInterval;          // 弾の発射間隔
    public float nextFireTime;          // 次に弾を発射できる時間

    public GameObject explosionPrefab;  // 爆発のプレハブ

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
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);  // 爆発の生成
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
