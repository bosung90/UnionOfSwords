using UnityEngine;
using System.Collections;

public class MoveTowardsBase : MonoBehaviour 
{
	private GameObject enemyBase;
	private string enemyTag;
	[Range(0.1f,10f)]
	public float speed = 2;
	[Range(0.5f, 30f)]
	public float AttackRange = 2;

	// Use this for initialization
	void Start () 
	{
		enemyTag = (this.gameObject.tag == PlayerBase.PlayerNum.PlayerOne.ToString ()) ? PlayerBase.PlayerNum.PlayerTwo.ToString () : PlayerBase.PlayerNum.PlayerOne.ToString ();

		if(this.gameObject.tag == PlayerBase.PlayerNum.PlayerOne.ToString())
		{
			//find playerTwo Base
			enemyBase = GameObject.FindGameObjectWithTag("Player2Base");
		}
		else if(this.gameObject.tag == PlayerBase.PlayerNum.PlayerTwo.ToString())
		{
			//find playerOne Base
			enemyBase = GameObject.FindGameObjectWithTag("Player1Base");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if there's any targetable object in range, stop and call attack method
		Collider target = GetClosestTargetable ();
		if(target != null)
		{
			//call attack(target)		
			Debug.Log("Attack");
		}
		// move towards enemy base
		else 
		{
			Debug.Log("Moving");
		    Vector3 currentPos = transform.position;
			Vector3 castlePos = enemyBase.transform.position;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (currentPos, castlePos, step);
		}
	}

	private Collider GetClosestTargetable()
	{
		float smallestDistance = float.MaxValue;
		Collider closestTarget = null;
		Collider[] cols = Physics.OverlapSphere(transform.position, AttackRange);
		foreach (Collider col in cols)
		{
			if (col && ( col.tag == enemyTag || col.tag == enemyBase.tag))
			{ 
				float distance = Vector3.Distance(transform.position, col.transform.position);
				if(distance<smallestDistance)
				{
					smallestDistance = distance;
					closestTarget = col;					
				}
			}	
		}
		return closestTarget;
	}
}

