using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SaveData : MonoBehaviour {

    [SerializeField]private Text incorrectName;
    [SerializeField]private InputField nameInput;
    private bool showPanel = true;
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
    private string nickname;
    public string Nickname
    {
        get
        {
            return nickname;
        }
        set
        {
            nickname = value;
        }
    }
    private int lp;
    public int LP
    {
        get
        {
            return lp;
        }
        set
        {
            lp = value;
        }
    }
    private int iconInt;
    public int IconInt
    {
        get
        {
            return iconInt;
        }
        set
        {
            iconInt = value;
        }
    }

    IEnumerator ShowText(float delay)
    {
        incorrectName.enabled = true;
        yield return new WaitForSeconds(delay);
        incorrectName.enabled = false;       
    }

    public void SaveIconInt(int arrayInt)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SpriteData.elohell");
        SpriteData enterSprite = new SpriteData();
        enterSprite.spriteInt = arrayInt;

        bf.Serialize(file, enterSprite);
        file.Close();
    }

    public void AddLeaguePoints(int leaguepoints)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData.elohell");
        EnterData enterName = new EnterData();

        enterName.leaguePoints += leaguepoints;
        bf.Serialize(file, enterName);
        file.Close();
    }

    public void StoreData(string nickname)
    {
        
        if (nameInput.text.Length >= 4 && nameInput.text.Length <= 16)
        {
            nickname = nameInput.text;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/SaveData.elohell");
            EnterData enterName = new EnterData();
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

    public void GetData()
    {
        if(File.Exists(Application.persistentDataPath + "/SaveData.elohell"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.elohell", FileMode.Open);

            EnterData saveData = (EnterData)bf.Deserialize(file);
            showPanel = saveData.firstTime;
            nickname = saveData.name;
            lp = saveData.leaguePoints;

            file.Close();
        }
    }

    public void GetSpriteData()
    {
        if (File.Exists(Application.persistentDataPath + "/SpriteData.elohell"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SpriteData.elohell", FileMode.Open);

            SpriteData spriteData = (SpriteData)bf.Deserialize(file);
            iconInt = spriteData.spriteInt;

            file.Close();
        }
    }
}

[System.Serializable]
public class EnterData
{
    public string name;
    public int leaguePoints;
    public bool firstTime;
}

[System.Serializable]
public class SpriteData
{
    public int spriteInt;
}