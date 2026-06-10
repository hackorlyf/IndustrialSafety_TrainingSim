using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    
    [SerializeField] private string interactText;

    public void Interact(){
        GameEvents.InteractBtnClicked();
    }

    public string GetInteractText() {
        return interactText;
    }

    public Transform GetTransform() {
        return transform;
    }
}
