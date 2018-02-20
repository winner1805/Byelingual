﻿using Assets.StoryTemplate.Infrastructure;
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


        // Use this for initialization
        private void Start()
        {
            //
            _storyTemplateScene = A.Scene().Named("StoryScene");
            SceneManager.LoadScene("StoryScene");

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