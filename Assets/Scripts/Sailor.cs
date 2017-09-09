using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sailor : MonoBehaviour {
	private int id;
	private int honorRequired;
	private int fearRequired;
	private int idleRequired;
	private int goldRequired;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetId(int id){
		this.id = id;
	}

	public int GetId(){
		return id;
	}

	public void SetRequirements(int honor, int fear, int idle, int gold){
		honorRequired = honor;
		fearRequired = fear;
		idleRequired = idle;
		goldRequired = gold;
	}

	public int GetHonorRequired(){
		return honorRequired;
	}

	public int GetFearRequired(){
		return fearRequired;
	}

	public int GetIdleRequired(){
		return idleRequired;
	}

	public int GetGoldRequired(){
		return goldRequired;
	}
}
