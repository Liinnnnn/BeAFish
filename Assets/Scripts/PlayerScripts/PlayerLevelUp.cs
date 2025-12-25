using System;
using UnityEngine;

public class PlayerLevelUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action onLevelUp;
    public static event Action onXpChange;
    // Update is called once per frame
    void FixedUpdate()
    {
        levelUp();
    }

    private void levelUp()
    {
        if(PlayerStats.currentXP >= PlayerStats.levelCap)
        {
            PlayerStats.level +=1;
            PlayerStats.levelCap += PlayerStats.levelCap;
            onLevelUp?.Invoke(); 
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob"))
        {
            int xp =  collision.GetComponent<FishManager>().exp;
            PlayerStats.currentXP += xp;
            if(PlayerStats.currentXP >= PlayerStats.levelCap)
            {
                PlayerStats.currentXP = PlayerStats.currentXP - PlayerStats.levelCap;
            }
            onXpChange?.Invoke();
        }
    }
}
