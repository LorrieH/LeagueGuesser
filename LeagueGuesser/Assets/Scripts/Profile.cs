using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Profile : MonoBehaviour 
{
    [SerializeField]private string name;
    private Sprite icon;
    private int elo;

    [SerializeField]private Text nameText;
    [SerializeField]private Image profileIcon;

    void Start()
    {
        nameText.text = name;
    }

    public void SetIcon(Sprite summonerIcon)
    {
        icon = summonerIcon;
        profileIcon.sprite = icon;
    }

}
