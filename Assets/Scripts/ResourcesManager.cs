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
	private int gold;
    private int ships;
    private int wood;
    private float woodForNextTurn;
    private float goldForNextTurn;
    private int citizens;


    void Start () {
		instance = this;
        troops = 0;
        honor = 0;
        fear = 0;
        gold = 0;
        AddWood(ShipsCost.WoodCost + 5);
        AddCitizens(45);
        AddGold(20);
        woodForNextTurn = 0.0f;
        goldForNextTurn = 0.0f;
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
        honorBar.fillAmount = (float)honor / HonorAndFear.Max;
    }

	public int GetFear() {
        return fear;
    }

    public void AddFear(int value) {
        fear += value;
        fearBar.fillAmount = (float)fear / HonorAndFear.Max;
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

    public void SetGoldForNextTunr(float value){
        goldForNextTurn = value;
    }

    public int GetGoldForNextTunr(){
        return (int)((goldForNextTurn * (float)citizens) / Taxes.exp);
    }

    public int GetEstimateGoldLostForNexTurn(int value){
        return (int)((goldForNextTurn * (float)citizens) / Taxes.exp) - (int)((goldForNextTurn * (float)(citizens - value)) / Taxes.exp);
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

    public void SetWoodForNextTunr(float value){
        woodForNextTurn = value;
    }
    
    public int GetWoodForNextTunr(){
        return (int)((woodForNextTurn * (float)citizens) / WoodCost.exp);
    }

    public int GetEstimateWoodLostForNexTurn(int value){
        return (int)((woodForNextTurn * (float)citizens) / WoodCost.exp) - (int)((woodForNextTurn * (float)(citizens - value)) / WoodCost.exp);
    }

    public void AddCitizens(int value){
        if (value > 0){
            citizens += value;
            UIManager.instance.SetCitizenDisplay(citizens);
            TimeManager.instance.SetResourcesForNextTurnDisplay();
        }

    }

    public void ReduceCitizen(int value){
        if (value > 0){
            citizens -= value;

            if (citizens < 0)
                citizens = 0;

            UIManager.instance.SetCitizenDisplay(citizens);
            TimeManager.instance.SetResourcesForNextTurnDisplay();
        }
    }

    public int GetCitizen(){
        return citizens;
    }

    public void TurnPassed(){
        AddWood((int)((woodForNextTurn * (float)citizens) / WoodCost.exp));
        AddGold((int)((goldForNextTurn * (float)citizens) / Taxes.exp));
        
        AddFearAndHonor();
    }

    private void AddFearAndHonor(){
        float woodFearVal = woodForNextTurn / (float)citizens;
        if (woodFearVal > 0.5f){
            if (woodFearVal <= 0.65f)
                AddFear(1);
            else if (woodFearVal <= 0.9f)
                AddFear(2);
            else
                AddFear(3);
        }
        else{
            if (woodFearVal >= 0.1f && woodFearVal <= 0.25f)
                AddHonor(2);
            else if (woodFearVal > 0.25f && woodFearVal <= 0.4f)
                AddHonor(1);
        }

        float goldFearVal = goldForNextTurn / (float)citizens;
        if (goldFearVal > 0.5f){
            if (goldFearVal <= 0.7f)
                AddFear(1);
            else if (goldFearVal <= 0.8f)
                AddFear(2);
            else
                AddFear(3);
        }
        else{
            if (goldFearVal > 0.15f && goldFearVal <= 0.3f)
                AddHonor(2);
            else if (goldFearVal > 0.3f && goldFearVal < 0.4f)
                AddHonor(1);
        }
    }

    public float GetHonorLevel(){
        return honorBar.fillAmount;
    }

    public float GetFearLevel(){
        return fearBar.fillAmount;
    }
}
