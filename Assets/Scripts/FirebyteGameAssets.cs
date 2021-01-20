using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebyteGameAssets : MonoBehaviour
{

    private static FirebyteGameAssets instance; //field

    public static FirebyteGameAssets Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<FirebyteGameAssets>("FirebyteGameAssets");
            }
            return instance;
        }
    }

    public Transform pfApple;
    public Transform pfOrange;
    public Transform pfCherry;
    public Transform pfGrapes;
    public Transform pfBanana;

}
