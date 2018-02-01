using UnityEngine;

namespace Assets.StoryTemplate.Infrastructure
{
    public class CanvasBuilder
    {

        private string _name = "UnnamedCanvas";



        public Canvas Build()
        {
            var canvas = new GameObject().AddComponent<Canvas>();
            canvas.name = _name;
            return canvas;
        }

        public CanvasBuilder Named(string name)
        {
            _name = name;
            return this;
        }

        public static implicit operator Canvas(CanvasBuilder canvasBuilder)
        {
            return canvasBuilder.Build();
        }
    }
}
