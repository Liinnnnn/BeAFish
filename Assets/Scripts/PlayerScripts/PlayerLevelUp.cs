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
    public AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClip;
    // Update is called once per frame
    private void levelUp()
    {
        currentLevel +=1;
        levelCap += levelCap;
        onLevelUp?.Invoke(); 
        audioSource.PlayOneShot(audioClip[1]);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob") && Math.Abs (FindAnyObjectByType<PlayerMovement>().size) >= Math.Abs(collision.transform.localScale.x))
        {
            int xp =  collision.GetComponent<FishManager>().exp * PlayerStats.XpMultiplier;
            currentXP += xp;
            if(currentXP >= levelCap)
            {
                currentXP = currentXP - levelCap;
                levelUp();
            }
            audioSource.PlayOneShot(audioClip[0]);
            Destroy(collision.gameObject);
            onXpChange?.Invoke();
        }
    }
}
