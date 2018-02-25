using Assets.StoryTemplate.Infrastructure;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets
{
    public class GameController : MonoBehaviour
    {
        
        private List<Story> _stories;
        private Canvas _mainMenu;
        

        // Use this for initialization
        private void Start()
        {
            //
            

            
            _stories = new List<Story>();
            _stories = Resources.GetStoriesFromInternet();


            var canvases = new List<Canvas>();
            var scenes = new List<Scene>();
            var buttons = new List<Button>();
            var sprites = new Dictionary<string, Sprite>();

            foreach (var story in _stories)
            {
                canvases.Add(A.Canvas().Named(story.SnakeCase() + "_canvas"));
                scenes.Add(A.Scene().Named(story.SnakeCase() + "_scenes"));
                buttons.Add(A.Button().Named("Load"+ story.SnakeCase() + "_button"));
                sprites.Add(story.ToString(), IMG2Sprite.instance(story.SnakeCase() + "_sprite").LoadNewSprite(story.ImageUrl));
                
            }

            //var mainMenuScene = (Scene) A.Scene().Named("MainMenuScene");
            var mainMenuScene = SceneManager.GetSceneByName("MainMenuScene");
            
            
            SceneManager.SetActiveScene(mainMenuScene);
           
            var mainMenuCanvas = (Canvas)A.Canvas().Named("MainMenuCanvas");
            _mainMenu = GameObject.Find("MainMenu").GetComponent<Canvas>();
            


            mainMenuCanvas.transform.SetAsLastSibling();
            
            SceneManager.MoveGameObjectToScene(mainMenuCanvas.gameObject, mainMenuScene);
           
            
            //Debug.Log(mainMenuCanvas.isRootCanvas);
                

                foreach (var button in buttons)
                {
                    
                    button.transform.SetParent(mainMenuCanvas.transform, false);
                    button.enabled = true;
                    button.image = new GameObject().AddComponent<Image>();
                    button.image.sprite = sprites[_stories[0].ToString()];


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
            //_story1Intro.enabled = true;
        }

        private void ExitStory1Intro()
        {
            //Remove this method - It's only for testing
            _mainMenu.enabled = true;
            //_story1Intro.enabled = false;
        }
    }
}