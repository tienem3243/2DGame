using UnityEngine;
using UnityEngine.UI;

public class GUIPlayer : MonoBehaviour
{
    [Header("Make health bar for player")]
    public Slider _slider;
    public Color _low;
    public Color _high;
    public Vector3 _offset;
    /// <summary>Set heal bar for display player Heath.</summary>
    /// <param name="health"> description </param>
    private void Start()
    {
        SetHealthBar(23, 100);
    }
    public void SetHealthBar(float hitPoint, float maxHitPoint)
    { 
        _slider.value = hitPoint;
        Debug.Log(_slider.value);
        _slider.maxValue = maxHitPoint;
        
    }
  
}
