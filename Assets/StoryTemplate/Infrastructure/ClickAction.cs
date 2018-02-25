using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.StoryTemplate.Infrastructure
{
    public class ClickAction : MonoBehaviour, IPointerClickHandler
    {
        private Canvas _target;
        private Dictionary<string, Canvas> _canvases;
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

        public override ClickAction Build()
        {
            


        }
    }
}