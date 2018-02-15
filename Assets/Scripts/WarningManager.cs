using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningManager : MonoBehaviour {
	static public WarningManager instance;
	public Image foodWarning;
	public Image woodPanelGoldWarning;
	public Image troopsPanelGoldWarning;
	public Image shipsPanelGoldWarning;
	public Image shipsPanelWoodWarning;
	public Image foodPanelGoldWarning;

	void Awake () {
		instance = this;
		foodWarning.enabled = false;
		woodPanelGoldWarning.enabled = false;
		troopsPanelGoldWarning.enabled = false;
		shipsPanelGoldWarning.enabled = false;
		shipsPanelWoodWarning.enabled = false;
		foodPanelGoldWarning.enabled = false;
	}
	
	void Update () {
		
	}

	public void CheckWarnings(){
		if (ResourcesManager.instance.GetTroops() > 0 && ResourcesManager.instance.GetFood() < 1 && ResourcesManager.instance.GetFoodForNextTurn () < 0.1f){
			foodWarning.enabled = true;
		}
		else{
			foodWarning.enabled = false;
		}

		if (ResourcesManager.instance.GetWoodWorking() > 0 && ResourcesManager.instance.GetGold() < 1 && ResourcesManager.instance.GetGoldForNextTurn() < 0.1f){
			woodPanelGoldWarning.enabled = true;
		}
		else{
			woodPanelGoldWarning.enabled = false;
		}

		if (ResourcesManager.instance.GetTroopsWorking() > 0 && ResourcesManager.instance.GetGold() < 1 && ResourcesManager.instance.GetGoldForNextTurn() < 0.1f){
			troopsPanelGoldWarning.enabled = true;
		}
		else{
			troopsPanelGoldWarning.enabled = false;
		}

		if (ResourcesManager.instance.GetShipsWorking() > 0 && ResourcesManager.instance.GetGold() < 1 && ResourcesManager.instance.GetGoldForNextTurn() < 0.1f){
			shipsPanelGoldWarning.enabled = true;
		}
		else{
			shipsPanelGoldWarning.enabled = false;
		}

		if (ResourcesManager.instance.GetShipsWorking() > 0 && ResourcesManager.instance.GetWood() < 1 && ResourcesManager.instance.GetWoodForNextTurn() < 0.1f){
			shipsPanelWoodWarning.enabled = true;
		}
		else{
			shipsPanelWoodWarning.enabled = false;
		}

		if (ResourcesManager.instance.GetFoodWorking() > 0 && ResourcesManager.instance.GetGold() < 1 && ResourcesManager.instance.GetGoldForNextTurn() < 0.1f){
			foodPanelGoldWarning.enabled = true;
		}
		else{
			foodPanelGoldWarning.enabled = false;
		}
	}
}
