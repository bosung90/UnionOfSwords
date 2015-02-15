using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnArmy : MonoBehaviour{

	public GameObject Unit;
	[Range(0.01f, 30)]
	public float SpawnTimer = 3;

	public PlayerBase.PlayerNum player;

	public int Health = 100;
	public int MaxHealth = 100;

	[Range(0,100)]
	public int StatusCost = 1;

	public GameObject particleSystemSpawn;

	private float spawnTicker = 0;
	public Image SpawnLoadImageUI;
	public Color32 StartC, MiddleC, EndC;

	// Use this for initialization
	void Start () {
	}

	void Update()
	{
		spawnTicker += Time.deltaTime;
		if(spawnTicker >= SpawnTimer)
		{
			SpawnUnit();
			spawnTicker = 0;
		}
		SpawnLoadImageUI.fillAmount = spawnTicker / SpawnTimer;
		if(SpawnLoadImageUI.fillAmount < .5f)
		{
			SpawnLoadImageUI.color = Color.Lerp(StartC, MiddleC, SpawnLoadImageUI.fillAmount * 2);
		}
		else
		{
			SpawnLoadImageUI.color = Color.Lerp(MiddleC, EndC, ((SpawnLoadImageUI.fillAmount - 0.5f) * 2));
		}
	}

	private void SpawnUnit()
	{
		if(player == PlayerBase.PlayerNum.PlayerOne)
		{
			if(Resource.currentResource_P1 >= StatusCost)
			{
				SpwnUnit();
				Resource.currentResource_P1 -= StatusCost;
			}
		}
		else if(player == PlayerBase.PlayerNum.PlayerTwo)
		{
			if(Resource.currentResource_P2 >= StatusCost)
			{
				SpwnUnit();
				Resource.currentResource_P2 -= StatusCost;
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
		particleSystemSpawn.particleSystem.Play (true);
	}

}
