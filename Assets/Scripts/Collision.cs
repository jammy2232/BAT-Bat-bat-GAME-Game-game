using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
	
	public AudioClip Danger1;
	public AudioClip Danger2;
	public AudioClip Danger3;
	public AudioClip rustle;
	public AudioClip thud;

	public AudioSource hawk;
	public AudioSource player;

	private Rigidbody playerRb;

	// Use this for initialization
	void Start () {
		player = GetComponent<AudioSource> ();
		playerRb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.CompareTag("Danger3")){
			hawk.PlayOneShot (Danger3, 0.7f);
			GAMECONTROLLER.playerAlive = false;
		}
		else if (other.gameObject.CompareTag("Danger2")){
			hawk.PlayOneShot (Danger2, 0.7f);
		}
		else if (other.gameObject.CompareTag("Danger1")){
			hawk.PlayOneShot (Danger1, 0.7f);
		}

		if (other.gameObject.CompareTag ("Leaves")) {
			player.PlayOneShot (rustle, 0.5f);
		}

		if (other.gameObject.CompareTag ("New Tag")){
			player.PlayOneShot (thud, 2.0f);
			GAMECONTROLLER.playerAlive = false;
		}

		if (GAMECONTROLLER.playerAlive == false) {
			playerRb.useGravity = true;
		}
	}
}