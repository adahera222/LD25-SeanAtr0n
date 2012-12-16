using UnityEngine;
using System.Collections;

public class GameZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider player) {
		if(player.tag != "Player") return;
		// activate enemy AI
		EnemyAI.seeking = true;
	}
	
}
