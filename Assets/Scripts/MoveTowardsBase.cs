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
		// if there's any targetable object in range, stop and call attack method
		Collider target = GetClosestTargetable ();
		if(target != null){
			//call attack(target)		
			Debug.Log("Attack");
	}
		// move towards enemy base
	else {
    Vector3 currentPos = transform.position;
	Vector3 castlePos = castle.transform.position;
	float step = speed * Time.deltaTime;
	transform.position = Vector3.MoveTowards (currentPos, castlePos, step);
	}
}

	
	Collider GetClosestTargetable(){
		float smallestDistance = float.MaxValue;
		Collider closestTarget = null;
			Collider[] cols = Physics.OverlapSphere(transform.position, .5f);
			foreach (Collider col in cols){
				if (col && col.tag == "Enemy"){ 
				float distance = Vector3.Distance(transform.position, col.transform.position);
				if(distance<smallestDistance){
					smallestDistance = distance;
					closestTarget = col;					
				}			
		}	
	}
			return closestTarget;
}
}

