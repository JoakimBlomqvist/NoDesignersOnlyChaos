using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    public static Camera _camera;
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed = 11f;
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] private float minZoom = 0.2f, maxZoom = 4f;
    private float _newZoom = 0;

    private int shakeCounter;
    
    
    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _newZoom = _camera.orthographicSize;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            OnZoom(Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            var cameraPosition = Vector2.Lerp(transform.position, player.position, Time.deltaTime * cameraSpeed);
            transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10);
        }
    } //updates the position with a Lerp function to smoothen the camera movement between its current position and _newPos
    
    //Zooms in or out within a range. 
    private void OnZoom(float zoom)
    {
        _newZoom -= zoom * scrollSpeed;

        _newZoom = Mathf.Clamp(_newZoom, minZoom, maxZoom);
        _camera.orthographicSize = _newZoom;
    }

    public void ShakeCamera(float value)
    {
        if (shakeCounter < 2)
        {
            StartCoroutine(Shake(value));
        }
    }
    
    IEnumerator Shake(float value)
    {
        shakeCounter++;
        value = value * 0.15f;
        int counter = 10;
        while (counter > 0)
        {
            _camera.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-value, value)));
            float ortoShake = Mathf.Clamp(value * 0.04f, 0f,0.30f);
            _camera.orthographicSize += Random.Range(-0f,ortoShake);
            counter--;
            yield return new WaitForSeconds(0.01f);
        }
        _camera.orthographicSize = _newZoom;
        _camera.transform.rotation = Quaternion.Euler(Vector3.zero);
        shakeCounter--;
    }
}
