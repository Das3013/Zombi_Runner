using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ResultObject;
    // Start is called before the first frame update
    public PlayerMove pm;
    public RoadSpawner rs;
    public void showRusult()
    {
        ResultObject.SetActive(true);
       
    }
    public void StartGame()
    {
        ResultObject.SetActive(false);
        rs.startgame();
        pm.CanPlay = true;
        
    }

}

