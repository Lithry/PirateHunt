using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour {
	static public CrewManager instance;
	private List<Sailor> reserv = new List<Sailor>();
	private List<Sailor> active = new List<Sailor>();

	void Start () {
		instance = this;
	}

	public void AddSailorToCrew(Sailor sailor){
		reserv.Add(sailor);
	}
}
