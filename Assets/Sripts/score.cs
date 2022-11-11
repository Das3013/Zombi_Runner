using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text scoreText;//Text mesh pro 
    private void Update()
    {
        scoreText.text = ((int)(player.position.z / 2)).ToString();// ≈бать это порно с плюсами
    }
}
