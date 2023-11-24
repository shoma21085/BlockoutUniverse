using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : GameEntityController, ITakeDamage
{
    public static int score;    // スコア

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = maxHP;
        hpSlider = gameObject.GetComponentInChildren<Slider>();     // Playerの子オブジェクトからも取得できる
        hpSlider.maxValue = 1;
        hpSlider.value = 1;
        score = 0;

        // 一定の間隔で弾を発射する
        // InvokeRepeating(nameof(CreateBullet), 0, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // 移動範囲の制限
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(transform.position.x, -25f, 25f);
        position.y = Mathf.Clamp(transform.position.y, 0f, 30f);
        transform.position = position;
    }

    void FixedUpdate()
    {
        if(CurrentHP > 0)
        {
            try
            {
                // 矢印キーの入力でプレイヤーを移動する
                float horizontal = Input.GetAxisRaw("Horizontal") * speed;
                float vertical = Input.GetAxisRaw("Vertical") * speed;

                GetComponent<Rigidbody>().AddForce(new Vector3(horizontal, vertical, 0f), ForceMode.Force);
                GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 1.0f), ForceMode.Force);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return;
            }

            // 弾を発射する
            if (Input.GetKeyDown("space") && (Time.time > nextFireTime))
            {
                try
                {
                    GameObject bullet = Instantiate(bulletPrefab, 
                        new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Acceleration);
                }
                catch (Exception e) 
                {
                    Debug.LogError(e);
                    return;
                }
                nextFireTime = Time.time + fireInterval;
            }
        }
        else
        {
            return;
        }
    }

    /* private void CreateBullet()
    {
        try
        {
            GameObject bullet = Instantiate(bulletPrefab, 
                new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Acceleration);
        }
        catch (Exception e) 
        {
            Debug.LogError(e);
            return;
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacle"))
        {
            if(CurrentHP > 0)
            {
                TakeDamage(10);
                hpSlider.value = (float)CurrentHP / (float)maxHP;
            }
            else
            {
                CurrentHP = 0;
                hpSlider.value = 0;
            }
        }
    }

    public void TakeDamage(int damege)
    {
        CurrentHP -= damege;
    }
}
