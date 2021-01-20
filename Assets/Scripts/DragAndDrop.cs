using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector2 lastPosition;
    private Transform currentPosition;
    private Vector3 mOffset;
    private float mZCoord;
    private Camera mainCamera;

    private bool isInsideBasket;
    private Basket basket;

    private Countdown countDown;

    private FruitColorManager fruitColorManager;

    private void Awake()
    {
        currentPosition = GetComponent<Transform>();
        lastPosition = currentPosition.position;
        isInsideBasket = false;

        countDown = GetComponent<Countdown>();
        basket = GetComponent<Basket>();
        fruitColorManager = GetComponent<FruitColorManager>();
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }
 
    private void OnMouseDown()
    {
        lastPosition = currentPosition.position;
        mZCoord = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = currentPosition.position - GetMouseWorldPos(); //Store offset = GO world pos - mouse world pos

        SoundManager.Instance.PlaySound(SoundManager.Sound.EnemyHit);
        
        if(basket == null)
        {
            SpawnManager.Instance.SetActiveFruitType(GetFruitIndex());
            fruitColorManager.ResetFruitColor();
            countDown.PauseCountdown();
        }
    }

    private void OnMouseUp()
    {
        if (isInsideBasket)
        {
            ScoreManager.Instance.AddPoint(SpawnManager.Instance.GetActiveFruitType());
            SoundManager.Instance.PlaySound(SoundManager.Sound.BuildingPlaced);
            SpawnManager.Instance.RemoveFruit();
            Destroy(gameObject);
        }
            
        
        if (basket == null)
        {
            currentPosition.position = lastPosition;
            fruitColorManager.ReturnToPreviousColor();
            countDown.ResumeCountdown();
        }

    }

    private void OnMouseDrag()
    {
        currentPosition.position = GetMouseWorldPos() + mOffset;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Basket basketCollider = collider2D.gameObject.GetComponent<Basket>();
        if(basketCollider != null)
            isInsideBasket = true;

    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        Basket basketCollider = collider2D.gameObject.GetComponent<Basket>();
        if (basketCollider != null)
            isInsideBasket = false;
    }

    private Vector3 GetMouseWorldPos()
    {       
        Vector3 mousePoint = Input.mousePosition; // pixel coordinates (x,y)
        mousePoint.z = mZCoord; // z coordinate of gameobject on screen

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private int GetFruitIndex()
    {
        if (gameObject.tag == "Apple")
        {
            Debug.Log("Apple: ");
            return 0;
        }

        if (gameObject.tag == "Orange")
        {
            Debug.Log("Orange: ");
            return 1;
        }

        if (gameObject.tag == "Cherry")
        { 
            Debug.Log("Cherry: ");
            return 2;
        }

        if (gameObject.tag == "Grapes")
        {
            Debug.Log("Grapes: ");
            return 3;
        }

        if (gameObject.tag == "Banana")
        { 
            Debug.Log("Banana: ");
            return 4;
        }

        return 0;
    }
           
}
