using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusControl : MonoBehaviour
{
    public Image oxygenBar;

    private readonly float startDelay = 0.5f;
    private readonly float intervalBetweenExecution = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateStatusBars", startDelay, intervalBetweenExecution);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateStatusBars()
    {
        oxygenBar.fillAmount -= 0.01f;
    }
}
