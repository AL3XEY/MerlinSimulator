using UnityEngine;
using System.Collections;



public class getHit : MonoBehaviour {
	
	//public playerHealth health;
	public GameObject hitbox;
	// Use this for initialization
	void Start () {
		//health=hitbox.GetComponent <playerHealth> ();
		hitbox=GameObject.Find("Hitbox");
	}
	void OnTriggerEnter(Collider other){

		if (other.tag == "ennemy") {
			//Debug.Log ("Hit");
			//health.TakeDamage (10);
			hitbox.GetComponent <playerHealth> ().TakeDamage (10);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
