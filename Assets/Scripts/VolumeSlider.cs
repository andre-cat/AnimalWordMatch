using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = GameManager.Volume;
    }

    void FixedUpdate()
    {
        SetVolume();
    }

    private void SetVolume()
    {
        GameManager.Volume = slider.value;
    }
}
