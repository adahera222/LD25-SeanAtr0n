using UnityEngine;
using System.Collections;

public class PawnSwap : MonoBehaviour {
	public GameObject footballPawn;
	public GameObject gliderPawn;
	
	public static new PawnSwap active;
	
	// Use this for initialization
	void Start () {
	
	}
	void Awake() {
		active = this;
//		ExitMenu();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void FootPawn() {
		if(footballPawn.activeSelf) return;
		footballPawn.transform.position = gliderPawn.transform.position;
		footballPawn.transform.rotation = gliderPawn.transform.rotation;
//		for( int i = gliderPawn.transform.childCount-1; i >= 0 ; i--) {
//			gliderPawn.transform.GetChild(i).transform.parent = footballPawn.transform;
//		}

		footballPawn.SetActive(true);
		Camera.mainCamera.gameObject.transform.parent = footballPawn.transform;
		Camera.mainCamera.gameObject.transform.localPosition = new Vector3(0.0f, 0.9f, 0f);
		gliderPawn.SetActive(false);

	}

}
