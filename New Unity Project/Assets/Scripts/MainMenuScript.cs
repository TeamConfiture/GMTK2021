using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;

    public void PlayNowButton(string scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
    public void CreditsButton() {
        CreditsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void MainMenuButton() {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }
    public void BackButton(){
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }
    public void QuitButton() {
        Application.Quit();
    }
    
}
