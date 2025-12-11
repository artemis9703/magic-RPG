using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;
    public CanvasGroup statsCanvas;
    private bool statsOpen = false;

    void Start()
    {
        UpdateAllStats();
    }

    void Update()
    {
        if (Input.GetButtonDown("ToggleStats") && statsOpen == false)
        {
            Time.timeScale = 0;
            statsCanvas.alpha = 1;
            statsCanvas.interactable = true;
            statsCanvas.blocksRaycasts = true;
            statsOpen = true;
        }
        else if (Input.GetButtonDown("ToggleStats") && statsOpen == true)
        {
            Time.timeScale = 1;
            statsCanvas.alpha = 0;
            statsCanvas.interactable = false;
            statsCanvas.blocksRaycasts = false;
            statsOpen = false;
        }
    }

    public void UpdateDamage()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatsManager.Instance.damage;
    }

    public void UpdateSpeed()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatsManager.Instance.speed;
    }

    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
    }
}