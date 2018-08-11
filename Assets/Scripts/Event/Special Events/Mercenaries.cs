using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mercenaries : Event{
    private int rand;
    public Mercenaries(){
		rand = Random.Range(50, 61);
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
		b1text.text = "Liberar";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Mantener";

		t.text = "¡Mercenarios Borrachos!";
		d.text = "Un grupo de mercenarios borrachos causo problemas en las calles y fueron encarcelados.\n" +
				 "Por suerte no causaron ningun problema mayor y nadie salio herido";
				 

		b1d.text = 	"\nLos liberas bajo advertencia\n";
		
		b2d.text = 	"Lo mantienes encarceladoy lo haces publico para mantener a otros mercenarios bajo control";
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
