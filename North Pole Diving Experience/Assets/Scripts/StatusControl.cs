using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusControl : MonoBehaviour
{
    public Image oxygenBar;
    public Image healthStatus;
    public PlayerControl player;

    private float hitpoints = 1f;
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
        if (player.isBitten)
        {
            hitpoints -= 10f;
            player.isBitten = false;
        }
    }

    void UpdateStatusBars()
    {
        hitpoints -= 0.01f;
        oxygenBar.fillAmount = hitpoints;

        healthStatus.color = UpdateHealthStatusColors();
    }

    private Color UpdateHealthStatusColors()
    {
        if (hitpoints > statusModerate && hitpoints < statusGood)
        {
            return Color.green;
        }
        else if (hitpoints > statusCritical && hitpoints < statusModerate)
        {
            return Color.yellow;
        }
        else if (hitpoints > 0 && hitpoints < statusCritical)
        {
            return Color.red;
        }

        return Color.gray;
    }
}
