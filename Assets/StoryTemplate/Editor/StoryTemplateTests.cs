using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;


public class StoryTemplateTests {
    
    public class Canvases
    {

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

        [Test]
        public void Is_The_StoryCharacterDialogCanvas_Present()
        {
            var cnvName = "StoryCharacterDialogCanvas";
            var canvas = GetCanvas(cnvName);

            Assert.IsNotNull(canvas);
        }

        [Test]
        public void Is_The_StoryObjectDialogCanvas_Present()
        {
            var cnvName = "StoryObjectDialogCanvas";
            var canvas = GetCanvas(cnvName);

            Assert.IsNotNull(canvas);
        }


    }

    public class Buttons
    {
        private static Button GetButton(string btnName)
        {
            return GameObject.Find(btnName).GetComponent<Button>();
        }

        [Test]
        public void Exit_Button_Present()
        {
            var btnName = "btnExit";
            var testButton = GetButton(btnName);

            Assert.IsNotNull(testButton);
        }
    }
}
