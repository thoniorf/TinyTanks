using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MainMenuEventChannel", menuName = "Events/UI/Main Menu Event Channel")]
public class MainMenuEventChannel : ScriptableObject
{
    public event UnityAction LocalGameModeEvent = delegate { };

    public void SelectLocalGameMode()
    {
        LocalGameModeEvent.Invoke();
    }

}
