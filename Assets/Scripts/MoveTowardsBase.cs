using UnityEngine;
using System.Collections;

public class MoveTowardsBase : MonoBehaviour {

	public GameObject castle;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = transform.position;
		Vector3 castlePos = castle.transform.position;
		float step = speed * Time.deltaTime;
		currentPos = Vector3.MoveTowards (currentPos, castlePos, step);
	}
}
