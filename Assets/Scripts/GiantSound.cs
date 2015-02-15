using UnityEngine;
using System.Collections;

public class GiantSound : MonoBehaviour {

	AudioSource giantSound;
	// Use this for initialization
	void Start () {
		giantSound = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		giantSound.Play ();
	}
}
