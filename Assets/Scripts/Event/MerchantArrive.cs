using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantArrive : Event{
    private int random;
	private int lastTime = 0;
	private int wood;
	private int gold;
	
	public MerchantArrive(){}

    public override Event CheckEvent(){
        random = Random.Range(1, 101);

		if (random <= 15 && TimeManager.instance.GetCurrentTime() - lastTime >= 5 && ResourcesManager.instance.GetGold() >= 25)
			return this;
		else
			return null;
    }

    public override void PlayEvent(Text t, Text d, Text b1d, Button b1, Text b1text, Text b2d, Button b2, Text b2text){
		TimeManager.instance.EventLaunched();
		lastTime = TimeManager.instance.GetCurrentTime();
		
		b1.onClick.AddListener(delegate{Button1(b1, b2);});
		b1text.text = "Comerciar";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Deportar";

		t.text = "¡Comerciante llega a la ciudad!";
		d.text = "\nUn comerciante esta de paso y te ofrece madera\n\n";

		wood = Random.Range(10, 16);
		while (wood * 3 > ResourcesManager.instance.GetGold())
		{
			wood--;
		}
		gold = wood * 3;

		b1d.text = 	"\n\nMadera: + " + wood.ToString() +
				 	"\nOro: - " + gold.ToString();
		
		b2d.text = 	"\n\n\nMadera: + " + ((int)(wood / 2)).ToString();

    }

    protected override void Button1(Button b1, Button b2){
		ResourcesManager.instance.AddWood(wood);
		ResourcesManager.instance.ReduceGold(gold);
		
		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
    }

    protected override void Button2(Button b1, Button b2){
       	ResourcesManager.instance.AddWood((int)(wood / 2));
		
		ResourcesManager.instance.AddFear(2);

		EventManager.instance.EndEvent();
		
		b1.onClick.RemoveAllListeners();
		b2.onClick.RemoveAllListeners();
    }
}
