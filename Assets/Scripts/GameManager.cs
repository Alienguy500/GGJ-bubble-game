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
    public int GetTimer()
    {
        return 1;
    }
}
