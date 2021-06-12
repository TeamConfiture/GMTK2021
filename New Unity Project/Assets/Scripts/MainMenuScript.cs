using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject Rules1Menu;
    public GameObject Rules2Menu;

    public void PlayNowButton(string scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
    public void Rules1Button()
    {
        Rules1Menu.SetActive(true);
        CreditsMenu.SetActive(false);
        MainMenu.SetActive(false);
        Rules2Menu.SetActive(false);
    }

    public void Rules2Button()
    {
        Rules2Menu.SetActive(true);
        CreditsMenu.SetActive(false);
        MainMenu.SetActive(false);
        Rules1Menu.SetActive(false);
    }

    public void CreditsButton() {
        CreditsMenu.SetActive(true);
        MainMenu.SetActive(false);
        Rules1Menu.SetActive(false);
        Rules2Menu.SetActive(false);
    }
    public void MainMenuButton() {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        Rules1Menu.SetActive(false);
        Rules2Menu.SetActive(false);
    }
    public void BackButton(){
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        Rules1Menu.SetActive(false);
        Rules2Menu.SetActive(false);
    }
    public void QuitButton() {
        Application.Quit();
    }
    
}
