using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Tests
{
    public class MainMenuTests
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

        [Test]
        public void Story_One_Button_Present()
        {
            var btnName = "btnStoryOne";
            var testButton = GetButton(btnName);

            Assert.IsNotNull(testButton);
        }

        [Test]
        public void All_Canvases_Can_Be_Disabled()
        {
            GameController.DisableAllCanvases();

            
        }
    }
}