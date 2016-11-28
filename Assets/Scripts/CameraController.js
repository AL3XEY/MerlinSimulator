#pragma strict

function Start () {

}

function Update () {
	var speed = 50.0;
	var y = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
	var x = - Input.GetAxis("Vertical") * Time.deltaTime * speed;
	transform.Rotate(x,y,0);
}

