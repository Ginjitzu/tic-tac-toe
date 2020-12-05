using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour {

    // Public attributes.
    public Button button;

    // Private attributes.
    private Text _text;
    private LogicManager _logic_manager;

    // Public abilities.
    public void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }

    public void SetText(string s) { _text.text = s; }

    public string GetText() { return this.GetComponentInChildren<Text>().text; }

    public void SetLogicManager(LogicManager logic_manager) { this._logic_manager = logic_manager; }

    public void SetColourScheme (Scheme scheme)
    {
        Debug.Log("Setting " + this + " colours to " + scheme.Name());
        Debug.Log("Normal is " + scheme.Normal());
        ColorBlock block = button.colors;
        block.normalColor = scheme.Normal();
        block.highlightedColor = scheme.Highlighted();
        block.pressedColor = scheme.Pressed();
        block.disabledColor = scheme.Disabled();
        _text.color = scheme.Text();
        button.colors = block;
    }

    public void Enable()
    {
        //Debug.Log("Enabling " + this);
        button.interactable = true;
    }

    public void Show ()
    {
        Debug.Log("Showing " + this);
        this.gameObject.SetActive(true);
    }

    public void Hide ()
    {
        Debug.Log("Hiding " + this);
        this.gameObject.SetActive(false);
    }

    public void OnClick ()
    {
        Debug.Log(_logic_manager.GetCurrentPlayer() + " clicked " + this.name);
        this.GetComponentInChildren<Text>().text = _logic_manager.GetCurrentPlayer();
        button.interactable = false;
        _logic_manager.Say("Hello!");
        _logic_manager.TurnEnds();
    }
}
