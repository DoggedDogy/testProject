using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
