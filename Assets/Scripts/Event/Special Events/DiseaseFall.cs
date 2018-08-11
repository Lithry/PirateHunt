using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseFall : Event{
	private int rand;
    public DiseaseFall(){
		rand = Random.Range(15, 23);
	}

    public override Event CheckEvent(){
        if (rand == TimeManager.instance.GetCurrentTime()){
			return this;
		}
		else
			return null;
    }

    public override void PlayEvent(Text t, Text d, Text b1d, Button b1, Text b1text, Text b2d, Button b2, Text b2text){
        TimeManager.instance.EventLaunched();
		
		b1.onClick.AddListener(delegate{Button1(b1, b2);});
		b1text.text = "Tratar Enfermedad";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Destruir Enfermedad";

		t.text = "¡Nueva Enfermedad!";
		d.text = "¡Una enfermedad desconocida esta atacando la ciudad!\nUn desconocido se acerca a la guardia y dice conocer la cura";

		b1d.text = 	"Le crees al desconocido y tratas la enfermedad\n" +
					"Poblacion: -15%";
		
		b2d.text = 	"Poner en cuarentena la ciudad y separar los enfermos\n" +
					"Poblacion: -8%";
    }

    protected override void Button1(Button b1, Button b2){
        ResourcesManager.instance.AddHonor(5);

		ResourcesManager.instance.ReducePopulation(15);

		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
    }

    protected override void Button2(Button b1, Button b2){
        ResourcesManager.instance.AddFear(5);

		ResourcesManager.instance.ReducePopulation(8);

		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
    }
}
