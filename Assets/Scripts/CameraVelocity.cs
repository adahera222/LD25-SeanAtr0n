using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CameraVelocity : MonoBehaviour {
	
	float velocity;
	public float accel;
	
	public float rangeFactor = 10;
	public UILabel measure;
	
	private Vignetting vig;
	private CharacterMotor motor;
	private GameObject motorParent;
	
	private Queue<float> avg;
	private float accum = 0f;
	public int smoothing = 10;
	
	// Use this for initialization
	void Start () {
		avg = new Queue<float>();
		for(int i = 0; i < smoothing; i++) avg.Enqueue(0f);
	}
	
	void Awake() {
		vig = GetComponent<Vignetting>();
		motorParent = transform.parent.gameObject;
		motor = transform.parent.GetComponent<CharacterMotor>();

	}
	
	// Update is called once per frame
	void Update () {
//		prevVelocity = velocity;
//		velocity = Vector3.Distance(transform.position,prevPos) / Time.deltaTime;
//		prevPos = transform.position;
		
		//accel = (velocity - prevVelocity)/Time.deltaTime;
		
		if(measure != null)
			measure.text = accum.ToString("F2");
		
//		if(motorParent.activeSelf) {
//			velocity = motor.movement.velocity.magnitude;
//		} else {
			velocity = transform.parent.gameObject.rigidbody.velocity.magnitude;
//		}
		accum += velocity;
		avg.Enqueue(velocity);
		accum -= avg.Dequeue();
		
		if(velocity > 50) {		
			//float rrange = velocity/rangeFactor;
			//GetComponent<Camera>().fov = fovBase + Mathf.Sin(Time.time * rangeFactor)/2;  // + Random.Range(rangeFactor,rangeFactor);
//			GetComponent<MotionBlur>().blurAmount = 0.8f;
			
		} else {
//			GetComponent<MotionBlur>().blurAmount = 0.0f;
//			vig.chromaticAberration = 0f;
		}
		
		vig.blur = Random.Range(0f, Mathf.Clamp((accum/smoothing - 50)/rangeFactor, 0f, 10f));
		vig.chromaticAberration = Mathf.Clamp((accum/smoothing - 50)/rangeFactor, 0f, 20f);


	}
}
