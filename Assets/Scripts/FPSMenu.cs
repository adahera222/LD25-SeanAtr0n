using UnityEngine;
using System.Collections;

public class FPSMenu : MonoBehaviour {
		
	
	void Awake() {
//		Time.timeScale = 0f;
		//doesn't work with animated menu
	}
	
	public void OnClick() {
		Screen.lockCursor = true;
		Time.timeScale = 1.0f;
	}
}
