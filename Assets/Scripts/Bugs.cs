using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : MonoBehaviour {

	private ParticleSystem BugEffect;
	private ParticleSystem.MainModule ps;

	private Color HiddenBugs;
	private Color VisibleBugs;

	private bool BugsVis;
	private float VisTimer;

	public float TimeVisible;

	private float y0;
	private float bugbobA;
	private float bugbobF;

	public AudioSource bugs;
	public AudioClip mothpickup;

	// Use this for initialization
	void Start () {

		BugEffect = GetComponent<ParticleSystem>();
		ps = BugEffect.main;

		BugsVis = false;
		VisTimer = 0;

		VisibleBugs.r = 255;
		VisibleBugs.b = 0;
		VisibleBugs.g = 174;
		VisibleBugs.a = 255;
		HiddenBugs = ps.startColor.color;

		y0 = transform.position.y;
		bugbobA = 0.01f;
		bugbobF = 2.0f;

	}

	// Update is called once per frame
	void Update () {

		if (BugsVis == true){ 
			VisTimer += Time.deltaTime;
		}

		if (VisTimer > TimeVisible) {
			BugsVis = false;
			VisTimer = 0;
			ps.startColor = HiddenBugs;
		}
	
		// Calculating the bobbing effect
		y0 += bugbobA*(Mathf.Sin(bugbobF*Time.time));//*Time.deltaTime*;
		transform.position = new Vector3(transform.position.x, y0, transform.position.z);
	}

	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.name == "PlayerSonar" && BugsVis == false) 
		{
			BugsVis = true;
			ps.startColor = VisibleBugs;
			VisTimer = 0;
		} 
		else if (col.gameObject.name == "PlayerSonar" && BugsVis == true) 
		{
			VisTimer = 0;
		}

		if(col.gameObject.name == "playerObject") 
		{
			bugs.PlayOneShot (mothpickup, 0.5f);
			GAMECONTROLLER.eatenBugs = true;
			Destroy(gameObject);
		}
	}

}
	