using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalivleSailors : MonoBehaviour {
	static public AvalivleSailors instance;
	private List<Sailor> avalivle = new List<Sailor>();
	public Sprite defaultFace;
	public Sprite honor;
	public Sprite fear;
	public Sprite idle;
	// Use this for initialization
	void Awake () {
		instance = this;
		avalivle.Clear();

		GameObject a = new GameObject();
		Sailor set = a.AddComponent<Sailor>();
		set.SetId(1);
		set.SetPortrait(honor);
		set.SetRequirements(1, 0, 0, 10);
		avalivle.Add(set);
		
		GameObject b = new GameObject();
		Sailor set2 = b.AddComponent<Sailor>();
		set2.SetId(2);
		set2.SetPortrait(fear);
		set2.SetRequirements(0, 1, 0, 10);
		avalivle.Add(set2);
		
		GameObject c = new GameObject();
		Sailor set3 = c.AddComponent<Sailor>();
		set3.SetId(3);
		set3.SetPortrait(idle);
		set3.SetRequirements(0, 0, 1, 10);
		avalivle.Add(set3);
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
