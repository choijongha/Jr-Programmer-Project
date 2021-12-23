using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // 정적 클래스 멤버 선언 
    // 이 클래스 멤버에 저장된 값이 해당 클래스의 모든 인스턴스에서 공유됨
    public static MainManager Instance;

    public Color TeamColor;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // 클래스 멤버 Instance(MainManager의 현재 인스턴스)에 "this"를 저장
        // 다른 스크립트(예: Unit 스크립트)에서 MainManager.Instance를 호출하고 해당 특정 인스턴스에 대한 링크를 가져올 수 있습니다.
        Instance = this;

        // 이 스크립트에 연결된 MainManager 게임 오브젝트가 장면이 변경될 때 파괴되지 않도록 표시
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
