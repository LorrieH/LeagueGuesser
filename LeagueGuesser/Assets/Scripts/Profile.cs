using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Profile : MonoBehaviour 
{
    [SerializeField]private Sprite[] icons;
    private SaveData saveDataScript;
    private DivisionChecker divisionChecker;
    private int icon;
    private int ip = 1337;
    private string summonerName;

    [SerializeField]private Text nameText;
    [SerializeField]private Text IPText;
    [SerializeField]private Image profileIcon;

    void Start()
    {
        saveDataScript = GameObject.FindWithTag("DataObject").GetComponent<SaveData>();
        divisionChecker = GetComponent<DivisionChecker>();
        StartingStats();
        //saveDataScript.StoreData(new EnterData(string name, int iconint, int leaguepoints));
        //to only set 1 variable, use saveDataScript.(variable) for the variables you dont want to change except for leaguepoints, set this to 0 if you dont want to change.
        //I.E. saveDataScript.StoreData(new EnterData(saveDataScript.name(dont want to change this), saveDataScript.IconInt(dont want to change this either), saveDataScript.LP + 21));
        //name should always be saveDataScript.name !
    }

    public void StartingStats()
    {
        saveDataScript.GetData();
        SetSummonerName();
        nameText.text = summonerName;
        SetIcon(saveDataScript.IconInt);
        SetElo(0);
        SetPoints();
        
    }

    private void SetSummonerName()
    {
        saveDataScript.GetData();
        summonerName = saveDataScript.Nickname;
    }

    public void SetIcon(int summonerIconIndex)
    {
        icon = summonerIconIndex;
        profileIcon.sprite = icons[icon];
    }

    public void SetPoints()
    {
        ip = saveDataScript.IP;
        IPText.text = "" + ip;
    }

    public void SetElo(int lp)
    {
        saveDataScript.GetData();
        saveDataScript.StoreData(new EnterData(summonerName, saveDataScript.IconInt, saveDataScript.LP + lp, saveDataScript.IP));
        divisionChecker.SetCurrentDivisionWithPoints(saveDataScript.LP);
    }

    public void AddLeaguePoints(int ip)
    {
        saveDataScript.GetData();
        saveDataScript.StoreData(new EnterData(summonerName, saveDataScript.IconInt, saveDataScript.LP, saveDataScript.IP + ip));
        SetPoints();
    }

    public void SaveIcon()
    {
        saveDataScript.StoreData(new EnterData(summonerName, icon, saveDataScript.LP, saveDataScript.IP));
    }

}
