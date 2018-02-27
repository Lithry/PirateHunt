using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {
	static public EventManager instance;
	private List<Event> nEvent = new List<Event>();
	private List<Event> sEvent = new List<Event>();
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
	public Button forwardButton;
	
	void Awake () {
		instance = this;
		button1Text = button1.GetComponentInChildren<Text>();
		button2Text = button2.GetComponentInChildren<Text>();
		SetEvents();
	}
	
	public void SetEvents(){
		nEvent = setter.SetEvents();
		sEvent = setter.SetSpecialEvents();
	}

	public void CheckEvents(){
		bool special = false;
		for (int i = 0; i < sEvent.Count; i++){
			eventActive = sEvent[i].CheckEvent();
			if (eventActive != null){
				forwardButton.interactable = false;
				eventActive.PlayEvent(eventTitle, eventDescription, eventB1Text, button1, button1Text, eventB2Text ,button2, button2Text);
				eventPanel.SetActive(true);
				eventActive = null;
				special = true;
				break;
			}
		}

		for (int i = 0; i < nEvent.Count; i++){
			if (special == false){
				eventActive = nEvent[i].CheckEvent();
				if (eventActive != null){
					forwardButton.interactable = false;
					eventActive.PlayEvent(eventTitle, eventDescription, eventB1Text, button1, button1Text, eventB2Text ,button2, button2Text);
					eventPanel.SetActive(true);		
					eventActive = null;
					break;
				}
			}
			else
				break;
		}
	}

	public void EndEvent(){
		eventPanel.SetActive(false);
		forwardButton.interactable = true;
	}
}
