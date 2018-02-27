using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownSecurity : Event{
	private int rand;
    public TownSecurity(){
		rand = Random.Range(5, 11);
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
		b1text.text = "Plan";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Mano Dura";

		t.text = "¡La seguridad en tu ciudad!";
		d.text = "\nParece que el anterior jefeno se preocupo mucho por\n" +
				 "establecer seguridad en la ciudad\n";

		b1d.text = 	"Generar un plan de\n" +
					"seguridad completo\n";
		
		b2d.text = 	"Soldados patrullen las\n" +
					"calles y atrapen a cada\n" +
					"persona sospechosa";
    }

    protected override void Button1(Button b1, Button b2){
        ResourcesManager.instance.AddHonor(5);

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
