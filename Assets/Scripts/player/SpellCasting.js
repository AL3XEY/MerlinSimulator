#pragma strict


var spell : GameObject;
var player : Camera; //TODO change this, link the script to the player controller
var fireBallCd : int;

var spawn : GameObject; //TODO remove this, spawn relatively to the player's position + rotation
var spawn2 : GameObject;

var enemy : GameObject;
var rdSpawn : int;



public function Start () {
	enemy.transform.localScale = new Vector3(50.0F, 50.0F, 50.0F);
}


function Update () {
	if(Input.GetMouseButtonDown(0)){ //Left click
		

        Instantiate(spell, player.transform.position, player.transform.rotation);

    }
    if(Input.GetMouseButtonDown(1)){ //Right click

    	rdSpawn = Random.Range(0,2) ;

    	if(rdSpawn == 1)
        	Instantiate(enemy, spawn.transform.position, spawn.transform.rotation);
        else
        	Instantiate(enemy, spawn2.transform.position, spawn2.transform.rotation);
    }
    /*if(Input.GetMouseButtonDown(2)){ //Wheel click
    }*/
}
public function Cast ()
{
	Instantiate(spell, player.transform.position, player.transform.rotation);
}

