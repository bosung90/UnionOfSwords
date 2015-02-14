using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour {

	public int Health = 100;
	public int MaxHealth = 100;
	public PlayerBase.PlayerNum player;

	// Use this for initialization
	void Start () {
		if (player == PlayerBase.PlayerNum.PlayerOne)
			this.renderer.material.color = Color.red;
		else if(player == PlayerBase.PlayerNum.PlayerTwo)
			this.renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ApplyDamage (int d)
	{
		Health -= d;
		if(Health <=0)
		{
			Destroy (this.gameObject);
		}
	}

	public void ApplyPercentDamage (float d)
	{
		Health -= (int) (MaxHealth * d);
		if (Health <= 0) 
		{
			Destroy (this.gameObject);
		}
	}
}
