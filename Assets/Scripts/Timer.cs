using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int secondsDelay = 60;
    private void OnEnable()
    {
        StartCoroutine(TimeScore());
    }

    private void OnDisable()
    {
        StopCoroutine(TimeScore());
    }

    IEnumerator TimeScore()
    {
        for (int i = 0; i < secondsDelay; ++i)
        {
            yield return new WaitForSeconds(1);

            Debug.Log(string.Format("{0} seconds |" +
                " Scene is {1} |" +
                " Camera in start point {2} |", GeneralStatic.count, GeneralStatic.isUsed, GeneralStatic.isPoint));
        }
    }
}
