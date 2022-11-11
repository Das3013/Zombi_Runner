using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] RoadBlockPrefab;
    public GameObject startBlock;
    public Transform PlayerTranf;
    float blockZpos=0;
    float startZpos;
    int blocksCount = 7;
    float blocklen = 0;
    int safezone = 300;
    Vector3 startplayer;
    List<GameObject> currBlock = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        startZpos = startBlock.transform.position.z;
        blocklen = startBlock.GetComponent<BoxCollider>().bounds.size.z;
        startplayer = PlayerTranf.position;
        startgame();


    }
    public void startgame()
    {
        blockZpos = startZpos;
        PlayerTranf.position = startplayer;
        foreach (var i in currBlock)
            Destroy(i);
        currBlock.Clear();
        for (var i = 0; i < blocksCount; i++)
            SpawnBlock();
    }
    void checkForSpawn()
    {
        if (PlayerTranf.position.z- safezone > (blockZpos - blocksCount * blocklen))
        {
            SpawnBlock();
            DestroyBlock();
        }
    }
    // Update is called once per frame
    void SpawnBlock()
    {
        GameObject block = Instantiate(RoadBlockPrefab[Random.Range(0, RoadBlockPrefab.Length)], transform);
        blockZpos += blocklen;
        block.transform.position = new Vector3(0, 0, blockZpos);
        currBlock.Add(block);
    }
    void Update()
    {
        checkForSpawn();
    }
    private void DestroyBlock()

    {
        Destroy(currBlock[0]);
        currBlock.RemoveAt(0);


    }
}
