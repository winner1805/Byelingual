using NUnit.Framework;
using UnityEngine;


public class StoryTemplateTests {

    private static Canvas GetCanvas(string cnvName)
    {
        return GameObject.Find(cnvName).GetComponent<Canvas>();
    }

    [Test]
    public void Is_The_StoryCanvas_Present()
    {
        var cnvName = "StoryCanvas";
        var canvas = GetCanvas(cnvName);

        Assert.IsNotNull(canvas);
    }

    [Test]
    public void Is_The_StoryIntroCanvas_Present()
    {
        var cnvName = "StoryIntroCanvas";
        var canvas = GetCanvas(cnvName);

        Assert.IsNotNull(canvas);
    }

}
