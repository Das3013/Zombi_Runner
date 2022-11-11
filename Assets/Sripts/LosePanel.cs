using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void MainScreen()
    {
        SceneManager.LoadScene(0);
    }
}
