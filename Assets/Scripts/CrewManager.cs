﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour {
	static public CrewManager instance;
	private Dictionary<int, Sailor> reserv = new Dictionary<int, Sailor>();
	private Dictionary<int, Sailor> active = new Dictionary<int, Sailor>();

	void Start () {
		instance = this;
	}

	void Update(){
		Debug.Log("Reserv: " + reserv.Count);
		Debug.Log("Active: " + active.Count);
	}

	public void AddSailorToCrew(Sailor sailor){
		reserv.Add(sailor.GetId(), sailor);
	}

	public void MoveToReserv(int id){
		reserv.Add(id, active[id]);
		active.Remove(id);
	}

	public void MoveToActive(int id){
		active.Add(id, reserv[id]);
		reserv.Remove(id);
	}

	public void MoveSailor(int id){
		if (reserv.ContainsKey(id)){
			active.Add(id, reserv[id]);
			reserv.Remove(id);
		}
		else if (active.ContainsKey(id)){
			reserv.Add(id, active[id]);
			active.Remove(id);
		}
	}

	public List<Sailor> GetSailorsInReserv(){
		List<Sailor> sai = new List<Sailor>(reserv.Values);
		return sai;
	}

	public List<Sailor> GetSailorsActives(){
		List<Sailor> sai = new List<Sailor>(active.Values);
		return sai;
	}
}
