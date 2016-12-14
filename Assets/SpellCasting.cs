using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpellCasting : MonoBehaviour
{



	public GameObject Lightning1;
	public GameObject Lightning2;
	public GameObject currentLightning;
	public bool LightningOn;
	public float LightningDuration ;

	public GameObject Beam;

	public GameObject Fireball ;
	public GameObject player ; //TODO change this, link the script to the player controller
	int fireBallCd ;

	public GameObject spawn; 
	public GameObject spawn2;

	public GameObject ennemy;
	public GameObject currentEnnemy;


	int rdSpawn;

	public GameObject leftHand;
	public GameObject rightHand;



	public void Start () {
		ennemy.transform.localScale = new Vector3(50.0F, 50.0F, 50.0F);
	}


	public void Update () {
		if(Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)){ //Right click

			rdSpawn = UnityEngine.Random.Range(0,2) ;

			if(rdSpawn == 1)
				Instantiate(ennemy, spawn.transform.position, spawn.transform.rotation);
			else
				Instantiate(ennemy, spawn2.transform.position, spawn2.transform.rotation);
		}

		if (LightningOn) {
			LightningDuration -= Time.deltaTime;
			if (LightningDuration < 0) {
				Destroy (currentLightning);
				LightningOn=false;
			}
		}
	}

	public void CastFireball ()
	{
		Instantiate(Fireball, rightHand.transform.position, aim().transform.rotation);
	}

	public void CastLightningbolt ()
	{
		GameObject lightning = Instantiate(Lightning1, rightHand.transform.position, aim().transform.rotation);
		currentLightning = lightning;
		LightningDuration = 2.0f;
		LightningOn = true;
	}

	public void CastBeam ()
	{
		Instantiate(Beam, rightHand.transform.position, aim().transform.rotation);
	}

	public void CastForce()
	{
		Vector3 force;
		force.x = 0;
		force.y = 3;
		force.z = 0;
		currentEnnemy.transform.Translate (force);
	}

	public Transform aim(){
		Transform direction;
		direction = player.GetComponent<Transform>();
		Vector3 position = currentEnnemy.transform.position;
		position.y += currentEnnemy.GetComponent<Collider>().bounds.size.y/2;
		direction.LookAt(position);
		return direction;
	}
}