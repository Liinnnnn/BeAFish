using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Player")]
    public GameObject fish;
    public GameObject levelUpUI;
    public Slider expBar;
    public PlayerLevelUp player;
    void Start()
    {
        PlayerLevelUp.onLevelUp += playerLevelUp;
        PlayerLevelUp.onXpChange += updateXPbar;
    }
    public void playerLevelUp()
    {
        levelUpUI.SetActive(true);
        Time.timeScale = 0;
    }
    
    private void updateXPbar()
    {
        expBar.value = Mathf.Clamp01((float) player.currentXP / player.levelCap);
    }
}
