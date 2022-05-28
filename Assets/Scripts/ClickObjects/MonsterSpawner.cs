using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObjects;

    [SerializeField] private float xMinRange = -12.0f;
    [SerializeField] private float xMaxRange = 12.0f;
    [SerializeField] private float yMinRange = 3.0f;
    [SerializeField] private float yMaxRange = 13.0f;
    [SerializeField] private float zMinRange = -12.0f;
    [SerializeField] private float zMaxRange = 12.0f;

    public bool canSpawn = false;

    private float nextSpawnTime;
    private float secondsBetweenSpawning = 1f;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    private void SpawnObjectAtRandomPlace()
    {
        Vector3 spawnPosition;
        spawnPosition.x = Random.Range(xMinRange, xMaxRange);
        spawnPosition.y = Random.Range(yMinRange, yMaxRange);
        spawnPosition.z = Random.Range(zMinRange, zMaxRange);

        int objectToSpawn = Random.Range(0, spawnObjects.Length);

        if (!CheckCollision(spawnPosition, spawnObjects[objectToSpawn].transform.lossyScale))
        {
            GameObject spawnedObject = Instantiate(spawnObjects[objectToSpawn], spawnPosition, transform.rotation) as GameObject;
            spawnedObject.transform.parent = gameObject.transform;
        }
    }

    private bool CheckCollision(Vector3 centerPosition, Vector3 scale)
    {
        return Physics.BoxCast(centerPosition, scale / 2, new Vector3(0, 0, 0), Quaternion.identity, 0);
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            if (canSpawn)
                SpawnObjectAtRandomPlace();

            yield return new WaitForSeconds(secondsBetweenSpawning);
        }
    }
}
