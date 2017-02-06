using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualibilityTronObjects : MonoBehaviour {

	private float VisTimer;
	private bool ObjectVisible;
	private Renderer rend;
	private Color HiddenColor;
	private Color VisibleColor;

	public float TimeVisible;

	// Use this for initialization
	void Start () {

		ObjectVisible = false;

		rend = GetComponent<Renderer>();

		HiddenColor.r = 0.05f;
		HiddenColor.b = 0.05f;
		HiddenColor.g = 0.05f;
		HiddenColor.a = 1.0f;

		VisibleColor.r = 0.0f;
		VisibleColor.b = 1.0f;
		VisibleColor.g = 1.0f;
		VisibleColor.a = 1.0f;

		rend.material.SetColor("_OutlineColor", HiddenColor);

	}
	
	// Update is called once per frame
	void Update () {

		if (ObjectVisible == true)
		{
			VisTimer = VisTimer + 1*Time.deltaTime;
		}

		if (VisTimer > TimeVisible) 
		{
			ObjectVisible = false;
			VisTimer = 0;
			rend.material.SetColor("_OutlineColor", HiddenColor);
		}
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name == "PlayerSonar" && ObjectVisible == false) 
		{
			ObjectVisible = true;
			rend.material.SetColor("_OutlineColor", VisibleColor);
			VisTimer = 0;
		}
		else if(col.gameObject.name == "PlayerSonar" && ObjectVisible == false) 
		{
			VisTimer = 0;
		}
	}

}
