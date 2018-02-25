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
        private List<Canvas> _canvases;

        

        // Use this for initialization
        private void Start()
        {
            _canvases = new List<Canvas>();
            //
            _stories = new List<Story>();
            _stories = Resources.GetStoriesFromInternet();

            if (_stories.Count > 0)
            {
                FindImage.Named("ImageStory1").sprite = IMG2Sprite.Instance(_stories[0].SnakeCase() + "spriter").LoadNewSprite(_stories[0].ImageUrl);
                FindImage.Named("ImageStory2").sprite = IMG2Sprite.Instance(_stories[1].SnakeCase() + "spriter").LoadNewSprite(_stories[1].ImageUrl);
            }

           
            
            
            //Canvas initialization
            var mainMenuCanvas = FindCanvas.Named("MainMenuCanvas");
            _canvases.Add(mainMenuCanvas);

            var story1Intro = FindCanvas.Named("Story1Intro");
            _canvases.Add(story1Intro);


            /*Button initialization
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
            Application.Quit();
        }

        private void StartStory1()
        {
            //hiding main menu and showing the story 1 intro
            DisableAllCanvases();
            //_story1Intro.enabled = true;
        }

        private void ExitStory1Intro()
        {
            //Remove this method - It's only for testing
            DisableAllCanvases();
            //_story1Intro.enabled = false;
        }

        public void DisableAllCanvases()
        {
            foreach (var canvas in _canvases)
            {
                canvas.enabled = false;
            }
        }

        public void EnableCanvas(Canvas canvas)
        {
            DisableAllCanvases();
            canvas.enabled = true;
        }
    }
}