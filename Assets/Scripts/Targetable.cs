using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour {

	public int Health = 100;
	public int MaxHealth = 100;
	public PlayerBase.PlayerNum player;
	public PlayerBase.UnitType type;
	[Range(0,100)]
	public int StatusCost = 1;

	// Use this for initialization
	void Start () {
		if (player == PlayerBase.PlayerNum.PlayerOne) 
		{
			foreach(Renderer r in this.GetComponents<Renderer>())
			{
				r.material.color = Color.red;
			}
		}
		else if(player == PlayerBase.PlayerNum.PlayerTwo)
		{
			foreach(Renderer r in this.GetComponents<Renderer>())
			{
				r.material.color = Color.blue;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ApplyDamage(float d)
	{
		if(type == PlayerBase.UnitType.Warlock)
			ApplyPercentDamage(d);
		else
			ApplyFlatDamage((int) d);
	}


	public void ApplyFlatDamage (int d)
	{
		Health -= d;
		if(Health <=0)
		{
			if(animation!=null)
				animation.Play("Dead", PlayMode.StopAll);
			Destroy (this.gameObject, 1f);
			collider.enabled = false;
			getResource();
			return;
		}
		if(animation!=null)
			animation.Play("Damage", PlayMode.StopAll);
	}

	public void ApplyPercentDamage (float d)
	{
		Health -= (int) (MaxHealth * d);
		if(Health <=0)
		{
			if(animation!=null)
				animation.Play("Dead", PlayMode.StopAll);
			Destroy (this.gameObject, 1f);
			collider.enabled = false;
			getResource();
			return;
		}
		if(animation!=null)
			animation.Play("Damage", PlayMode.StopAll);
	}

	public void getResource() {
		if(player == PlayerBase.PlayerNum.PlayerTwo) 
		{
			Resource.currentResource_P1 += StatusCost;
		}
		else if(player == PlayerBase.PlayerNum.PlayerOne)
		{
			Resource.currentResource_P2 += StatusCost;
		}
	}

}
