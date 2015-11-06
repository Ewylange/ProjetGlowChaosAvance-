using UnityEngine;
using System.Collections;

public class XboxControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButton("360_AButton")){

			Debug.Log("Button A works");
		}
	}
}
