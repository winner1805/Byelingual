using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.StoryTemplate.Infrastructure
{
    public class ClickAction : MonoBehaviour, IPointerClickHandler
    {

        public virtual void OnPointerClick(PointerEventData eventData)
        {
           
        }
    }

    public class LaunchGame : ClickAction
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            var canvases = GetComponentsInParent<Canvas>();
            foreach (var canvas in canvases)
            {
                if (canvas.enabled) canvas.enabled = false;
            }

            var gameCanvas = (Canvas) FindCanvas.Named(gameObject.name + "_canvas");
            gameCanvas.enabled = true;


            var panel = FindPanel.GO("ControlBar");
            panel.transform.SetParent(gameCanvas.transform);
            

            
            panel.transform.SetAsLastSibling();
          

            



        }
    }
   /* public class ClickActionBuilder : ComponentBuilder<ClickAction>
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
    }*/
}