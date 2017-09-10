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
		
		GameObject c = new GameObject();
		Sailor set3 = c.AddComponent<Sailor>();
		set3.SetId(3);
		set3.SetRequirements(0, 0, 1, 10);
		avalivle.Add(set3);
		
		GameObject d = new GameObject();
		Sailor set4 = d.AddComponent<Sailor>();
		set4.SetId(4);
		set4.SetRequirements(0, 1, 1, 50);
		avalivle.Add(set4);

		GameObject e = new GameObject();
		Sailor set5 = e.AddComponent<Sailor>();
		set5.SetId(5);
		set5.SetRequirements(1, 2, 0, 60);
		avalivle.Add(set5);
		
		GameObject f = new GameObject();
		Sailor set6 = f.AddComponent<Sailor>();
		set6.SetId(6);
		set6.SetRequirements(3, 1, 0, 100);
		avalivle.Add(set6);
	}

	public List<Sailor> GetAvalivleSailors(){
		return avalivle;
	}

	public void HireSailor(int id){
		for(int i = 0; i < avalivle.Count; i++){
			if (id == avalivle[i].GetId()){
				CrewManager.instance.AddSailorToCrew(avalivle[i]);
				ResourcesManager.instance.ReduceGold(avalivle[i].GetGoldRequired());
				avalivle.Remove(avalivle[i]);
			}
		}
	}
}
