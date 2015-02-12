using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour {

	public int Health = 1000;
	public int MaxHealth = 1000;
	public PlayerNum player;
	public enum PlayerNum{PlayerOne, PlayerTwo};//Name Must match with Tags

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
