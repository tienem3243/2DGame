using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class GUIPlayer : MonoBehaviour
{
    [Header("Make health bar for player")]
    public Slider _slider;
    public Slider sliderDot;
    public Color _low;
    public Color _high;
    public Vector3 _offset;
    /// <summary>Set heal bar for display player Heath.</summary>
    /// <param name="health"> description </param>
    public void SetHealthBar(float hitPoint, float maxHitPoint)
    {
        _slider.maxValue = maxHitPoint;
        _slider.value = hitPoint;      
    }
  
}
