using System.Collections.Generic;
using Assets.StoryTemplate.Infrastructure;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets
{
    public class GameController : MonoBehaviour
    {
        //Scenes
        private Scene _mainMenuScene;
        private Scene _storyTemplateScene;
        
        //Canvases
        private Canvas _mainMenu;
        private Canvas _story1Intro;

        //Buttons
        private Button _exitButton;

        private Button _buttonS1Int;

        //Only for testing
        private Button _story1Button;

        //UnityActions
        private UnityAction _exit;
        private UnityAction _exitStory1Intro;
        private UnityAction _startStory1;
        private List<Story> _stories;


        // Use this for initialization
        private void Start()
        {
            //
            

            var jsonString = Resources.GetStringResponse("stories");
            _stories = new List<Story>();
            var jsonStories = JSON.Parse(jsonString);




            var storyCount = jsonStories["stories"].Count;
            for (var i = 0; i < storyCount; i++)
            {
                _stories.Add(
                    new Story(
                        jsonStories["stories"][i]["name"].ToString(),
                        jsonStories["stories"][i]["description"].ToString(),
                        jsonStories["stories"][i]["image"].ToString()
                    )
                );
            }


            var canvases = new List<Canvas>();
            var scenes = new List<Scene>();
            var buttons = new List<Button>();
            var sprites = new Dictionary<string, Sprite>();

            foreach (var story in _stories)
            {
                canvases.Add(A.Canvas().Named(story + "Canvas"));
                scenes.Add(A.Scene().Named(story + "Scene"));
                buttons.Add(A.Button().Named("Load"+ story + "Button"));
                sprites.Add(story.ToString(), IMG2Sprite.instance.LoadNewSprite("media/" + story.ImageUrl));
                
            }

            var mainMenuScene = (Scene) A.Scene().Named("MainMenuScene");
            
            SceneManager.LoadScene("MainMenuScene");
            if (mainMenuScene.isLoaded) { 
                var mainMenuCanvas = (Canvas)A.Canvas().Named("MainMenuCanvas");
                foreach (var button in buttons)
                {
                    button.transform.SetParent(mainMenuCanvas.transform, false);

                    
                }
            }
            /*
            //Canvas initialization
            _mainMenu = GameObject.Find("MainMenu").GetComponent<Canvas>();
            _story1Intro = GameObject.Find("Story1Intro").GetComponent<Canvas>();


            //Button initialization
            _exitButton = GameObject.Find("btnExit").GetComponent<Button>();
            _buttonS1Int = GameObject.Find("ButtonS1Int").GetComponent<Button>();
            //Only for testing
            _story1Button = GameObject.Find("btnStoryOne").GetComponent<Button>();

            //Assigning Methods to Unity actions
            _exit += ExitGame;
            _startStory1 += StartStory1;
            //Only for testing
            _exitStory1Intro += ExitStory1Intro;


            //Assigning Unity actions to button Events
            _exitButton.onClick.AddListener(_exit);
            _story1Button.onClick.AddListener(_startStory1);
            //Only for testing
            _buttonS1Int.onClick.AddListener(_exitStory1Intro);*/
        }

        // Update is called once per frame
        private void Update()
        {
        }

        

        private static void ExitGame()
        {
            Debug.Log("Exiting Game");
            Application.Quit();
        }

        private void StartStory1()
        {
            //hiding main menu and showing the story 1 intro
            _mainMenu.enabled = false;
            _story1Intro.enabled = true;
        }

        private void ExitStory1Intro()
        {
            //Remove this method - It's only for testing
            _mainMenu.enabled = true;
            _story1Intro.enabled = false;
        }
    }
}