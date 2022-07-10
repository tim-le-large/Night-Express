using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private AudioSource radio;
    private void Start() {
        radio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) )
            {
                if (hit.transform.tag == "Radio")
                {   
                    radio.mute = !radio.mute;
                    FindObjectOfType<AudioManager>().Play("Turn_On");
                }
            }
        }  
    }
}
