using UnityEngine;
using System.Collections;

public class GoblinScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!animation.isPlaying)
			animation.Play("combat_idle",  PlayMode.StopAll);
	}

	void AttackAnimate(){

		animation.Play ("attack1", PlayMode.StopAll);
	}

	void WalkAnimate(){
		animation.Play ("walk", PlayMode.StopAll);
		}
	
}
