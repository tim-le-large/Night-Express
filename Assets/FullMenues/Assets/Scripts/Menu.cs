using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject ControlsMenu;
    public GameObject AboutMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)



        foreach (Transform child in MainMenu.transform)
            if (child.transform.name != "Background")
            {
                child.gameObject.SetActive(false);
            }


        //yield on a new YieldInstruction that waits for 5 seconds.

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameLevel");

    }

    public void ToggleControlsMenuButton()
    {
        MainMenu.SetActive(!MainMenu.activeSelf);
        ControlsMenu.SetActive(!ControlsMenu.activeSelf);
    }
    public void ToggleAboutMenuButton()
    {// Quit Game
        MainMenu.SetActive(!MainMenu.activeSelf);
        AboutMenu.SetActive(!AboutMenu.activeSelf);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}