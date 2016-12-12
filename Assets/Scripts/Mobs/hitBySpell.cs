using UnityEngine;
using System.Collections;

public class hitBySpell : MonoBehaviour {

	public int health;

	void OnTriggerEnter(Collider other){
		
		if (other.tag == "spell") {
			Debug.Log (other.tag);

			health = health - 10;
		}
	}
	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
