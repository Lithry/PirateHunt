using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEncounter : Event {
	private int maxAtTime = 7;
	private int probability;
	private int random;
	private Event requiredEvent;
	private int shipsNumber;
	private int pirateNumber;
	private int resourcesReward;
	private int goldReward;
	private int shipReward;
	private int troopLost;
	private int honorReward;

    public BossEncounter(Event requiredEvent) : base(){
		this.requiredEvent = requiredEvent;
	}

	override public Event CheckEvent(){
		probability = TimeManager.instance.GetCurrentTime() - TimeManager.instance.GetTimeOfLastEvent();
		probability = (probability * 100) / maxAtTime;
		random = Random.Range(1, 101);


		if (random <= probability && requiredEvent.Count() >= 1 && ResourcesManager.instance.GetTroops() >= 40){
			return this;
		}
		else{
			return null;
		}
	}

    public override void PlayEvent(Text t, Button b1, Text b1text, Button b2, Text b2text){
		shipsNumber = Random.Range(4, 8);
		pirateNumber = Random.Range((int)(TroopsSlots.TroopsForShip / 2) + 5, TroopsSlots.TroopsForShip + 1) * shipsNumber;

		resourcesReward = (80 + Random.Range(-15, 16)) * shipsNumber;
		if (shipsNumber >= 2){
			shipReward = (int)Random.Range(2.5f, 4.5f);
		}
		else
			shipReward = 1;
		
		goldReward = 200 + (int)(pirateNumber / 4) + Random.Range(0, 12) + Random.Range(10, 21);
		
		troopLost = (pirateNumber + 15) - ResourcesManager.instance.GetTroops();
		if (troopLost < 0)
			troopLost = 0;
		else if (troopLost > ResourcesManager.instance.GetTroops())
			troopLost = ResourcesManager.instance.GetTroops();

		honorReward = 5;

		b1.onClick.AddListener(delegate{Button1(b1, b2);});
		b1text.text = "Atacar";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Ignorar";

		t.text = "Te has encontrado con la flota del Jefe Pirata!!!\nParece que está compuesta " +
				 "por " + shipsNumber.ToString() + " barcos con " + 
				  pirateNumber.ToString() + " piratas.\n" + 
				 "Es una flota grande y podemos sufrir pérdidas, pero es también la oportunidad " + 
				 "de acabar con los piratas de estos mares!.\n\n" + 
				 "\t--Recompensa por destruirlos--\nRecursos: " + resourcesReward.ToString() +
				 "\nBarcos: " + shipReward.ToString() + "\nOro: " + goldReward.ToString() + "\n\n" +
				 "\t--Pérdidas por combate--\nTropas: " + troopLost.ToString();
		
		
		TimeManager.instance.EventLaunched();
    }

	override protected void Button1(Button b1, Button b2){
		count++;
		ResourcesManager.instance.ReduceTroops(troopLost);
		ResourcesManager.instance.AddWood(resourcesReward);
		ResourcesManager.instance.AddShip(shipReward);
		ResourcesManager.instance.AddGold(goldReward);
		ResourcesManager.instance.AddHonor(honorReward);
		
		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
	}

	override protected void Button2(Button b1, Button b2){
		ResourcesManager.instance.AddFear(honorReward + 5);

		EventManager.instance.EndEvent();

		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
	}
}