using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class skillCoolDowns : MonoBehaviour {

	GameObject Caster;
	SpellCasting spellCaster;

    public List<GameObject> ennemies;
    //private AndroidJavaObject script;
    private int currentEnnemy;
    public GameObject targetedEnnemy;
    public Camera camera;
    public GameObject targeter;
    public int  targeterHeight;

    Vector3 Horizon;
    
    
    public List<Skill> skills;

    
   

    void FixedUpdate()
    {

        //ICI on s'OCCUPE DE CAST LES POUVOIRS
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
			CastFireball ();
        }

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			CastLightningbolt ();
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			CastBeam ();
		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			CastForce ();
		}

        //ET LA DE TARGET LES ENNEMIS
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentEnnemy <= ennemies.Count - 1)
            {
                currentEnnemy++;
                targetedEnnemy = ennemies[currentEnnemy];
				spellCaster.currentEnnemy = targetedEnnemy;
            }
        }
        else if( Input.GetKeyDown(KeyCode.A) )
        { 
                if(currentEnnemy > 0)
                {
                    currentEnnemy--;
                    targetedEnnemy = ennemies[currentEnnemy];
					spellCaster.ennemy = targetedEnnemy;
                }
        }
               
    }

	public void CastFireball()
	{

		//ICI on s'OCCUPE DE CAST LES POUVOIRS
	
			if (skills[0].currentCooldown >= skills[0].cooldown)
			{
				
			spellCaster.CastFireball ();
				skills[0].currentCooldown = 0;

			}
			
	}

	public void CastLightningbolt()
	{

		if (skills[1].currentCooldown >= skills[1].cooldown)
		{

			spellCaster.CastLightningbolt ();
			skills[1].currentCooldown = 0;

		}
			
	}

	public void CastBeam()
	{

		if (skills[2].currentCooldown >= skills[2].cooldown)
		{

			spellCaster.CastBeam ();
			skills[2].currentCooldown = 0;

		}

	}

	public void CastForce()
	{

		if (skills[3].currentCooldown >= skills[3].cooldown)
		{

			spellCaster.CastForce ();
			skills[3].currentCooldown = 0;

		}

	}

	// Use this for initialization
	void Start () {
		Caster = GameObject.Find ("SpellCastingSystem");
		spellCaster = Caster.GetComponent<SpellCasting> ();

        ennemies = GameObject.FindGameObjectWithTag("Player").GetComponent<EnnemiesList>().ennemies;
        currentEnnemy = -1;
        
	}

    // Update is called once per frame
    void Update() {
        Horizon.x = 0; Horizon.z = 0; Horizon.y = 10;
        //rafraichir les cooldowns
        foreach (Skill s in skills) {
            if (s.currentCooldown < s.cooldown) {
                s.currentCooldown += Time.deltaTime;
                s.SkillIcon.fillAmount = s.currentCooldown / s.cooldown;
            }
        }
        if (currentEnnemy != -1) {
            targeter.transform.position = targetedEnnemy.transform.position;
            Vector3 t;
            t.x = 0; t.y = targeterHeight; t.z = 0;
            targeter.transform.Translate(t);
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