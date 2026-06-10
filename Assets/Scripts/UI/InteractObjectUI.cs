using UnityEngine;
using TMPro;

public class InteractObjectUI : MonoBehaviour
{
    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private TextMeshPro DialogueText;

    private void OnEnable(){
        //GameEvents.OnInteractBtnClicked += ShowDialogueBox;
    }

    private void ShowDialogueBox(){
        SetDialogueText("TODO: Fetch from JSON");
        DialogueBox.SetActive(true);
    }

    private void SetDialogueText(string dialogueText){
        DialogueText.text = dialogueText;
    }

    private void OnDisable(){
        //GameEvents.OnInteractBtnClicked -= ShowDialogueBox;
    }
}
