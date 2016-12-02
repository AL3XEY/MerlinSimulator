#pragma strict

var enemy : GameObject;
var spawnTime : float = 3f;
var spawnPoints : Transform[];

function Start () {
	InvokeRepeating("Spawn", spawnTime, spawnTime);
	enemy.transform.localScale += new Vector3(50.0F, 50.0F, 50.0F);
}

function Update () {

}

function Spawn () {
	var spawnPointIndex : int = Random.Range(0, spawnPoints.Length);

	Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
}