using UnityEngine;
using System.Collections;

public class Attack_MG : MonoBehaviour {

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

	void AttackAnimate(AttackInfo attackInfo){
		attackInfo.Target.SendMessage ("ApplyDamage", attackInfo.AttackDamage, SendMessageOptions.DontRequireReceiver);
		animation.Play ("Attack_01", PlayMode.StopAll);
		giantSound.Play ();
	}
}
