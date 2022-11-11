using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    CharacterController cc;
    Vector3 moveVec;
    public int speed=10;
    int laneNumber = 1,laneCounter=2;
    public float firslanepos, lanedistance, sidespeed;
    
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        moveVec = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {

        cc.Move(speed * moveVec);
    }
}
