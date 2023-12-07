using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonMethods : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("VillageEnvironment");
    }
    public void QuitGameButton()
    {
        Application.Quit();
    }
}
