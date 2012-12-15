using UnityEngine;
using System.Collections;

public class PanelControl : MonoBehaviour {
	
	bool isOut = false;
	
	// Use this for initialization
	void Start () {
		transform.Translate(0f,1200f,0f);
		isOut = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Screen.lockCursor) {
			if(!isOut) {
				gameObject.animation.Play("menu_out");
				isOut = true;
			}
		} else {
			if(isOut) {
				gameObject.animation.Play("menu_in");
				isOut = false;
			}
		}
	}
}
