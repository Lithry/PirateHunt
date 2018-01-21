using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour {
	static public ResourcesManager instance;
	private float honor;
	private float fear;
	private float citizens;
	private float food;
	private float foodWorking;
	private float foodForNextTurn;
	private float gold;
	private float goldWorking;
	private float wood;
	private float woodWorking;
	private float ships;
	private float shipsWorking;
	private float troops;
	private float troopsWorking;

	void Start () {
		instance = this;
		honor = 0;
		fear = 0;
		citizens = 0;
		AddCitizens(45);
		food = 0;
		foodWorking = 0;
		AddFood(40);
	}

#region Honor
	public void AddHonor(float value){
		if (value > 0)
			honor += value;
	}

	public void ReduceHonor(float value){
		if (value > 0)
			honor -= value;

		if (honor < 0)
			honor = 0;
	}

	public float GetHonor(){
		return honor;
	}
#endregion

#region Fear
	public void AddFear(float value){
		if (value > 0)
			fear += value;
	}

	public void ReduceFear(float value){
		if (value > 0)
			fear -= value;

		if (fear < 0)
			fear = 0;
	}

	public float GetFear(){
		return fear;
	}
#endregion

#region Citizens
	public void AddCitizens(float value){
		if (value > 0)
			citizens += value;

		UIManager.instance.CitizensDisplay(citizens);
	}

	public void ReduceCitizens(float value){
		if (value > 0)
			citizens -= value;

		if (citizens < 0)
			citizens = 0;

		UIManager.instance.CitizensDisplay(citizens);
	}

	public float GetCitizens(){
		return citizens;
	}
#endregion

#region Food
	public void AddFood(float value){
		if (value > 0)
			food += value;

		UIManager.instance.FoodDisplay(food);
	}

	public void ReduceFood(float value){
		if (value > 0)
			food -= value;

		if (food < 0)
			food = 0;

		UIManager.instance.FoodDisplay(food);
	}

	public void AddToWorkFood(){
		if (citizens >= 1){
			ReduceCitizens(1);
			foodWorking++;
			foodForNextTurn = foodWorking * Food.foodPerWorker;
		}

		UIManager.instance.FoodWorkingDisplay(foodWorking);
		UIManager.instance.FoodPerNextTurnDisplay(foodForNextTurn);
	}

	public void ReduceToWorkFood(){
		if (foodWorking >= 1){
			AddCitizens(1);
			foodWorking--; 
			foodForNextTurn = foodWorking * Food.foodPerWorker;
		}

		UIManager.instance.FoodWorkingDisplay(foodWorking);
		UIManager.instance.FoodPerNextTurnDisplay(foodForNextTurn);
	}

	public float GetFood(){
		return food;
	}

	public float GetFoodWorking(){
		return foodWorking;
	}
#endregion



	public void TurnPassed(){
		AddFood(foodForNextTurn);
	}

}
