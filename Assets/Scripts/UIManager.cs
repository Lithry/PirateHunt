using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	static public UIManager instance;
	public GameObject cityUI;
	public GameObject objetivePanel;
	public GameObject troopsPanel;
	public Text troopsDisplay;
	public GameObject shipsPanel;
	public Button shipBuild;
	public Text shipsDisplay;
	public GameObject WoodPanel;
	public Text woodDisplay;
	public Text woodForNextTurnDisplay;
	public Slider woodSetter;
	public Text woodValue;
	public Text woodMaxValue;
	public GameObject goldPanel;
	public Text goldDisplay;
	public Text goldForNextTurnDisplay;
	public Slider goldSetter;
	public Text goldValue;
	public Text goldMaxValue;
	private int troopsCount;
	public Text troopsCountDisplay;
	public Text troopsGoldCost;
	public Button troopsAddButton;
	public Button troopsDeductButton;
	public Text troopsWoodForNexTurn;
	public Text troopsGoldForNexTurn;
	public Text foodDisplay;
	public Text citizenDisplay;

	void Awake () {
		instance = this;
		objetivePanel.SetActive(true);
		troopsPanel.SetActive(false);
		shipsPanel.SetActive(false);
		WoodPanel.SetActive(false);
		goldPanel.SetActive(false);
	}

	// DISPLAY OPTIONS =================================================================

	public void SetTroopsDisplay(int value){
		troopsDisplay.text = "x " + value.ToString();
	}

	public void SetShipsDisplay(int value){
		shipsDisplay.text = "x " + value.ToString();
	}
	
	public void SetWoodDisplay(int value){
		woodDisplay.text = "x " + value.ToString();
	}

	public void SetGoldDisplay(int value){
		goldDisplay.text = "x " + value.ToString();
	}
	
	public void SetFoodDisplay(int value){
		foodDisplay.text = "x " + value.ToString();
	}

	public void SetCitizenDisplay(int value){
		citizenDisplay.text = "x " + value.ToString();
	}

	public void CloseObjetivePanel(){
		objetivePanel.SetActive(false);
	}

	// =================================================================================
	// PANEL OPTIONS ===================================================================
	// GENERAL =========================================================================

	public void ClossAllPanels(){
		objetivePanel.SetActive(false);
		troopsPanel.SetActive(false);
		shipsPanel.SetActive(false);
		WoodPanel.SetActive(false);
		goldPanel.SetActive(false);
	}

	// TROOPS PANEL ====================================================================
	public void OpenTroopsPanel(){
		troopsCount = 0;
		troopsCountDisplay.text = troopsCount.ToString();
		troopsDeductButton.interactable = false;
		
		if (ResourcesManager.instance.GetShips() * TroopsSlots.TroopsForShip <= troopsCount + ResourcesManager.instance.GetTroops() || ResourcesManager.instance.GetCitizen() - troopsCount < 1)
				troopsAddButton.interactable = false;
		else
			troopsAddButton.interactable = true;
		
		troopsGoldCost.text = "0";
		troopsWoodForNexTurn.text = "- " + "0";
		troopsGoldForNexTurn.text = "- " + "0";
		shipsPanel.SetActive(false);
		WoodPanel.SetActive(false);
		goldPanel.SetActive(false);
		troopsPanel.SetActive(true);
	}

	public void AddTroops(){
		troopsCount++;

		if (troopsCount > 0)
			troopsDeductButton.interactable = true;
	
		if (ResourcesManager.instance.GetShips() * TroopsSlots.TroopsForShip <= troopsCount + ResourcesManager.instance.GetTroops() || ResourcesManager.instance.GetCitizen() - troopsCount < 1)
			troopsAddButton.interactable = false;

		troopsWoodForNexTurn.text = "- " + ResourcesManager.instance.GetEstimateWoodLostForNexTurn(troopsCount).ToString();
		troopsGoldForNexTurn.text = "- " + ResourcesManager.instance.GetEstimateGoldLostForNexTurn(troopsCount).ToString();
		troopsCountDisplay.text = troopsCount.ToString();
	}

	public void DeductTroops(){
		troopsCount--;

		troopsAddButton.interactable = true;

		if (!troopsDeductButton.interactable || troopsCount == 0)
			troopsDeductButton.interactable = false;

		troopsWoodForNexTurn.text = "- " + ResourcesManager.instance.GetEstimateWoodLostForNexTurn(troopsCount).ToString();
		troopsGoldForNexTurn.text = "- " + ResourcesManager.instance.GetEstimateGoldLostForNexTurn(troopsCount).ToString();
		troopsCountDisplay.text = troopsCount.ToString();
	}

	public void AcceptTroopsPanel(){
		if (troopsCount != 0){
			ResourcesManager.instance.AddTroops(troopsCount);
			ResourcesManager.instance.ReduceCitizen(troopsCount);
	
			troopsCount = 0;
			troopsCountDisplay.text = troopsCount.ToString();
			troopsWoodForNexTurn.text = "- 0";
			troopsGoldForNexTurn.text = "- 0";

			if (ResourcesManager.instance.GetShips() * TroopsSlots.TroopsForShip <= troopsCount + ResourcesManager.instance.GetTroops() || ResourcesManager.instance.GetCitizen() - troopsCount < 1)
					troopsAddButton.interactable = false;

			troopsDeductButton.interactable = false;
		}
	}

	public void CancelTroopsPanel(){
		troopsPanel.SetActive(false);
	}

	// =================================================================================
	// SHIPS PANEL =====================================================================

	public void OpenShipsPanel(){
		troopsPanel.SetActive(false);
		WoodPanel.SetActive(false);
		goldPanel.SetActive(false);
		shipBuild.interactable = true;

		if (ShipsCost.WoodCost > ResourcesManager.instance.GetWood()){
			shipBuild.interactable = false;
		}

		shipsPanel.SetActive(true);
	}

	public void ShipsBuild(){
		ResourcesManager.instance.AddShip(1);
		ResourcesManager.instance.ReduceWood(ShipsCost.WoodCost);
		
		if (ShipsCost.WoodCost > ResourcesManager.instance.GetWood()){
			shipBuild.interactable = false;
		}
	}

	public void CancelShipsPanel(){
		shipsPanel.SetActive(false);
	}

	// =================================================================================
	// WOOD PANEL ======================================================================

	public void OpenWoodPanel(){
		troopsPanel.SetActive(false);
		shipsPanel.SetActive(false);
		goldPanel.SetActive(false);

		woodForNextTurnDisplay.text = "+ " + ResourcesManager.instance.GetWoodForNextTunr();

		woodSetter.maxValue = (float)ResourcesManager.instance.GetCitizen();

		WoodPanel.SetActive(true);
	}

	public void WoodChangePanel(){
		ResourcesManager.instance.SetWoodForNextTunr(woodSetter.value);
		woodForNextTurnDisplay.text = "+ " + ResourcesManager.instance.GetWoodForNextTunr();
		TimeManager.instance.SetResourcesForNextTurnDisplay();
	}

	public void CancelWoodPanel(){
		WoodPanel.SetActive(false);
	}

	// =================================================================================
	// GOLD PANEL ======================================================================

	public void OpenGoldPanel(){
		troopsPanel.SetActive(false);
		shipsPanel.SetActive(false);
		WoodPanel.SetActive(false);

		goldForNextTurnDisplay.text = "+ " + ResourcesManager.instance.GetGoldForNextTunr();

		goldSetter.maxValue = (float)ResourcesManager.instance.GetCitizen();
		
		goldPanel.SetActive(true);
	}

	public void GoldChangePanel(){
		ResourcesManager.instance.SetGoldForNextTunr(goldSetter.value);
		goldForNextTurnDisplay.text = "+ " + ResourcesManager.instance.GetGoldForNextTunr();
		TimeManager.instance.SetResourcesForNextTurnDisplay();
	}

	public void CancelGoldPanel(){
		goldPanel.SetActive(false);
	}

	// =================================================================================
	// GAMEOVER OPTIONS ================================================================

	public void Restart(){
		SceneManager.LoadScene("Pirate Hunt");
	}

	public void Quit(){
		Application.Quit();
	}
}
