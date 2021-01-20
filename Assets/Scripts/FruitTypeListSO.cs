using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FruitTypeList")]
public class FruitTypeListSO : ScriptableObject
{
    public List<FruitTypeSO> list;
}
