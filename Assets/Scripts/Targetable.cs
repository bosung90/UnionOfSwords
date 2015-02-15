using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour {

	public int Health = 100;
	public int MaxHealth = 100;
	public PlayerBase.PlayerNum player;
	public PlayerBase.UnitType type;

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
			animation.Play("Dead", PlayMode.StopAll);
			Destroy (this.gameObject, 1f);
			collider.enabled = false;
			getResource();
			return;
		}
		animation.Play("Damage", PlayMode.StopAll);
	}

	public void ApplyPercentDamage (float d)
	{
		Health -= (int) (MaxHealth * d);
		if(Health <=0)
		{
			animation.Play("Dead", PlayMode.StopAll);
			Destroy (this.gameObject, 1f);
			collider.enabled = false;
			getResource();
			return;
		}
		animation.Play("Damage", PlayMode.StopAll);
	}

	public void getResource() {
		if(player == PlayerBase.PlayerNum.PlayerTwo) 
		{
			if(type == PlayerBase.UnitType.Footman)
				Resource_P1.currentResource += 7;
			else if(type == PlayerBase.UnitType.Ranger)
				Resource_P1.currentResource += 9;
			else if(type == PlayerBase.UnitType.Arcane_Magician)
				Resource_P1.currentResource += 21;
			else if(type == PlayerBase.UnitType.Mountain_Giant)
				Resource_P1.currentResource += 35;
			else if(type == PlayerBase.UnitType.Dragon_Rider)
				Resource_P1.currentResource += 84;
			else if(type == PlayerBase.UnitType.Warlock)
				Resource_P1.currentResource += 56;
			else if(type == PlayerBase.UnitType.Turret)
				Resource_P1.currentResource += 100;
		}
		else if(player == PlayerBase.PlayerNum.PlayerOne)
		{
			if(type == PlayerBase.UnitType.Footman)
				Resource_P2.currentResource += 7;
			else if(type == PlayerBase.UnitType.Ranger)
				Resource_P2.currentResource += 9;
			else if(type == PlayerBase.UnitType.Arcane_Magician)
				Resource_P2.currentResource += 21;
			else if(type == PlayerBase.UnitType.Mountain_Giant)
				Resource_P2.currentResource += 35;
			else if(type == PlayerBase.UnitType.Dragon_Rider)
				Resource_P2.currentResource += 84;
			else if(type == PlayerBase.UnitType.Warlock)
				Resource_P2.currentResource += 56;
			else if(type == PlayerBase.UnitType.Turret)
				Resource_P2.currentResource += 100;
		}
	}

}
