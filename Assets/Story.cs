using Assets.StoryTemplate.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class Story
    {
        private string _name;
        private string _description;
        private Sprite _sprite;
        private Image _backgroundImage;
        private Canvas _titleCanvas;

        public Story(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public Story WithCanvas(string name)
        {
            _titleCanvas = A.Canvas().Named(name);
            return this;
        }

        public Story WithImage(Image image)
        {
            _backgroundImage = image;
            return this;
        }


        public string Description
        {
            get { return _description; }
        }

        public override string ToString()
        {
            return _name;
        }
        

    }
}