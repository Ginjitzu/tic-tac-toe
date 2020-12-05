using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomColors
{
    // 100/8 = 12.5
    // Grey scale
    public static readonly Color black = new Color(0, 0, 0);
    public static readonly Color grey_black = new Color(0.125f, 0.125f, 0.125f);
    public static readonly Color grey_deep = new Color(0.25f, 0.25f, 0.25f);
    public static readonly Color grey_dark = new Color(0.375f, 0.375f, 0.375f);
    public static readonly Color grey = new Color(0.5f, 0.5f, 0.5f);
    public static readonly Color grey_light = new Color(0.625f, 0.625f, 0.625f);
    public static readonly Color grey_bright = new Color(0.75f, 0.75f, 0.75f);
    public static readonly Color grey_white = new Color(0.875f, 0.875f, 0.875f);
    public static readonly Color white = new Color(1, 1, 1);

    // Red scale
    public static readonly Color red_pastel_light = new Color(0.75f, 0.5f, 0.5f);
    public static readonly Color red_pastel = new Color(0.75f, 0.25f, 0.25f);
    public static readonly Color red_pastel_dark = new Color(0.5f, 0.25f, 0.25f);
    public static readonly Color red_black = new Color(0.25f, 0f, 0f);

    // Yellow
    public static readonly Color yellow_white = new Color(1, 1, 0.75f);
    public static readonly Color yellow_vibrant_light = new Color(1, 1, 0.25f);
    public static readonly Color yellow_vibrant = new Color(1, 1, 0);
    public static readonly Color yellow_vibrant_dark = new Color(0.75f, 0.75f, 0f);
    public static readonly Color yellow_black = new Color(0.25f, 0.25f, 0f);

    // Green scale
    public static readonly Color green_pastel_light = new Color(0.5f, 0.75f, 0.5f);
    public static readonly Color green_pastel = new Color(0.25f, 0.75f, 0.25f);
    public static readonly Color green_pastel_dark = new Color(0.25f, 0.5f, 0.25f);
    public static readonly Color green_black = new Color(0f, 0.25f, 0f);

    // Cyan
    public static readonly Color cyan_vibrant_light = new Color(0.25f, 1, 1);
    public static readonly Color cyan_vibrant = new Color(0, 1, 1);
    public static readonly Color cyan_vibrant_dark = new Color(0f, 0.75f, 0.75f);
    public static readonly Color cyan_black = new Color(0f, 0.25f, 0.25f);

    // Blue scale
    public static readonly Color blue_pastel_light = new Color(0.5f, 0.5f, 0.75f);
    public static readonly Color blue_pastel = new Color(0.25f, 0.25f, 0.75f);
    public static readonly Color blue_pastel_dark = new Color(0.25f, 0.25f, 0.5f);
    public static readonly Color blue_black = new Color(0f, 0f, 0.25f);

    // Magenta
    public static readonly Color magenta_vibrant_light = new Color(1, 0.25f, 1);
    public static readonly Color magenta_vibrant = new Color(1, 0, 1);
    public static readonly Color magenta_vibrant_dark = new Color(0.75f, 0f, 0.75f);
    public static readonly Color magenta_black = new Color(0.25f, 0, 0.25f);

    // Schemes
    public static readonly Scheme scheme_grey = new Scheme("Grey", black, grey_light, grey_bright, grey_dark, grey_dark, grey_deep, white);
    public static readonly Scheme scheme_red = new Scheme("Pastel Red", red_black, red_pastel, red_pastel_light, red_pastel, red_pastel, red_pastel_dark, white);
    public static readonly Scheme scheme_yellow_vibrant = new Scheme("Vibrant Yellow", blue_black, yellow_vibrant, yellow_vibrant_light, yellow_vibrant, yellow_vibrant, yellow_vibrant_dark, black);
    public static readonly Scheme scheme_green = new Scheme("Pastel Green", green_black, green_pastel, green_pastel_light, green_pastel, green_pastel, green_pastel_dark, white);
    public static readonly Scheme scheme_cyan_vibrant = new Scheme("Vibrant Cyan", red_black, cyan_vibrant, cyan_vibrant_light, cyan_vibrant, cyan_vibrant, cyan_vibrant_dark, black);
    public static readonly Scheme scheme_blue = new Scheme("Pastel Blue", blue_black, blue_pastel, blue_pastel_light, blue_pastel, blue_pastel, blue_pastel_dark, white);
    public static readonly Scheme scheme_magenta_vibrant = new Scheme("Vibrant Magenta", green_black, magenta_vibrant, magenta_vibrant_light, magenta_vibrant, magenta_vibrant, magenta_vibrant_dark,
        black);
}

public class Scheme
{
    private string _name;
    private Color _background;
    private Color _normal;
    private Color _highlighted;
    private Color _pressed;
    private Color _selected;
    private Color _disabled;
    private Color _text;

    public Scheme(string name, Color background, Color normal, Color highlighted, Color pressed, Color selected, Color disabled, Color text)
    {
        _name = name;
        _background = background;
        _normal = normal;
        _highlighted = highlighted;
        _pressed = pressed;
        _selected = selected;
        _disabled = disabled;
        _text = text;
    }

    public string Name() { return _name; }
    public Color Background() { return _background; }
    public Color Normal() { return _normal; }
    public Color Highlighted() { return _highlighted; }
    public Color Pressed() { return _pressed; }
    public Color Disabled() { return _disabled; }
    public Color Text() { return _text; }
}