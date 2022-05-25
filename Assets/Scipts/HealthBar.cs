using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HP_Slider;

    public void SetHealth(int health)
    {
        HP_Slider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        HP_Slider.maxValue = health;
        HP_Slider.value = health;
    }

    public float GetHealth()
    {
        return HP_Slider.value;
    }
}
