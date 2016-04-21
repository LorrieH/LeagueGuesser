using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckForFirstTime : MonoBehaviour {

    private SaveName saveName;
    [SerializeField]private GameObject panel;
    [SerializeField]private GameObject playButton;
	// Use this for initialization
	void Start () {
        saveName = GameObject.FindWithTag("DataObject").GetComponent<SaveName>();
        CheckFirstTime();
    }

    void CheckFirstTime()
    {
        saveName.GetName();

        HidePanel();
    }

    public void HidePanel()
    {
        saveName.GetName();

        if (saveName.ShowPanel == false)
        {
            panel.SetActive(!panel.activeSelf);
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }
}
