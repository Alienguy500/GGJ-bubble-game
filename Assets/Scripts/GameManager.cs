using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get;
    }
    public GameObject mainCamera;
    public SoundManager soundManager;
    public MusicManager musicManager;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
        soundManager = mainCamera.GetComponent<SoundManager>();
        musicManager = mainCamera.GetComponent<MusicManager>();
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
