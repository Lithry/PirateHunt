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
	public GameObject WoodPanel;
	public Button wood100Pay;
	public Button wood500Pay;
	public Text woodDisplay;
	public GameObject goldPanel;
	public Text timeToCollect;
	public Button goldCollectButton;
	private int lastCollectedTaxesTurn;
	public Text goldDisplay;
	private int troopsCount;
	public Text troopsCountDisplay;
	public Text troopsGoldCost;
	public Button troopsAddButton;
	public Button troopsDeductButton;
	public Text citizenDisplay;

	void Awake () {
		instance = this;
		lastCollectedTaxesTurn = 0;
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
		
		if (ResourcesManager.instance.GetGold() < TroopsCost.Gold * (troopsCount + 1) || ResourcesManager.instance.GetTroops() >= TroopsSlots.TroopsForShip * ResourcesManager.instance.GetShips())
			troopsAddButton.interactable = false;
		else
			troopsAddButton.interactable = true;
		
		troopsGoldCost.text = "0";
		shipsPanel.SetActive(false);
		WoodPanel.SetActive(false);
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
		if (troopsCount != 0){
			ResourcesManager.instance.AddTroops(troopsCount);
			ResourcesManager.instance.ReduceGold(TroopsCost.Gold * troopsCount);
	
			troopsCount = 0;
			troopsCountDisplay.text = troopsCount.ToString();
			troopsGoldCost.text = (Mathf.Abs(TroopsCost.Gold) * troopsCount).ToString();
			if (ResourcesManager.instance.GetGold() < Mathf.Abs(TroopsCost.Gold) * (troopsCount + 1))
					troopsAddButton.interactable = false;
			troopsDeductButton.interactable = false;
	
			TimeManager.instance.AddTime(1);
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
		ship1Pay.interactable = true;
		ship5Pay.interactable = true;

		if (ShipsCost.ResourcesCost > ResourcesManager.instance.GetWood()){
			ship1Pay.interactable = false;
			ship5Pay.interactable = false;
		}
		else if (((ShipsCost.ResourcesCost * 5) - (((ShipsCost.ResourcesCost * 5) / 100) * ShipsCost.DiscountForMassProduct)) > ResourcesManager.instance.GetWood()){
			ship5Pay.interactable = false;
		}

		shipsPanel.SetActive(true);
	}

	public void Ships1Pay(){
		ResourcesManager.instance.AddShip(1);
		ResourcesManager.instance.ReduceWood(ShipsCost.ResourcesCost);
		ResourcesManager.instance.AddHonor(ShipsCost.HonorIfPay);
		TimeManager.instance.AddTime(1);
		
		if (ShipsCost.ResourcesCost > ResourcesManager.instance.GetWood()){
			ship1Pay.interactable = false;
			ship5Pay.interactable = false;
		}
		else if (((ShipsCost.ResourcesCost * 5) - (((ShipsCost.ResourcesCost * 5) / 100) * ShipsCost.DiscountForMassProduct)) > ResourcesManager.instance.GetWood()){
			ship5Pay.interactable = false;
		}
	}

	public void Ships5Pay(){
		ResourcesManager.instance.AddShip(5);
		ResourcesManager.instance.ReduceWood((ShipsCost.ResourcesCost * 5) - (((ShipsCost.ResourcesCost * 5) / 100) * ShipsCost.DiscountForMassProduct));
		ResourcesManager.instance.AddHonor(ShipsCost.HonorIfPay * 5);
		TimeManager.instance.AddTime(1);

		if (ShipsCost.ResourcesCost > ResourcesManager.instance.GetWood()){
			ship1Pay.interactable = false;
			ship5Pay.interactable = false;
		}
		else if (((ShipsCost.ResourcesCost * 5) - (((ShipsCost.ResourcesCost * 5) / 100) * ShipsCost.DiscountForMassProduct)) > ResourcesManager.instance.GetWood()){
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
		TimeManager.instance.AddTime(1);
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
		wood100Pay.interactable = true;
		wood500Pay.interactable = true;

		if (ResourceCost.ResourcesCost100 > ResourcesManager.instance.GetGold()){
			wood100Pay.interactable = false;
			wood500Pay.interactable = false;
		}
		else if (((ResourceCost.ResourcesCost100 * 5) - (((ResourceCost.ResourcesCost100 * 5) / 100) * ResourceCost.DiscountForMassProduct)) > ResourcesManager.instance.GetGold()){
			wood500Pay.interactable = false;
		}

		WoodPanel.SetActive(true);
	}

	public void Resources100Pay(){
		ResourcesManager.instance.AddWood(100);
		ResourcesManager.instance.ReduceGold(ResourceCost.ResourcesCost100);
		ResourcesManager.instance.AddHonor(ResourceCost.HonorIfPay);
		TimeManager.instance.AddTime(1);
		
		if (ResourceCost.ResourcesCost100 > ResourcesManager.instance.GetGold()){
			wood100Pay.interactable = false;
			wood500Pay.interactable = false;
		}
		else if (((ResourceCost.ResourcesCost100 * 5) - (((ResourceCost.ResourcesCost100 * 5) / 100) * ResourceCost.DiscountForMassProduct)) > ResourcesManager.instance.GetGold()){
			wood500Pay.interactable = false;
		}
	}

	public void Resources500Pay(){
		ResourcesManager.instance.AddWood(500);
		ResourcesManager.instance.ReduceGold((ResourceCost.ResourcesCost100 * 5) - (((ResourceCost.ResourcesCost100 * 5) / 100) * ResourceCost.DiscountForMassProduct));
		ResourcesManager.instance.AddHonor(ResourceCost.HonorIfPay * 5);
		TimeManager.instance.AddTime(1);

		if (ResourceCost.ResourcesCost100 > ResourcesManager.instance.GetGold()){
			wood100Pay.interactable = false;
			wood500Pay.interactable = false;
		}
		else if (((ResourceCost.ResourcesCost100 * 5) - (((ResourceCost.ResourcesCost100 * 5) / 100) * ResourceCost.DiscountForMassProduct)) > ResourcesManager.instance.GetGold()){
			wood500Pay.interactable = false;
		}
	}

	public void Resources100Force(){
		ResourcesManager.instance.AddWood(100);
		ResourcesManager.instance.AddFear(ResourceCost.FearIfForce);
		TimeManager.instance.AddTime(1);
	}

	public void Resources500Force(){
		ResourcesManager.instance.AddWood(500);
		ResourcesManager.instance.AddFear(ResourceCost.FearIfForce * 5);
		TimeManager.instance.AddTime(1);
	}

	public void CancelResourcesPanel(){
		WoodPanel.SetActive(false);
	}

	// =================================================================================
	// GOLD PANEL ======================================================================

	public void OpenGoldPanel(){
		troopsPanel.SetActive(false);
		shipsPanel.SetActive(false);
		WoodPanel.SetActive(false);

		if (TimeManager.instance.GetCurrentTime() - lastCollectedTaxesTurn < Taxes.TimeToWait){
			goldCollectButton.interactable = false;
			timeToCollect.text = "Espera\n" + (Taxes.TimeToWait - (TimeManager.instance.GetCurrentTime() - lastCollectedTaxesTurn)).ToString() + " turnos";
		}
		else{
			goldCollectButton.interactable = true;
			timeToCollect.text = "Puedes\nRecolectar";
		}
		
		goldPanel.SetActive(true);
	}

	public void CollectTaxes(){
		ResourcesManager.instance.AddGold(Taxes.Gold);
		ResourcesManager.instance.AddHonor(Taxes.HonorIfCollected);
		lastCollectedTaxesTurn = TimeManager.instance.GetCurrentTime();
		goldCollectButton.interactable = false;
		timeToCollect.text = "Espera\n"+ (Taxes.TimeToWait - 1).ToString() + " turnos";
		TimeManager.instance.AddTime(1);
	}

	public void ForceTaxes(){
		ResourcesManager.instance.AddGold(Taxes.Gold);
		ResourcesManager.instance.AddFear(Taxes.FearIfForced);
		TimeManager.instance.AddTime(1);
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
