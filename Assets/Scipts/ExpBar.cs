using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider Exp_Slider;

    public void AddExp(int exp)
    {
        Exp_Slider.value += exp;
    }

    public void SetMaxExp(int exp)
    {
        Exp_Slider.maxValue = exp;
    }

    public float GetExp()
    {
        return Exp_Slider.value;
    }

    public void SetExp(int exp)
    {
        Exp_Slider.value = exp;
    }
}
