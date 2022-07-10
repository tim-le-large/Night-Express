using System.Collections;
using UnityEngine;
using System;

public class Rotate : MonoBehaviour
{
    public static event Action<string> Rotated = delegate { };
    private bool couroutineAllowed;
    private int numberShown;

    // Start is called before the first frame update
    void Start()
    {
        couroutineAllowed = true;
        numberShown = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Wheel")
                {
                    if (couroutineAllowed)
                    {   
                        StartCoroutine("RotateWheel", hit);
                    }

                }
            }
        }
    }


    private IEnumerator RotateWheel(RaycastHit hit)
    {
        couroutineAllowed = false;
        for (int i = 0; i <= 11; i++)
        {
            
            hit.transform.Rotate(-3f, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
        }
        couroutineAllowed = true;
        FindObjectOfType<AudioManager>().Play("Lock");
        Debug.Log("lock");
        Rotated(hit.transform.name);
    }




}
