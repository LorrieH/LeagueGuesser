using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour {

    private Image fadeImage;
    private float timer;
    public float Timer
    {
        get
        {
            return timer;
        }
        set
        {
            timer = value;
        }
    }

	// Use this for initialization
	void Start () {
        fadeImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        Fade();
    }

    void Fade()
    {
        timer += Time.deltaTime;
        fadeImage.color = new Color(255f, 255f, 255f, Mathf.Lerp(0f,1, timer)); 
    }

    public void ResetAlpha()
    {
        timer = 0f;
    }
}
