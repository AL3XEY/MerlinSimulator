using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class skillCoolDowns : MonoBehaviour {

	GameObject Caster;
	//private AndroidJavaObject script;

	public List<Skill> skills;

	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if (skills[0].currentCooldown >= skills[0].cooldown) {
				Caster.SendMessage ("Cast");

				skills [0].currentCooldown = 0;
			}
		}
	}

	// Use this for initialization
	void Start () {
		Caster = GameObject.Find ("SpellCastingSystem");
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Skill s in skills){
			if (s.currentCooldown < s.cooldown) {
				s.currentCooldown += Time.deltaTime;
				s.SkillIcon.fillAmount = s.currentCooldown / s.cooldown;
			}
		}
	}
}

[System.Serializable]
public class Skill{
	public string name;
	public float cooldown;
	public Image SkillIcon;
	[HideInInspector]
	public float currentCooldown;
}