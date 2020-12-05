using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour {

    public Button button;

    private LogicManager _logic_manager;
    public void SetSceneManager(LogicManager logic_manager) { this._logic_manager = logic_manager; }

    public void SetColourScheme (Scheme scheme)
    {
        Debug.Log("Setting " + this + " colours to " + scheme.Name());
        Debug.Log("Normal is " + scheme.Normal());
        ColorBlock block = button.colors;
        block.normalColor = scheme.Normal();
        block.highlightedColor = scheme.Highlighted();
        block.pressedColor = scheme.Normal();
        block.selectedColor = scheme.Normal();
        block.disabledColor = scheme.Disabled();
        button.colors = block;
    }

    public void OnClick()
    {
        Debug.Log("Clicked " + this.name);
        _logic_manager.ToggleSettings();
    }
}
