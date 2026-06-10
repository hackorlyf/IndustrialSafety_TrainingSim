using UnityEngine;
using TMPro;

public class ScrewdriverInteractable : MonoBehaviour, IInteractable
{
    
    [SerializeField] private string interactText;
    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private TextMeshPro DialogueText;

    private void ShowDialogueBox(){
        SetDialogueText("Hand tool used to tighten or loosen screws.");
        DialogueBox.SetActive(true);
    }

    private void SetDialogueText(string dialogueText){
        DialogueText.text = dialogueText;
    }

    public void Interact(){
        ShowDialogueBox();
        GameEvents.InteractBtnClicked();
    }

    public string GetInteractText() {
        return interactText;
    }

    public Transform GetTransform() {
        return transform;
    }
}
