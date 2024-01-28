using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    public float maximun;
    public float value;
    public Image mask;
    public Image fill;
    public Color color;
    public Gradient gradient;


    void Start()
    {

    }

    void Update()
    {
        CurrentFill();
    }

    void CurrentFill()
    {
        if(value <= 6)
        {
            float fillAmount = (float)value / (float)maximun;
            mask.fillAmount = fillAmount / 2;
            fill.color = gradient.Evaluate(fill.fillAmount*2);
        }    
    }
}
