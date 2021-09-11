using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusControl : MonoBehaviour
{
    public Image oxygenBar;
    public Image healthStatus;

    private readonly float startDelay = 0.5f;
    private readonly float intervalBetweenExecution = 0.5f;

    private readonly float statusGood = 1;
    private readonly float statusModerate = 0.60f;
    private readonly float statusCritical = 0.35f;

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

        if (oxygenBar.fillAmount > statusModerate && oxygenBar.fillAmount < statusGood)
        {
            healthStatus.color = Color.green;
        }
        if (oxygenBar.fillAmount > statusCritical && oxygenBar.fillAmount < statusModerate)
        {
            healthStatus.color = Color.yellow;
        }
        else if(oxygenBar.fillAmount > 0 && oxygenBar.fillAmount < statusCritical)
        {
            healthStatus.color = Color.red;
        }
    }
}
