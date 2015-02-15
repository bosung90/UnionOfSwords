using UnityEngine;
using System.Collections;

public class Attack_Warlock : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
//		if(!animation.isPlaying)
//			animation.Play("001-01_idle01",  PlayMode.StopAll);	
	}

	void AttackAnimate(AttackInfo attackInfo){
		attackInfo.Target.SendMessage ("ApplyDamage", attackInfo.AttackDamage, SendMessageOptions.DontRequireReceiver);
	}

	void WalkAnimate(){
//		animation.Play ("002_walk01", PlayMode.StopAll);
	}
}
