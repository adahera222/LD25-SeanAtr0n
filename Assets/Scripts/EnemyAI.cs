using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public static bool seeking = true; //TODO deactivate
	
	public float speed = 4f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
		//transform.Translate(transform.forward * speed);
		
	}
	
}
