using UnityEngine;
using System.Collections;

public class PopIA : MonoBehaviour {

	// Gère le pop des cellules 

	public Transform IA;
	public GameObject _compteurCellule;
	public Vector3 _positionAlea;
	public Vector3 _rotationAlea;

	NbreCellule my_nbCellule;

	// Use this for initialization
	void Start () {

		my_nbCellule = _compteurCellule.GetComponent<NbreCellule>();
	}
	
	// Update is called once per frame
	void Update () {
		// dans script Nbre de cellule, on peut choisir le nbre de cellule qui pop avant de passer le bool false
		// ce qui stop le pop de cellule
		if(my_nbCellule._instantiate == true){
			IAPop();
		}
	}

	void IAPop () {



		_positionAlea = new Vector3 (Random.Range (-380, 350), Random.Range (-180, 380),0);
		Transform newGameObject = Instantiate (IA) as Transform;
			newGameObject.transform.position = _positionAlea;
		

	}
}
