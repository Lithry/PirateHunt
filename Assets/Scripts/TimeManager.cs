using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
	static public TimeManager instance;
	public Text display;
	private int time;
	private int timeOfLastEvent;

	// Use this for initialization
	void Start () {
		instance = this;
		time = 0;
		timeOfLastEvent = time;
		display.text = (time - timeOfLastEvent).ToString();
	}
	
	public void AddTime(int value){
		time += value;
		display.text = (time - timeOfLastEvent).ToString();

		EventManager.instance.CheckEvents();
	}

	public int GetCurrentTime(){
		return time;
	}

	public void ForwardButton(){
		UIManager.instance.ClossAllPanels();
		time++;
		display.text = (time - timeOfLastEvent).ToString();

		EventManager.instance.CheckEvents();
	}

	public int GetTimeOfLastEvent(){
		return timeOfLastEvent;
	}
	
	public void EventLaunched(){
		timeOfLastEvent = time;
		display.text = (time - timeOfLastEvent).ToString();
	}
	
}
