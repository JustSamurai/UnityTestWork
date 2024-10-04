using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Camera camera;
    public GameObject target;
    public float speed = 2.0f;

    public delegate void MouseClickAction();
    public static event MouseClickAction OnMouseClick;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        RotateCameraAround();
    }

    void RotateCameraAround()
    {
        if (Input.GetMouseButton(0))
        {
            GeneralStatic.isUsed = true;
            GeneralStatic.isPoint = false;
            GeneralStatic.isCameraPoint = false;
            GeneralStatic.isInAction = false;

            camera.transform.RotateAround(target.transform.position,
                camera.transform.up, -Input.GetAxis("Mouse X") * speed);

            camera.transform.RotateAround(target.transform.position,
                camera.transform.right, -Input.GetAxis("Mouse Y") * speed);

            OnMouseClick?.Invoke();
        }
        else
        {
            GeneralStatic.isUsed = false;
        }

    }
}
