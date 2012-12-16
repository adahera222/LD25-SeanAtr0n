using UnityEngine;
using System.Collections;

public class TutorialJetpackPed : MonoBehaviour {
	
	public GameObject jetpack;
	public int setTutStep = 6;

	
	void OnTriggerEnter(Collider other) {
		jetpack.SetActive(false);
		if(TutorialText.active.step < setTutStep)
			TutorialText.active.NextStep();
	}
}
