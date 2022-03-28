using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_MT_ScoreController : MonoBehaviour
{

    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    public Image star, starNull;
    public Camera cam;

    /// <summary>Set heal bar for display entity's Heath.</summary>
    /// <param name="health"> description </param>
    public void SetHealthBar(float health, float maxhealth)
    {
        slider.gameObject.SetActive(health < maxhealth);
        slider.value = health;
        slider.maxValue = maxhealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    void Update()
    {
        // make HeathBar/Slider move with parant position
        slider.transform.position = cam.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void turnOff_On()
    {
        star.gameObject.SetActive(true);
        starNull.gameObject.SetActive(false);
    }

}
