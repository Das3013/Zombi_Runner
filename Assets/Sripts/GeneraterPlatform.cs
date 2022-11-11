using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneraterPlatform : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTit = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLength = 100;
    [SerializeField] private Transform player;
    private int starTit = 4;
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < starTit; i++)
            SpawnTile(Random.Range(0, tilePrefabs.Length));
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z -60 > spawnPos - (starTit * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTit();
        }

    }
    private void SpawnTile(int titIndex)
    {
        GameObject nextTit= Instantiate(tilePrefabs[titIndex], transform.forward * spawnPos, transform.rotation);
        activeTit.Add(nextTit);
        spawnPos += tileLength;
    }
    private void DeleteTit()
       
    {
        Destroy(activeTit[0]);
        activeTit.RemoveAt(0);


    }
}
