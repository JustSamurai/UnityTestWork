using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    RotateCamera rotateCamera;

    public Camera camera;

    public Transform startPoint;

    public Transform target;

    private float speed = 1f;

    private bool isTimerOn;

    void Start()
    {
        rotateCamera = GetComponent<RotateCamera>();
    }
    void FixedUpdate()
    {
        if (GeneralStatic.isUsed == false)
        {
            if (GeneralStatic.isInAction)
            {
                camera.transform.LookAt(target.transform);

                camera.transform.position = Vector3.MoveTowards(camera.transform.position,
                    startPoint.position,
                    speed * Time.deltaTime);

                if (camera.transform.position == startPoint.position)
                {
                    GeneralStatic.isPoint = true;
                }
            }
        }
    }
}
