using Assets.StoryTemplate.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuilder : TestBuilder<Button>
{
    private string _name;

    public ButtonBuilder Named(string name)
    {
        _name = name;
        return this;
    }

    public override Button Build()
    {

        var button = new GameObject().AddComponent<Button>();
        
        button.name = _name;
        return button;

    }
}
