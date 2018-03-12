using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : Event {
	private float honorLevel;
	private float fearLevel;
	private float diference;
	private string honorName;
	private string fearName;

    public EndGame(){}

	override public Event CheckEvent(){
		if (TimeManager.instance.GetCurrentTime() >= 100){
			return this;
		}
		else{
			return null;
		}
	}

    public override void PlayEvent(Text t, Text d, Text b1d, Button b1, Text b1text, Text b2d, Button b2, Text b2text){
		TimeManager.instance.EventLaunched();
		
		b1.onClick.AddListener(delegate{Button1(b1, b2);});
		b1text.text = "Nuevo Juego";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Menu Principal";

		honorLevel = ResourcesManager.instance.GetHonorLevel();
		fearLevel = ResourcesManager.instance.GetFearLevel();

		CheckNames();
		
		if (fearLevel == 1.0f){
			t.text = "¡Fin de tu camino!";
			d.text = "Un inspector te ha estado investigando y reunio las pruevas necesarias para encarcelarte\n\n" +
					 "Titulo: El " + honorName + " " + fearName;
		}
		else if (honorLevel == 1.0f){
			t.text = "¡Conseguiste tu aumento!";
			d.text = "Has logrado conseguir el aumento a Almirante que tanto anhelabas!\n\n" +
					 "Titulo: El " + honorName + " " + fearName;
		}
		else{
			t.text = "¡Fin de tu camino!";
			d.text = "Há pasado un tiempo y aunque no hayas logrado conseguir el aumento a Almirante que tanto anhelabas, la\n" +
					 "población ya conoce tu carácter... ¡y hasta te dieron un apodo!\n" +
					 "Apodo: El " + honorName + " " + fearName;
		}

		b1d.text = 	"";
		b2d.text = 	"";
    }

	override protected void Button1(Button b1, Button b2){
		SceneManager.LoadScene("Pirate Hunt");
	}

	override protected void Button2(Button b1, Button b2){
		SceneManager.LoadScene("Menu");
	}

	private void CheckNames(){
		if (honorLevel < 0.2f)
			honorName = "Don Nadie";
		else if (honorLevel >= 0.2f && honorLevel < 0.4f)
			honorName = "Amable";
		else if (honorLevel >= 0.4f && honorLevel < 0.6f)
			honorName = "Carismatico";
		else if (honorLevel >= 0.6f && honorLevel < 0.8f)
			honorName = "Santo";
		else if (honorLevel >= 0.8f)
			honorName = "General";
		else if (honorLevel >= 1.0f)
			honorName = "Almirante";

		if (fearLevel < 0.2f)
			fearName = "Implacable";
		else if (fearLevel >= 0.2f && fearLevel < 0.4f)
			fearName = "Travieso";
		else if (fearLevel >= 0.4f && fearLevel < 0.6f)
			fearName = "Criminal";
		else if (fearLevel >= 0.6f && fearLevel < 0.8f)
			fearName = "Corrupto";
		else if (fearLevel >= 0.8f)
			fearName = "Demoniaco";
	}
}