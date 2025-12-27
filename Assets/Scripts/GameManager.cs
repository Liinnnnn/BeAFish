using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Player")]
    public GameObject fish;
    public GameObject levelUpUI;
    public GameObject lostUI;
    public Slider expBar;
    public PlayerLevelUp player;
    public GameObject LVupNotice;
    void Start()
    {
        PlayerLevelUp.onLevelUp += playerLevelUp;
        PlayerLevelUp.onXpChange += updateXPbar;
        FishManager.onPlayerDying += losingUI;
    }
    public void playerLevelUp()
    {
        levelUpUI.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(levelUp());
    }
    
    private void updateXPbar()
    {
        expBar.value = Mathf.Clamp01((float) player.currentXP / player.levelCap);
    }
    
    private IEnumerator levelUp()
    {
        LVupNotice.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        LVupNotice.SetActive(false);
    }
    private void losingUI()
    {
        lostUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void restart()
    {
        Time.timeScale = 1;
        fish.tag = "Player";
        fish.SetActive(true);
        lostUI.SetActive(false);
    }
}
