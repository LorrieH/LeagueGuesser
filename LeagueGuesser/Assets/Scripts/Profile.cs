using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Profile : MonoBehaviour 
{
    private SaveData saveDataScript;
    [SerializeField]private string name;
    private Sprite icon;
    private int elo;

    [SerializeField]private Text nameText;
    [SerializeField]private Image profileIcon;

    void Start()
    {
        saveDataScript = GameObject.FindWithTag("DataObject").GetComponent<SaveData>();
        SetNickname();   
    }

    public void SetIcon(Sprite summonerIcon)
    {
        icon = summonerIcon;
        profileIcon.sprite = icon;
    }

    public void SetNickname()
    {
        saveDataScript.GetData();
        nameText.text = saveDataScript.Nickname;
    }

}
