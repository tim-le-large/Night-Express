using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{

    private bool menuOpened = false;
    private bool menuClosing = false;
    public GameObject escMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (menuOpened)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            if(menuClosing){
                Time.timeScale = 1;
                menuClosing = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escMenu.gameObject.SetActive(!escMenu.gameObject.activeSelf);
            menuOpened = !menuOpened;
            menuClosing = true;
        }
    }
}