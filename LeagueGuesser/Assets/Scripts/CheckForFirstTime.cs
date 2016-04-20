using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckForFirstTime : MonoBehaviour {

    private SaveName saveName;
    [SerializeField]private GameObject panel;
	// Use this for initialization
	void Start () {
        saveName = GameObject.FindWithTag("DataObject").GetComponent<SaveName>();
        CheckFirstTime();
        Debug.Log(saveName.ShowPanel);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(saveName.ShowPanel);
    }

    void CheckFirstTime()
    {
       
        if (saveName.ShowPanel == false)
        {
            
            panel.SetActive(!panel.activeSelf);
        }
    }
}
