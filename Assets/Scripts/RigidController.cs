using UnityEngine;
using System.Collections;

public class RigidController : MonoBehaviour {
	
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
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		float forward = Input.GetAxis("Vertical") * speed;
		float sideways = Input.GetAxisRaw("Horizontal");
		
		counter += Time.deltaTime;
		if(counter > impulseFreq) {
			rigidbody.AddForce((transform.forward + myUp * stepForce) * forward , ForceMode.Impulse);
			
			
			counter = 0f;
		}
		
		dodgeCounter += Time.deltaTime;
		
		if (breath < stamina)
			breath += 1;
		
		if(sideways != 0f && dodgeCounter > dodgeFreq) {
			rigidbody.AddForce((transform.right *  Mathf.Sign(sideways) + myUp * stepForce) * dodgeForce, ForceMode.Impulse);
			dodgeCounter = 0f;
			breath -= 200;
			stamina -= 1;
		}
		
		
		
		if(Input.GetButtonDown("Jump")) {
			rigidbody.AddForce(myUp * jumpForce, ForceMode.Impulse);
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
