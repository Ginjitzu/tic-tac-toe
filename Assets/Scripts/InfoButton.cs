using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour {

    // Public attributes.
    public Button button;

    // Private attributes.
    private Text _text;

    // A reference to the LogicManager is needed to call it's public functions when the button is clicked.
    // This reference needs to be set by the LogicManager itself.
    private GameStateManager _logic_manager;

    // Public abilities.
    public void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }

    public void SetLogicManager (GameStateManager logic_manager)
    {
        this._logic_manager = logic_manager;
    }

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
        button.interactable = true;
    }

    public void Disable()
    {
        button.interactable = false;
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Show(string message)
    {
        Debug.Log("Showing " + this);
        this.GetComponentInChildren<Text>().text = message;
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        Debug.Log("Hiding " + this);
        this.gameObject.SetActive(false);
    }

    public void OnClick ()
    {
        Debug.Log("Clicked " + this.name);
        _logic_manager.StartNewGame();
    }
}
