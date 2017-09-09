using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalivleSailors : MonoBehaviour {
	static public AvalivleSailors instance;
	private List<Sailor> avalivle = new List<Sailor>();
	// Use this for initialization
	void Awake () {
		instance = this;
		avalivle.Clear();

		GameObject a = new GameObject();
		Sailor set = a.AddComponent<Sailor>();
		set.SetId(1);
		set.SetRequirements(1, 0, 0, 10);
		avalivle.Add(set);
		
		GameObject b = new GameObject();
		Sailor set2 = b.AddComponent<Sailor>();
		set2.SetId(2);
		set2.SetRequirements(0, 1, 0, 10);
		avalivle.Add(set2);
		
		/*Sailor c = new Sailor();
		c.SetId(3);
		c.SetRequirements(0, 0, 1, 10);
		avalivle.Add(c);

		Sailor a2 = new Sailor();
		a2.SetId(4);
		a2.SetRequirements(10, 0, 0, 100);
		avalivle.Add(a2);
		
		Sailor b2 = new Sailor();
		b2.SetId(5);
		b2.SetRequirements(0, 10, 0, 100);
		avalivle.Add(b2);
		
		Sailor c2 = new Sailor();
		c2.SetId(6);
		c2.SetRequirements(0, 0, 10, 100);
		avalivle.Add(c2);*/
	}

	public List<Sailor> GetAvalivleSailors(){
		return avalivle;
	}

	public void HireSailor(int id){
		for(int i = 0; i < avalivle.Count; i++){
			if (id == avalivle[i].GetId()){
				CrewManager.instance.AddSailorToCrew(avalivle[i]);
				avalivle.Remove(avalivle[i]);
			}
		}
	}
}
