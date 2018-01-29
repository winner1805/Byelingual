using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Editor
{
    public class MainMenuTests
    {
        
        
        [Test]
        public void Exit_Button_Present() {
            var exitButton = GameObject.Find("btnExit").GetComponent<Button>();

            Assert.IsNotNull(exitButton);
        }


    }
}
