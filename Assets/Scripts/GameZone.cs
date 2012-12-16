using UnityEngine;
using System.Collections;

public class GameZone : MonoBehaviour {
	
	private EnemyAI[] enemies;
	
	//public System.TimeSpan countdown = new System.TimeSpan(0,2,0);
	public float countdown = 120f;
	
	public UILabel clock;
	public bool gameTime = false;
	
	// Use this for initialization
	void Start () {
		enemies = GameObject.FindObjectsOfType(typeof( EnemyAI)) as EnemyAI[];
	}
	
	// Update is called once per frame
	void Update () {
		if(gameTime) {
			countdown -= Time.deltaTime;
			clock.text = Mathf.FloorToInt(countdown/60).ToString() + ":" + Mathf.CeilToInt(countdown%60).ToString("D2");
		}
	}
	
	void OnTriggerEnter(Collider player) {
		if(player.tag != "Player") return;
		// activate enemy AI
		//EnemyAI.seeking = true;
		PawnSwap.active.FootPawn();
		enemies[0].Init();
		GetComponent<StaminaMeter>().Init();
		clock.gameObject.SetActive(true);
		gameTime = true;
		
		
	}
	
}
