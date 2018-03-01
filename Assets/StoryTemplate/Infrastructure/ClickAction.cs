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
            //take control of the game controller
            var gc = FindGameController.Named("GameController");

            //find the current game canvas
            var gameCanvas = FindCanvas.Named(gameObject.name + "_canvas");
            
            //bring game canvas to front
            gc.EnableCanvas(gameCanvas);
            
            //set game controller's current story to the correct story from the Dictionary
            gc.CurrentStory = gc.Stories[gameObject.name];
            //and assign it to a local variable just for more readable code
            var currentStory = gc.CurrentStory;

            //Find GameTitle text in Game canvas, and set it to the currentStory name
            gameCanvas.transform.Find("GameTitle").GetComponent<Text>().text = currentStory.ToString();

            //move the ControlBar to the game canvas
            var panel = FindPanel.GO("ControlBar");
            panel.transform.SetParent(gameCanvas.transform);
            panel.transform.SetAsLastSibling();

            //copy the exit button, place it on the panel, rename and relabel
            var backButton = Instantiate(panel.GetComponentInChildren<Button>(), panel.transform, true);
            backButton.name = "BackButton";
            backButton.transform.SetParent(panel.transform);
            backButton.gameObject.GetComponentInChildren<Text>().text = "Back";
            //move button a bit to the left
            backButton.transform.Translate(-400f,0,0);
            //apply the game controller action to the back button
            backButton.onClick.AddListener(gc.BackToMainMenu);


            
        }
    }
   

}