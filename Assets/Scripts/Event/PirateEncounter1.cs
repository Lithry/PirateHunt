using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateEncounter1 : Event {
	private int maxAtTime = 10;
	private int probability;
	private int random;
	private int count = 0;
	private int pirateNumber;
	private int resourcesReward;
	private int goldReward;
	private int shipReward;
	private int troopLost;
	private int idleReward;
	private int honorReward;

    public PirateEncounter1() : base(){}

	override public Event CheckEvent(){
		probability = TimeManager.instance.GetCurrentTime() - TimeManager.instance.GetTimeOfLastEvent();
		probability = (probability * 100) / maxAtTime;
		random = Random.Range(1, 101);


		if (random <= probability && ResourcesManager.instance.GetTroops() > 10 && count < 4){
			return this;
		}
		else{
			return null;
		}
	}

    public override void PlayEvent(Text t, Button b1, Text b1text, Button b2, Text b2text){
		pirateNumber = Random.Range((int)(TroopsSlots.TroopsForShip / 2), TroopsSlots.TroopsForShip + 1);

		resourcesReward = 30 + Random.Range(-5, 6);
		shipReward = 0;
		goldReward = 15 + (int)(pirateNumber / 4) + Random.Range(0, 6) + Random.Range(5, 16);
		troopLost = pirateNumber - ResourcesManager.instance.GetTroops();
		if (troopLost < 0)
			troopLost = 0;
		idleReward = (int)(pirateNumber / 2);
		honorReward = 2 * (pirateNumber / 2);

		b1.onClick.AddListener(delegate{Button1(b1, b2);});
		b1text.text = "Atacar";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Ignorar";

		t.text = "Te has encontrado un barco con " + pirateNumber.ToString() + " piratas.\n\n\n" + 
				 "Es un grupo pequeño, puede que se halla separado de su flota por alguna razón, " + 
				 "o que esté investigando algo.\n\n\n\n\n" + 
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
		ResourcesManager.instance.AddIdle(idleReward);

		EventManager.instance.EndEvent();

		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
	}
}