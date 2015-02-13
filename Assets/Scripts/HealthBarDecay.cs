using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarDecay : MonoBehaviour {

	Image healthDecayBar;

	[Range(0,1)]
	public float decaySpeed;

	public Targetable health;

	private float decayStartPos;
	private float decayEndPos;

	private float decayTimer = 0;

	// Use this for initialization
	void Start () {
		healthDecayBar = GetComponent<Image> ();
		decayStartPos = health.Health / (float)health.MaxHealth;
		decayEndPos = health.Health / (float)health.MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		float healthPercent = health.Health / (float)health.MaxHealth;
		//if health changes, set new starting and ending values for lerp
		if(decayEndPos != healthPercent)
		{
			decayTimer = 0;
			decayStartPos = healthDecayBar.fillAmount;
			decayEndPos = healthPercent;
		}
		
		decayTimer += Time.deltaTime;
		healthDecayBar.fillAmount = Mathf.Lerp (decayStartPos, decayEndPos, decayTimer * decaySpeed);
	}
}
