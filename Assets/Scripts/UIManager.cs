using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    bool escKeyDown = false;
    public Canvas pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float escKey = Input.GetAxisRaw("Cancel");
        if (escKey != 0)
        {
            if (!escKeyDown)
            {
                pauseMenu.enabled = !pauseMenu.enabled;
                escKeyDown = true;
                if (pauseMenu.enabled)
                {
                    GameManager.Instance.Unpause();
                }
                else
                {
                    GameManager.Instance.Pause();
                }
            }
        }
        else
        {
            escKeyDown = false;
        }
    }
    public void BackToGame()
    {
        pauseMenu.enabled = false;
    }
}
