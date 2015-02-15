using UnityEngine;
using System.Collections;

public class ThunderScript : MonoBehaviour {

	AudioSource[] thunderSounds;
	int randomNumber;
	// Use this for initialization
	void Start () {
		thunderSounds = this.GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ThunderOn(){
		particleSystem.Play (true);
		randomNumber = Mathf.Abs (Random.Range (1, 1000));
		if(randomNumber % 2 == 0){
			thunderSounds[0].Play ();
		}
		else{
			thunderSounds[1].Play();
		}

}
}