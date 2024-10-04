using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveTo : MonoBehaviour
{
    RotateCamera rotateCamera;
    public FileReader reader;

    public GameObject[] cameraPoints;
    public GameObject uiPanel;

    private float speed = 0.5f;
    private float timeCount = 0.5f;

    private void Start()
    {
        rotateCamera = GetComponent<RotateCamera>();
    }

    private void Update()
    {
        transform.LookAt(rotateCamera.target.transform);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"{hit.collider.name} Detected", hit.collider.gameObject);

                string edgeName = hit.collider.gameObject.name;
                int pointIndex = GetPointIndex(edgeName);

                if (pointIndex != -1 && !GeneralStatic.isCameraPoint)
                {
                    MoveToPoint(cameraPoints[pointIndex]);
                    ShowUIPanel();
                }
            }
        }
    }
    private void ShowUIPanel()
    {
        uiPanel.SetActive(true);
        reader.LoadJson();
    }
    public void MoveToPoint(GameObject toPoint)
    {
        transform.position = toPoint.transform.position;
        GeneralStatic.isCameraPoint = true;
    }

    private int GetPointIndex(string edgeName)
    {
        switch (edgeName)
        {
            case "Edge Up": return 0;
            case "Edge Down": return 1;
            case "Edge Left": return 2;
            case "Edge Right": return 3;
            case "Edge Back": return 4;
            case "Edge Front": return 5;
            default: return -1;
        }
    }
}
