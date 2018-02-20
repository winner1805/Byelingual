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
        private string _imageUrl;

        public string ImageUrl
        {
            get { return _imageUrl;}
            set {_imageUrl = value; }
        }

        public Story(string name, string description, string imageUrl)
        {
            _name = name;
            _description = description;
            _imageUrl = imageUrl;
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

        public Story WithSprite(Sprite sprite)
        {
            _sprite = sprite;
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