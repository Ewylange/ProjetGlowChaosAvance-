using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float _playerSpeed;
	float _rotationSpeed = 4;
	float _moveSpeed = 3;
	float _angle, _angleTarget = 0;

	float _speedDeplacement  ;
	//Vector3 _move;
	//Rigidbody2D rigid;
	////public Vector3 eulerAngleVelocity;
	float _debug_rotationSpeed = 200;
	Transform _transform;

	public Vector2 L_STICK {
		get {
			return new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
		}
		
	}

	public Vector2 R_STICK {
		get {
			return new Vector2(Input.GetAxis("360_R_Stick_Horizontal"),Input.GetAxis("360_R_Stick_Vertical"));
		}
	}


	// Walk state movespeed
	public float _walkSpeed = 1000;
	
	// Walk acceleration
	public float _acceleration = 2f;
	
	// Walk momentum conservation
	public float _inertia = 0.1f;
	
	// Curent walk velocity
	[HideInInspector] public Vector2 _velocityInput = Vector3.zero;
	// Use this for initialization


	void Start () {
		_angle = 0;
		_transform = this.gameObject.transform;
		//rigid = GetComponent<Rigidbody2D> ();
		_playerSpeed = 40;
	}
	
	// Update is called once per frame
	void Update () {
	
		Movement ();

		Rotation ();

	}

	void Movement () {



		/*if(Input.GetAxis("Vertical")){

			transform.Translate (Vector3.forward *Time.deltaTime * _playerSpeed );
		}*/
		transform.Translate(Vector3.right * Time.deltaTime * _playerSpeed * L_STICK.y, Space.Self );


	}

	void Rotation () {
		if (R_STICK.x != 0.0f || R_STICK.y != 0.0f) {
			_angleTarget = Mathf.Atan2(R_STICK.x, R_STICK.y) * Mathf.Rad2Deg;
//			Debug.Log (R_STICK);
			_angle = Mathf.Lerp (_angle, _angleTarget, Time.deltaTime * 100);
			transform.eulerAngles = new Vector3(0f, 0f, _angleTarget);
//	//		Quaternion newRotation = _transform.localRotation;
//	//		newRotation *= Quaternion.AngleAxis(Time.deltaTime * R_STICK.x * _debug_rotationSpeed, Vector3.forward);
//	//		_transform.localRotation = newRotation;
//			/*if(R_STICK == Vector2.zero) {
//				transform.Rotate(0,0,90);
//			}*/
//
////			if(R_STICK == new Vector2(0,1)){
////				transform.Rotate(0,0,-90);
////			}
////
//		}


	}
	}
}

