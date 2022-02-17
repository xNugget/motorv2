using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    void Update()
    {
        
    }
    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);

        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

    }
    public GameObject coinPrefab;
    void SpawnCoins()
    {
        int coinToSpawn = 10;
        for(int i = 0; i < coinToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }
        
}
