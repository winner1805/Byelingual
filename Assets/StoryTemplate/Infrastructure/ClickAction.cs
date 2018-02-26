using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.StoryTemplate.Infrastructure
{
    public class ClickAction : MonoBehaviour, IPointerClickHandler
    {
        private readonly Canvas _target;
        private readonly Dictionary<string, Canvas> _canvases;
        public ClickAction(Canvas target, Dictionary<string, Canvas> canvases)
        {
            _canvases = canvases;
            _target = target;
        }



        public void OnPointerClick(PointerEventData eventData)
        {
            foreach (var canvas in _canvases.Values)
            {
                canvas.enabled = false;

            }

            _target.enabled = true;

        }
    }

    public class ClickActionBuilder : ComponentBuilder<ClickAction>
    {
        private Canvas _target;
        private Dictionary<string, Canvas> _canvases;

        public ClickActionBuilder(string name, Canvas target, Dictionary<string, Canvas> canvases)
        {
            _name = name;
            _target = target;
            _canvases = canvases;
        }

        public ClickActionBuilder TargettingCanvas(Canvas target)
        {
            _target = target;
            return this;
        }

        public ClickActionBuilder ControlsCanvases(Dictionary<string, Canvas> canvases)
        {
            _canvases = canvases;
            return this;
        }

        public override ClickAction Build()
        {

            var ca = new ClickAction(_target, _canvases) {name = _name};
            return ca;

        }
    }
}