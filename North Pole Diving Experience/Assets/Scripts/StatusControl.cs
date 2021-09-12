using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatusControl : MonoBehaviour
{
    private static StatusControl instance;
    public static StatusControl Instance()
    {
        return instance;
    }

    public Image oxygenBar;
    public Image healthStatus;
    public Text crystalInfo;
    public PlayerControl player;
    public Image DarknessOfDeath;

    private int crystalInLevel = 0;
    private int crystalCollected = 0;

    private readonly float startDelay = 0.5f;
    private readonly float intervalBetweenExecution = 0.5f;

    private readonly float statusGood = 1;
    private readonly float statusModerate = 0.60f;
    private readonly float statusCritical = 0.35f;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;

            crystalInLevel = GameObject.FindGameObjectsWithTag("Crystal").Length;
            crystalInfo.text = crystalCollected + " / " + crystalInLevel;

            InvokeRepeating("UpdateStatusBars", startDelay, intervalBetweenExecution);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isBitten)
        {
            player.isBitten = false;
            oxygenBar.fillAmount = oxygenBar.fillAmount - 0.4f;
        }
        if(oxygenBar.fillAmount <= 0)
        {
            StartCoroutine(FadeToBlack());
            SceneManager.LoadScene("GameOver");
        }
    }

    private IEnumerator FadeToBlack(int fadeSpeed = 5)
    {
        Color objectColor = DarknessOfDeath.color;
        float fadeAmount;
        while(DarknessOfDeath.color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            DarknessOfDeath.color = objectColor;
            yield return null;

        }
    }

    void UpdateStatusBars()
    {
        oxygenBar.fillAmount = oxygenBar.fillAmount - 0.01f;

        healthStatus.color = UpdateHealthStatusColors(oxygenBar.fillAmount);
    }

    private Color UpdateHealthStatusColors(float hitpoints)
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

    public void AddOxygen(float amount)
    {
        oxygenBar.fillAmount = oxygenBar.fillAmount + amount;
    }

    public void BreakCrystal()
    {
        crystalCollected++;
        crystalInfo.text = crystalCollected + " / " + crystalInLevel;
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
