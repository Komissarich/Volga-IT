using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    
    public void SetHealth(float health, float maxhealth){
        slider.value = health;
        slider.maxValue = maxhealth;
        slider.gameObject.SetActive(true);
        slider.value = health;
        slider.maxValue = maxhealth;
          slider.gameObject.SetActive(true);
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
       
    }
}
