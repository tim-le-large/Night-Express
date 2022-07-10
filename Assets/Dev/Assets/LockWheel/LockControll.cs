using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockControll : MonoBehaviour
{

    public GameObject door;
    private int[] result, correctCombination;
    // Start is called before the first frame update

    void Start()
    {
        result = new int[] { 0, 0, 0 };
        correctCombination = new int[] { 7, 5, 9 };
        Rotate.Rotated += CheckResult;

    }

    private void CheckResult(string wheelName)
    {
        
        switch (wheelName)
        {
            case "Wheel1":
                result[0] = ++result[0] % 10;
                break;
            case "Wheel2":
                result[1] = ++result[1] % 10;
                break;
            case "Wheel3":
                result[2] = ++result[2] % 10;
                break;
        }
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            FindObjectOfType<AudioManager>().Play("Lock_Open");
            FindObjectOfType<AudioManager>().Play("Door_Open");
            door.GetComponent<Animation>().Play("openDoor");
        }
    }
}
