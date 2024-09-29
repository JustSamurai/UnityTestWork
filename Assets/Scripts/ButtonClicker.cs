using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicker : MonoBehaviour
{
    public GameObject uiPanel;
    public void Back()
    {
        uiPanel.SetActive(false);
    }
}
