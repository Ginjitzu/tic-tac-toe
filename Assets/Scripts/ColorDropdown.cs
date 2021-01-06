using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorDropdown : MonoBehaviour {

    public Dropdown dropdown;
    private Text _text;
    private Image _arrow;
    
    private GameStateManager _logic_manager;
    public void SetLogicManager(GameStateManager logic_manager) { this._logic_manager = logic_manager; }

    public void SetColourScheme (Scheme scheme)
    {
        Debug.Log("Setting " + this + " colours to " + scheme.Name());
        _text.color = scheme.Text();
        _arrow.color = scheme.Text();
    }

    public void Awake()
    {
        _text = GetComponentInChildren<Text>();
        _arrow = transform.Find("Arrow").GetComponent<Image>();
        List<string> scheme_names = new List<string>();
        foreach (Scheme scheme in _logic_manager.color_schemes)
        {
            scheme_names.Add(scheme.Name());
        }
        // Debug.Log("Adding " + String.Join(", ", scheme_names) + " to " + this);
        dropdown.AddOptions(scheme_names);
    }

    public void Start()
    {
    }

    public void OnSelection(int selection)
    {
        Debug.Log(_logic_manager.color_schemes[selection].Name() + " scheme selected.");
        _logic_manager.SetColourScheme(selection);
    }

    public void Show() { this.gameObject.SetActive(true); }

    public void Hide() { this.gameObject.SetActive(false); }
}
