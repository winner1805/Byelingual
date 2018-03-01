using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
            var gc = FindGameController.Named("GameController");


            var gameCanvas = (Canvas)FindCanvas.Named(gameObject.name + "_canvas");
            gc.EnableCanvas(gameCanvas);
            //gameCanvas.enabled = true;



            var panel = FindPanel.GO("ControlBar");
            panel.transform.SetParent(gameCanvas.transform);
            var backButton = Instantiate(panel.GetComponentInChildren<Button>(), panel.transform,true);
            backButton.name = "BackButton";
            backButton.transform.SetParent(panel.transform);

            backButton.gameObject.GetComponentInChildren<Text>().text = "Back";
            //backButton.transform.position.Set(-2.0f,0, 0);
            backButton.transform.Translate(-200f,0,9);
            backButton.onClick.AddListener(gc.BackToMainMenu);
            


            panel.transform.SetAsLastSibling();
            return;

            
            





        }
    }
   

}