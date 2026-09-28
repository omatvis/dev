using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Structural_Patterns;

/// <summary>
/// The Flyweight pattern is a structural design pattern that allows programs to support vast quantities of objects by keeping their memory consumption low. It achieves this by sharing as much data as possible with similar objects; it is a way to use objects in large numbers when a simple repeated representation would use an unacceptable amount of memory.
/// </summary>
interface IFont
{
    void SetSize(int size);
    void SetStyle(string style);
    void SetColor(string color);
    void Display(string text);
}

class ConcreteFont : IFont
{
    private int size;
    private string style = String.Empty;
    private string color = String.Empty;

    public void SetSize(int size)
    {
        this.size = size;
    }

    public void SetStyle(string style)
    {
        this.style = style;
    }

    public void SetColor(string color)
    {
        this.color = color;
    }

    public void Display(string text)
    {
        Console.WriteLine($"Text: '{text}' | Size: {size} | Style: {style} | Color: {color}");
    }
}

class FontFactory
{
    private Dictionary<string, IFont> fonts = new Dictionary<string, IFont>();

    public IFont GetFont(string key)
    {
        if (!fonts.ContainsKey(key))
        {
            fonts[key] = new ConcreteFont();
        }
        return fonts[key];
    }
}