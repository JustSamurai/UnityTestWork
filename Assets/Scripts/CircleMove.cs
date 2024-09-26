using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    public enum Circle
    {
        Horizontal = 0,
        HorizontalAndY = 1,
    }

    public Circle circle = Circle.HorizontalAndY;

    [SerializeField]
    Transform target;

    [SerializeField]
    float radius = 10f, angularSpeed = 0.5f;

    float positionX, positionY, positionZ, angle = 0f;

    void FixedUpdate()
    {
        if(GeneralStatic.isPoint = true && GeneralStatic.count >= 60)
        {
            if (!GeneralStatic.isGamePaused)
            {
                ALLMOVES();
            }
        }
    }

    public void ALLMOVES() 
    {
        transform.LookAt(target);

        positionX = target.position.x + Mathf.Cos(angle) * radius;
        positionY = target.position.x + Mathf.Cos(angle) * radius;
        positionZ = target.position.z + Mathf.Sin(angle) * radius;
        
        if (circle == Circle.HorizontalAndY)
        {
            transform.position = new Vector3(positionX, positionY, positionZ);
        }
        else if (circle == Circle.Horizontal)
        {
            transform.position = new Vector3(positionX, 0, positionZ);
        }
            
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
