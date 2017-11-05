using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateEncounter2 : Event {
	private int maxAtTime = 10;
	private int probability;
	private int random;
	private Event requiredEvent;
	private int shipsNumber;
	private int pirateNumber;
	private int resourcesReward;
	private int goldReward;
	private int shipReward;
	private int troopLost;
	private int idleReward;
	private int honorReward;

    public PirateEncounter2(Event requiredEvent) : base(){
		this.requiredEvent = requiredEvent;
	}

	override public Event CheckEvent(){
		probability = TimeManager.instance.GetCurrentTime() - TimeManager.instance.GetTimeOfLastEvent();
		probability = (probability * 100) / maxAtTime;
		random = Random.Range(1, 101);


		if (random <= probability && count <= 3 && requiredEvent.Count() >= 1){
			return this;
		}
		else{
			return null;
		}
	}

    public override void PlayEvent(Text t, Button b1, Text b1text, Button b2, Text b2text){
		shipsNumber = Random.Range(2, 4);
		pirateNumber = Random.Range((int)(TroopsSlots.TroopsForShip / 2), TroopsSlots.TroopsForShip + 1) * shipsNumber;

		resourcesReward = 50 + Random.Range(-5, 6) * shipsNumber;
		if (shipsNumber >= 2){
			shipReward = (int)Random.Range(0.0f, 1.3f);
		}
		else
			shipReward = 0;
		
		goldReward = 30 + (int)(pirateNumber / 4) + Random.Range(0, 12) + Random.Range(10, 21);
		troopLost = pirateNumber - ResourcesManager.instance.GetTroops();
		if (troopLost < 0)
			troopLost = 0;
		else if (troopLost > ResourcesManager.instance.GetTroops())
			troopLost = ResourcesManager.instance.GetTroops();

		idleReward = (int)(pirateNumber / 2);
		honorReward = 10;

		b1.onClick.AddListener(delegate{Button1(b1, b2);});
		b1text.text = "Atacar";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Ignorar";

		t.text = "Te has encontrado una flota pirata de " + shipsNumber.ToString() + " barcos con " + 
				  pirateNumber.ToString() + " piratas.\n" + 
				 "Es una flota normal de piratas, puede que estén regresando de saquear algún " + 
				 "barco mercante.\n\n\n" + 
				 "\t--Recompensa por destruirlos--\nRecursos: " + resourcesReward.ToString() +
				 "\nBarcos: " + shipReward.ToString() + "\nOro: " + goldReward.ToString() + "\n\n" +
				 "\t--Pérdidas por combate--\nTropas: " + troopLost.ToString();
		
		count++;
		TimeManager.instance.EventLaunched();
    }

	override protected void Button1(Button b1, Button b2){
		ResourcesManager.instance.ReduceTroops(troopLost);
		ResourcesManager.instance.AddResources(resourcesReward);
		ResourcesManager.instance.AddShip(shipReward);
		ResourcesManager.instance.AddGold(goldReward);
		ResourcesManager.instance.AddHonor(honorReward);
		
		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
	}

	override protected void Button2(Button b1, Button b2){
		ResourcesManager.instance.AddFear(honorReward);
		ResourcesManager.instance.AddIdle(idleReward);

		EventManager.instance.EndEvent();

		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
	}
}