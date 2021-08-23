using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed = 11f;
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] private float minZoom = 0.2f, maxZoom = 4f;
    private float _newZoom = 0;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _newZoom = _camera.orthographicSize;
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

    public void ShakeCamera()
    {
        if (isShaking == false)
        {
            StartCoroutine(Shake());
        }
    }

    private bool isShaking;
    IEnumerator Shake()
    {
        isShaking = true;
        int counter = 10;
        while (counter > 0)
        {
            _camera.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-4, 4)));
            _camera.orthographicSize += Random.Range(-0f, 0.1f);
            counter--;
            yield return new WaitForSeconds(0.01f);
        }
        _camera.orthographicSize = _newZoom;
        _camera.transform.rotation = Quaternion.Euler(Vector3.zero);
        isShaking = false;
    }
}
