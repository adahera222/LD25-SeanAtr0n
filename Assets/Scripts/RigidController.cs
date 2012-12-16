using UnityEngine;
using System.Collections;

public class RigidController : MonoBehaviour {
		
	public static new RigidController active;
	
	public float speed;
	public float jumpForce;
	
	public float stepForce;
	
	public float dodgeForce;
	public float dodgeFreq = 1f;
	private float dodgeCounter = 0f;
	
	public float impulseFreq = 0.5f;
	private float counter = 0f;
	
	
	public GameObject field;
	
	public bool grounded = false;
	
	private Vector3 myUp;
	
	
	public float stamina = 400;
	public float breath = 400;
	
	float lastStrafe = 0f;
	float lastStrafeSign = 0f;
	float doubleTapSpeed = 0.5f;
	
	bool strafing = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake() {
		//GetComponent<StaminaMeter>().Init();
		active = this;
		
	}
	
	void FixedUpdate() {
		if(rigidbody.velocity.y == 0f) grounded = true; //meh 
		
		float forward = Input.GetAxis("Vertical");
		float sideways = Input.GetAxisRaw("Horizontal");
		
//		if(Input.GetKeyDown("Right")) {
//			if((Time.time - lastStrafe) > doubleTapSpeed) {
//				Debug.Log("strafe");
//			}
//		}
		
		if(sideways != 0f) {
			if(!strafing) {
				if( lastStrafeSign == Mathf.Sign(sideways)  &&  (Time.time - lastStrafe) < doubleTapSpeed) {
					if(breath > 200) {
						rigidbody.AddForce((transform.right *  Mathf.Sign(sideways) + transform.up * stepForce) * dodgeForce, ForceMode.Impulse);
//						dodgeCounter = 0f;
						breath -= 200;
						stamina -= 1;
					} else {
						//play failure sound
					}
				}
				strafing = true;
				lastStrafe = Time.time;
				lastStrafeSign = Mathf.Sign(sideways);
			}
		} else {
			strafing = false;
		}
		
		
		counter += Time.deltaTime;
		if(counter > impulseFreq && (sideways != 0f || forward != 0f)) {
			rigidbody.AddForce((transform.forward * forward + transform.right * sideways + myUp * stepForce) * speed , ForceMode.Impulse);
			
			
			counter = 0f;
		}
		
//		dodgeCounter += Time.deltaTime;
		
		if (breath < stamina)
			breath += 1;
		
//		if(sideways != 0f && dodgeCounter > dodgeFreq) {
//			rigidbody.AddForce((transform.right *  Mathf.Sign(sideways) + myUp * stepForce) * dodgeForce, ForceMode.Impulse);
//			dodgeCounter = 0f;
//			breath -= 200;
//			stamina -= 1;
//		}
		
		
		
		if(Input.GetButtonDown("Jump") && grounded) {
			rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
		}
		
		
		
	}
	
	void OnCollisionEnter( Collision collision) {
		if (collision.gameObject == field) {
			grounded = true;
			myUp = transform.up;
		}
	}
	
	void OnCollisionExit( Collision collision) {
		if (collision.gameObject == field) {
			grounded = false;
			myUp = Vector3.zero;
		}
	}
	
	
}
