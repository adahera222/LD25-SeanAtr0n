using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public static new Checkpoint last;
	
	public int setTutStep = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnTriggerEnter(Collider other) {
		last = this;
		if(	TutorialText.active.step < setTutStep ) {
			TutorialText.active.NextStep();
		}
	}
	
	public void OnCollisionEnter(Collision other) {
		last = this;
		if(	TutorialText.active.step < setTutStep ) {
			TutorialText.active.NextStep();
		}
	}
	
}
