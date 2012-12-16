using UnityEngine;
using System.Collections;

public class StaminaMeter : MonoBehaviour {
	
	public UISlider stamina;
	public UISlicedSprite background;
	public UISlicedSprite background2;
	
	public RigidController player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void Init() {
		stamina.gameObject.SetActive(true);
		background.gameObject.SetActive(true);
		background2.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		stamina.fullSize.x = player.stamina;
		stamina.sliderValue = player.breath/player.stamina;
		background.transform.localScale = new Vector3(player.stamina, 30f, 1f);
	}
}
