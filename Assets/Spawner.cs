using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject fallingObject;
    float screenBorder;
    float nextSpawnTime;
    public Vector2 spawnDelayRange;
    public Vector2 size;
    public float rotateAngle;
    
    void Start()
    {
        float halfObjectWidth = transform.localScale.x / 2f;
        screenBorder = Camera.main.aspect * Camera.main.orthographicSize - halfObjectWidth;
        
    }

    void Update()
    {
        if (Time.time > nextSpawnTime) {
            float spawnDelay = Mathf.Lerp(spawnDelayRange.y, spawnDelayRange.x, Difficulty.getDifficulty());
            nextSpawnTime = Time.time + spawnDelay;
            
            float spawnAngle = Random.Range(-rotateAngle, rotateAngle);
            float spawnScaleX = Random.Range(size.x, size.y);
            float spawnScaleY = Random.Range(size.x, size.y);

            Vector2 spawnPosition = new Vector2(Random.Range(-screenBorder, screenBorder), Camera.main.orthographicSize + Mathf.Max(spawnScaleX, spawnScaleY));
            GameObject newBlock = (GameObject) Instantiate(fallingObject, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

            newBlock.transform.localScale = new Vector3(spawnScaleX, spawnScaleY, 1);
        }
    }
}
