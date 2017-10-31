using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour {
	static public ResourcesManager instance;
    public Image honorBar;
    public Image fearBar;
    private int troops;
	private int honor;
	private int fear;
	private int idle;
	private int gold;
    private int ships;
    private int resources;


    void Start () {
		instance = this;
        troops = 0;
        honor = 0;
        fear = 0;
        idle = 0;
        gold = 0;
        AddGold(300);
        honorBar.fillAmount = 0;
        fearBar.fillAmount = 0;
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
        honorBar.fillAmount = ((float)(honor - idle) / 100) / 2;;
    }

	public int GetFear() {
        return fear;
    }

    public void AddFear(int value) {
        fear += value;
        fearBar.fillAmount = ((float)(fear - idle) / 100) / 2;;
    }

	public int GetIdle() {
        return idle;
    }

    public void AddIdle(int value) {
        idle += value;
        
        honorBar.fillAmount = ((float)(honor - idle) / 100) / 2;;
        fearBar.fillAmount = ((float)(fear - idle) / 100) / 2;;
    }

    public void ReduceIdle(int value) {
        idle -= value;

        honorBar.fillAmount = ((float)(honor - idle) / 100) / 2;;
        fearBar.fillAmount = ((float)(fear - idle) / 100) / 2;;
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
}
