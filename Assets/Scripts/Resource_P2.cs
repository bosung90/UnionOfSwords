using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resource_P2 : MonoBehaviour {

	Text resource;
	public static int currentResource;

	// Use this for initialization
	void Start () {
		resource = GetComponent<Text> ();
		currentResource = 20;
		resource.text = "Resource : " + currentResource;
	}
	
	// Update is called once per frame
	void Update () {
		resource.text = "Resource : " + currentResource;
	
	}
}
