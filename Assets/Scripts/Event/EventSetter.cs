using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSetter {
	public List<Event> SetEvents(){
		List<Event> events = new List<Event>();

		Event pAtack1 = new PirateEncounter1();
		events.Add(pAtack1);

		return events;
	}
}
