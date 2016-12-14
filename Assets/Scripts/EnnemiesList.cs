using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesList : MonoBehaviour {
    public List<GameObject> ennemies;
    public int currentId = 0;

    public void AddEnnemy(GameObject ennemy)
    {
        ennemies.Add(ennemy);
        ennemy.GetComponent<basicIA>().ID = currentId;
        currentId++;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
