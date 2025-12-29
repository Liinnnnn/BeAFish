using System;
using UnityEngine;

public class Bite : MonoBehaviour
{
    public GameObject Fish;
    public static event Action onPlayerDying;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Math.Abs(Fish.transform.localScale.x) > Math.Abs (FindAnyObjectByType<PlayerMovement>().size) )
        {
            collision.gameObject.SetActive(false);
            Destroy(Fish);
            onPlayerDying?.Invoke();
        }
    }
}
