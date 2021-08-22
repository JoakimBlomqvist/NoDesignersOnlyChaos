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
    
    
    public static Vector3 GetMouseWorldPos()
    {
        Camera camera = Camera.main;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = camera.nearClipPlane;
        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
        return worldPos;
    }
}
