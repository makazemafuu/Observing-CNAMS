using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScript : MonoBehaviour
{
    public void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        SceneManager.LoadScene(0);
    }
}
