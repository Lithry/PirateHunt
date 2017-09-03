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
	}
	
	public int GetHonor() {
        return honor;
    }

    public void SetHonor(int value) {
        honor = value;
    }

	public int GetFear() {
        return fear;
    }

    public void SetFear(int value) {
        fear = value;
    }

	public int GetIdle() {
        return idle;
    }

    public void SetIdle(int value) {
        idle = value;
    }

	public int GetGold() {
        return gold;
    }

    public void SetGold(int value) {
        gold = value;
    }
}
