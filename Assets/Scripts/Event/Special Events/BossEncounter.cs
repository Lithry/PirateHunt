using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEncounter : Event {
	private int rand;
	private int shipsNumber;
	private int pirateNumber;
	private int troopLost;
    public BossEncounter(){
		rand = Random.Range(90, 95);
    }

    public override Event CheckEvent(){
        if (rand == TimeManager.instance.GetCurrentTime()){
			return this;
		}
		else
			return null;
    }

    public override void PlayEvent(Text t, Text d, Text b1d, Button b1, Text b1text, Text b2d, Button b2, Text b2text){
        shipsNumber = Random.Range(4, 8);
		pirateNumber = Random.Range((int)(Ships.troopsPerShip / 2), Ships.troopsPerShip) * shipsNumber;

		troopLost = (pirateNumber) - (int)ResourcesManager.instance.GetTroops();
		if (troopLost < 0)
			troopLost = pirateNumber + Random.Range(-10, 11);
		
		if (troopLost > ResourcesManager.instance.GetTroops())
			troopLost = (int)ResourcesManager.instance.GetTroops();

		b1.onClick.AddListener(delegate{Button1(b1, b2);});
		b1text.text = "Atacar";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Dar información";
		
		t.text = "¡Escondite Pirata Encontrado!";
		d.text = "¡Has encontrado el escondite de los piratas!\n" +
				 "Segun te informan cuentan con " + shipsNumber.ToString() + " barcos y\n" + 
				 pirateNumber.ToString() + " piratas";

		b1d.text = 	"Atacar generara una\n" +
					"perdida de " + troopLost.ToString() + " tropas\n\n";
		
		b2d.text = 	"Lo ignoras y le pasas la\n" +
					"informacion a otra ciudad costera,\n" +
					"esperando que se encarge por tí";
		
		TimeManager.instance.EventLaunched();
    }

    protected override void Button1(Button b1, Button b2){
        ResourcesManager.instance.AddHonor(5);
		ResourcesManager.instance.ReduceTroops(troopLost);

		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
    }

    protected override void Button2(Button b1, Button b2){
        ResourcesManager.instance.AddFear(5);

		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
    }
}