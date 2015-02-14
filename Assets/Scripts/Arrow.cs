using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	[HideInInspector]
	public GameObject enemy;
	public Vector3 originalPos;
	public Vector3 finalPos;
	public Vector3 startRot;
	public Vector3 endRot;
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

		if (delayTime > .5f) 
		{
			
			enemy.SendMessage ("ApplyDamage", attackDamage, SendMessageOptions.DontRequireReceiver);
			Destroy (this.gameObject);
		}
		Vector3 _rot;
		Vector3 _position = ArrowInterpolation (originalPos, finalPos, delayTime/.5f, out _rot);



		transform.position = _position;
		transform.localEulerAngles = _rot;

	
	}

	Vector3 ArrowInterpolation (Vector3 s, Vector3 d, float t, out Vector3 _rotation) {
		float x = s.x + (d.x - s.x) * t;
		float y = (s.y + (d.y - s.y) * t + Mathf.Sin (t * Mathf.PI)*15) / 2;
		float z = s.z + (d.z - s.z) * t;

		_rotation = Vector3.Lerp (startRot, endRot, t);

		return new Vector3 (x, y, z);
	}
}
