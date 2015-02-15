using UnityEngine;
using System.Collections;

public class Attack_Tower : MonoBehaviour {

	public GameObject arcane;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AttackAnimate(AttackInfo _attackInfo){
		GameObject _arrow = Instantiate(arcane) as GameObject;
		_arrow.transform.position = transform.position;
		Arcane a = _arrow.GetComponent<Arcane>();
		a.enemy = _attackInfo.Target;
		Vector3 _pos = new Vector3 (this.transform.position.x, this.transform.position.y + 25f, this.transform.position.z);
		a.originalPos = _pos;
		a.finalPos = _attackInfo.Target.transform.position;
		a.attackDamage = _attackInfo.AttackDamage;
	}
}




