using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public GameObject endScreen;


    void Update()
    {
        if (transform.position == new Vector3(-0.3f, 0f, -0.006f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10))
                {
                    print(hit.transform.name);
                    if (hit.transform.name == "Tür_vorne")
                    {
                        //öffne End Screne
                        endScreen.SetActive(true);
                    }
                }
            }
        }
    }
}
