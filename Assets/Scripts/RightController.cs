using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController : MonoBehaviour {

	public GameManager gameManager;
	public TextMesh text;

	SteamVR_TrackedController controller;
	int year = 1996;


	static int minYear = 1996;
	static int maxYear = 2015;

	// Use this for initialization
	void Start () {
		controller = this.GetComponent<SteamVR_TrackedController> ();
		text.gameObject.SetActive (false);
		controller.TriggerClicked += HandleTriggerClicked;
		controller.TriggerUnclicked += HandleTriggerReleased;
		controller.PadClicked += HandlePadClicked;
		controller.PadTouched += HandlePadTouched;
		controller.PadUntouched += HandlePadUntouched;
		controller.MenuButtonClicked += HandleMenuClicked;
		UpdateYear ();
	}

	void HandleMenuClicked (object sender, ClickedEventArgs e) {
		gameManager.RefreshLines ();
	}

	void HandlePadTouched (object sender, ClickedEventArgs e) {
		text.gameObject.SetActive (true);
	}

	void HandlePadUntouched (object sender, ClickedEventArgs e) {
		text.gameObject.SetActive (false);
	}

	void HandlePadClicked (object sender, ClickedEventArgs e) {
		if (e.padX < 0) {
			year--;
			if (year < minYear)
				year = maxYear;
			SteamVR_Controller.Input ((int)controller.controllerIndex).TriggerHapticPulse ();
		} else {
			year++;
			if (year > maxYear) {
				year = minYear;
			}
			SteamVR_Controller.Input ((int)controller.controllerIndex).TriggerHapticPulse ();
		}
		UpdateYear ();

	}

	void UpdateYear() {
		text.text = year.ToString();
		gameManager.rightYear = year;
	}

	void HandleTriggerReleased (object sender, ClickedEventArgs e) {
		Debug.Log("right trigger released");
	}

	void HandleTriggerClicked(object sender, ClickedEventArgs e) {
		Debug.Log("right trigger clicked");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
