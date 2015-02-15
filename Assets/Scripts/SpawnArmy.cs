using UnityEngine;
using System.Collections;

public class SpawnArmy : MonoBehaviour{

	public GameObject Unit;
	[Range(0.01f, 30)]
	public float SpawnTimer = 3;

	public PlayerBase.PlayerNum player;
	public PlayerBase.UnitType type;

	public int Health = 100;
	public int MaxHealth = 100;

	[Range(0,15)]
	public int StatusCost = 1;



	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnUnit", 0, SpawnTimer);
	}

	private void SpawnUnit()
	{
		if(player == PlayerBase.PlayerNum.PlayerOne)
		{
			switch(type)
			{
			case PlayerBase.UnitType.Footman:
					if(Resource.currentResource_P1 >= 5) 
					{
						SpwnUnit();
					Resource.currentResource_P1 -= 5;
					}
				break;
			case PlayerBase.UnitType.Ranger:
					if(Resource.currentResource_P1 >= 6) 
					{
						SpwnUnit();
						Resource.currentResource_P1 -= 6;
					}
				break;
			case PlayerBase.UnitType.Arcane_Magician:
					if(Resource.currentResource_P1 >= 6) 
					{
						SpwnUnit();
						Resource.currentResource_P1 -= 6;
					}
				break;
			case PlayerBase.UnitType.Mountain_Giant:
					if(Resource.currentResource_P1 >= 25) 
					{
						SpwnUnit();
						Resource.currentResource_P1 -= 25;
					}
				break;
			case PlayerBase.UnitType.Dragon_Rider:
					if(Resource.currentResource_P1 >= 60) 
					{
						SpwnUnit();
						Resource.currentResource_P1 -= 60;
					}
				break;
			case PlayerBase.UnitType.Warlock:
					if(Resource.currentResource_P1 >= 40) 
					{
						SpwnUnit();
						Resource.currentResource_P1 -= 40;
					}
				break;

			}
		}else if(player == PlayerBase.PlayerNum.PlayerTwo)
		{
			switch(type)
			{
			case PlayerBase.UnitType.Footman:
				if(Resource.currentResource_P2 >= 5) 
				{
					SpwnUnit();
					Resource.currentResource_P2 -= 5;
				}
				break;
			case PlayerBase.UnitType.Ranger:
				if(Resource.currentResource_P2 >= 6) 
				{
					SpwnUnit();
					Resource.currentResource_P2 -= 6;
				}
				break;
			case PlayerBase.UnitType.Arcane_Magician:
				if(Resource.currentResource_P2 >= 6) 
				{
					SpwnUnit();
					Resource.currentResource_P2 -= 6;
				}
				break;
			case PlayerBase.UnitType.Mountain_Giant:
				if(Resource.currentResource_P2 >= 25) 
				{
					SpwnUnit();
					Resource.currentResource_P2 -= 25;
				}
				break;
			case PlayerBase.UnitType.Dragon_Rider:
				if(Resource.currentResource_P2 >= 60) 
				{
					SpwnUnit();
					Resource.currentResource_P2 -= 60;
				}
				break;
			case PlayerBase.UnitType.Warlock:
				if(Resource.currentResource_P2 >= 40) 
				{
					SpwnUnit();
					Resource.currentResource_P2 -= 40;
				}
				break;
				
			}
		}
	}

	private void SpwnUnit() {
		GameObject newUnit = Instantiate (Unit) as GameObject;
		//set newUnit's position to be at the SpawnCircle.
		newUnit.transform.position = this.transform.position;
		//set newUnit's tag to be same as spawnCircle tag string literal.
		newUnit.tag = this.player.ToString ();
		Targetable targetable = newUnit.GetComponent<Targetable> ();
		targetable.player = this.player;
	}

}
