using UnityEngine;
using System.Collections;

public class SendToCheckpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnCollisionEnter(Collision other) {
		other.gameObject.rigidbody.velocity = Vector3.zero;
		other.gameObject.transform.position = Checkpoint.last.transform.position;
		
		//TODO play error noise
	}
}
