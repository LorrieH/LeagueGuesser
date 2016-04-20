using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SaveName : MonoBehaviour {

    [SerializeField]private InputField nameInput;
    [SerializeField]private bool showPanel;
    public bool ShowPanel
    {
        get
        {
            return showPanel;
        }
        set
        {
            showPanel = value;
        }
    }
	// Use this for initialization
	void Start () {
        GetName();
	}

    public void StoreName(string nickname)
    {
        nickname = nameInput.text;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/NameData.elohell");
        EnterName enterName = new EnterName();
        enterName.name = nickname;
        enterName.firstTime = false;

        bf.Serialize(file, enterName);
        file.Close();
    }

    public void GetName()
    {
        if(File.Exists(Application.persistentDataPath + "/NameData.elohell"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/NameData.elohell", FileMode.Open);

            EnterName saveData = (EnterName)bf.Deserialize(file);
            showPanel = saveData.firstTime;
            Debug.Log("your nickname = " + saveData.name + "firstTime = " + showPanel);
            file.Close();
        }
    }
}

[System.Serializable]
public class EnterName
{
    public string name;
    public bool firstTime;
}