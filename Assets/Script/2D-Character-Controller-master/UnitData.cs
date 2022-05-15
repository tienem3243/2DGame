using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        public string SceneName;//if you stand in front of the door and go to room from other scene that position you stand is previous location 
       public PlayerData(float pMaxHP, float pHp,float pAtk,float pDef,Vector2 pos)
        {
            this.pMaxHP = pMaxHP;
            this.pDef = pDef;
            this.pHp = pHp;
            this.pAtk = pAtk;
            saveLocate = pos;
            this.SceneName = SceneManager.GetActiveScene().name;
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
        
        // Dùng PlayerPrefs lưu dữ liệu lại
      PlayerPrefs.SetString(KEY_DATA, s);

    }
    [ContextMenu("Load")]
    public void Load()
    {
        //Lấy dữ liệu dạng string ở PlayerPrefs
        string s = PlayerPrefs.GetString(KEY_DATA);


        // Nếu chuỗi string null hoặc rỗng thì sẽ tạo một data mới với các giá trị mặc định
        if (string.IsNullOrEmpty(s))
        {
            GameData.PlayerData = new UnitData.PlayerData();
            return;
        }

        // Dùng JsonDotNet convert dữ liệu từ string sang object
        GameData.PlayerData = JsonUtility.FromJson<UnitData.PlayerData>(s);
       
        StartCoroutine(SetupAndMove());
        

    }
    public IEnumerator SetupAndMove()
    {
       
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(GameData.PlayerData.SceneName);
        gameObject.GetComponentInParent<Rigidbody2D>().MovePosition(GameData.PlayerData.saveLocate);
        player.sethitPoint(GameData.PlayerData.pHp);
        player.setMaxhitPoint(GameData.PlayerData.pMaxHP);
        player.setAtk(GameData.PlayerData.pAtk);
        player.setDef(GameData.PlayerData.pDef);
        player.gui.SetHealthBar(GameData.PlayerData.pHp, GameData.PlayerData.pMaxHP);

       
       
       
    }
    public IEnumerator Respawn()
    {

        player.sethitPoint(GameData.PlayerData.pMaxHP);
        player.setMaxhitPoint(GameData.PlayerData.pMaxHP);
        player.setAtk(GameData.PlayerData.pAtk);
        player.setDef(GameData.PlayerData.pDef);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(GameData.PlayerData.SceneName);
        gameObject.GetComponentInParent<Rigidbody2D>().MovePosition(GameData.PlayerData.saveLocate);


    }
}
