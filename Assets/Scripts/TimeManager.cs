using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
	static public TimeManager instance;
	public Text display;
	private int time;
	private int timeOfLastEvent;

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
}
