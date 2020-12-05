using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingText : MonoBehaviour
{
    public readonly string MESSAGE = "Waiting for other player...   ";

    private Text _text;
    private int _index;

    public void Awake()
    {
        _text = GetComponent<Text>();
        _index = 0;
    }

    public void LogText()
    {
        Debug.Log(_text.text);
    }

    public void UpdateText()
    {
        if (_index < MESSAGE.Length)
        {
            _text.text += MESSAGE[_index];
            _index++;
        }
        else
        {
            _text.text = "";
            _index = 0;
        }
    }

    public void SetText(string str)
    {
        _text.text = str;
    }
}
