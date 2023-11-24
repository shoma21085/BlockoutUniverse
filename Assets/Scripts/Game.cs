using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject playerPrefab;         // �v���C���[�̃v���n�u
    public GameObject enemyPrefab;          // �G�̃v���n�u
    public float enemySpawnInterval;        // �G�̏o���Ԋu
    private float enemySpawnTime;           // �G�̏o������
    public GameObject obstaclePrefab;       // ��Q���̃v���n�u
    public float obstacleSpawnInterval;     // ��Q���̏o���Ԋu
    private float obstacleSpawnTime;        // ��Q���̏o������

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);   // �v���C���[�̐���
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
        // �Q�[���I�[�o�[�̔���
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Invoke(nameof(GameEnd), 1);
        }
        else
        {
            Invoke(nameof(CreateEnemy), enemySpawnTime);        // �G�̐���
            enemySpawnTime += enemySpawnInterval;
            Invoke(nameof(CreateObstacle), obstacleSpawnTime);  // ��Q���̐���
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
