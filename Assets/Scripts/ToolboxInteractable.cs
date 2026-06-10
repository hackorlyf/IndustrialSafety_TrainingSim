using UnityEngine;
using TMPro;

public class ToolboxInteractable : MonoBehaviour, IInteractable
{
    
    [SerializeField] private string interactText;
    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private TextMeshPro DialogueText;

    private void ShowDialogueBox(){
        SetDialogueText("Stores and organizes tools for safe and efficient access during tasks.");
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
