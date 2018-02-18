using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour {
#region Variables
	static public ResourcesManager instance;
	public Image honorBar;
	private float honor;
	public Image fearBar;
	private float fear;
	private float citizens;
	private float food;
	private float foodWorking;
	private float foodForNextTurn;
	private float gold;
	private float goldWorking;
	private float goldForNextTurn;
	private float wood;
	private float woodWorking;
	private float woodForNextTurn;
	private float ships;
	private float shipsWorking;
	private float shipsForNextTurn;
	private float troops;
	private float troopsWorking;
	private float troopsForNextTurn;
#endregion
	
	void Start () {
		instance = this;
		honor = 0;
		AddHonor(0);
		fear = 0;
		AddFear(0);
		citizens = 0;
		AddCitizens(45);
		food = 0;
		foodWorking = 0;
		AddFood(40);
		gold = 0;
		goldWorking = 0;
		AddGold(100);
		wood = 0;
		woodWorking = 0;
		AddWood(100);
		ships = 0;
		shipsWorking = 0;
		AddShips(0);
		troops = 0;
		troopsWorking = 0;
		AddTroops(0);
	}

#region Honor
	public void AddHonor(float value){
		if (value > 0)
			honor += value;

		honorBar.fillAmount = (honor * 0.01f) / HonorFear.pluss;
	}

	public void ReduceHonor(float value){
		if (value > 0)
			honor -= value;

		if (honor < 0)
			honor = 0;

		honorBar.fillAmount = (honor * 0.01f) / HonorFear.pluss;
	}

	public float GetHonor(){
		return honor;
	}

	public float GetHonorLevel(){
		return honorBar.fillAmount;
	}
#endregion

#region Fear
	public void AddFear(float value){
		if (value > 0)
			fear += value;

		fearBar.fillAmount = (fear * 0.01f) / HonorFear.pluss;
	}

	public void ReduceFear(float value){
		if (value > 0)
			fear -= value;

		if (fear < 0)
			fear = 0;

		fearBar.fillAmount = (fear * 0.01f) / HonorFear.pluss;
	}

	public float GetFear(){
		return fear;
	}

	public float GetFearLevel(){
		return fearBar.fillAmount;
	}
#endregion

#region Citizens
	public void AddCitizens(float value){
		if (value > 0)
			citizens += value;

		DisplayResources();
	}

	public void ReduceCitizens(float value){
		if (value > 0)
			citizens -= value;

		if (citizens < 0)
			citizens = 0;

		DisplayResources();
	}

	public float GetCitizens(){
		return citizens;
	}
#endregion

#region Food
	public void AddFood(float value){
		if (value > 0)
			food += value;

		DisplayResources();
	}

	public void ReduceFood(float value){
		if (value > 0)
			food -= value;

		if (food < 0)
			food = 0;

		DisplayResources();
	}

	public void AddToWorkFood(){
		if (citizens >= 1){
			ReduceCitizens(1);
			foodWorking++;
			foodForNextTurn = (foodWorking * Food.foodPerWorker) - (troops * Troops.foodCost);
			goldForNextTurn = (goldWorking * Gold.goldPerWorker) - (troopsWorking * Troops.goldCost) - (foodWorking * Food.goldCost) - (woodWorking * Wood.goldCost) - (shipsWorking * Ships.goldCost);
		}
		
		DisplayResources();
	}

	public void ReduceToWorkFood(){
		if (foodWorking >= 1){
			AddCitizens(1);
			foodWorking--; 
			foodForNextTurn = (foodWorking * Food.foodPerWorker) - (troops * Troops.foodCost);
			goldForNextTurn = (goldWorking * Gold.goldPerWorker) - (troopsWorking * Troops.goldCost) - (foodWorking * Food.goldCost) - (woodWorking * Wood.goldCost) - (shipsWorking * Ships.goldCost);
		}

		DisplayResources();
	}

	public float GetFood(){
		return food;
	}

	public float GetFoodWorking(){
		return foodWorking;
	}

	public float GetFoodForNextTurn(){
		return foodForNextTurn;
	}
#endregion

#region Gold
	public void AddGold(float value){
		if (value > 0)
			gold += value;

		DisplayResources();
	}

	public void ReduceGold(float value){
		if (value > 0)
			gold -= value;

		if (gold < 0)
			gold = 0;

		DisplayResources();
	}

	public void AddToWorkGold(){
		if (citizens >= 1){
			ReduceCitizens(1);
			goldWorking++;
			goldForNextTurn = (goldWorking * Gold.goldPerWorker) - (troopsWorking * Troops.goldCost) - (foodWorking * Food.goldCost) - (woodWorking * Wood.goldCost) - (shipsWorking * Ships.goldCost);
		}

		DisplayResources();
	}

	public void ReduceToWorkGold(){
		if (goldWorking >= 1){
			AddCitizens(1);
			goldWorking--; 
			goldForNextTurn = (goldWorking * Gold.goldPerWorker) - (troopsWorking * Troops.goldCost) - (foodWorking * Food.goldCost) - (woodWorking * Wood.goldCost) - (shipsWorking * Ships.goldCost);
		}

		DisplayResources();
	}

	public float GetGold(){
		return gold;
	}

	public float GetGoldWorking(){
		return goldWorking;
	}

	public float GetGoldForNextTurn(){
		return goldForNextTurn;
	}
#endregion

#region Wood
	public void AddWood(float value){
		if (value > 0)
			wood += value;

		DisplayResources();
	}

	public void ReduceWood(float value){
		if (value > 0)
			wood -= value;

		if (wood < 0)
			wood = 0;

		DisplayResources();
	}

	public void AddToWorkWood(){
		if (citizens >= 1){
			ReduceCitizens(1);
			woodWorking++;
			woodForNextTurn = (woodWorking * Wood.woodPerWorker) - (shipsWorking * Ships.woodCost);
			goldForNextTurn = (goldWorking * Gold.goldPerWorker) - (troopsWorking * Troops.goldCost) - (foodWorking * Food.goldCost) - (woodWorking * Wood.goldCost) - (shipsWorking * Ships.goldCost);
		}
		
		DisplayResources();
	}

	public void ReduceToWorkWood(){
		if (woodWorking >= 1){
			AddCitizens(1);
			woodWorking--; 
			woodForNextTurn = (woodWorking * Wood.woodPerWorker) - (shipsWorking * Ships.woodCost);
			goldForNextTurn = (goldWorking * Gold.goldPerWorker) - (troopsWorking * Troops.goldCost) - (foodWorking * Food.goldCost) - (woodWorking * Wood.goldCost) - (shipsWorking * Ships.goldCost);
		}

		DisplayResources();
	}

	public float GetWood(){
		return wood;
	}

	public float GetWoodWorking(){
		return woodWorking;
	}

	public float GetWoodForNextTurn(){
		return woodForNextTurn;
	}
#endregion

#region Ships
	public void AddShips(float value){
		if (value > 0)
			ships += value;

		DisplayResources();
	}

	public void ReduceShips(float value){
		if (value > 0)
			ships -= value;

		if (ships < 0)
			ships = 0;

		DisplayResources();
	}

	public void AddToWorkShips(){
		if (citizens >= 1){
			ReduceCitizens(1);
			shipsWorking++;
			shipsForNextTurn = shipsWorking * Ships.shipsPerWorker;
			woodForNextTurn = (woodWorking * Wood.woodPerWorker) - (shipsWorking * Ships.woodCost);
			goldForNextTurn = (goldWorking * Gold.goldPerWorker) - (troopsWorking * Troops.goldCost) - (foodWorking * Food.goldCost) - (woodWorking * Wood.goldCost) - (shipsWorking * Ships.goldCost);
		}

		DisplayResources();
	}

	public void ReduceToWorkShips(){
		if (shipsWorking >= 1){
			AddCitizens(1);
			shipsWorking--; 
			shipsForNextTurn = shipsWorking * Ships.shipsPerWorker;
			woodForNextTurn = (woodWorking * Wood.woodPerWorker) - (shipsWorking * Ships.woodCost);
			goldForNextTurn = (goldWorking * Gold.goldPerWorker) - (troopsWorking * Troops.goldCost) - (foodWorking * Food.goldCost) - (woodWorking * Wood.goldCost) - (shipsWorking * Ships.goldCost);
		}

		DisplayResources();
	}

	public float GetShips(){
		return ships;
	}

	public float GetShipsWorking(){
		return shipsWorking;
	}
#endregion

#region Troops
	public void AddTroops(float value){
		if (value > 0 && ((int)(ships + 0.05f) * Ships.troopsPerShip) >= (troops + value))
			troops += value;
		else if (((int)(ships + 0.05f) * Ships.troopsPerShip) < (troops + value))
			troops = ((int)(ships + 0.05f) * Ships.troopsPerShip);

		DisplayResources();
	}

	public void ReduceTroops(float value){
		if (value > 0)
			troops -= value;

		if (troops < 0)
			troops = 0;
		
		DisplayResources();
	}

	public void AddToWorkTroops(){
		if (citizens >= 1){
			ReduceCitizens(1);
			troopsWorking++;
			troopsForNextTurn = troopsWorking * Troops.troopsPerWorker;
			goldForNextTurn = (goldWorking * Gold.goldPerWorker) - (troopsWorking * Troops.goldCost) - (foodWorking * Food.goldCost) - (woodWorking * Wood.goldCost) - (shipsWorking * Ships.goldCost);
		}

		DisplayResources();
	}

	public void ReduceToWorkTroops(){
		if (troopsWorking >= 1){
			AddCitizens(1);
			troopsWorking--; 
			troopsForNextTurn = troopsWorking * Troops.troopsPerWorker;
			goldForNextTurn = (goldWorking * Gold.goldPerWorker) - (troopsWorking * Troops.goldCost) - (foodWorking * Food.goldCost) - (woodWorking * Wood.goldCost) - (shipsWorking * Ships.goldCost);
		}

		DisplayResources();
	}

	public float GetTroops(){
		return troops;
	}

	public float GetTroopsWorking(){
		return troopsWorking;
	}
#endregion

	public void TurnPassed(){
		if (foodForNextTurn > 0){
			if (gold > 0)
				AddFood(foodForNextTurn);
		}
		else
			ReduceFood(Mathf.Abs(foodForNextTurn));
		
		if (goldForNextTurn > 0)
			AddGold(goldForNextTurn);
		else
			ReduceGold(Mathf.Abs(goldForNextTurn));
		
		if (woodForNextTurn > 0){
			if (gold > 0)
				AddWood(woodForNextTurn);
		}
		else
			ReduceWood(Mathf.Abs(woodForNextTurn));
		
		if (shipsForNextTurn > 0){
			if (wood > 0 && gold > 0)
				AddShips(shipsForNextTurn);
		}
		else
			ReduceShips(Mathf.Abs(shipsForNextTurn));
		
		if (troopsForNextTurn > 0){
			if (gold > 0 && food > 0.09f)
				AddTroops(troopsForNextTurn);
			else if (food < 0.09f)
				ReduceTroops(troops / Troops.lossesFromLackFood);
		}
		else
			ReduceTroops(Mathf.Abs(troopsForNextTurn));

		
		
		foodForNextTurn = (foodWorking * Food.foodPerWorker) - (troops * Troops.foodCost);
		DisplayResources();
	}

	private void DisplayResources(){
		UIManager.instance.CitizensDisplay(citizens);
		UIManager.instance.FoodDisplay(food);
		UIManager.instance.FoodWorkingDisplay(foodWorking);
		UIManager.instance.FoodPerNextTurnDisplay(foodForNextTurn);
		UIManager.instance.GoldDisplay(gold);
		UIManager.instance.GoldWorkingDisplay(goldWorking);
		UIManager.instance.GoldPerNextTurnDisplay(goldForNextTurn);
		UIManager.instance.WoodDisplay(wood);
		UIManager.instance.WoodWorkingDisplay(woodWorking);
		UIManager.instance.WoodPerNextTurnDisplay(woodForNextTurn);
		UIManager.instance.ShipsDisplay(ships);
		UIManager.instance.ShipsWorkingDisplay(shipsWorking);
		UIManager.instance.ShipsPerNextTurnDisplay(shipsForNextTurn);
		UIManager.instance.TroopsDisplay(troops, ((int)(ships + 0.05f) * Ships.troopsPerShip));
		UIManager.instance.TroopsWorkingDisplay(troopsWorking);
		UIManager.instance.TroopsPerNextTurnDisplay(troopsForNextTurn);
		WarningManager.instance.CheckWarnings();
	}

}
