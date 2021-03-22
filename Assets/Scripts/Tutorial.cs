using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Image prompt1;
    public Image prompt2;
    public Image prompt3;
    public Image prompt4;
    public Image prompt5;
    public Image prompt6;
    private Image[] prompts;
    private int currentPrompt;
    public bool tutorialActive;

    private void Awake()
    {
        tutorialActive = true;
        currentPrompt = 0;
        prompts = new Image[6] { prompt1, prompt2, prompt3, prompt4, prompt5, prompt6 };
        DisplayTutorial(currentPrompt);
    }

    private void Update()
    {
        if (tutorialActive)
        {
            if (currentPrompt+1 < prompts.Length)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    currentPrompt += 1;
                    DisplayTutorial(currentPrompt);
                }
            } else
            {
                DisplayTutorial(currentPrompt);
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    foreach (Image image in prompts)
                    {
                        image.gameObject.SetActive(false);
                        tutorialActive = false;
                    }
                }    
            }
        } 
    }

    private void DisplayTutorial(int prompt)
    {
        foreach (Image image in prompts)
        {
            image.gameObject.SetActive(false);
        }
        prompts[prompt].gameObject.SetActive(true);
    }
}
