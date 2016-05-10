﻿using UnityEngine;
using System.Collections;

public class PulseColor : MonoBehaviour {

    public float FadeDuration = 1f;
    public Color Color1 = Color.gray;
    public Color Color2 = Color.white;

    private Color startColor;
    private Color endColor;
    private float lastColorChangeTime;

    [SerializeField]private Material material;

    // Use this for initialization
    void Start () {
        //material = GetComponent<Renderer>().material;
        startColor = Color1;
        endColor = Color2;
    }
	
	// Update is called once per frame
	void Update () {
        var ratio = (Time.time - lastColorChangeTime) / FadeDuration;
        ratio = Mathf.Clamp01(ratio);
        material.color = Color.Lerp(startColor, endColor, ratio);
        //material.color = Color.Lerp(startColor, endColor, Mathf.Sqrt(ratio)); // A cool effect
        //material.color = Color.Lerp(startColor, endColor, ratio * ratio); // Another cool effect

        if (ratio == 1f)
        {
            lastColorChangeTime = Time.time;

            // Switch colors
            var temp = startColor;
            startColor = endColor;
            endColor = temp;
        }
        
    }

}
