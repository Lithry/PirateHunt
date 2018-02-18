using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	static public UIManager instance;
	public GameObject helpDisplay;

	void Awake () {
		instance = this;
		helpDisplay.SetActive(false);
	}

	public void OpenHelpPanel(){
		helpDisplay.SetActive(true);
	}

	public void CloseHelpPanel(){
		helpDisplay.SetActive(false);
	}

#region Display
	public Text citizensDisplay;
	public Text foodDisplay;
	public Text foodWorkingDisplay;
	public Text foodPerNextTurnDisplay;
	public Text goldDisplay;
	public Text goldWorkingDisplay;
	public Text goldPerNextTurnDisplay;
	public Text woodDisplay;
	public Text woodWorkingDisplay;
	public Text woodPerNextTurnDisplay;
	public Text shipsDisplay;
	public Text shipsWorkingDisplay;
	public Text shipsPerNextTurnDisplay;
	public Text troopsDisplay;
	public Text troopsWorkingDisplay;
	public Text troopsPerNextTurnDisplay;

	public void CitizensDisplay(float value){
		citizensDisplay.text = "x " + value.ToString("F0");
	}
	
	public void FoodDisplay(float value){
		foodDisplay.text = value.ToString("F1");
	}

	public void FoodWorkingDisplay(float value){
		foodWorkingDisplay.text = value.ToString("F0");
	}

	public void FoodPerNextTurnDisplay(float value){
		if (value < 0){
			foodPerNextTurnDisplay.color = Color.red;
			foodPerNextTurnDisplay.text = "- " + Mathf.Abs(value).ToString("F1");
		}
		else{
			foodPerNextTurnDisplay.color = Color.green;
			foodPerNextTurnDisplay.text = "+ " + value.ToString("F1");
		}
	}

	public void GoldDisplay(float value){
		goldDisplay.text = value.ToString("F1");
	}

	public void GoldWorkingDisplay(float value){
		goldWorkingDisplay.text = value.ToString("F0");
	}

	public void GoldPerNextTurnDisplay(float value){
		if (value < 0){
			goldPerNextTurnDisplay.color = Color.red;
			goldPerNextTurnDisplay.text = "- " + Mathf.Abs(value).ToString("F1");
		}
		else{
			goldPerNextTurnDisplay.color = Color.green;
			goldPerNextTurnDisplay.text = "+ " + value.ToString("F1");
		}
	}

	public void WoodDisplay(float value){
		woodDisplay.text = value.ToString("F1");
	}

	public void WoodWorkingDisplay(float value){
		woodWorkingDisplay.text = value.ToString("F0");
	}

	public void WoodPerNextTurnDisplay(float value){
		if (value < 0){
			woodPerNextTurnDisplay.color = Color.red;
			woodPerNextTurnDisplay.text = "- " + Mathf.Abs(value).ToString("F1");
		}
		else{
			woodPerNextTurnDisplay.color = Color.green;
			woodPerNextTurnDisplay.text = "+ " + value.ToString("F1");
		}
	}

	public void ShipsDisplay(float value){
		shipsDisplay.text = value.ToString("F1");
	}

	public void ShipsWorkingDisplay(float value){
		shipsWorkingDisplay.text = value.ToString("F0");
	}

	public void ShipsPerNextTurnDisplay(float value){
		shipsPerNextTurnDisplay.text = "+ " + value.ToString("F1");
	}

	public void TroopsDisplay(float value, int max){
		troopsDisplay.text = value.ToString("F0") + "/" + max.ToString();
	}

	public void TroopsWorkingDisplay(float value){
		troopsWorkingDisplay.text = value.ToString("F0");
	}

	public void TroopsPerNextTurnDisplay(float value){
		troopsPerNextTurnDisplay.text = "+ " + value.ToString("F1");
	}
#endregion

#region FoodPanel
	public void FoodAddWorking(){
		if (ResourcesManager.instance.GetCitizens() >= 1)
			ResourcesManager.instance.AddToWorkFood();
	}
	
	public void FoodReduceWorking(){
		if (ResourcesManager.instance.GetFoodWorking() >= 1)
			ResourcesManager.instance.ReduceToWorkFood();
	}
#endregion

#region GoldPanel
	public void GoldAddWorking(){
		if (ResourcesManager.instance.GetCitizens() >= 1)
			ResourcesManager.instance.AddToWorkGold();
	}
	
	public void GoldReduceWorking(){
		if (ResourcesManager.instance.GetGoldWorking() >= 1)
			ResourcesManager.instance.ReduceToWorkGold();
	}
#endregion

#region WoodPanel
	public void WoodAddWorking(){
		if (ResourcesManager.instance.GetCitizens() >= 1)
			ResourcesManager.instance.AddToWorkWood();
	}
	
	public void WoodReduceWorking(){
		if (ResourcesManager.instance.GetWoodWorking() >= 1)
			ResourcesManager.instance.ReduceToWorkWood();
	}
#endregion

#region ShipsPanel
	public void ShipsAddWorking(){
		if (ResourcesManager.instance.GetCitizens() >= 1)
			ResourcesManager.instance.AddToWorkShips();
	}
	
	public void ShipsReduceWorking(){
		if (ResourcesManager.instance.GetShipsWorking() >= 1)
			ResourcesManager.instance.ReduceToWorkShips();
	}
#endregion

#region TroopsPanel
	public void TroopsAddWorking(){
		if (ResourcesManager.instance.GetCitizens() >= 1)
			ResourcesManager.instance.AddToWorkTroops();
	}
	
	public void TroopsReduceWorking(){
		if (ResourcesManager.instance.GetTroopsWorking() >= 1)
			ResourcesManager.instance.ReduceToWorkTroops();
	}
#endregion
}
