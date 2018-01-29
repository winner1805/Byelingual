using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Editor
{
    public class MainMenuTests
    {
        private Button _exitButton;
        
        [Test]
        public void Exit_Button_Present() {
            _exitButton = GameObject.Find("ButtonExit").GetComponent<Button>();

            Assert.IsNotNull(_exitButton);
        }


    }
}
