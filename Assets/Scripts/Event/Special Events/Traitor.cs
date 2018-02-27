using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traitor : Event{
	private int rand;
    public Traitor(){
		rand = Random.Range(27, 41);
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

		t.text = "¡Traidor!";
		d.text = "¡Has encontrado un traidor entre tus lineas!\n" +
				 "Por suerte, el traidor no tenia ninguna informacion valiosa\n" + 
				 "que pudiera comprometer a tu ejercito";

		b1d.text = 	"Lo encierras en el\n" +
					"calabozo hasta que\n" +
					"reciba su sentencia";
		
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
