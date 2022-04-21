using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenRoom : MonoBehaviour
{
    [SerializeField] public Tilemap tilemaps;
    [SerializeField] private GameObject hiddenLight;
    [SerializeField] private GameObject hiddenFrog;
    [SerializeField] private Cursor hiddenCursor;
    [SerializeField] private Vector3Int position;

    [ContextMenu("Visibal Hidden Room")]
    public void SetVisible(bool visibal)
    {
        hiddenLight.SetActive(visibal);
        hiddenFrog.SetActive(!visibal);
        
    }
    private void Update()
    {
        SetVisible(hiddenCursor.getCollider());
    }
}
