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
    [SerializeField] private int Width, Heigh;
    float a = 1;
    [ContextMenu("Visibal Hidden Room")]
    public void SetVisible(){
        {
            if (a > 0)
            {
                a -=   Time.deltaTime;
                for (int x = position.x - Width; x < position.x + Width; x++)
                {
                    for (int y = position.y - Heigh; y < position.y + Heigh; y++)
                    {
                        tilemaps.SetTileFlags(new Vector3Int(x, y, 0), TileFlags.None);
                        tilemaps.SetColor(new Vector3Int(x, y, 0), new Color(1, 1, 1, a));
                    }

                }
            }
         
          
            
            

            
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(position, new Vector3(Width, Heigh, 0));
    }
    private void Update()
    {
        if(hiddenCursor.getCollider())
        SetVisible();
    }
}
