using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour {
	static public ResourcesManager instance;
    public Image honorBar;
    public Image fearBar;
    private float honorFearBarLong;
    private int troops;
	private int honor;
	private int fear;
	private int idle;
	private int gold;
    private int ships;
    private int wood;
    private int citizens;


    void Start () {
		instance = this;
        troops = 0;
        honor = 0;
        fear = 0;
        idle = 0;
        gold = 0;
        AddWood(ShipsCost.WoodCost);
        AddCitizens(20);
        AddGold(190);
        honorFearBarLong = 1.0f;
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
        honorBar.fillAmount = ((float)(honor - idle) / 100) / honorFearBarLong;
    }

	public int GetFear() {
        return fear;
    }

    public void AddFear(int value) {
        fear += value;
        fearBar.fillAmount = ((float)(fear - idle) / 100) / honorFearBarLong;
    }

	public int GetIdle() {
        return idle;
    }

    public void AddIdle(int value) {
        idle += value;
        
        honorBar.fillAmount = ((float)(honor - idle) / 100) / honorFearBarLong;
        fearBar.fillAmount = ((float)(fear - idle) / 100) / honorFearBarLong;
    }

    public void ReduceIdle(int value) {
        idle -= value;

        honorBar.fillAmount = ((float)(honor - idle) / 100) / honorFearBarLong;
        fearBar.fillAmount = ((float)(fear - idle) / 100) / honorFearBarLong;
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

    public void AddWood(int value){
        if (value > 0){
            wood += value;
            UIManager.instance.SetWoodDisplay(wood);
        }
    }

    public void ReduceWood(int value){
        if (value > 0){
            wood -= value;

            if (wood < 0)
                wood = 0;

            UIManager.instance.SetWoodDisplay(wood);
        }
    }

    public int GetWood(){
        return wood;
    }

    public void AddCitizens(int value){
        if (value > 0){
            citizens += value;
            UIManager.instance.SetCitizenDisplay(citizens);
        }
    }

    public void ReduceCitizen(int value){
        if (value > 0){
            citizens -= value;

            if (citizens < 0)
                citizens = 0;

            UIManager.instance.SetCitizenDisplay(citizens);
        }
    }

    public int GetCitizen(){
        return citizens;
    }

    public float GetHonorLevel(){
        return honorBar.fillAmount;
    }

    public float GetFearLevel(){
        return fearBar.fillAmount;
    }
}
