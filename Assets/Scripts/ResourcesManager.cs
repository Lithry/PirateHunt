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
    private int ships;
    private int resources;
    private int exp;


    void Start () {
		instance = this;
        troops = 0;
        honor = 0;
        fear = 0;
        idle = 0;
        gold = 0;
        AddGold(500);
        AddResources(100);
        exp = 0;
	}

    public int GetTroops(){
        return troops;
    }

    public void AddTroops(int value){
        troops += value;
        UIManager.instance.SetTroopsDisplay(troops);
    }

    public void ReduceTroops(int value){
        if (value > 0){
            troops -= value;

            if (troops < 0)
                troops = 0;

            UIManager.instance.SetTroopsDisplay(troops);

        }
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

    public void ReduceIdle(int value) {
        idle -= value;
    }

	public int GetGold() {
        return gold;
    }

    public void AddGold(int value) {
        if (value > 0){
            gold += value;
            UIManager.instance.SetGoldDisplay(gold);
        }
    }

    public void ReduceGold(int value){
        if (value > 0){
            gold -= value;
            
            if (gold < 0)
                gold = 0;

            UIManager.instance.SetGoldDisplay(gold);
        }
    }

    public void AddShip(int value){
        if (value > 0){
            ships += value;
            UIManager.instance.SetShipsDisplay(ships);
        }
    }

    public void ReduceShip(int value){
        if (value > 0){
            ships += value;

            if (ships < 0)
                ships = 0;

            UIManager.instance.SetShipsDisplay(ships);
        }
    }

    public int GetShips(){
        return ships;
    }

    public void AddResources(int value){
        if (value > 0){
            resources += value;
            UIManager.instance.SetResourcesDisplay(resources);
        }
    }

    public void ReduceResources(int value){
        if (value > 0){
            resources -= value;

            if (resources < 0)
                resources = 0;

            UIManager.instance.SetResourcesDisplay(resources);
        }
    }

    public int GetResources(){
        return resources;
    }

    public void AddExp(int value){
        exp += value;
    }

    public int GetExp(){
        return exp;
    }
}
