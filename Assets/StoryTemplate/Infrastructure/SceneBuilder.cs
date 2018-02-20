using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.StoryTemplate.Infrastructure
{
    public class SceneBuilder : TestBuilder<Scene>
    {

        private string _name = "UnnamedScene";


        public SceneBuilder Named(string name)
        {
            _name = name;
            return this;
        }

        public override Scene Build()
        {
            var scene = SceneManager.CreateScene(_name);
            return scene;
        }
    }
}
