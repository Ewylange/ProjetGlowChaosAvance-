using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NbreCellule : MonoBehaviour {

	// Calcule le pourcentage des cellules contaminées 
	// Et affiche le résultat dans la scène ( pas encore OP )
	// changement de l'environnement
	 public int _nbreCellule;
	public GameObject _celluleObj;

	public int _nbreCelluleContamin ;

	public float pourcentage;

	public int _nbrePopCellule;

	Text text;

	public bool _instantiate;
	public bool _palierSain;
	public bool _palier35;
	public bool _palier50;


	void Awake () {

		text= GetComponent<Text>();

		//text.text = pourcentage + " % ";
	}
	// Use this for initialization


	void Start () {

		_nbreCellule = 2;
		_nbreCelluleContamin = 1;
		_instantiate = true;
		_nbrePopCellule = 50;
		_palier35 = false;

		//_celluleObj = GameObject.FindGameObjectWithTag("Cellule");
	
	}
	
	// Update is called once per frame
	void Update () {

		if(_nbreCellule >= _nbrePopCellule){
			_instantiate = false;
		}



			pourcentage = _nbreCelluleContamin * 100 /_nbreCellule;

		//text.text = "Score : " + pourcentage;

		if(pourcentage <= 35){
			_palierSain = true;
			_palier35 = false;
			_palier50 = false;
		}

		if(pourcentage >= 35 ){
			Debug.Log("35%");
			_palierSain = false;
			_palier35 = true;
			_palier50 = false;
		}

		if(pourcentage >= 50){
			Debug.Log("50%");
			_palierSain = false;
			_palier35 = true;
			_palier50 = true;

		}

	}
}
