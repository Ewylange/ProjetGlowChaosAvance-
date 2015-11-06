using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {
	// Gère le changement de phase des cellules ( bleu -> vert )
	// Changement qd trigger avec le joueur 
	public float _timer;
	public bool _activeTimer;
	public Sprite _cellule;
	public Sprite _celluleContamin ;

	public int celluleContamin;
	 
	public GameObject _compteurCellule;
	NbreCellule nbCellule;

	public bool contamin;
	MoveCellule _scriptMoveCellule;

	bool _excited;
	// Use this for initialization
	void Start () {

		GetComponent<SpriteRenderer>().sprite = _cellule;
		_scriptMoveCellule = GetComponent<MoveCellule>();
		nbCellule = _compteurCellule.GetComponent<NbreCellule>();
		nbCellule._nbreCellule +=1;
		contamin = false;
		_excited = false;
	}
	
	// Update is called once per frame
	void Update () {

		_scriptMoveCellule.speed = Random.Range(50,60);
		// on active le timer qd le player rentre ds le trigger de la cellule
		if (_activeTimer == true){

			_timer += Time.deltaTime;
		}

		// moment où la cellule devient verte 
		if(_timer>= 0.2f && contamin == false){


			GetComponent<Renderer>().material.color = Color.red;
			// change color



			contamin = true;
			CelluleContamin ();

			_timer =0;

		}
		if(GetComponent<Renderer>().material.color == Color.red){
			_scriptMoveCellule.speed = Random.Range(100,120);
			_excited = true;
			 
		}
		if(_excited == true){
			Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
			GetComponent<Renderer>().material.color = newColor; 
			transform.Rotate( new Vector3(90,0,90));

		}

		if(_activeTimer == false){

			_timer = 0;
		}
	}

	/*void OnCollision2D(Collision2D col){

		//Debug.Log ("Collision");

		//if(col.gameObject.tag("Player")){

			Debug.Log ("collisionPlayer");
			_activeTimer = true;
		/*else {
			_activeTimer = false;
		 }
		//}
	}*/


	void OnTriggerEnter2D (Collider2D colEnter) {

		if(colEnter.gameObject.tag ==("Player")){
			_activeTimer = true;
			Debug.Log("TriggerEnterPlayer");
		}
	}

		void OnTriggerExit2D (Collider2D colExit) {
		if(colExit.gameObject.tag ==("Player")){
			_activeTimer = false;
			Debug.Log ("TriggerExit");
		}
	}



	void CelluleContamin (){
		nbCellule._nbreCelluleContamin +=1;

	}
}
