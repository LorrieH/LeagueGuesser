using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

    [SerializeField]private AudioClip[] clips;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
    public void PlaySound(int clipNumber)
    {
        source.clip = clips[clipNumber];
        source.PlayOneShot(source.clip);
    }
}
