using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WhohasWon : MonoBehaviour {

	Text _winner;

	public static string winner = "";
	// Use this for initialization
	void Start () {
		_winner = GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		_winner.text = winner;
	
	}
}
