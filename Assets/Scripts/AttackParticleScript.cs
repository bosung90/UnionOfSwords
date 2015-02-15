using UnityEngine;
using System.Collections;

public class AttackParticleScript : MonoBehaviour {

	AudioSource swordSound;

	// Use this for initialization
	void Start () {
		swordSound = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AttackAnimate(){
		particleSystem.Play (true);
		swordSound.Play ();
	}
}
