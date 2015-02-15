using UnityEngine;
using System.Collections;

public class MeteorScript : MonoBehaviour {

	AudioSource meteorSound;
	// Use this for initialization
	void Start () {
		meteorSound = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void MeteorOn() {
		particleSystem.Play (true);
		meteorSound.Play ();
	}
}
