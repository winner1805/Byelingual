using UnityEngine;

namespace Assets.StoryTemplate.Infrastructure
{
    public class CanvasBuilder : TestBuilder<Canvas>
    {

        private string _name = "UnnamedCanvas";


        public CanvasBuilder Named(string name)
        {
            _name = name;
            return this;
        }

        public override Canvas Build()
        {
            var canvas = new GameObject().AddComponent<Canvas>();
            canvas.name = _name;
            return canvas;
        }
    }
}
