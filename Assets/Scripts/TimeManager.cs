using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
	static public TimeManager instance;
	public Text display;
	private int time;

	// Use this for initialization
	void Start () {
		instance = this;
		time = 0;
		display.text = time.ToString();
	}
	
	public void AddTime(int value){
		time += value;
		
		display.text = time.ToString();
	}

	public int GetCurrentTime(){
		return time;
	}

	public void ForwardButton(){
		UIManager.instance.ClossAllPanels();
		time++;
		display.text = time.ToString();
	}
	
}
