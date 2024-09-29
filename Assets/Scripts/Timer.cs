using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int secondsDelay = 60;
    private int i = 0;

    private void OnEnable()
    {
        StartCoroutine(TimerCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        for (i = 0; i < secondsDelay; i++)
        {
            Debug.Log(string.Format("{0} seconds |" +
                " Scene is {1} |" +
                " Camera in start point {2} |" +
                " Action is {3} |", i, GeneralStatic.isUsed, GeneralStatic.isPoint, GeneralStatic.isInAction));
            yield return new WaitForSeconds(1);
        }
        GeneralStatic.isInAction = true;
    }

}
