using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefugeesAarrive : Event{
	private int random;
	private int lastTime;
	private int refugees;
	private int goldCost;
    public RefugeesAarrive(){}

    public override Event CheckEvent(){
       random = Random.Range(1, 101);

		if (random <= 15 && TimeManager.instance.GetCurrentTime() - lastTime >= 9 && ResourcesManager.instance.GetGold() >= 10)
			return this;
		else
			return null;
    }

    public override void PlayEvent(Text t, Text d, Text b1d, Button b1, Text b1text, Text b2d, Button b2, Text b2text){
		TimeManager.instance.EventLaunched();
		lastTime = TimeManager.instance.GetCurrentTime();
        
		b1.onClick.AddListener(delegate{Button1(b1, b2);});
		b1text.text = "Brindar apoyo";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Ignorar";

		refugees = Random.Range(1, 8);
		goldCost = (int)(refugees / 2);
		
		while (goldCost >= ResourcesManager.instance.GetGold())
		{
			goldCost--;
		}

		t.text = "¡Refugiados!";
		d.text = "Un grupo de " + refugees.ToString() + " refugiados a llegado a la ciudad\n\n";
		
			
		b1d.text = 	"\n\nOro: - " + goldCost.ToString() + 
					"\nAldeanos: + " + refugees.ToString();;
		
		b2d.text = 	"\n\n\nAldeanos: + " + ((int)(refugees / 2)).ToString();
		
    }

    protected override void Button1(Button b1, Button b2){
        ResourcesManager.instance.AddCitizens(refugees);
		ResourcesManager.instance.ReduceGold(goldCost);
		ResourcesManager.instance.AddHonor(1);

		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
    }

    protected override void Button2(Button b1, Button b2){
        ResourcesManager.instance.AddCitizens(((int)refugees / 2));
		ResourcesManager.instance.AddFear(1);

		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
    }
}
