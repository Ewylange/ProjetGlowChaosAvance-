using UnityEngine;
using System.Collections;

public class IA_Carre : MonoBehaviour {

	 State _state;
	float _speedIACarre;
	Vector3 direction;
	public bool _canChangeState = false;
	public float _timerChangeState;

	enum State : int {
		CALME,
		EXCITE
	}
	// Use this for initialization
	void Start () {

		_state = State.CALME;
		//direction = Random.insideUnitCircle * Time.deltaTime;
		_speedIACarre = 100;//Random.Range(10,20);

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (_state);

		switch(_state){

		case State.CALME :

			// Vitesse de l'objet 
			//_speedIACarre = Random.Range(50,60);

			// Déplacement Aléa
			//direction = Random.insideUnitCircle * Time.deltaTime * _speedIACarre;
			//transform.Translate (direction);
			// Couleur de l'objet
			GetComponent<Renderer>().material.color = Color.white; 

			break;

		case State.EXCITE :

			// Déplacement en state EXCITE
			direction = Random.insideUnitCircle * Time.deltaTime * _speedIACarre;
			transform.Translate (direction);

			//Couleur de l'objet 
			Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
			GetComponent<Renderer>().material.color = newColor;

			//Timer pour changer de state qd collision avec joueur 
			_timerChangeState += Time.deltaTime;

			if(_timerChangeState >= 2){

				_canChangeState = true;
				_timerChangeState = 0;
			}
			//	
			break;
		}
	}

	void OnTriggerEnter2D (Collider2D colEnter) {

		// SI collision avec le joueur on regarde dans quel état se trouve le carré et on l'inverse 
		if(colEnter.gameObject.tag ==("Player")){

			if(_state == State.CALME){

				_state = State.EXCITE;
			}

		
			if(_state == State.EXCITE && _canChangeState == true){

				_canChangeState = false;
				_state = State.CALME;
			}
		}
	
	}
}