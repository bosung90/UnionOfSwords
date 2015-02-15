using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour {

	public int Health = 100;
	public int MaxHealth = 100;
	public PlayerBase.PlayerNum player;

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
			return;
		}
		if(animation!=null)
			animation.Play("Damage", PlayMode.StopAll);
	}
}
