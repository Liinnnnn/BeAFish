using System;
using UnityEngine;

public class PlayerLevelUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action onLevelUp;
    public static event Action onXpChange;
    public int currentXP;
    public int currentLevel;
    public int levelCap;
    // Update is called once per frame
    private void levelUp()
    {
        currentLevel +=1;
        levelCap += levelCap;
        onLevelUp?.Invoke(); 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob") && Math.Abs(collision.transform.localScale.x) <= Math.Abs (FindAnyObjectByType<PlayerMovement>().size))
        {
            int xp =  collision.GetComponent<FishManager>().exp * PlayerStats.XpMultiplier;
            currentXP += xp;
            if(currentXP >= levelCap)
            {
                currentXP = currentXP - levelCap;
                levelUp();
            }
            Destroy(collision.gameObject);
            onXpChange?.Invoke();
        }
    }
}
