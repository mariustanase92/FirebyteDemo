using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FruitType")] 
public class FruitTypeSO : ScriptableObject
{

    public string fruitName;
    public Transform prefab;
    
    [Tooltip("How long until the fruit dissapears?")]
    public int lifeTime;

    [Tooltip("Min and Max values must ALWAYS be different from any other fruit!")]
    public int minSpawnRate;

    [Tooltip("Min and Max values must ALWAYS be different from any other fruit!")]
    public int maxSpawnRate;

    [Tooltip("How many points will this fruit give the player?")]
    public int pointsAmount;

}