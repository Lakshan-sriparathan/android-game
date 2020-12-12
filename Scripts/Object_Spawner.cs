using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner : MonoBehaviour {

    public GameObject Player;
    public GameObject[] coins;
    public GameObject[] trees;
    public GameObject enemy;
    private float coinSpawnTimer = 7.0f;
    private float enemySpawnTimer = 10.0f;
    private float treeSpawnTimer = 0.5f;

    // Update is called once per frame
    void Update() {
        coinSpawnTimer -= Time.deltaTime;
        enemySpawnTimer -= Time.deltaTime;
        treeSpawnTimer -= Time.deltaTime;

        if (coinSpawnTimer < 0.01) {
            SpawnCoins();
        }
        if (enemySpawnTimer < 0.01) {
            SpawnEnemy();
        }
        if (treeSpawnTimer < 0.01) {
            SpawnTrees();

        }
    }

    void SpawnCoins () {
        Instantiate(coins [(Random.Range (0, coins.Length ))], new Vector3 (Player.transform.position.x + 30, Random.Range(2, 8), 0), Quaternion.identity);
        coinSpawnTimer = Random.Range(1.0f, 3.0f);
    }

    void SpawnEnemy() {
        enemy.transform.localScale = new Vector3(Random.Range(1, 1.5f), Random.Range(1, 1.5f), Random.Range(1, 1.5f));
        Instantiate (enemy, new Vector3 (Player.transform.position.x + 30, Random.Range (1, 9), 0), Quaternion.identity);
        enemySpawnTimer = Random.Range (1, 3);
    }

    void SpawnTrees () {
        Instantiate(trees[(Random.Range(0, trees.Length))], new Vector3(Player.transform.position.x + 70, 0, Random.Range(5, 22)), Quaternion.identity);
        treeSpawnTimer = 0.5f;
    }

}














