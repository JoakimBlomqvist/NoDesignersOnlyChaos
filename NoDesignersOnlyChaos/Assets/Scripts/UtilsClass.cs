using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsClass : MonoBehaviour
{
    private static Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
    }
    
    
    public static Vector2 GetMouseWorldPos()
    {
        Camera camera = Camera.main;
        Vector3 mousePos = Input.mousePosition;
        //mousePos.z = camera.nearClipPlane;
        mousePos.z = 0;
        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
        return worldPos;
    }
    public static Vector3 GetMouseWorldPosV3()
    {
        Camera camera = Camera.main;
        Vector3 mousePos = Input.mousePosition;
        //mousePos.z = camera.nearClipPlane;
        mousePos.z = 0;
        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
        return worldPos;
    }
}
