using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public void MaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health){
        slider.value = health;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
