﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSetter {
	public List<Event> SetEvents(){
		List<Event> events = new List<Event>();

		Event pAtack1 = new PirateEncounter1();
		events.Add(pAtack1);

		Event pAtack2 = new PirateEncounter2(pAtack1);
		events.Add(pAtack2);

		Event merchant = new MerchantArrive();
		events.Add(merchant);

		Event refugees = new RefugeesAarrive();
		events.Add(refugees);
		
		Event endGame = new EndGame();
		events.Add(endGame);

		return events;
	}

	public List<Event> SetSpecialEvents(){
		List<Event> events = new List<Event>();

		Event tSecurity = new TownSecurity();
		events.Add(tSecurity);

		Event diseaseFall = new DiseaseFall();
		events.Add(diseaseFall);

		Event traitor = new Traitor();
		events.Add(traitor);

		Event mercenaries = new Mercenaries();
		events.Add(mercenaries);

		Event spy = new Spy();
		events.Add(spy);

		Event boss = new BossEncounter();
		events.Add(boss);
		
		return events;
	}
}
