using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSetter {
	public List<Event> SetEvents(){
		List<Event> events = new List<Event>();

		Event pAtack1 = new PirateEncounter1();
		events.Add(pAtack1);

		Event pAtack2 = new PirateEncounter2(pAtack1);
		events.Add(pAtack2);

		Event boss = new BossEncounter(pAtack2);
		events.Add(boss);

		Event endGame = new EndGame(boss);
		events.Add(endGame);

		return events;
	}
}
