using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGeneratorScript : MonoBehaviour {

    // Use this for initialization
    private AudioSource source;


    void Start () {
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound()
    {
        source.Play();
    }
}
