using UnityEngine;
using System.Collections;

public class MoveCellule : MonoBehaviour {

	// Gère le déplacement des cellules 
	// Et qu'elle ne sorte pas du cadre
	public int state =  0;
	float chrono1;
	float chrono2;
	float timerMin1 = 0;
	float timerMax1 = 1;
	float timerMin2 = 0;
	float timerMax2 = 1;
	float stopChrono1;
	float stopChrono2;
	Vector3 direction;
	
	public float speed;
	
	// Use this for initialization
	void Start () {
		
		direction = Random.insideUnitCircle * Time.deltaTime;
		speed = Random.Range(10,20);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.rotation = Quaternion.identity;
		
		if (state == 0) {
			chrono1 += Time.deltaTime;
			
			
			if ( chrono1 >= stopChrono1){
				state = 1;
				chrono1 = 0;
				
			}
			if (chrono1<= 0){
				stopChrono1 = Random.Range( timerMin1, timerMax1);
			}
			
			
			
			
			
		} else if (state == 1) {
			
			transform.Translate (direction);
			
			chrono2 += Time.deltaTime;
			
			if(chrono2 >= stopChrono2){
				chrono2 = 0;
				state = 0;
				direction = Random.insideUnitCircle * Time.deltaTime * speed;

				//direction.normalized;
				
				

			}
			if (chrono2 <= 0){
				stopChrono2 = Random.Range( timerMin2, timerMax2);
			}
			
		}
		
		
	}
	
	void OnTriggerEnter2D (Collider2D coll) {
		
		//Debug.Log("TriggerBordButDontChangeDirection");
		if(coll.gameObject.tag== "Bord"){
			//Debug.Log("-direction");
			direction = - direction;
		}
		
		
	}
}
