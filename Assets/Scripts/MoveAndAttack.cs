using UnityEngine;
using System.Collections;

public class MoveAndAttack : MonoBehaviour 
{
	private GameObject enemyBase;
	private string enemyTag;
	private bool canAttack = true;
	
	public PlayerBase.AttackType attackType;
	
	[Range(0f,100f)]
	public float speed = 2;
	[Range(0.5f, 100f)]
	public float AttackRange = 2;
	[Range(0.01f, 5f)]
	public float AttackSpeed = 2;
	[Range(0, 200)]
	public float AttackDamage = 10f;
	
	//	private Animation animation;
	
	// Use this for initialization
	void Start () 
	{
		if(this.gameObject.tag == PlayerBase.PlayerNum.PlayerOne.ToString () || this.gameObject.tag == PlayerBase.PlayerNum.PlayerTwo.ToString ())
			enemyTag = (this.gameObject.tag == PlayerBase.PlayerNum.PlayerOne.ToString ()) ? PlayerBase.PlayerNum.PlayerTwo.ToString () : PlayerBase.PlayerNum.PlayerOne.ToString ();
		else
			enemyTag = (this.gameObject.tag == "Player1Base") ? PlayerBase.PlayerNum.PlayerTwo.ToString () : PlayerBase.PlayerNum.PlayerOne.ToString ();

		
		InvokeRepeating ("ResetAttack", 0, AttackSpeed);
	}
	
	private void ResetAttack()
	{
		canAttack = true;
	}
	
	// Update is called once per frame
	void Update () 
	{

						
		if(animation != null) {
			if(!animation.isPlaying) {
				this.BroadcastMessage("StartAnimation", SendMessageOptions.DontRequireReceiver);
			}
		}
		
		if(enemyBase == null)
		{
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
			if(enemyBase == null)
			{
				if(this.GetComponent<Targetable>().type != PlayerBase.UnitType.Turret)
					return;
			}
		}
		
		// if there's any targetable object in range, stop and call attack method
		Collider target = GetClosestTargetable ();
		if(target != null)
		{
			if(canAttack == true)
			{
				//call attack(target)		
				Debug.Log("Attack");
				//target.SendMessage("ApplyDamage", AttackDamage, SendMessageOptions.DontRequireReceiver);
				this.transform.LookAt(target.transform, Vector3.up);
				//this.BroadcastMessage("AttackAnimate", SendMessageOptions.DontRequireReceiver);
				this.BroadcastMessage("AttackAnimate", new AttackInfo(target.gameObject, AttackDamage), SendMessageOptions.DontRequireReceiver);
				canAttack = false;
			}
		}
		// move towards enemy base
		else 
		{ 
			if(this.GetComponent<Targetable>().type != PlayerBase.UnitType.Turret)
			{
				Vector3 currentPos = transform.position;
				Vector3 enemyBasePos = enemyBase.transform.position;
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards (currentPos, enemyBasePos, step);
				this.BroadcastMessage("WalkAnimate", SendMessageOptions.DontRequireReceiver);
				this.transform.LookAt(enemyBasePos, Vector3.up);
			}

		}
	}
	
	private Collider GetClosestTargetable()
	{
		float smallestDistance = float.MaxValue;
		Collider closestTarget = null;
		Collider[] cols = Physics.OverlapSphere(transform.position, AttackRange);
		if(enemyBase != null) 
		{
			foreach (Collider col in cols)
			{
				if (col && ( col.tag == enemyTag || col.tag == enemyBase.tag))
				{
					if(col.GetComponent<Targetable>().type == PlayerBase.UnitType.Dragon_Rider && attackType == PlayerBase.AttackType.Ground)
						continue;
					else
					{
						float distance = Vector3.Distance(transform.position, col.transform.position);
						if(distance<smallestDistance)
						{
							smallestDistance = distance;
							closestTarget = col;					
						}
					}
					
				}	
			}
		}else
		{
			foreach (Collider col in cols)
			{
				if (col && ( col.tag == enemyTag))
				{
					float distance = Vector3.Distance(transform.position, col.transform.position);
					if(distance<smallestDistance)
					{
						smallestDistance = distance;
						closestTarget = col;					
					}

					
				}	
			}
		}

		return closestTarget;
	}
}

