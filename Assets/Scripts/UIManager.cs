using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	static public UIManager instance;
	// Use this for initialization
	void Start () {
		instance = this;
	}
#region Display
	public Text citizensDisplay;
	public Text foodDisplay;
	public Text foodWorkingDisplay;
	public Text foodPerNextTurnDisplay;

	public void CitizensDisplay(float value){
		citizensDisplay.text = "x " + value.ToString("F1");
	}
	
	public void FoodDisplay(float value){
		foodDisplay.text = value.ToString("F1");
	}

	public void FoodWorkingDisplay(float value){
		foodWorkingDisplay.text = value.ToString("F0");
	}

	public void FoodPerNextTurnDisplay(float value){
		foodPerNextTurnDisplay.text = "+ " + value.ToString("F1");
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

}
