using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	static public UIManager instance;
	public GameObject cityUI;
	public GameObject combatUI;
	public GameObject objetivePanel;
	public Text troopsDisplay;
	public Text honorDisplay;
	public Text fearDisplay;
	public Text idleDisplay;
	public Text goldDisplay;
	public GameObject troopsPanel;
	private int troopsCount;
	public Text troopsCountDisplay;
	public Text troopsGoldCost;
	public Button troopsAddButton;
	public Button troopsDeductButton;

	void Awake () {
		instance = this;
		combatUI.SetActive(false);
		objetivePanel.SetActive(true);
		troopsPanel.SetActive(false);
	}

	// DISPLAY OPTIONS =================================================================

	public void SetTroopsDisplay(int value){
		troopsDisplay.text = "x " + value.ToString();
	}

	public void SetHonorDisplay(int value){
		honorDisplay.text = "x " + value.ToString();
	}
	
	public void SetFearDisplay(int value){
		fearDisplay.text = "x " + value.ToString();
	}
	
	public void SetIdleDisplay(int value){
		idleDisplay.text = "x " + value.ToString();
	}

	public void SetGoldDisplay(int value){
		goldDisplay.text = "x " + value.ToString();
	}

	public void CloseObjetivePanel(){
		objetivePanel.SetActive(false);
	}

	// =================================================================================
	// PANEL OPTIONS ===================================================================

	public void OpenTroopsPanel(){
		troopsCount = 0;
		troopsCountDisplay.text = troopsCount.ToString();
		troopsDeductButton.interactable = false;
		
		if (ResourcesManager.instance.GetGold() < Mathf.Abs(TroopsCost.Gold) * (troopsCount + 1))
				troopsAddButton.interactable = false;
		
		troopsGoldCost.text = "0";
		troopsPanel.SetActive(true);
	}

	public void AddTroops(){
		troopsCount++;

		if (troopsCount > 0)
			troopsDeductButton.interactable = true;
	
		if (ResourcesManager.instance.GetGold() < Mathf.Abs(TroopsCost.Gold) * (troopsCount + 1))
			troopsAddButton.interactable = false;

		troopsGoldCost.text = (Mathf.Abs(TroopsCost.Gold) * troopsCount).ToString();
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

		troopsCount = 0;
		troopsCountDisplay.text = troopsCount.ToString();
		troopsGoldCost.text = (Mathf.Abs(TroopsCost.Gold) * troopsCount).ToString();
		if (ResourcesManager.instance.GetGold() < Mathf.Abs(TroopsCost.Gold) * (troopsCount + 1))
				troopsAddButton.interactable = false;
		troopsDeductButton.interactable = false;
	}

	public void CancelTroopsPanel(){
		troopsPanel.SetActive(false);
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
