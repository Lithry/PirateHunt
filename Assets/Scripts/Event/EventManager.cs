using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {
	static public EventManager instance;
	private List<Event> eventList = new List<Event>();
	private EventSetter setter = new EventSetter();
	private Event eventActive;
	public GameObject eventPanel;
	public Text eventTitle;
	public Text eventDescription;
	public Text eventB1Text;
	public Text eventB2Text;
	public Button button1;
	private Text button1Text;
	public Button button2;
	private Text button2Text;
	public Button troopsButton;
	public Button shipsButton;
	public Button resourcesButton;
	public Button goldButton;
	public Button forwardButton;
	
	void Awake () {
		instance = this;
		button1Text = button1.GetComponentInChildren<Text>();
		button2Text = button2.GetComponentInChildren<Text>();
		SetEvents();
	}
	
	public void SetEvents(){
		eventList = setter.SetEvents();
	}

	public void CheckEvents(){
		for (int i = 0; i < eventList.Count; i++){
			eventActive = eventList[i].CheckEvent();
			if (eventActive != null){
				troopsButton.interactable = false;
				shipsButton.interactable = false;
				resourcesButton.interactable = false;
				goldButton.interactable = false;
				forwardButton.interactable = false;
				eventActive.PlayEvent(eventTitle, eventDescription, eventB1Text, button1, button1Text, eventB2Text ,button2, button2Text);
				eventPanel.SetActive(true);		
				eventActive = null;
				break;
			}
		}
	}

	public void EndEvent(){
		eventPanel.SetActive(false);
		troopsButton.interactable = true;
		shipsButton.interactable = true;
		resourcesButton.interactable = true;
		goldButton.interactable = true;
		forwardButton.interactable = true;
	}
}
