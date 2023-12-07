using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField, Tooltip("Make sure to have pause menu display over all other UI objects by having it lower down in the child object hierarchy on the canvas.")] 
    private GameObject menuObject;

    private void Awake()
    {
        menuObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseScreenState(PauseManager.Instance.IsPaused);
        }
    }
    private void ChangePauseScreenState(bool pauseState)
    {
        if (pauseState)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        menuObject.SetActive(true);
        PauseManager.Instance.SetPauseState(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        menuObject.SetActive(false);
        PauseManager.Instance.SetPauseState(false);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartLevel()
    {
        PauseManager.Instance.SetPauseState(false);
        SceneManagerScript.Instance.RestartScene();
    }

    public void GoToMainMenu()
    {
        PauseManager.Instance.SetPauseState(false);
        SceneManagerScript.Instance.LoadScene(Scenes.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
