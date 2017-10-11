using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour {
	static public ResourcesManager instance;
    private int troops;
	private int honor;
	private int fear;
	private int idle;
	private int gold;
    private int exp;


    void Start () {
		instance = this;
        troops = 0;
        honor = 0;
        fear = 0;
        idle = 0;
        gold = 0;
        AddGold(500);
        exp = 0;
	}

    public int GetTroops(){
        return troops;
    }

    public void AddTroops(int value){
        AddGold(TroopsCost.Gold * value);
        AddHonor(TroopsCost.Honor * value);
        AddFear(TroopsCost.Fear * value);
        AddIdle(TroopsCost.Idle * value);

        troops += value;
        UIManager.instance.SetTroopsDisplay(troops);
    }

	public int GetHonor() {
        return honor;
    }

    public void AddHonor(int value) {
        honor += value;
        UIManager.instance.SetHonorDisplay(honor);
    }

	public int GetFear() {
        return fear;
    }

    public void AddFear(int value) {
        fear += value;
        UIManager.instance.SetFearDisplay(fear);
    }

	public int GetIdle() {
        return idle;
    }

    public void AddIdle(int value) {
        idle += value;
        UIManager.instance.SetIdleDisplay(idle);
    }

	public int GetGold() {
        return gold;
    }

    public void AddGold(int value) {
        gold += value;
        UIManager.instance.SetGoldDisplay(gold);
    }

    public void ReduceGold(int value){
        gold -= value;
    }

    public void AddExp(int value){
        exp += value;
    }

    public int GetExp(){
        return exp;
    }
}
