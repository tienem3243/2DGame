using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBarController : MonoBehaviour
{
    [Header("Make health bar for entity")]
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    /// <summary>Set heal bar for display entity's Heath.</summary>
    /// <param name="health"> description </param>
    public void SetHealthBar(float hitPoint, float maxHitPoint)
    {
        // only true or false
        slider.gameObject.SetActive(hitPoint < maxHitPoint);
        slider.value = hitPoint;
        slider.maxValue = maxHitPoint;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    private void Update()
    {
        // make HeathBar/Slider move with parant position
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
