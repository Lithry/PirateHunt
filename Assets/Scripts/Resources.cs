using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour {
	static public Resources instance;
	private int honor;
	private int fear;
	private int idle;
	private int gold;


    void Start () {
		instance = this;
        honor = 0;
        fear = 0;
        idle = 0;
        gold = 0;
	}
	
	public int GetHonor() {
        return honor;
    }

    public void AddHonor(int value) {
        honor += value;
    }

	public int GetFear() {
        return fear;
    }

    public void AddFear(int value) {
        fear += value;
    }

	public int GetIdle() {
        return idle;
    }

    public void AddIdle(int value) {
        idle += value;
    }

	public int GetGold() {
        return gold;
    }

    public void AddGold(int value) {
        gold += value;
    }
}
