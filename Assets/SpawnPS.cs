using UnityEngine;
using System.Collections;

public class SpawnPS : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		InvokeRepeating ("SpawnParticleSystem", 0, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnParticleSystem()
	{
		particleSystem.Play (true);
	}
}
