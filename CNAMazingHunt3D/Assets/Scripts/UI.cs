using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    public void Restart()
    {
        Debug.Log("Restart the game !");
        SceneManager.LoadScene(0);
    }
}

