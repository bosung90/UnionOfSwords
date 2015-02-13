using UnityEngine;
using System.Collections;

public class AlwaysFaceCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.LookAt (Camera.main.transform);
		transform.RotateAround (transform.position, transform.up, 180f);
	}
}
