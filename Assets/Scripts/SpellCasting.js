#pragma strict

var spell : GameObject;
var player : Camera; //TODO change this, link the script to the player controller

var spawn : GameObject; //TODO remove this, spawn relatively to the player's position + rotation
var enemy : GameObject;

function Start () {
	enemy.transform.localScale = new Vector3(50.0F, 50.0F, 50.0F);
}

function Update () {
	if(Input.GetMouseButtonDown(0)){ //Left click
        Instantiate(spell, player.transform.position, player.transform.rotation);

    }
    if(Input.GetMouseButtonDown(1)){ //Right click
        Instantiate(enemy, spawn.transform.position, spawn.transform.rotation);
    }
    /*if(Input.GetMouseButtonDown(2)){ //Wheel click
    }*/
}