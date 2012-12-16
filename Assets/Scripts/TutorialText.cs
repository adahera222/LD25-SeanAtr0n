using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour {
	
	public static new TutorialText active;
	
	public UILabel TutText;
	
	public GameObject TutDoor;
	public GameObject TutDoor2;

	
	public int step = 0;
	public float currentDisplayTime = 0f;
	
	// Use this for initialization
	void Awake () {
		active = this;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Screen.lockCursor) {
			currentDisplayTime += Time.deltaTime;
			switch(step) {
			case 0:
				TutText.enabled = true;
				TutText.gameObject.SetActive(true);
				TutText.text = "Testing Movement:\nPlease press W or Up Arrow";
				RigidController.active.dodgeForce = 0f;
				if(Input.GetAxis("Vertical") > 0f) NextStep();
				break;
			case 1:
				TutText.text = "Testing Movement:\nPlease press S or Down Arrow";
				if(Input.GetAxis("Vertical") < 0f) NextStep();
				break;
			case 2:
				TutText.text = "Testing Movement:\nPlease press A or Right Arrow";
				if(Input.GetAxis("Horizontal") < 0f) NextStep();
				break;
			case 3:
				TutText.text = "Testing Movement:\nPlease press D or Left Arrow";
				if(Input.GetAxis("Horizontal") > 0f) NextStep();
				break;
			case 4:
				TutText.text = "Press Escape at any point to change settings\nPlease proceed to the next Room.";
				iTween.MoveBy(TutDoor, new Vector3(10f,0f,0f),5f);
				break;
			case 5:
				if(currentDisplayTime == Time.deltaTime ) {
					TutText.text = "This is (a virtual version) of your new jetpack!\nPlease approach.";
					iTween.MoveBy(TutDoor, new Vector3(10f,0f,0f),5f);
				}
				break;
			case 6:
				if(currentDisplayTime == Time.deltaTime ) {
					TutText.text = "Your new Jetpack is currently in impulse mode.\nDouble-tap Left or Right to Impulse Strafe";
					RigidController.active.dodgeForce = 3000f;
				}
				if(RigidController.active.breath != RigidController.active.stamina) {
					NextStep();
				}
				break;
			case 7:
				if(currentDisplayTime == Time.deltaTime ) {
					TutText.text = "Impulse thrusters must be primed and drain fuel quickly.\nThis meter monitors priming and fuel consumption.";
					RigidController.active.GetComponent<StaminaMeter>().Init();
					iTween.MoveBy(TutDoor2, new Vector3(30f,0f,0f),5f);
				}
				if(currentDisplayTime > 15f) {
					TutText.text = "Please continue to the next room.";
				}
				break;
			case 8:
				if(currentDisplayTime == Time.deltaTime ) {
					TutText.text = "Try Impulse Strafing to reach the other side of this room!\n";
				}
				break;
			case 9:
				TutText.text = "Training complete! Returning to reality...";
				if(currentDisplayTime > 5f) {
			        if (Application.CanStreamedLevelBeLoaded("outdoors"))
			            Application.LoadLevel("outdoors");
				}
				break;
			}
		}
		
		
	}
	
	public void NextStep() {
		currentDisplayTime = 0f;
		step++;
	}
}
