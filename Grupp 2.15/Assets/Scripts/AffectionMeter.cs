using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectionMeter : MonoBehaviour
{
    public int minAffection = 0;
    public int maxAffection = 100;
    public int currentAffection;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        currentAffection = minAffection;
        fill.color = gradient.Evaluate(1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DecreaseAffection();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            IncreaseAffection();
        }
    }
    public void IncreaseAffection()
    {
        currentAffection += 10;
        slider.value = currentAffection;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (currentAffection > maxAffection)
        {
            currentAffection = maxAffection;
        }
    }
    public void DecreaseAffection()
    {
        currentAffection -= 10;
        slider.value = currentAffection;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (currentAffection < minAffection)
        {
            currentAffection = minAffection;
        }
    }
}
