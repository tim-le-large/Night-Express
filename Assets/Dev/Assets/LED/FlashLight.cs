using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Material lightbolb;
    public Material lightMat;
    public Light lightUp;
    public Light lightDown;
    public Light lightPoint;
    public float updateSeconds = 0.5f;
    private double[] morseCode;
    private float elapsed;
    private bool changeL = false;
    private int currentMorseIndex = 0;

    void Start()
    {
        morseCode = new double[] { 2.5, 0.5, 2.5, 0.5, 0.75, 0.5, 0.75, 0.5, 0.75, 5};
        
        lightbolb.EnableKeyword("_EMISSION");
        lightMat.EnableKeyword("_EMISSION");
        lightUp.enabled = true;
        lightDown.enabled = true;
        lightPoint.enabled = true;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        // after 1 second + morseCode
        if (elapsed >= updateSeconds + morseCode[currentMorseIndex]) {
            elapsed = elapsed % updateSeconds;
            changeLight(changeL);
            changeL = !changeL;
            if (currentMorseIndex == morseCode.GetLength(0)-1){
                currentMorseIndex = 0;
            }else{
                currentMorseIndex++;
            }   
        }
    }

    void changeLight(bool on){
        if(on){
            // turn lights on 
            lightbolb.EnableKeyword("_EMISSION");
            lightMat.EnableKeyword("_EMISSION");
            lightUp.enabled = true;
            lightDown.enabled = true;
            lightPoint.enabled = true;
        }else{
            // turn lights off
            lightbolb.DisableKeyword("_EMISSION");
            lightMat.DisableKeyword("_EMISSION");
            lightUp.enabled = false;
            lightDown.enabled = false;
            lightPoint.enabled = false;
        }
    }
}
