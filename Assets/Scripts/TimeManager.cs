using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
	static public TimeManager instance;
	public Text display;
	private int time;
	private int timeOfLastEvent;
	public Text woodDisplay;
	public Text goldDisplay;

	// Use this for initialization
	void Awake () {
		instance = this;
		time = 0;
		timeOfLastEvent = time;
		display.text = time.ToString();
	}

	public int GetCurrentTime(){
		return time;
	}

	public void ForwardButton(){
		UIManager.instance.ClossAllPanels();
		time++;
		display.text = time.ToString();
		ResourcesManager.instance.TurnPassed();
		EventManager.instance.CheckEvents();
	}

	public int GetTimeOfLastEvent(){
		return timeOfLastEvent;
	}
	
	public void EventLaunched(){
		timeOfLastEvent = time;
	}

	public void SetResourcesForNextTurnDisplay(){
		woodDisplay.text = "+ " + ResourcesManager.instance.GetWoodForNextTunr();
		goldDisplay.text = "+ " + ResourcesManager.instance.GetGoldForNextTunr();
	}
	
}
