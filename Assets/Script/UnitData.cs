using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour
{
   [SerializeField] private string KEY_DATA = "playerdata";
    [SerializeField] Player player;
   public class PlayerData {
       public float pMaxHP;
       public float pHp;
       public float pDef;
        public float pAtk;
        public Vector2 saveLocate;
        public Vector2 previousLocate;//if you stand in front of the door and go to room from other scene that position you stand is previous location 
       public PlayerData(float pMaxHP, float pHp,float pAtk,float pDef,Vector2 pos)
        {
            this.pMaxHP = pMaxHP;
            this.pDef = pDef;
            this.pHp = pHp;
            this.pAtk = pAtk;
            saveLocate = pos;
        }
        public PlayerData()
        {
        }
    }


    [ContextMenu("Save")]
    public void Save()
    {
        PlayerData playerData = new PlayerData(player.getMaxhitpoint(),player.gethitpoint(),player.getAtk(),player.getDef(),player.transform.position);
        // Convert dữ liệu sang dạng string
        string s = JsonUtility.ToJson(playerData);
        Debug.Log(s);
        // Dùng PlayerPrefs lưu dữ liệu lại
      PlayerPrefs.SetString(KEY_DATA, s);

    }


}
