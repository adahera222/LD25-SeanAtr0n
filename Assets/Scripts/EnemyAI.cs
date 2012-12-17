using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public bool seeking = false;
	
	public float speed = 4f;
	
	public float pursuitForce = 3000;
	
	public Vector3 initialPos;
	
	// Use this for initialization
	void Awake () {
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		
		if(seeking) {
			transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
		//transform.Translate(transform.forward * speed);
		
		}
		
	}
	
	public void Init() {
		GetComponent<ConstantForce>().relativeForce = new Vector3(0f,0f, pursuitForce);
		seeking = true;
	}
	
}
