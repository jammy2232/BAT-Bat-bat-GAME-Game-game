using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityTronStyleGrass : MonoBehaviour {

	private float VisTimer;
	private bool ObjectVisible;
	private Renderer rend;
	private Material[] mats;

	public float TimeVisible;
	public Material Hidden;
	public Material Visible;

	// Use this for initialization
	void Start () {

		ObjectVisible = false;

		rend = GetComponent<Renderer>();

		mats = rend.materials;
		for(int i=0; i<50;i++){
			mats[i] = Hidden;
		}

		rend.materials = mats;

	}

	// Update is called once per frame
	void Update () {

		if (ObjectVisible == true){
			VisTimer = VisTimer + 1*Time.deltaTime;
		}

		if (VisTimer > TimeVisible) {
			ObjectVisible = false;
			VisTimer = 0;

			for(int i=0; i<50;i++){
				mats[i] = Hidden;
			}

		}

		rend.materials = mats;

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name == "PlayerSonar" && ObjectVisible == false) 
		{
			ObjectVisible = true;
			VisTimer = 0;

			for (int i = 0; i < 50; i++) 
			{
				mats [i] = Visible;
			}
		} 
		else if(col.gameObject.name == "PlayerSonar" && ObjectVisible == true)
		{
			VisTimer = 0;	
			}
	}

}


