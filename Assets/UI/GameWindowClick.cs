using UnityEngine;
using System.Collections;

public class GameWindowClick : MonoBehaviour {

	public void OnPress (bool isDown) {
		if(!isDown) {
			Screen.lockCursor = true;
		}
	}
}
