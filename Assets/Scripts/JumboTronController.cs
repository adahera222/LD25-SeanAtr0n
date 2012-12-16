using UnityEngine;
using System.Collections;

public class JumboTronController : MonoBehaviour {
	
	public Camera[] cameras;
	
	public float cameraSwitchTime = 10f;
	private float cameraSwitchCounter = 0f;
	
	int currentCamera = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cameraSwitchCounter += Time.deltaTime;
		if( cameraSwitchCounter > cameraSwitchTime) {
			cameraSwitchCounter = 0f;
			for(int i = currentCamera + 1; i != currentCamera; i++) {
				if(i >= cameras.Length)	i = 0;
				if(cameras[i].gameObject.activeSelf) {
					cameras[currentCamera].enabled = false;
					currentCamera = i;
					cameras[currentCamera].enabled = true;
					return;
				}
			}
		}
		
	}
}
