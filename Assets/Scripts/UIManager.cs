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
	public Text tropsDisplay;
	public Text honorDisplay;
	public Text fearDisplay;
	public Text idleDisplay;
	public Text goldDisplay;

	void Awake () {
		instance = this;
		combatUI.SetActive(false);
		objetivePanel.SetActive(true);
	}

	public void SetTropsDisplay(int value){
		tropsDisplay.text = "x " + value;
	}

	public void SetHonorDisplay(int value){
		honorDisplay.text = "x " + value;
	}
	
	public void SetFearDisplay(int value){
		fearDisplay.text = "x " + value;
	}
	
	public void SetIdleDisplay(int value){
		idleDisplay.text = "x " + value;
	}

	public void SetGoldDisplay(int value){
		goldDisplay.text = "x " + value;
	}

	public void CloseObjetivePanel(){
		objetivePanel.SetActive(false);
	}
	
	// QUEST OPTIONS ===================================================================


	// =================================================================================
	// COMBAT OPTIONS ==================================================================


	// =================================================================================
	// GAMEOVER OPTIONS ================================================================

	public void Restart(){
		SceneManager.LoadScene("Pirate Hunt");
	}

	public void Quit(){
		Application.Quit();
	}
}
