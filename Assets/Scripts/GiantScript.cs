using UnityEngine;
using System.Collections;

public class GiantScript : MonoBehaviour {
	AudioSource giantSound;
	// Use this for initialization
	void Start () {
		giantSound = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!animation.isPlaying)
			animation.Play("Idle_01",  PlayMode.StopAll);

	}

	void AttackAnimate(){
		animation.Play ("Attack_01", PlayMode.StopAll);
		giantSound.Play ();
		}


}
