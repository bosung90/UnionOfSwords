using UnityEngine;
using System.Collections;

public class Arcane : MonoBehaviour {

	[HideInInspector]
	public GameObject enemy;
	public Vector3 originalPos;
	public Vector3 finalPos;

	public int attackDamage;

	public float delayTime;

	// Use this for initialization
	void Start () {
		delayTime = 0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		delayTime += Time.deltaTime;
		if(enemy != null)
		{
			finalPos = enemy.transform.position;
		}

		if (delayTime > 1f) 
		{
			
			enemy.SendMessage ("ApplyDamage", attackDamage, SendMessageOptions.DontRequireReceiver);
			Destroy (this.gameObject);
		}

		Vector3 _position = Vector3.Lerp (originalPos, finalPos, delayTime);

		transform.position = _position;
		

	
	}

	Vector3 ArcaneInterpolation (Vector3 s, Vector3 d, float t) {
		float x = s.x + (d.x - s.x) * t;
		float y = s.y + (d.y - s.y) * t;
		float z = s.z + (d.z - s.z) * t;


		return new Vector3 (x, y, z);
	}
}
