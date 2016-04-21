using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SaveName : MonoBehaviour {

    [SerializeField]private Text incorrectName;
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

    IEnumerator ShowText(float delay)
    {
        incorrectName.enabled = true;
        yield return new WaitForSeconds(delay);
        incorrectName.enabled = false;       
    }

    public void StoreName(string nickname)
    {
        
        if (nameInput.text.Length >= 4 && nameInput.text.Length <= 16)
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
        else
        {
            StartCoroutine(ShowText(1.5f));
        }
    }

    public void GetName()
    {
        if(File.Exists(Application.persistentDataPath + "/NameData.elohell"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/NameData.elohell", FileMode.Open);

            EnterName saveData = (EnterName)bf.Deserialize(file);
            showPanel = saveData.firstTime;
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