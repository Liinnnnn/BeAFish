using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    public GameObject[] Fishes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DelayTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnFish()
    {
        float numberOfFish = Random.Range(1,Fishes.Length);
        List<int> spawnsIndex = new List<int>();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnsIndex.Add(i);
        }

        for (int i = 0; i < numberOfFish; i++)
        {
            if (spawnsIndex.Count == 0) break;

            int listIndex = Random.Range(0, spawnsIndex.Count); 
            int actualSpawnPointIndex = spawnsIndex[listIndex];

            Instantiate(Fishes[i], spawnPoints[actualSpawnPointIndex].position, Quaternion.identity);

            spawnsIndex.RemoveAt(listIndex);
        }       
    }

    private IEnumerator DelayTime()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(2f);
            spawnFish();
        }
    }

}
