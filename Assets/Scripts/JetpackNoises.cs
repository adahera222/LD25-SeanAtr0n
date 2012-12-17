using UnityEngine;
using System.Collections;

public class JetpackNoises : MonoBehaviour {
	
	public AudioClip startup;
	bool warm = false;
	public AudioClip coast;
	
	AudioSource jetpack;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void Awake() {
		jetpack = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rigidbody.velocity.magnitude > 50) {
			if(!jetpack.isPlaying){
				if(warm) {
					jetpack.loop = true;
					jetpack.PlayOneShot(coast);
				} else {
					jetpack.loop = false;
					jetpack.PlayOneShot(startup);
					warm = true;
				}
			}
		} else {
			warm = false;
		}
	}
	
	
}
