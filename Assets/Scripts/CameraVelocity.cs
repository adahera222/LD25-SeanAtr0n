using UnityEngine;
using System.Collections;

public class CameraVelocity : MonoBehaviour {
	
	float velocity;
	Vector3 prevPos;
	float prevVelocity;
	float fovBase;
	float accel;
	
	public float rangeFactor = 10;
	public UILabel measure;
	
	// Use this for initialization
	void Start () {
		prevPos = transform.position;
		fovBase = GetComponent<Camera>().fov;
	}
	
	// Update is called once per frame
	void Update () {
		prevVelocity = velocity;
		velocity = Vector3.Distance(transform.position,prevPos) / Time.deltaTime;
		prevPos = transform.position;
		
		accel = (velocity - prevVelocity)/Time.deltaTime;
		
		measure.text = accel.ToString("F2");

		if(accel > 50) {		
			float rrange = velocity/rangeFactor;
			GetComponent<Camera>().fov = fovBase + Mathf.Sin(Time.time * rangeFactor)/2;  // + Random.Range(rangeFactor,rangeFactor);
		}
	}
}
