using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject uiToChange;
    [SerializeField] private GameObject deadScreen;
    private bool t;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            t = player.activeInHierarchy;
        }
        catch(MissingReferenceException e)
        {
            uiToChange.SetActive(false);
            deadScreen.SetActive(true);
        }
    }
    public void SceneRestart()
    {
        SceneManager.LoadScene(1);
    }
    public void SceneToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
