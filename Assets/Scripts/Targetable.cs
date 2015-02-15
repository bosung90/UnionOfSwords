using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour {

	public int Health = 100;
	public int MaxHealth = 100;
	public PlayerBase.PlayerNum player;
	public PlayerBase.UnitType type;
	[Range(1, 100)]
	public int Footman_Cost = 3;
	[Range(1, 100)]
	public int Ranger_Cost = 3;
	[Range(1, 100)]
	public int A_Magician_Cost = 3;
	[Range(1, 100)]
	public int M_Giant_Cost = 3;
	[Range(1, 100)]
	public int Dragon_Cost = 3;
	[Range(1, 100)]
	public int Warlock_Cost = 3;
	[Range(1, 200)]
	public int Tower_Cost = 3;



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

	public void ApplyDamage (int d)
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
			if(type == PlayerBase.UnitType.Footman)
				Resource.currentResource_P1 += Footman_Cost;
			else if(type == PlayerBase.UnitType.Ranger)
				Resource.currentResource_P1 += Ranger_Cost;
			else if(type == PlayerBase.UnitType.Arcane_Magician)
				Resource.currentResource_P1 += A_Magician_Cost;
			else if(type == PlayerBase.UnitType.Mountain_Giant)
				Resource.currentResource_P1 += M_Giant_Cost;
			else if(type == PlayerBase.UnitType.Dragon_Rider)
				Resource.currentResource_P1 += Dragon_Cost;
			else if(type == PlayerBase.UnitType.Warlock)
				Resource.currentResource_P1 += Warlock_Cost;
			else if(type == PlayerBase.UnitType.Turret)
				Resource.currentResource_P1 += Tower_Cost;
		}
		else if(player == PlayerBase.PlayerNum.PlayerOne)
		{
			if(type == PlayerBase.UnitType.Footman)
				Resource.currentResource_P2 += Footman_Cost;
			else if(type == PlayerBase.UnitType.Ranger)
				Resource.currentResource_P2 += Ranger_Cost;
			else if(type == PlayerBase.UnitType.Arcane_Magician)
				Resource.currentResource_P2 += A_Magician_Cost;
			else if(type == PlayerBase.UnitType.Mountain_Giant)
				Resource.currentResource_P2 += M_Giant_Cost;
			else if(type == PlayerBase.UnitType.Dragon_Rider)
				Resource.currentResource_P2 += Dragon_Cost;
			else if(type == PlayerBase.UnitType.Warlock)
				Resource.currentResource_P2 += Warlock_Cost;
			else if(type == PlayerBase.UnitType.Turret)
				Resource.currentResource_P2 += Tower_Cost;
		}
	}

}
