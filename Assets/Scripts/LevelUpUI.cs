using System;
using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action onUpgrade;
    public GameObject UI;
    public void upgradeSpeed()
    {
        Time.timeScale = 1;
        PlayerStats.Speed += 0.2f;
        UI.SetActive(false);
        onUpgrade?.Invoke();
    }
    public void upgradeSize()
    {
        Time.timeScale = 1;
        PlayerStats.Size += 0.1f;
        UI.SetActive(false);
        onUpgrade?.Invoke();
    }
    public void upgradeExp()
    {
        Time.timeScale = 1;
        PlayerStats.XpMultiplier += 1;
        UI.SetActive(false);
        onUpgrade?.Invoke();
    }
}
