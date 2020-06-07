using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab00;
    public GameObject foodPrefab01;
    public GameObject foodPrefab02;

    public float spawnDelta00 = 20f;
    public float spawnDelta01 = 15f;
    public float spawnDelta02 = 25f;

    float timer00 = 0f;
    float timer01 = 0f;
    float timer02 = 0f;

    float randX;
    float randY;

    public Vector2 minBounds;
    public Vector2 maxBounds;

    public bool stillAlive00;
    public bool stillAlive01;
    public bool stillAlive02;

    GameObject tempObj;

    private void Start()
    {
        stillAlive00 = true;
        stillAlive01 = true;
        stillAlive02 = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer00 += Time.deltaTime;
        timer01 += Time.deltaTime;
        timer02 += Time.deltaTime;

        if(timer00 > spawnDelta00 && stillAlive00)
        {
            randX = Random.Range(minBounds.x, maxBounds.x);
            randY = Random.Range(minBounds.y, maxBounds.y);
            tempObj = Instantiate(foodPrefab00, new Vector2(randX, randY), Quaternion.identity);
            timer00 = 0;
        }
        if (timer01 > spawnDelta01 && stillAlive01)
        {
            randX = Random.Range(minBounds.x, maxBounds.x);
            randY = Random.Range(minBounds.y, maxBounds.y);
            tempObj = Instantiate(foodPrefab01, new Vector2(randX, randY), Quaternion.identity);
            timer01 = 0;
        }
        if (timer02 > spawnDelta02 && stillAlive02)
        {
            randX = Random.Range(minBounds.x, maxBounds.x);
            randY = Random.Range(minBounds.y, maxBounds.y);
            tempObj = Instantiate(foodPrefab02, new Vector2(randX, randY), Quaternion.identity);
            timer02 = 0;
        }
    }
}
