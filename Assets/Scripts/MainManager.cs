using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // ���� Ŭ���� ��� ���� 
    // �� Ŭ���� ����� ����� ���� �ش� Ŭ������ ��� �ν��Ͻ����� ������
    public static MainManager Instance;

    public Color TeamColor;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // Ŭ���� ��� Instance(MainManager�� ���� �ν��Ͻ�)�� "this"�� ����
        // �ٸ� ��ũ��Ʈ(��: Unit ��ũ��Ʈ)���� MainManager.Instance�� ȣ���ϰ� �ش� Ư�� �ν��Ͻ��� ���� ��ũ�� ������ �� �ֽ��ϴ�.
        Instance = this;

        // �� ��ũ��Ʈ�� ����� MainManager ���� ������Ʈ�� ����� ����� �� �ı����� �ʵ��� ǥ��
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
