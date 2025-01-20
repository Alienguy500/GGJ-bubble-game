using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager instance;
    public static MainMenuManager Instance
    {
        get;
    }

    public GameObject mainCamera;
    public SoundManager soundManager;

    void Start()
    {
        if (mainCamera != null)
        {
            soundManager = mainCamera.GetComponent<SoundManager>();
        }
    }

    public void Play()
    {
        Debug.Log("hi");
        SceneManager.LoadScene("Level 1");
    }
}
