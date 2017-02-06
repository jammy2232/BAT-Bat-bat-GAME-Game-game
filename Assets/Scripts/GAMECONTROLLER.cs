using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GAMECONTROLLER : MonoBehaviour {

	// Game Objects that will need effected
	public Text youDied;

	// Game Variables
	public float nightTimeLimit;
	public float rateofFoodConsumption;
	public float minSecondsBetweenPulse;
	public float maxSecondsBetweenPulse;
	public float foodInTummy;
	public float foodperbug;

	private int daysSurvived;
	private float timeInSeconds;
	private bool deadtimer;

	public static bool eatenBugs;
	public static bool safeZone;
	public static bool playerAlive;
	public static bool activateBugs;
	public static float pulsetimecontrol;

	// Use this for initialization
	void Start () {

		daysSurvived = 0;
		playerAlive = true;
		deadtimer = false;
		timeInSeconds = 0;
		eatenBugs = false;
		// safeZone = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (timeInSeconds < nightTimeLimit && playerAlive == true) {

			// Put game loop code here
			foodInTummy = foodInTummy - rateofFoodConsumption * Time.deltaTime;

			// Calculate pulses
			pulsetimecontrol = maxSecondsBetweenPulse - (maxSecondsBetweenPulse-minSecondsBetweenPulse)*(foodInTummy/100);

			// eating a fly
			if (eatenBugs == true) {
				if (foodInTummy < 100) {
					foodInTummy += foodperbug;
				}
				eatenBugs = false;
			}

		} else if (safeZone == true) { // Safe zone needs to dissappear
		
			// Start next day code show days and wait

			youDied.text = "Day " + daysSurvived;

			// start the death timer
			if (deadtimer == false) {
				timeInSeconds = 0;
				deadtimer = true;
				daysSurvived++;
			}

			if (timeInSeconds > 3) {
				safeZone = false;
				youDied.text = "";

			}


		} else if (playerAlive == false || timeInSeconds > nightTimeLimit) {
		
			// Put what happens when you die here

			youDied.text = "GAME OVER";

			// start the death timer
			if (deadtimer == false) {
				timeInSeconds = 0;
				deadtimer = true;
			}

			if (timeInSeconds > 3) {

				SceneManager.LoadScene(0); // Go back to main menu

			}

		}

		// Check for conditions that the player may have died
		if (foodInTummy < 0) {
			playerAlive = false;
		}
			
		// Increment the timer
		timeInSeconds = timeInSeconds + 1.0f * Time.deltaTime;
			
	}
}
