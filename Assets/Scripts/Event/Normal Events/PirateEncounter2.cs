using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateEncounter2 : Event {
	private int maxAtTime = 30;
	private int probability;
	private int random;
	private Event requiredEvent;
	private int woodReward;
	private int goldReward;
	private int pluss1;
	private int pluss2;
	private int troopLost;
	private int shipsLost;

    public PirateEncounter2(Event requiredEvent) : base(){
		this.requiredEvent = requiredEvent;
	}

	override public Event CheckEvent(){
		probability = TimeManager.instance.GetCurrentTime() - TimeManager.instance.GetTimeOfLastEvent();
		probability = (probability * 100) / maxAtTime;
		random = Random.Range(1, 101);


		if (random <= probability && count <= 3 && requiredEvent.Count() >= 2 && ResourcesManager.instance.GetShips() >= 4 && ResourcesManager.instance.GetTroops() >= 20 && TimeManager.instance.GetCurrentTime() > 50){
			return this;
		}
		else{
			return null;
		}
	}

    public override void PlayEvent(Text t, Text d, Text b1d, Button b1, Text b1text, Text b2d, Button b2, Text b2text){
		TimeManager.instance.EventLaunched();
		count++;
		
		b1.onClick.AddListener(delegate{Button1(b1, b2);});
		b1text.text = "Atrapar";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Matar";

		t.text = "¡Flota pirata avistada!";
		d.text = "\nUna de tus patrullas se ha encontrado una flota pirata\n\n";
		
		woodReward = Random.Range(5, 16);
		goldReward = Random.Range(7, 14);
		troopLost = Random.Range(3, 9);
		shipsLost = Random.Range(0, 2);
		pluss1 = Random.Range(1, 11);
		pluss2 = Random.Range(1, 11);
		
		while (troopLost + pluss1 >= ResourcesManager.instance.GetTroops())
		{
			if (troopLost > 0)
				troopLost--;
			else
				pluss1--;
		}

		b1d.text = 	"\nMadera: + " + woodReward.ToString() +
				 	"\nOro: + " + goldReward.ToString() +
				 	"\nTropas: - " + (troopLost + pluss1).ToString() +
					"\nShips: - " + shipsLost.ToString();
		
		b2d.text = 	"\nOro: + " + (goldReward + pluss2).ToString() +
				 	"\nTropas: - " + troopLost.ToString() +
					"\nShips: - " + (shipsLost + 1).ToString();
		
    }

	override protected void Button1(Button b1, Button b2){
		ResourcesManager.instance.ReduceTroops(troopLost + pluss1);
		ResourcesManager.instance.AddWood(woodReward);
		ResourcesManager.instance.AddGold(goldReward);
		ResourcesManager.instance.ReduceShips(shipsLost);
		
		ResourcesManager.instance.AddHonor(1);
		
		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
	}

	override protected void Button2(Button b1, Button b2){
		ResourcesManager.instance.ReduceTroops(troopLost);
		ResourcesManager.instance.AddGold(goldReward + pluss2);
		ResourcesManager.instance.ReduceShips(shipsLost + 1);
		
		ResourcesManager.instance.AddFear(1);
		
		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
	}
}