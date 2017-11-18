using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
	public Button troopsButton;
	public GameObject troopsPanel;
	public GameObject troopsButton1;
	public Text troopsText1;
	public GameObject troopsButton2;
	public GameObject troopsButton3;
	public Button shipButton;
	public GameObject shipsPanel;
	public GameObject shipsButton1;
	public GameObject shipsButton2;
	public Button resourcesButton;
	public GameObject resourcesPanel;
	public GameObject resourcesButton1;
	public GameObject resourcesButton2;
	public Button resourcesButtonNo;
	public Button goldButton;
	public GameObject goldPanel;
	public GameObject goldButton1;
	public GameObject goldButton2;
	public Button forwardButton;
	public GameObject finger;
	public GameObject tutorialPanel;
	private RectTransform tutorialPanelTransform;
	public Text tutorialText;
	public GameObject objetivePanel;
	public GameObject godBabBar;
	private int steps;
	private int turn;
	private int currentGold;

	public GameObject eventPanel;
	public Text eventText;
	public Button button1;
	private Text button1Text;
	public Button button2;
	private Text button2Text;
	// Use this for initialization
	void Awake () {
		troopsButton.interactable = false;
		shipButton.interactable = false;
		resourcesButton.interactable = false;
		goldButton.interactable = false;
		forwardButton.interactable = false;
		resourcesButtonNo.interactable = false;
		tutorialPanelTransform = tutorialPanel.GetComponent<RectTransform>();
		tutorialPanel.SetActive(false);
		finger.SetActive(false);
		eventPanel.SetActive(false);
		steps = 0;
		turn = 0;

		button1Text = button1.GetComponentInChildren<Text>();
		button2Text = button2.GetComponentInChildren<Text>();
	}

	void Update(){
		if (!objetivePanel.activeSelf && steps == 0){
			tutorialPanelTransform.anchorMin = new Vector2(0.5f, 0.25f);
			tutorialPanelTransform.anchorMax = new Vector2(1f, 0.85f);
			tutorialPanelTransform.sizeDelta = Vector2.zero;
			tutorialPanelTransform.offsetMin = Vector2.zero;
			tutorialPanelTransform.offsetMax = Vector2.zero;
			tutorialText.text = "Bienvenido a la ciudad!\n\nEsta es la ciudad que debes proteger, para eso necesitarás " + 
								"tropas que te ayuden, pero para poder tener tropas tendrás que tener barcos en donde " + 
								"asentarlas.\nEmpecemos consiguiendo los recursos necesarios para construir algunos barcos!";
			tutorialPanel.SetActive(true);
			finger.transform.position = resourcesButton.transform.position;
			finger.SetActive(true);
			resourcesButton.interactable = true;
			steps = 1;
		}
		else if (resourcesPanel.activeSelf && steps == 1){
			tutorialPanelTransform.anchorMin = new Vector2(0.45f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.95f, 0.8f);
			tutorialText.text = "Tienes cuatro opciones para recolectar recursos, dos que den 100 y dos que dan 500.\n" + 
								"La diferencia entre ellas es la forma en que serán recolectados los recursos.\nEn una " +
								"le pagaras a los ciudadanos por su trabajo, en la otra pues... no. Pero ten cuidado! " +
								"Para llegar a ser Almirante, el apoyo de la población es indispensable!";
			troopsButton.interactable = false;
			shipButton.interactable = false;
			resourcesButton.interactable = false;
			resourcesButtonNo.interactable = false;
			goldButton.interactable = false;
			forwardButton.interactable = false;
			finger.transform.position = resourcesButton1.transform.position;
			steps = 2;
		}
		else if (ResourcesManager.instance.GetWood() != 0 && steps == 2){
			tutorialPanelTransform.anchorMin = new Vector2(0.3f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.65f, 0.8f);
			tutorialText.text = "\n\n\n\nCierra el panel luego de haber terminado.\n\n\n\n";
			finger.transform.position = resourcesButton2.transform.position;
			steps = 3;
		}
		else if (!resourcesPanel.activeSelf && steps == 3){
			tutorialPanelTransform.anchorMin = new Vector2(0.4f, 0.25f);
			tutorialPanelTransform.anchorMax = new Vector2(0.9f, 0.85f);
			tutorialText.text = "\n\n\n\nAhora que tienes recursos, pasa a construir un barco.\nLos barcos son lo que limita " +
								"las tropas que podras teren. por cada uno podras contratar 15 tropas.\n\n\n\n";
			shipButton.interactable = true;
			finger.transform.position = shipButton.transform.position;
			steps = 4;
		}
		else if (shipsPanel.activeSelf && steps == 4){
			tutorialPanelTransform.anchorMin = new Vector2(0.45f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.95f, 0.8f);
			tutorialText.text = "Aquí también tienes cuatro opciones, dos para construir un barco y otras dos para construir " +
								"cinco barcos\nAl igual que la recolección de recursos, tienes la opción de pagarle a la " +
								"los ciudadanos por su trabajo o no. Nuevamente, ten cuidado, que necesitarás el apoyo de los " +
								"ciudadanos para ascender";
			troopsButton.interactable = false;
			shipButton.interactable = false;
			resourcesButton.interactable = false;
			goldButton.interactable = false;
			forwardButton.interactable = false;
			finger.transform.position = shipsButton1.transform.position;
			steps = 5;
		}
		else if (ResourcesManager.instance.GetShips() != 0 && steps == 5){
			tutorialPanelTransform.anchorMin = new Vector2(0.2f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.65f, 0.8f);
			tutorialText.text = "\n\n\n\nAhora podes ir a reclutar tropas para tus barcos, vamos!\n\n\n\n";
			finger.transform.position = shipsButton2.transform.position;
			steps = 6;
		}
		else if (!shipsPanel.activeSelf && steps == 6){
			tutorialPanelTransform.anchorMin = new Vector2(0.2f, 0.25f);
			tutorialPanelTransform.anchorMax = new Vector2(0.6f, 0.85f);
			tutorialText.text = "\n\n\n\nAbre el panel de tropas.\n\n\n\n";
			troopsButton.interactable = true;
			finger.transform.position = troopsButton.transform.position;
			steps = 7;
		}
		else if (troopsPanel.activeSelf && steps == 7){
			tutorialPanelTransform.anchorMin = new Vector2(0.6f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.95f, 0.8f);
			tutorialText.text = "\n\n\n\nUtiliza el botón para agregar tropas.\nSubilo a 15.\n\n\n\n";
			troopsButton.interactable = false;
			shipButton.interactable = false;
			resourcesButton.interactable = false;
			goldButton.interactable = false;
			forwardButton.interactable = false;
			finger.transform.position = troopsButton1.transform.position;
			steps = 8;
		}
		else if (troopsText1.text == "15" && steps == 8){
			tutorialPanelTransform.anchorMin = new Vector2(0.2f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.6f, 0.8f);
			tutorialText.text = "\n\n\n\nContrata las tropas.\n\n\n\n";
			finger.transform.position = troopsButton2.transform.position;
			steps = 9;
		}
		else if (!troopsPanel.activeSelf && ResourcesManager.instance.GetTroops() == 0 && steps == 9){
			tutorialPanelTransform.anchorMin = new Vector2(0.2f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.65f, 0.8f);
			tutorialText.text = "\n\n\n\nVamos otra vez.\nAbre el panel de tropas.\n\n\n\n";
			troopsButton.interactable = true;
			finger.transform.position = troopsButton.transform.position;
			steps = 7;
		}
		else if (troopsPanel.activeSelf && ResourcesManager.instance.GetTroops() != 0 && steps == 9){
			tutorialPanelTransform.anchorMin = new Vector2(0.2f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.6f, 0.8f);
			tutorialText.text = "\n\n\n\n\nCerra el panel.\n\n\n\n\n";
			finger.transform.position = troopsButton3.transform.position;
			steps = 10;
		}
		else if (ResourcesManager.instance.GetTroops() != 0 && !troopsPanel.activeSelf && steps == 10){
			tutorialPanelTransform.anchorMin = new Vector2(0.2f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.6f, 0.8f);
			tutorialText.text = "\nAquí puedes ver un reloj y un botón.\nEn el reloj puedes ver los turnos que han " + 
								"pasado desde el último evento y el botón que esta a su derecha sirve para pasar un turno " +
								"sin hacer nada.\nProba pasar un turno.\n";
			forwardButton.interactable = true;
			finger.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 100));
			finger.transform.position = forwardButton.transform.position;
			steps = 11;
			turn = TimeManager.instance.GetCurrentTime();
		}
		else if (TimeManager.instance.GetCurrentTime() == turn + 1 && steps == 11){
			Event tutorialEvent = new PirateEncounter1();
			tutorialEvent.PlayEvent(eventText, button1, button1Text, button2, button2Text);
			eventPanel.SetActive(true);

			tutorialPanelTransform.anchorMin = new Vector2(0.8f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(1f, 0.8f);
			tutorialText.text = "\n\nMira, ocurrió un evento.\nCon las tropas que tienes puedes " +
								"completarlo sin pérdidas, inténtalo.\n\n";
			troopsButton.interactable = false;
			shipButton.interactable = false;
			resourcesButton.interactable = false;
			goldButton.interactable = false;
			forwardButton.interactable = false;
			finger.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 0));
			finger.transform.position = button1.transform.position;
			steps = 12;
		}
		else if (!eventPanel.activeSelf && steps == 12){
			tutorialPanelTransform.anchorMin = new Vector2(0.5f, 0.25f);
			tutorialPanelTransform.anchorMax = new Vector2(1f, 0.85f);
			tutorialText.text = "\n\n\nPerfecto.\nAhora vamos cobrar los impuestos para recaudar un poco de oro.\n\n\n";
			goldButton.interactable = true;
			finger.transform.position = goldButton.transform.position;
			steps = 13;
		}
		else if (goldPanel.activeSelf && steps == 13){
			tutorialPanelTransform.anchorMin = new Vector2(0.45f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.95f, 0.8f);
			tutorialText.text = "\nAca tenes dos tipos de opciones, una es para recolectar los impuestos normalmente, esta " +
								"opción se habilita cada una cierta cantidad de turnos.\nLa otra es forzar a los " +
								"ciudadanos a pagar.\n";
			troopsButton.interactable = false;
			shipButton.interactable = false;
			resourcesButton.interactable = false;
			goldButton.interactable = false;
			forwardButton.interactable = false;
			finger.transform.position = goldButton1.transform.position;
			steps = 14;
			currentGold = ResourcesManager.instance.GetGold();
		}
		else if (currentGold != ResourcesManager.instance.GetGold() && steps == 14){
			tutorialPanelTransform.anchorMin = new Vector2(0.25f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.65f, 0.8f);
			tutorialText.text = "\n\n\n\nPerfecto, cierra el panel para continuar.\n\n\n\n";
			finger.transform.position = goldButton2.transform.position;
			steps = 15;
		}
		else if (!goldPanel.activeSelf && steps == 15){
			tutorialPanelTransform.anchorMin = new Vector2(0.2f, 0.2f);
			tutorialPanelTransform.anchorMax = new Vector2(0.6f, 0.8f);
			#if   UNITY_EDITOR
        		tutorialText.text = "\nPor ultimo, aqui tenes un medidor que te irá diciendo cómo piensa la " +
									"población de vos.\nLa barra verde es el apoyo que te dan mientras que la " +
									"roja representa el miedo que te tienen.\n\n(clic izquierdo para terminar)\n";
			#elif UNITY_STANDALONE_WIN
       			tutorialText.text = "\nPor ultimo, aqui tenes un medidor que te irá diciendo cómo piensa la " +
									"población de vos.\nLa barra verde es el apoyo que te dan mientras que la " +
									"roja representa el miedo que te tienen.\n\n(clic izquierdo para terminar)\n";
			#elif UNITY_ANDROID
        		tutorialText.text = "\nPor ultimo, aqui tenes un medidor que te irá diciendo cómo piensa la " +
									"población de vos.\nLa barra verde es el apoyo que te dan mientras que la " +
									"roja representa el miedo que te tienen.\n\n(Tocar pantalla para terminar)\n";
			#endif
			
			finger.transform.position = godBabBar.transform.position;
			steps = 16;
		}
		else if (Input.GetMouseButtonDown(0) && steps == 16){
			troopsButton.interactable = true;
			shipButton.interactable = true;
			resourcesButton.interactable = true;
			goldButton.interactable = true;
			forwardButton.interactable = true;
			resourcesButtonNo.interactable = true;

			EventManager.instance.SetEvents();

			Destroy(tutorialPanel.gameObject);
			Destroy(finger.gameObject);
			Destroy(gameObject);
		}

		
	}

}
