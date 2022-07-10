using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{

    private bool cursorLocked = true;
    public GameObject escMenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            escMenu.gameObject.SetActive(!escMenu.gameObject.activeSelf);
            if (cursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                cursorLocked = true;
                //Debug.Log(Cursor.lockState);
            }
            else
            {   
                Cursor.lockState = CursorLockMode.None;
                cursorLocked = false;
            }

        } 
    }
}
