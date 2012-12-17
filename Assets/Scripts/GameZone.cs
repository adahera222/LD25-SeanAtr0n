using UnityEngine;
using System.Collections;

public class GameZone : MonoBehaviour {
	
	public static new GameZone active;
	
	private EnemyAI[] enemies;
	
	//public System.TimeSpan countdown = new System.TimeSpan(0,2,0);
	public float gameLength = 120f;
	public float countdown;
	
	public float delayTime = 120f;
	public UILabel filibusterTime;
	public UILabel filibusterLabel;
	
	public UILabel clock;
	public UILabel clockLabel;
	public bool filibustering = false;
	
	public UILabel victoryText;
	public UILabel victoryText2;
	public UILabel failText;
	public UILabel failText2;
	
	public bool gameOn = false;
	
	public float gameStartDelay = 10f;
	
	public int spawned = 0;
	public float nextSpawn = 115f;
	
	// Use this for initialization
	void Start () {
		enemies = GameObject.FindObjectsOfType(typeof( EnemyAI)) as EnemyAI[];
	}
	
	void Awake() {
		HideLabels();
		active = this;
		Invoke("StartClocks",gameStartDelay);
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameOn) return;
		if(!filibustering) {
			filibusterLabel.enabled = false;
			filibusterTime.enabled = false;
			clock.enabled = true;
			clockLabel.enabled = true;
			countdown -= Time.deltaTime;
			clock.text = Mathf.FloorToInt(countdown/60).ToString() + ":" + Mathf.FloorToInt(countdown%60).ToString("D2");
		} else {
			if(delayTime - Time.deltaTime < 100f && delayTime > 100f) {
				enemies[1].Init();
			}
			if(delayTime - Time.deltaTime < 90f && delayTime > 90f) {
				enemies[1].Init();
			}
			if(delayTime - Time.deltaTime < 80f && delayTime > 80f) {
				enemies[2].Init();
				enemies[3].Init();
			}
			if(delayTime - Time.deltaTime < 70f && delayTime > 70f) {
			}
			if(delayTime - Time.deltaTime < 60f && delayTime > 60f) {
			}
			if(delayTime - Time.deltaTime < 50f && delayTime > 50f) {
			}
			if(delayTime - Time.deltaTime < 40f && delayTime > 40f) {
			}
			if(delayTime - Time.deltaTime < 30f && delayTime > 30f) {
			}
			if(delayTime - Time.deltaTime < 20f && delayTime > 20f) {
			}
			if(delayTime - Time.deltaTime < 10f && delayTime > 10f) {
			}
			
			if(delayTime < nextSpawn) {
				nextSpawn = delayTime - 5f;
				if(spawned < enemies.Length) enemies[spawned++].Init();
			}
			
			
			filibusterLabel.enabled = true;
			filibusterTime.enabled = true;
			delayTime -= Time.deltaTime;
			filibusterTime.text = Mathf.FloorToInt(delayTime/60).ToString() + ":" + Mathf.FloorToInt(delayTime%60).ToString("D2");
		}
		
		if(countdown <= 0f) {
			countdown -= Time.deltaTime;
			failText.enabled = true;
			failText2.enabled = true;
			
			if(countdown <= 10f) {
				//reset level
				HideLabels();
			}
			//game over
		} else if(delayTime <= 0f) {
			//HideLabels();
			clock.enabled = false;
			clockLabel.enabled = false;
			filibusterLabel.enabled = false;
			filibusterTime.enabled = false;
			victoryText.enabled = true;
			victoryText2.enabled = true;
		}
	}
	
	void OnTriggerEnter(Collider player) {
		if(player.tag != "Player") return;
		// activate enemy AI
		//EnemyAI.seeking = true;
//		PawnSwap.active.FootPawn();
		enemies[0].Init();
//		GetComponent<StaminaMeter>().Init();
//		clock.gameObject.SetActive(true);
		filibustering = true;
	}
	
	void OnTriggerExit(Collider player) {
		if(player.tag != "Player") return;
		if(delayTime <= 0f) {
			//TODO Victory music?
			victoryText.enabled = false;
			victoryText2.enabled = true;
		}
		// reset enemies
		filibustering = false;
	}
	
	public void Reset() {
		countdown = gameLength;
		delayTime = gameLength;
		gameOn = false;
	}
	
	public void StartClocks() {
		gameOn = true;
		//play crowd noises
	}
	
	public void HideLabels() {
		filibusterLabel.enabled = false;
		filibusterTime.enabled = false;
		clockLabel.enabled = false;
		clock.enabled = false;
		victoryText2.enabled = false;
		victoryText.enabled = false;
		failText.enabled = false;
		failText2.enabled = false;
	}
	
}
