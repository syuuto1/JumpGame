using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnPoint;
    public Text timeText;
    public float obstacleSpeed = 3f;

    //障害物スポーン時間の調整
    public float MinSpawnTime = 3f;
    public float MaxSpawnTime = 5f;


    public Sprite[] obstacleSprites; //スプライト配列

    private float time = 0f;

    public static float resultTime; //リザルトにタイムを送る用

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    void Update()
    {
        time += Time.deltaTime * 10;
        timeText.text = "Time: " + Mathf.FloorToInt(time);
        resultTime = time; //リザルト用
    }

    /// <summary>
    /// 一定間隔で障害物を生成するコルーチン
    /// </summary>
    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(1f); //初回ディレイ

        while (true)
        {
            SpawnObstacle();

            //生成時間をランダムにする
            float waitTime = UnityEngine.Random.Range(MinSpawnTime, MaxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    /// <summary>
    /// 障害物を生成して速度とスプライトを設定
    /// </summary>
    void SpawnObstacle()
    {
        GameObject obs = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity); //生成
        obs.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * obstacleSpeed;          //速度の設定

        if (obstacleSprites.Length > 0) //ランダムにスプライト表示
        {
            SpriteRenderer sr = obs.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                int index = UnityEngine.Random.Range(0, obstacleSprites.Length);
                sr.sprite = obstacleSprites[index];
            }
        }

        Destroy(obs, 6f);
    }
}