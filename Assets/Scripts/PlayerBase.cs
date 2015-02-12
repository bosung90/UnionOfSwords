using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour {

	public int Health = 1000;
	public int MaxHealth = 1000;
	public PlayerNum player; //Do we need this since we use tag ?
	public enum PlayerNum{PlayerOne, PlayerTwo};//Name Must match with Tags

	// Use this for initialization
	void Start () {
		if (this.gameObject.tag == "Player1Base")
			this.renderer.material.color = Color.red;
		else if(this.gameObject.tag == "Player2Base")
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
}
