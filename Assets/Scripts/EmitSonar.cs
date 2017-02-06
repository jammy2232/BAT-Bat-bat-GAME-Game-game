using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitSonar : MonoBehaviour {

	public float sonarSpeed;
	public float sonarRange;

	private float sonarSize;
	private float pulsetime;

	public AudioClip SonarSound;
	public AudioSource sonar;

	private Collider colidy;


	// Use this for initialization
	void Start () {
		sonarSize = sonarRange + 1.0f;
		pulsetime = 0.0f;
		colidy = GetComponent<Collider> ();
		sonar = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Logic to trigger the sonar
		if (pulsetime > GAMECONTROLLER.pulsetimecontrol && GAMECONTROLLER.playerAlive == true) {
			sonarSize = 0.0f;
			pulsetime = 0.0f;
			colidy.enabled = true;
			sonar.PlayOneShot (SonarSound, 0.5f);
		}

		// Logic to spread the sonar
		if (sonarSize < sonarRange) {
			sonarSize = sonarSize + sonarSpeed * Time.deltaTime;
			transform.localScale = (new Vector3 (sonarSize, sonarSize, sonarSize));
		} else {
			transform.localScale = (new Vector3 (0, 0, 0));
			colidy.enabled = false;
		}

		pulsetime = pulsetime + 1 * Time.deltaTime;

	}
		
}
