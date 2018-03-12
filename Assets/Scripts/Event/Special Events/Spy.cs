using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spy : Event{
	private int rand;
    public Spy(){
		rand = Random.Range(70, 81);
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
		b1text.text = "Encarcelar";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Ejecutar";

		t.text = "¡Infiltrado!";
		d.text = "¡Has encontrado un infiltrado de los piratas en tu ciudad!\n" +
				 "Has logrado extraerle informacion sobre la guarida de los piratas\n" + 
				 "y solo te queda decidir como tratar con él";

		b1d.text = 	"\nLo encierras en el calabozo\n" +
					"hasta que muera\n";
		
		b2d.text = 	"Lo ejecutas publicamente\n" +
					"para mandarle un mensaje\n" +
					"a los piratas";
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
