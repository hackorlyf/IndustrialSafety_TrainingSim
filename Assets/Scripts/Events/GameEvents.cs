using UnityEngine;

public class GameEvents : MonoBehaviour
{
    #region Delegate
    public delegate void VoidEvent();
    #endregion

    #region Events
    public static event VoidEvent OnInteractBtnClicked;
    #endregion

    #region Invokation
    public static void InteractBtnClicked() { OnInteractBtnClicked?.Invoke(); }
    #endregion
}