using UnityEngine;
using System.Collections;

public class RangerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!animation.isPlaying)
			animation.Play("001-01_idle01",  PlayMode.StopAll);
	
	}

	void WalkAnimate(){
		animation.Play("002_walk01",PlayMode.StopAll);
		}
}
