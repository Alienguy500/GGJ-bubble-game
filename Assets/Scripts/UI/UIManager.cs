using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    bool escKeyDown = false;
    public Canvas pauseMenu;
    public Canvas optionsMenu;
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
                    Time.timeScale = 0f;
               }
                else
                {
                    Time.timeScale = 1f;   
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
        optionsMenu.enabled = false;
    }
    public void TitleScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OptionsMenu()
    {
        pauseMenu.enabled = false;
        optionsMenu.enabled = true;
    }
}
