using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : Event {
	private Event requiredEvent;
	private float honorLevel;
	private float fearLevel;
	private float diference;

    public EndGame(Event requiredEvent) : base(){
		this.requiredEvent = requiredEvent;
	}

	override public Event CheckEvent(){
		if (requiredEvent.Count() >= 1){
			return this;
		}
		else{
			return null;
		}
	}

    public override void PlayEvent(Text t, Button b1, Text b1text, Button b2, Text b2text){
		honorLevel = ResourcesManager.instance.GetHonorLevel();
		fearLevel = ResourcesManager.instance.GetFearLevel();

		b1.onClick.AddListener(delegate{Button1(b1, b2);});
		b1text.text = "Jugar\nNuevamente";
        b2.onClick.AddListener(delegate{Button2(b1, b2);});
		b2text.text = "Salir";

		if (honorLevel > fearLevel){
			diference = honorLevel - fearLevel;
			if (diference <= 0.10f){
				t.text = "Felisidades!!\nHas logrado destruir a los piratas que rondaban estos mares.\n\n" +
					 	 "En cuanto a tu ascenso, no has conseguido el apoyo necesario de la población.\n" +
					 	 "Tu reputación es mala y los ciudadanos han presentado quejas a tus superiores, " +
					 	 "haciendo que recibas un castigo de su parte, seguido de una relocalización a una " +
					 	 "isla deshabitada.\n\nMuchas Gracias por Jugar!";
			}
			else if (diference > 0.10f && diference < 0.50f){
				t.text = "Felisidades!!\nHas logrado destruir a los piratas que rondaban estos mares.\n\n" +
						 "En cuanto a tu ascenso, no has conseguido el apoyo necesario de la población.\n" +
						 "Por suerte, tu reputación no es tan mala, por lo que pudiste conservar el puesto " +
						 "de Capitán de flota.\n\nMuchas Gracias por Jugar!";
			}
			else if (diference >= 0.50f){
				t.text = "Felisidades!!\nHas logrado destruir a los piratas que rondaban estos mares.\n\n" +
						 "En cuanto a tu ascenso, lo has conseguido!.\n" +
						 "Tu reputación te precede y la población te alaba como un salvador!\nBienvenido al " +
						 "rango de Almirante!\n\nMuchas Gracias por Jugar!";
			}
		}
		else if (fearLevel > honorLevel){
			diference = fearLevel - honorLevel;
			if (diference <= 0.10f){
				t.text = "Felisidades!!\nHas logrado destruir a los piratas que rondaban estos mares.\n\n" +
					 	 "En cuanto a tu ascenso, no has conseguido el apoyo necesario de la población.\n" +
					 	 "Tu reputación es mala y los ciudadanos han presentado quejas a tus superiores, " +
					 	 "haciendo que recibas un castigo de su parte, seguido de una relocalización a una " +
					 	 "isla deshabitada.\n\nMuchas Gracias por Jugar!";
			}
			else if (diference > 0.10f && diference < 0.50f){
				t.text = "Felisidades!!\nHas logrado destruir a los piratas que rondaban estos mares.\n\n" +
						 "En cuanto a tu ascenso, no has conseguido el apoyo necesario de la población.\n" +
						 "Pero la población te teme lo suficiente, y utilizando el temor te lanzas a un " +
						 "nuevo camino, el del Tirano!!.\n\nMuchas Gracias por Jugar!";
			}
			else if (diference >= 0.50f){
				t.text = "Felisidades!!\nHas logrado destruir a los piratas que rondaban estos mares.\n\n" +
						 "En cuanto a tu ascenso, no has conseguido el apoyo necesario de la población.\n" +
						 "Más que apoyo, has ganado el odio de esta, y los ciudadanos se han levantado " +
						 "en armas para deshacerse de ti.\nPor suerte lograste escapar, convirtiendote luego " +
						 "en el nuevo Jefe Pirata de estos mares.\n\nMuchas Gracias por Jugar!";
			}
			
		}
		else{
			t.text = "Felisidades!!\nHas logrado destruir a los piratas que rondaban estos mares.\n\n" +
					 "En cuanto a tu ascenso, no has conseguido el apoyo necesario de la población.\n" +
					 "Tu reputación es mala y los ciudadanos han presentado quejas a tus superiores, " +
					 "haciendo que recibas un castigo de su parte, seguido de una relocalización a una " +
					 "isla deshabitada.\n\nMuchas Gracias por Jugar!";
		}
		
		
		count++;
		TimeManager.instance.EventLaunched();
    }

	override protected void Button1(Button b1, Button b2){
		SceneManager.LoadScene("Pirate Hunt");
	}

	override protected void Button2(Button b1, Button b2){
		Application.Quit();
	}
}