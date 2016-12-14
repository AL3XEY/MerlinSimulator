using UnityEngine;
using System.Collections;

public class basicIA : MonoBehaviour {

    public int ID;
	public Transform player;
	public Animator anim;
	private bool isWalking, isAttacking, isRunning,isDead;

	public float timeBetweenAttacks ;
	public int attackDamage = 10;

	playerHealth playerHealth;
	public int health;

	int deathTimer;
	int currentDeathTimer;

	//range a partir de laquelle le squelette va attaquer.
	public int meleeAttackRange;
	public int dangerZone;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		health = 100;

		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <playerHealth> ();

		deathTimer = 500;
		currentDeathTimer = 0;

		meleeAttackRange = 7;
		dangerZone = 20;
		isWalking = isAttacking = isRunning = false;


        //il faut recuperer son ID
        GameObject.FindGameObjectWithTag("Player").GetComponent<EnnemiesList>().AddEnnemy(gameObject);

    }

	/*private void setTriggers(string state){
		foreach (AnimatorControllerParameter param in anim.parameters) {
			if (AnimatorControllerParameter.type == AnimatorControllerParameterType.Bool) {
				if (param.name == state)
					anim.SetBool (state, true);
				else {
					anim.SetBool (param.name, false);
				}
			}
		}
	}*/
	// Update is called once per frame
	void Update () {

       
        
		if (isDead == false && health <= 0) {
			isDead = true;
			anim.SetTrigger ("deathTrigger");

		} else if (isDead != true) {
			
		

			if (Vector3.Distance (player.position, this.transform.position) < 10100) {
				Vector3 direction = player.position - this.transform.position;
				direction.y = 0;


				this.transform.rotation = Quaternion.Slerp (this.transform.rotation,
					Quaternion.LookRotation (direction), 0.1f);

				//si on est a plus de 6 le squelette marche vers nous
				if (direction.magnitude >= dangerZone) {
					if (isRunning == false) {
						anim.SetTrigger ("runTrigger");
						isRunning = true;
						isWalking = isAttacking = false;
					}
					this.transform.Translate (0, 0, 0.20f);
				}

				if (direction.magnitude >= meleeAttackRange && direction.magnitude < dangerZone) {
					if (isWalking == false) {
						isWalking = true;
						anim.SetTrigger ("walkTrigger");
						isRunning = false;
						isAttacking = false;
					}
					this.transform.Translate (0, 0, 0.08f);
				}
				if (direction.magnitude <= meleeAttackRange) {
					if (isAttacking == false) {
						isAttacking = true;
						anim.SetTrigger ("attackTrigger");
						isRunning = false;
						isWalking = false;
					} 

				}
			}
		} else {
			currentDeathTimer++;
			if (currentDeathTimer >= deathTimer) {
				GameObject.Destroy (gameObject);
			}
		}
	}
	// Pour les collisions avec les spells
	void OnTriggerEnter(Collider other){

		if (other.tag == "spell") {
			Debug.Log (other.tag);

			health = health - 10;
		}
	}
}
