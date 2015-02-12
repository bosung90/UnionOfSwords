using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour {

	public int Health = 100;
	public int MaxHealth = 100;
	public PlayerBase.PlayerNum player;

	// Use this for initialization
	void Start () {
	
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
}
