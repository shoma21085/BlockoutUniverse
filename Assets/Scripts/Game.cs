using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject playerPrefab;         // プレイヤーのプレハブ
    public GameObject enemyPrefab;          // 敵のプレハブ
    public float enemySpawnInterval;        // 敵の出現間隔
    private float enemySpawnTime;           // 敵の出現時間
    public GameObject obstaclePrefab;       // 障害物のプレハブ
    public float obstacleSpawnInterval;     // 障害物の出現間隔
    private float obstacleSpawnTime;        // 障害物の出現時間

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);   // プレイヤーの生成
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return;
        }
        enemySpawnTime = enemySpawnInterval;
        obstacleSpawnTime = obstacleSpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオーバーの判定
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Invoke(nameof(GameEnd), 1);
        }
        else
        {
            Invoke(nameof(CreateEnemy), enemySpawnTime);        // 敵の生成
            enemySpawnTime += enemySpawnInterval;
            Invoke(nameof(CreateObstacle), obstacleSpawnTime);  // 障害物の生成
            obstacleSpawnTime += obstacleSpawnInterval;
        }
    }

    private void CreateEnemy()
    {
        try
        {
            Instantiate(enemyPrefab, new Vector3
                (UnityEngine.Random.Range(-25f, 25f), UnityEngine.Random.Range(0f, 30f), transform.position.z + 200), Quaternion.identity);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return;
        }
    }

    private void CreateObstacle()
    {
        try
        {
            Instantiate(obstaclePrefab, new Vector3
                (UnityEngine.Random.Range(-25f, 25f), UnityEngine.Random.Range(0f, 30f), transform.position.z + 200), Quaternion.identity);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return;
        }
    }

    private void GameEnd()
    {
        SceneManager.LoadScene("Result");
    }
}
