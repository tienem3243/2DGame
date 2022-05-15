using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{

    public string nextScene;

    private string KEY_DATA = "playerdata";

    private void Awake()
    {
        LoadUnitData();

        // Chuyển sang Scene khác sau khi load dữ liệu xong
        SceneManager.LoadScene(nextScene);
    }

    [ContextMenu("load")]
    private void LoadUnitData()
    {
        //Lấy dữ liệu dạng string ở PlayerPrefs
        string s = PlayerPrefs.GetString(KEY_DATA);
        Debug.Log(s);

        // Nếu chuỗi string null hoặc rỗng thì sẽ tạo một data mới với các giá trị mặc định
        if (string.IsNullOrEmpty(s))
        {
            GameData.PlayerData= new UnitData.PlayerData();
            return;
        }

        // Dùng JsonDotNet convert dữ liệu từ string sang object
        GameData.PlayerData = JsonUtility.FromJson<UnitData.PlayerData>(s);
    }
}