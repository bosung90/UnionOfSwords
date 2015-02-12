using UnityEngine;
using System.Collections;

public class SpawnArmy : MonoBehaviour{

	public GameObject Unit;
	[Range(0.01f, 30)]
	public float SpawnTimer = 3;

	public PlayerBase.PlayerNum player;

	public int Health = 100;
	public int MaxHealth = 100;

	[Range(0,15)]
	public int StatusCost = 1;

	private bool isAlive = true;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnUnit", 0, SpawnTimer);
	}

	private void SpawnUnit()
	{
		if(isAlive == false)
		{
			CancelInvoke();
			return;
		}

		GameObject newUnit = Instantiate (Unit) as GameObject;
		//set newUnit's position to be at the SpawnCircle.
		newUnit.transform.position = this.transform.position;
		//set newUnit's tag to be same as spawnCircle tag string literal.
		newUnit.tag = this.player.ToString ();
		if (this.player == PlayerBase.PlayerNum.PlayerOne)
			newUnit.renderer.material.color = Color.red;
		else
			newUnit.renderer.material.color = Color.blue;
	}

	public void ApplyDamage (int d)
	{
		Health -= d;
		if(Health <=0)
		{
			isAlive = false;
		}
	}
}
