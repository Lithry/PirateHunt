using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	static public UIManager instance;
	public GameObject questPrefab;
	public GameObject questPanel;
	public GameObject questAceptButton;
	public GameObject questContainer;
	public Sprite questNormalButton;
	public Sprite questSelectedButton;
	private List<Quest> questList = new List<Quest>();
	private int questSelectedId;
	public GameObject cityUI;
	public GameObject combatUI;
	
	void Start () {
		instance = this;
		questPanel.SetActive(false);
		questAceptButton.SetActive(false);
		combatUI.SetActive(false);
		questSelectedId = 0;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)){
			Application.Quit();
		}
	}

	// QUEST OPTIONS ===================================================================

	public void QuestPanelOpen(){
		if (!questPanel.active){
			questPanel.SetActive(true);
			List<QuestManager.QuestData> q;
			q = QuestManager.instance.GetQuests();
			for (int i = 0; i < q.Count; i++){
				GameObject nQuest = Instantiate(questPrefab);
				nQuest.transform.SetParent(questContainer.transform);

				RectTransform trans = nQuest.GetComponent<RectTransform>();
				trans.transform.position = new Vector3(563.2f, -(100 * i) + 600, 0f);

				Quest que = nQuest.GetComponent<Quest>();
				que.SetTexts(q[i].id, q[i].dificult, q[i].numEnemis);

				questList.Add(que);
			}
		}
	}

	public void QuestPanelClose(){
		foreach (Quest que in questList){
			que.Destroy();
		}
		questList.Clear();
		questAceptButton.SetActive(false);
		questPanel.SetActive(false);
	}

	public void QuestSelected(int id){
		questSelectedId = id;
		foreach (Quest que in questList){
			if (questSelectedId == que.GetId())
				que.ChangeImageSelected();
			else
				que.ChangeImageNormal();
		}
		questAceptButton.SetActive(true);
	}

	public void AceptQuest(){
		foreach (Quest que in questList){
			if (questSelectedId == que.GetId()){
				QuestAndRewards.instance.SetQuest(questSelectedId);
			}
		}
		QuestPanelClose();
		StartCoroutine(ChangeInstance());
	}

	public Sprite QuestNormalButton(){
		return questNormalButton;
	}

	public Sprite QuestSelectedButton(){
		return questSelectedButton;
	}

	IEnumerator ChangeInstance()
    {
        float fadeTime = FadeTransition.instance.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        cityUI.SetActive(false);
		combatUI.SetActive(true);
		FadeTransition.instance.BeginFade(-1);
		
    }

	// ================================================================================
}
