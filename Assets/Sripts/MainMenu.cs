using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text coinText;
    private void Start()
    {
        int coins = PlayerPrefs.GetInt("moneybag");
        coinText.text = coins.ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
