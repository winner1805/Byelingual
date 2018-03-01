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

            gc.CurrentStory = gc.Stories[gameCanvas.name.Remove(gameCanvas.name.LastIndexOf('_'))];
            gameCanvas.transform.Find("GameTitle").GetComponent<Text>().text = gc.CurrentStory.ToString();


            var panel = FindPanel.GO("ControlBar");
            panel.transform.SetParent(gameCanvas.transform);
            var backButton = Instantiate(panel.GetComponentInChildren<Button>(), panel.transform,true);
            backButton.name = "BackButton";
            backButton.transform.SetParent(panel.transform);

            backButton.gameObject.GetComponentInChildren<Text>().text = "Back";
            
            backButton.transform.Translate(-600f,0,0);
            backButton.onClick.AddListener(gc.BackToMainMenu);
            


            panel.transform.SetAsLastSibling();
            return;

            
            





        }
    }
   

}