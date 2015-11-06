using UnityEngine;
using System.Collections;

public class MoveMac : MonoBehaviour {

	public float _playerSpeed = 35f;

	// Use this for initialization
	void Start () {
		_playerSpeed = 35f;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(-Vector2.right * Time.deltaTime * _playerSpeed);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(Vector2.right * Time.deltaTime * _playerSpeed);
		}

		if(Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(Vector2.up* Time.deltaTime * _playerSpeed);
		}

		if(Input.GetKey(KeyCode.DownArrow)){
			transform.Translate(-Vector2.up * Time.deltaTime * _playerSpeed);
		}
	
	}
}
