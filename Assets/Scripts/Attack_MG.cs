using UnityEngine;
using System.Collections;

public class Attack_MG : MonoBehaviour {

	public AudioSource giantSound;

	// Use this for initialization
	void Start () {
		giantSound = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!animation.isPlaying)
			animation.Play("combat_idle",  PlayMode.StopAll);
	
	}

	void AttackAnimate(AttackInfo attackInfo){
		attackInfo.Target.SendMessage ("ApplyDamage", attackInfo.AttackDamage, SendMessageOptions.DontRequireReceiver);
		animation.Play ("Attack", PlayMode.StopAll);
		giantSound.Play ();
	}
}
