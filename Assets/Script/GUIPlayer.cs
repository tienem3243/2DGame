using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPlayer : MonoBehaviour
{
    [Header("Make health bar for player")]
    public Slider _slider;
    public Color _low;
    public Color _high;
    public Vector3 _offset;
    public Camera cam;

    /// <summary>Set heal bar for display player Heath.</summary>
    /// <param name="health"> description </param>
    public void SetHealthBar(float hitPoint, float maxHitPoint)
    { 
        _slider.value = hitPoint;
        _slider.maxValue = maxHitPoint;
        _slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(_low, _high, _slider.normalizedValue);
    }
}
