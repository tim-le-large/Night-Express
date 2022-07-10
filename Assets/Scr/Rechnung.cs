using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rechnung : MonoBehaviour
{
    public GameObject recept;
    public GameObject player;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) )
            {
                if (hit.transform.tag == "Rechnung")
                {   
                    FindObjectOfType<AudioManager>().Play("Paper");
                    recept.gameObject.SetActive(!recept.gameObject.activeSelf);   
                    player.GetComponent<Move>().enabled = !player.GetComponent<Move>().enabled;
                    
                }
            }
        }   
    }    
}
