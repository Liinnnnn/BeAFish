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

    // Update is called once per frame
    void Update()
    {
    }

    public void playerLevelUp()
    {
        levelUpUI.SetActive(true);
    }
    
    private void updateXPbar()
    {
        expBar.value = Mathf.Clamp01((float) player.currentXP / player.levelCap);
    }
}
