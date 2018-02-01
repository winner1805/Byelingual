using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.StoryTemplate.Editor
{
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
                const string cnvName = "StoryCanvas";
                var canvas = GetCanvas(cnvName);

                Assert.IsNotNull(canvas);
            }

            [Test]
            public void Is_The_StoryIntroCanvas_Present()
            {
                const string cnvName = "StoryIntroCanvas";
                var canvas = GetCanvas(cnvName);

                Assert.IsNotNull(canvas);
            }

            [Test]
            public void Is_The_StoryCharacterDialogCanvas_Present()
            {
                const string cnvName = "StoryCharacterDialogCanvas";
                var canvas = GetCanvas(cnvName);

                Assert.IsNotNull(canvas);
            }

            [Test]
            public void Is_The_StoryObjectDialogCanvas_Present()
            {
                const string cnvName = "StoryObjectDialogCanvas";
                var canvas = GetCanvas(cnvName);

                Assert.IsNotNull(canvas);
            }

            [Test]
            public void Is_The_StoryMemorySequenceCanvas_Present()
            {
                const string cnvName = "StoryMemorySequenceCanvas";
                var canvas = GetCanvas(cnvName);
                
                Assert.IsNotNull(canvas);
            }

            [Test]
            public void Is_The_StoryEndingCanvas_Present()
            {
                const string cnvName = "StoryEndingCanvas";
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
}
