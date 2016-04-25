using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Profile : MonoBehaviour 
{
    [SerializeField]private Sprite[] icons;
    private SaveData saveDataScript;
    private int icon;
    private int elo;
    private int ip = 1337;

    [SerializeField]private Text nameText;
    [SerializeField]private Text IPText;
    [SerializeField]private Image profileIcon;

    void Start()
    {
        saveDataScript = GameObject.FindWithTag("DataObject").GetComponent<SaveData>();
        SetNickname();
        SetPoints();
        StartingIcon();
        SetElo();
        //add elo like this: saveDataScript.AddLeaguePoints(20);
    }

    private void StartingIcon()
    {
        saveDataScript.GetSpriteData();
        SetIcon(saveDataScript.IconInt);
    }
    public void SetIcon(int summonerIconIndex)
    {
        icon = summonerIconIndex;
        profileIcon.sprite = icons[icon];
    }

    public void SetPoints()
    {
        IPText.text = "" + ip;
    }

    public void SetNickname()
    {
        saveDataScript.GetData();
        nameText.text = saveDataScript.Nickname;
    }

    public void SetElo()
    {
        saveDataScript.GetData();
        elo = saveDataScript.LP;
    }

    public void SaveIcon()
    {
        saveDataScript.SaveIconInt(icon);
    }

}
