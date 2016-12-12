using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
	public int startingHealth =100;
	public int currentHealth;
	public Slider healthSlider;
	bool damaged;
	public Image damageImage;
	public float flashSpeed = 5f;

	public Color flashColour = new Color(1f,0f,0f,0.1f);
	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear,
				flashSpeed * Time.deltaTime);
		}
		damaged = false;*/
	}
	public void TakeDamage (int amount){
		//damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
	}
}
