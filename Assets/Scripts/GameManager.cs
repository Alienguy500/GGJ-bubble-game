using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            
                instance = FindObjectOfType<GameManager>();
            return instance;
        }
        set => instance = value;
    }
    public GameObject mainCamera;
    public SoundManager soundManager;
    public MusicManager musicManager;

    private void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(instance);
        soundManager = mainCamera.GetComponent<SoundManager>();
        musicManager = mainCamera.GetComponent<MusicManager>();
        Time.timeScale = 1f;
    }
    public int GetTimer()
    {
        return 1;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Unpause()
    {
        Time.timeScale = 1f;
    }
}
