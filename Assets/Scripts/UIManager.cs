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
	public Button ship1Pay;
	public Button ship5Pay;
	public Text shipsDisplay;
	public GameObject resourcesPanel;
	public Text resourcesDisplay;
	public GameObject goldPanel;
	public Text goldDisplay;
	private int troopsCount;
	public Text troopsCountDisplay;
	public Text troopsGoldCost;
	public Button troopsAddButton;
	public Button troopsDeductButton;

	void Awake () {
		instance = this;
		objetivePanel.SetActive(true);
		troopsPanel.SetActive(false);
		shipsPanel.SetActive(false);
		resourcesPanel.SetActive(false);
		goldPanel.SetActive(false);
	}

	// DISPLAY OPTIONS =================================================================

	public void SetTroopsDisplay(int value){
		troopsDisplay.text = "x " + value.ToString();
	}

	public void SetShipsDisplay(int value){
		shipsDisplay.text = "x " + value.ToString();
	}
	
	public void SetResourcesDisplay(int value){
		resourcesDisplay.text = "x " + value.ToString();
	}

	public void SetGoldDisplay(int value){
		goldDisplay.text = "x " + value.ToString();
	}

	public void CloseObjetivePanel(){
		objetivePanel.SetActive(false);
	}

	// =================================================================================
	// PANEL OPTIONS ===================================================================
	// TROOPS PANEL ====================================================================
	public void OpenTroopsPanel(){
		troopsCount = 0;
		troopsCountDisplay.text = troopsCount.ToString();
		troopsDeductButton.interactable = false;
		
		if (ResourcesManager.instance.GetGold() < TroopsCost.Gold * (troopsCount + 1) || ResourcesManager.instance.GetTroops() >= TroopsSlots.TroopsForShip * ResourcesManager.instance.GetShips())
			troopsAddButton.interactable = false;
		else
			troopsAddButton.interactable = true;
		
		troopsGoldCost.text = "0";
		shipsPanel.SetActive(false);
		resourcesPanel.SetActive(false);
		goldPanel.SetActive(false);
		troopsPanel.SetActive(true);
	}

	public void AddTroops(){
		troopsCount++;

		if (troopsCount > 0)
			troopsDeductButton.interactable = true;
	
		if (ResourcesManager.instance.GetGold() < TroopsCost.Gold * (troopsCount + 1) || ResourcesManager.instance.GetShips() * TroopsSlots.TroopsForShip < ((troopsCount + 1) + ResourcesManager.instance.GetTroops()))
			troopsAddButton.interactable = false;

		troopsGoldCost.text = (TroopsCost.Gold * troopsCount).ToString();
		troopsCountDisplay.text = troopsCount.ToString();
	}

	public void DeductTroops(){
		troopsCount--;

		troopsAddButton.interactable = true;

		if (!troopsDeductButton.interactable || troopsCount == 0)
			troopsDeductButton.interactable = false;

		troopsGoldCost.text = (Mathf.Abs(TroopsCost.Gold) * troopsCount).ToString();
		troopsCountDisplay.text = troopsCount.ToString();
	}

	public void AcceptTroopsPanel(){
		ResourcesManager.instance.AddTroops(troopsCount);
		ResourcesManager.instance.ReduceGold(TroopsCost.Gold * troopsCount);
        ResourcesManager.instance.AddHonor(TroopsCost.Honor * troopsCount);
        ResourcesManager.instance.AddFear(TroopsCost.Fear * troopsCount);
        ResourcesManager.instance.ReduceIdle(TroopsCost.Idle * troopsCount);

		troopsCount = 0;
		troopsCountDisplay.text = troopsCount.ToString();
		troopsGoldCost.text = (Mathf.Abs(TroopsCost.Gold) * troopsCount).ToString();
		if (ResourcesManager.instance.GetGold() < Mathf.Abs(TroopsCost.Gold) * (troopsCount + 1))
				troopsAddButton.interactable = false;
		troopsDeductButton.interactable = false;

		TimeManager.instance.AddTime(2);
	}

	public void CancelTroopsPanel(){
		troopsPanel.SetActive(false);
	}

	// =================================================================================
	// SHIPS PANEL =====================================================================

	public void OpenShipsPanel(){
		troopsPanel.SetActive(false);
		resourcesPanel.SetActive(false);
		goldPanel.SetActive(false);

		if (ShipsCost.ResourcesCost > ResourcesManager.instance.GetResources()){
			ship1Pay.interactable = false;
			ship5Pay.interactable = false;
		}
		else if (ShipsCost.ResourcesCost * 5 > ResourcesManager.instance.GetResources()){
			ship5Pay.interactable = false;
		}

		shipsPanel.SetActive(true);
	}

	public void Ships1Pay(){
		ResourcesManager.instance.AddShip(1);
		ResourcesManager.instance.ReduceResources(ShipsCost.ResourcesCost);
		ResourcesManager.instance.AddHonor(ShipsCost.HonorIfPay);
		TimeManager.instance.AddTime(1);
		
		if (ShipsCost.ResourcesCost > ResourcesManager.instance.GetResources()){
			ship1Pay.interactable = false;
			ship5Pay.interactable = false;
		}
		else if (ShipsCost.ResourcesCost * 5 > ResourcesManager.instance.GetResources()){
			ship5Pay.interactable = false;
		}
	}

	public void Ships5Pay(){
		ResourcesManager.instance.AddShip(5);
		ResourcesManager.instance.ReduceResources((ShipsCost.ResourcesCost * 5) - (((ShipsCost.ResourcesCost * 5) / 100) * ShipsCost.DiscountForMassProduct));
		ResourcesManager.instance.AddHonor(ShipsCost.HonorIfPay * 5);
		TimeManager.instance.AddTime(3);

		if (ShipsCost.ResourcesCost > ResourcesManager.instance.GetResources()){
			ship1Pay.interactable = false;
			ship5Pay.interactable = false;
		}
		else if (ShipsCost.ResourcesCost * 5 > ResourcesManager.instance.GetResources()){
			ship5Pay.interactable = false;
		}
	}

	public void Ships1Force(){
		ResourcesManager.instance.AddShip(1);
		ResourcesManager.instance.AddFear(ShipsCost.FearIfForce);
		TimeManager.instance.AddTime(1);
	}

	public void Ships5Force(){
		ResourcesManager.instance.AddShip(5);
		ResourcesManager.instance.AddFear(ShipsCost.FearIfForce * 5);
		TimeManager.instance.AddTime(3);
	}

	public void CancelShipsPanel(){
		shipsPanel.SetActive(false);
	}

	// =================================================================================
	// RESOURCES PANEL =================================================================

	public void OpenResourcesPanel(){
		troopsPanel.SetActive(false);
		shipsPanel.SetActive(false);
		goldPanel.SetActive(false);
		resourcesPanel.SetActive(true);
	}

	public void AcceptResourcesPanel(){

	}

	public void CancelResourcesPanel(){
		resourcesPanel.SetActive(false);
	}

	// =================================================================================
	// GOLD PANEL ======================================================================

	public void OpenGoldPanel(){
		troopsPanel.SetActive(false);
		shipsPanel.SetActive(false);
		resourcesPanel.SetActive(false);
		goldPanel.SetActive(true);
	}

	public void AcceptGoldPanel(){

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
