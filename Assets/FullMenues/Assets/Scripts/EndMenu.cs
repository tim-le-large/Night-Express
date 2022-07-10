using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{


    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void BackToMainMenu()
    {

        gameObject.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }


}