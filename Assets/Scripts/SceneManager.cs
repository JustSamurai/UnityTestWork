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
        //StartCoroutine(TimeScore());
        
        rotateCamera = GetComponent<RotateCamera>();
    }
    void FixedUpdate()
    {
        if(GeneralStatic.isUsed == false)
        {
            if (!GeneralStatic.isGamePaused)
            {
                if (GeneralStatic.count >= 60)
                {
                    camera.transform.LookAt(target.transform);

                    camera.transform.position = Vector3.MoveTowards(camera.transform.position,
                        startPoint.position,
                        speed * Time.deltaTime);

                    if (camera.transform.position == startPoint.position)
                    {
                        GeneralStatic.isPoint = true;
                        Debug.Log("Камера в точке ---> " + GeneralStatic.isPoint + " <--");
                    }
                }
            }
        }
        else
        {
            GeneralStatic.count = 0;

            //if(GeneralStatic.count == 0 && isTimerOn == false)
            //    StartCoroutine(TimeScore());
        }
    }
    //IEnumerator TimeScore()
    //{
    //    for (GeneralStatic.count = 0; GeneralStatic.count < 60; ++GeneralStatic.count)
    //    {
    //        isTimerOn = true;

    //        if (GeneralStatic.count == 59)
    //            isTimerOn = false;

    //        yield return new WaitForSeconds(1);

    //        Debug.Log(string.Format("{0} seconds |" +
    //            " Scene is {1} |" +
    //            " Camera in start point {2} |" +
    //            " Timer is {3}", GeneralStatic.count, GeneralStatic.isUsed, GeneralStatic.isPoint, isTimerOn));
    //    }
    //}
}
