using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume_controller : MonoBehaviour
{
 // Start is called before the first frame update
    [SerializeField] Slider volumeSlider;


    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);

        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

}
