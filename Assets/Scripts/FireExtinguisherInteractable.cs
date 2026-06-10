using UnityEngine;
using TMPro;

public class FireExtinguisherInteractable : MonoBehaviour, IInteractable
{
    
    [SerializeField] private string interactText;
    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private TextMeshPro DialogueText;

    private void ShowDialogueBox(){
        SetDialogueText("Used to control or extinguish small fires during emergencies.");
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
