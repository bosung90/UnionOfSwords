using UnityEngine;
using System.Collections;

public class DragonScript : MonoBehaviour {

	AudioSource roar;
	// Use this for initialization
	void Start () {
		roar = this.GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DragonAppear(){
		particleSystem.Play (true);
		roar.Play ();
	}
}
