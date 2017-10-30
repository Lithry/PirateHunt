using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {
	static public EventManager instance;
	private List<Event> eventList;
	private EventSetter setter = new EventSetter();
	private Event eventActive;
	public GameObject eventPanel;
	public Text eventText;
	public Button button1;
	private Text button1Text;
	public Button button2;
	private Text button2Text;
	
	void Awake () {
		instance = this;
		button1Text = button1.GetComponentInChildren<Text>();
		button2Text = button2.GetComponentInChildren<Text>();
		eventList = setter.SetEvents();
	}
	
	public void CheckEvents(){
		for (int i = 0; i < eventList.Count; i++){
			eventActive = eventList[i].CheckEvent();
			if (eventActive != null){
				eventActive.PlayEvent(eventText, button1, button1Text, button2, button2Text);
				eventPanel.SetActive(true);		
				eventActive = null;
				break;
			}
		}
	}

	public void EndEvent(){
		eventPanel.SetActive(false);
	}
}
