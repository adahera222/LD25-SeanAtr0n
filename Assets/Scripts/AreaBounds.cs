using UnityEngine;
using System.Collections;

public class AreaBounds : MonoBehaviour {
	public Transform origin;
	void OnTriggerExit(Collider other) {
		other.transform.position = origin.position;
		other.transform.rotation = origin.rotation;
	}
}
