using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morse : MonoBehaviour
{
    public GameObject morse;
    public GameObject player;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) )
            {
                if (hit.transform.tag == "Morse")
                {   
                    FindObjectOfType<AudioManager>().Play("Paper");
                    morse.gameObject.SetActive(!morse.gameObject.activeSelf);   
                    player.GetComponent<Move>().enabled = !player.GetComponent<Move>().enabled;
                    
                }
            }
        }   
    }    
}
