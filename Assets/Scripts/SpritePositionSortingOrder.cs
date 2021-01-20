using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositionSortingOrder : MonoBehaviour {

    [SerializeField] private bool runOnce;
    
    [Tooltip("order multiple sprites on the same parent/sorting order")]
    [SerializeField] private float positionOffsetY; 

    private SpriteRenderer spriteRenderer;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate() {

        //refresh sorting order (put the ones on the bottom to be on top layer)
        float precisionMultiplier = 5f; //we will have 5 sortin orders per each unit location
        spriteRenderer.sortingOrder = (int)(-(transform.position.y + positionOffsetY) * precisionMultiplier);
        
        if(runOnce) {
            Destroy(this);
        }
    }
}
