using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    // 캐릭터 위치 및 방향 
    public Vector3 playerPos;
    public Vector3 playerRot;

    // 인벤토리 아이템 저장
    public List<int> invenArrayNumber = new List<int>();
    public List<string> invenItemName = new List<string>();
    public List<int> invenItemNumber = new List<int>();

    // 캐릭터 스테이터스 창
}
public class SaveLoad : MonoBehaviour
{
    private SaveData saveData = new SaveData();

    private string SAVE_DATA_DIRECTORY;
    private string SAVE_FILENAME = "/SaveFile.txt";

    private PlayerController thePlayer;
    private Inventory theInven;

    // Start is called before the first frame update
    void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/Saves/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
        }
    }

    public void SaveData()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theInven = FindObjectOfType<Inventory>();

        saveData.playerPos = thePlayer.transform.position;
        saveData.playerRot = thePlayer.transform.eulerAngles;

        
        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        Debug.Log("저장 완료");
        Debug.Log(json);
    }

    public void LoadData()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {

            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            thePlayer = FindObjectOfType<PlayerController>();

            thePlayer.transform.position = saveData.playerPos; // 캐릭터의 위치
            thePlayer.transform.eulerAngles = saveData.playerRot; // 캐릭터의 방향


            Debug.Log("로드 완료");

        }
        else
            Debug.Log("세이브 파일이 없습니다.");

    }
}
