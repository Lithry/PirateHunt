﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	static public UIManager instance;
	public GameObject cityUI;
	public GameObject objetivePanel;
	public Text troopsDisplay;
	public GameObject honorPanel;
	public Text honorDisplay;
	public GameObject fearPanel;
	public Text fearDisplay;
	public GameObject idlePanel;
	public Text idleDisplay;
	public GameObject goldPanel;
	public Text goldDisplay;
	public GameObject troopsPanel;
	private int troopsCount;
	public Text troopsCountDisplay;
	public Text troopsGoldCost;
	public Button troopsAddButton;
	public Button troopsDeductButton;

	void Awake () {
		instance = this;
		objetivePanel.SetActive(true);
		troopsPanel.SetActive(false);
		honorPanel.SetActive(false);
		fearPanel.SetActive(false);
		idlePanel.SetActive(false);
		goldPanel.SetActive(false);
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
	// TROOPS PANEL ====================================================================
	public void OpenTroopsPanel(){
		troopsCount = 0;
		troopsCountDisplay.text = troopsCount.ToString();
		troopsDeductButton.interactable = false;
		
		if (ResourcesManager.instance.GetGold() < Mathf.Abs(TroopsCost.Gold) * (troopsCount + 1))
				troopsAddButton.interactable = false;
		
		troopsGoldCost.text = "0";
		honorPanel.SetActive(false);
		fearPanel.SetActive(false);
		idlePanel.SetActive(false);
		goldPanel.SetActive(false);
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

		TimeManager.instance.AddTime(2);
	}

	public void CancelTroopsPanel(){
		troopsPanel.SetActive(false);
	}

	// =================================================================================
	// HONOR PANEL =====================================================================

	public void OpenHonorPanel(){
		troopsPanel.SetActive(false);
		fearPanel.SetActive(false);
		idlePanel.SetActive(false);
		goldPanel.SetActive(false);
		honorPanel.SetActive(true);
		TimeManager.instance.AddTime(1);
	}

	public void AcceptHonorPanel(){

	}

	public void CancelHonorPanel(){
		honorPanel.SetActive(false);
	}

	// =================================================================================
	// Fear PANEL ======================================================================

	public void OpenFearPanel(){
		troopsPanel.SetActive(false);
		honorPanel.SetActive(false);
		idlePanel.SetActive(false);
		goldPanel.SetActive(false);
		fearPanel.SetActive(true);
		TimeManager.instance.AddTime(3);
	}

	public void AcceptFearPanel(){

	}

	public void CancelFearPanel(){
		fearPanel.SetActive(false);
	}

	// =================================================================================
	// IDLE PANEL ======================================================================

	public void OpenIdlePanel(){
		troopsPanel.SetActive(false);
		honorPanel.SetActive(false);
		fearPanel.SetActive(false);
		goldPanel.SetActive(false);
		idlePanel.SetActive(true);
	}

	public void AcceptIdlePanel(){

	}

	public void CancelIdlePanel(){
		idlePanel.SetActive(false);
	}

	// =================================================================================
	// GOLD PANEL ======================================================================

	public void OpenGoldPanel(){
		troopsPanel.SetActive(false);
		honorPanel.SetActive(false);
		fearPanel.SetActive(false);
		idlePanel.SetActive(false);
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
