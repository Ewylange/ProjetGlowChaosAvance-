using UnityEngine;
using System.Collections;

public class IA_ROND1 : MonoBehaviour {

	float _speedIARond;
	State _state;
	 
	public Transform _player;
	public float _distanceToPlayer;

	public bool _canChangeState = false;
	public float _timerChangeState;

	enum State : int {
		CALME,
		FUITE,
		EXCITE
	}
	// Use this for initialization
	void Start () {
		
		_state = State.CALME;
		//direction = Random.insideUnitCircle * Time.deltaTime;
		_speedIARond = 5;//Random.Range(10,20);
		
	}
	
	// Update is called once per frame
	void Update () {


		Debug.Log (_state);

		_distanceToPlayer = Vector3.Distance( transform.position , _player.transform.position);

		switch(_state){
			
		case State.CALME :
			
			// Vitesse de l'objet 
			//_speedIACarre = Random.Range(50,60);
			
			// Déplacement Aléa
			//direction = Random.insideUnitCircle * Time.deltaTime * _speedIARond;
			//transform.Translate (direction);
			// Couleur de l'objet
			GetComponent<Renderer>().material.color = Color.white; 
			if(_distanceToPlayer <= 20){
				_state = State.FUITE;
			}

			break;

		case State.FUITE :

			Vector3 dir = _player.position - transform.position;
			transform.position -= dir.normalized * _speedIARond;
			/*if(_distanceToPlayer <= 100){
				_state = State.CALME;
			}*/
			break;
			
		case State.EXCITE :
			
			//Couleur de l'objet 
			//Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
			GetComponent<Renderer>().material.color = Color.magenta;

			//Timer pour changer de state qd collision avec joueur 
			_timerChangeState += Time.deltaTime;
			
			if(_timerChangeState >= 2f){
				
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
