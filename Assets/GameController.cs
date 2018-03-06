using Assets.StoryTemplate.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class GameController : MonoBehaviour
    {
        
        private Dictionary<string, Story> _stories; //list of stories available in the platform
        private bool _init = true; //flag for async methods that run on first update frame
        private Story _currentStory; //currently active story
        private Dictionary<string, Canvas> _canvases; //list of canvases to loop through when disabling them
        private List<GameObject> _panels; //list of game panels
        private List<GameObject> _elementsToCrossfade; //list of elements for visual transition

        //Current story property
        public Story CurrentStory
        {
            get { return _currentStory; }
            set { _currentStory = value; }
        }

        //Stories property - returns the list of locally available stories
        public Dictionary<string, Story> Stories
        {
            get { return _stories; }
        }


        // Use this for initialization
        private void Start()
        {
            //Initialazing lists
            _canvases = new Dictionary<string, Canvas>();
            _stories = new Dictionary<string, Story>();
            _panels = new List<GameObject>();
            _elementsToCrossfade = new List<GameObject>();

            //add panels to the list
            FillPanels();
            
            //show the main menu control bar
            ShowPanel(FindPanel.GO("ControlBar"));

            //get stories from internet
            _stories = Resources.GetStoriesFromInternet();

            // add ExitGame callback to ExitButton listener
            FindButton.Named("ExitButton").onClick.AddListener(ExitGame);
            
            //Testing text transition (fade in)
            var text = FindText.Named("TextGameTitle");
            VisualEffects.SetTextTransparent(text);
            _elementsToCrossfade.Add(text.gameObject);

            

            //Canvas initialization
            var mainMenuCanvas = FindCanvas.Named("MainMenuCanvas");
            
            mainMenuCanvas.transform.SetAsLastSibling();
            _canvases["mainMenuCanvas"]=mainMenuCanvas;

            

            foreach (var story in Stories.Values)
            {
                var cnv = Instantiate(FindCanvas.Named("StoryCanvas"));
                cnv.name = story.SnakeCase() + "_canvas";
                _canvases[story.SnakeCase()] = cnv;

            }


            



            /*Button initialization
            _exitButton = GameObject.Find("btnExit").GetComponent<Button>();
            

            //Assigning Methods to Unity actions
            _exit += ExitGame;
            

            //Assigning Unity actions to button Events
            _exitButton.onClick.AddListener(_exit);
            */

        }

        private void FillPanels()
        {
            _panels.Add(FindPanel.GO("ControlBar"));
            _panels.Add(FindPanel.GO("ControlBarText"));
            _panels.Add(FindPanel.GO("ControlBarImage"));
            _panels.Add(FindPanel.GO("ControlBarImageDragDrop"));
        }

        public void BackToMainMenu()
        {
            DisableAllCanvases();
            var mm = FindCanvas.Named("MainMenuCanvas");
            EnableCanvas(mm);
            var panel = FindPanel.GO("ControlBar");
            panel.transform.SetParent(mm.transform);
            ShowPanel(panel,Color.grey);
            Destroy(FindButton.Named("BackButton").gameObject);
        }

        private async void LoadButtons()
        {
            
            if (Stories.Count > 0) //a hack, have to refactor at some point
            {
                var a = IMG2Sprite.Instance(Stories.Values.ElementAt(0).SnakeCase() + "spriter");
                var b = IMG2Sprite.Instance(Stories.Values.ElementAt(1).SnakeCase() + "spriter");

                var ImageStory1 = FindImage.Named("ImageStory1");
                ImageStory1.sprite = await a.LoadNewSprite(Stories.Values.ElementAt(0).ImageUrl);
                ImageStory1.name = Stories.Values.ElementAt(0).SnakeCase();
                VisualEffects.SetImageTransparent(ImageStory1);
                _elementsToCrossfade.Add(ImageStory1.gameObject);

                var ImageStory2 = FindImage.Named("ImageStory2");
                ImageStory2.sprite = await b.LoadNewSprite(Stories.Values.ElementAt(1).ImageUrl);
                ImageStory2.name = Stories.Values.ElementAt(1).SnakeCase();
                VisualEffects.SetImageTransparent(ImageStory2);
                _elementsToCrossfade.Add(ImageStory2.gameObject);

                foreach (var story in Stories.Values)
                {

                    FindImage.Named(story.SnakeCase()).gameObject.AddComponent<LaunchGame>();
                }

            }

           
        }

        // Update is called once per frame
        private void Update()
        {

            if (_init)
            {
                EnableCanvas(FindCanvas.Named("MainMenuCanvas"));
                LoadButtons();
                _init = false;
            }

            CrossFadeElements();

        }

        private void CrossFadeElements()
        {
            //container of items to remove from crossfade list once the item completes the transition
            var itemsToRemove = new List<GameObject>();

            //go through the crossfade list
            foreach (var element in _elementsToCrossfade)
            {
                //try to get an image from the gameObject element
                var image = element.GetComponent<Image>();
                //try to get a text from the gameObject element
                var text = element.GetComponent<Text>();

                //test if the element is image
                if (image)
                {
                    VisualEffects.ImageFadeIn(image, 1.0f, 0.8f);
                    if (Math.Abs(image.color.a - 1.0f) < 0.0001)
                    {
                        itemsToRemove.Add(element);
                    }
                }//test if the element is text
                else if (text)
                {
                    VisualEffects.TextFadeIn(text, 1.0f, 0.8f);
                    if (Math.Abs(text.color.a - 1.0f) < 0.0001)
                    {
                        itemsToRemove.Add(element);
                        
                    }
                }

                
            }
            //cleanup the elements which completed transition
            foreach (var item in itemsToRemove)
            {
                _elementsToCrossfade.Remove(item);
                Debug.Log("object removed from fade list");
            }


        }


        private static void ExitGame()
        {
            Debug.Log("Exiting game");
            Application.Quit();
        }

      

        public void DisableAllCanvases()
        {
            foreach (var canvas in _canvases.Values)
            {
                canvas.enabled = false;
            }
        }

        public void HideAllPanels()
        {
            foreach (var panel in _panels)
            {
                panel.transform.SetAsFirstSibling();
            }
        }

        public void ShowPanel(GameObject panel)
        {
           ShowPanel(panel, Color.black);
        }

        public void ShowPanel(GameObject panel, Color color)
        {
            HideAllPanels();
            panel.transform.SetAsLastSibling();
            panel.transform.GetComponent<Image>().color = color;
        }

        public void EnableCanvasByName(string name)
        {
            EnableCanvas(FindCanvas.Named(name));
        }

        public void EnableCanvas(Canvas canvas)
        {
            DisableAllCanvases();
            canvas.enabled = true;
        }
    }
}