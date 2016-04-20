using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour {

    private Image fadeImage;
    private Color c;
    private float alpha;

	// Use this for initialization
	void Start () {
        fadeImage = GetComponent<Image>();

        ResetAlpha();
	}
	
	// Update is called once per frame
	void Update () {
        if(c.a < 1)
        {
            UpdateColor();
        }
	}

    void UpdateColor()
    {
        alpha = alpha + 0.01f;
        c.a = alpha;
        fadeImage.color = c;
    }

    public void ResetAlpha()
    {
        c = fadeImage.color;
        c.a = 0;
        fadeImage.color = c;
    }
}
