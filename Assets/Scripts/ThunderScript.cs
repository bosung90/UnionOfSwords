using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThunderScript : MonoBehaviour {

	private float thunderTicker = 0;
	public float ThunderTimer = 240;

	public PlayerBase.PlayerNum player;
	private PlayerBase.PlayerNum enemyTag;
	GameObject[] targetEnemies;

	AudioSource[] thunderSounds;
	int randomNumber;

	public GameObject ThunderParticle;

	public Image SpawnLoadImageUI;
	public Color32 StartC, MiddleC, EndC;

	// Use this for initialization
	void Start () {
		thunderTicker = ThunderTimer;
		thunderSounds = this.GetComponents<AudioSource> ();

		if(player == PlayerBase.PlayerNum.PlayerOne)
		{
			enemyTag = PlayerBase.PlayerNum.PlayerTwo;
		}
		else
			enemyTag = PlayerBase.PlayerNum.PlayerOne;
	}
	
	// Update is called once per frame
	void Update () {
		thunderTicker += Time.deltaTime;
		if(thunderTicker >= ThunderTimer)
		{
			thunderTicker = 0;
			ThunderOn();
		}
		SpawnLoadImageUI.fillAmount = thunderTicker / ThunderTimer;
		if(SpawnLoadImageUI.fillAmount < .5f)
		{
			SpawnLoadImageUI.color = Color.Lerp(StartC, MiddleC, SpawnLoadImageUI.fillAmount * 2);
		}
		else
		{
			SpawnLoadImageUI.color = Color.Lerp(MiddleC, EndC, ((SpawnLoadImageUI.fillAmount - 0.5f) * 2));
		}
	}

	void ThunderOn()
	{
		//particleSystem.Play (true);
		randomNumber = Mathf.Abs (Random.Range (1, 1000));
		if(randomNumber % 2 == 0){
			thunderSounds[0].Play ();
		}
		else{
			thunderSounds[1].Play();
		}
		GameObject[] enemies = FindAllEnemies ();
		foreach(GameObject enemy in enemies)
		{
			enemy.SendMessage("ApplyDamage", 60f, SendMessageOptions.DontRequireReceiver);
			GameObject thunder = Instantiate(ThunderParticle) as GameObject;
			thunder.transform.position = enemy.transform.position;
			thunder.particleSystem.Play(true);
			Destroy(thunder, 3f);
		}
	}

	private GameObject[] FindAllEnemies()
	{
		return GameObject.FindGameObjectsWithTag(enemyTag.ToString());
	}
}