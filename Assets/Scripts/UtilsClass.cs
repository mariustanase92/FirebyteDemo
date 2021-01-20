using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsClass {

    private static Camera mainCamera;
    public static Vector3 GetMouseWorldPosition() {
        if (mainCamera == null) mainCamera = Camera.main;

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //get the world position of the main camera (convert from screen to world pos)
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

    public static Vector3 GetRandomDir() {
        return new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
            ).normalized;
    }

    public static float GetAngleFromVector(Vector3 vector) {
        float radians = Mathf.Atan2(vector.y, vector.x); //it first takes the Y and then the X
        float degrees = radians * Mathf.Rad2Deg;
        return degrees;
    }
}
