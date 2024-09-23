using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    RotateCamera rotateCamera;

    public GameObject[] cameraPoints;

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
                Debug.Log($"{hit.collider.name} Detected",
                    hit.collider.gameObject);

                if (hit.collider.gameObject.name == "Edge Up" && GeneralStatic.isCameraPoint == false)
                {
                    MoveToPoint(cameraPoints[0]);
                }
                if (hit.collider.gameObject.name == "Edge Down" && GeneralStatic.isCameraPoint == false)
                {
                    MoveToPoint(cameraPoints[1]);
                }
                if (hit.collider.gameObject.name == "Edge Left" && GeneralStatic.isCameraPoint == false)
                {
                    MoveToPoint(cameraPoints[2]);
                }
                if (hit.collider.gameObject.name == "Edge Right" && GeneralStatic.isCameraPoint == false)
                {
                    MoveToPoint(cameraPoints[3]);
                }
                if (hit.collider.gameObject.name == "Edge Back" && GeneralStatic.isCameraPoint == false)
                {
                    MoveToPoint(cameraPoints[4]);
                }
                if (hit.collider.gameObject.name == "Edge Front" && GeneralStatic.isCameraPoint == false)
                {
                    MoveToPoint(cameraPoints[5]);
                }
            }
        }

    }

    public void MoveToPoint(GameObject toPoint) 
    {
        transform.position = toPoint.transform.position;

        if (transform.position == toPoint.transform.position)
        {
            GeneralStatic.isCameraPoint = true;

            GeneralStatic.isGamePaused = true;
            Debug.Log("Пауза ---> " + GeneralStatic.isGamePaused + " <--");
            Debug.Log("Камера в точке ---> " + GeneralStatic.isCameraPoint + " <--");
        }
    }


}
