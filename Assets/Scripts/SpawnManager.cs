using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; set; }

    private FruitTypeListSO fruitTypeList;
    private FruitTypeSO activeFruitType;
    
    public event EventHandler OnMaxFruitsSpawned;
    public event EventHandler OnUpdateFruitsNumber;

    private float firstSpawn = 2f; //first time SpawnFruit() is called

    [Tooltip ("spawn a new fruit at a set time (seconds)")]
    [SerializeField] private float spawnTime; 

    [SerializeField] private int maxFruitsToSpawn = 0;
    private int fruitsSpawned = 0;

    private int fruitTime; //fruit lifetime before it dissapears

    private Vector2 screenBounds;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    void Start()
    {     
        fruitTypeList = Resources.Load<FruitTypeListSO>(typeof(FruitTypeListSO).Name);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        fruitsSpawned = 0;

        InvokeRepeating("SpawnFruit", firstSpawn, spawnTime); //invoke a method after a set time, then again after another set time
    }

    public void SpawnFruit()
    {
        Vector2 randomSpawnPosition;
        randomSpawnPosition = new Vector2(UnityEngine.Random.Range(-screenBounds.x + 1, screenBounds.x - 1), UnityEngine.Random.Range(-screenBounds.y + 1, screenBounds.y - 3));

        int probability = UnityEngine.Random.Range(0, 100);

        for (int j = 0; j < fruitTypeList.list.Count; j++)
        {
            if (probability >= fruitTypeList.list[j].minSpawnRate && probability <= fruitTypeList.list[j].maxSpawnRate)
            {
                FruitTypeSO newFruit = fruitTypeList.list[j];
                fruitTime = newFruit.lifeTime;

                Instantiate(newFruit.prefab, randomSpawnPosition, Quaternion.identity);
                fruitsSpawned++;
                CheckFruitsSpawnedNumber();
                break;
            }
        }

    }

    public void CheckFruitsSpawnedNumber()
    {
        if ((fruitsSpawned) >= maxFruitsToSpawn)
        {
            OnMaxFruitsSpawned?.Invoke(this, EventArgs.Empty);
            CancelInvoke("SpawnFruit");
        }
    }

    public void RemoveFruit()
    {
        fruitsSpawned--;
        fruitsSpawned = Mathf.Clamp(fruitsSpawned, 0, maxFruitsToSpawn);
        InvokeRepeating("SpawnFruit", firstSpawn, spawnTime);
    }

    public void SetActiveFruitType(int fruitIndex)
    {
        activeFruitType = fruitTypeList.list[fruitIndex];
    }

    public FruitTypeSO GetActiveFruitType()
    {
        return activeFruitType;
    }

    public int GetFruitTime()
    {
        return fruitTime;
    }

}

