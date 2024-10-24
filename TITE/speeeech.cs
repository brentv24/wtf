using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour
{
    public InputField inputField;
    public Button enterButton;
    public Image displayImage;

    // Create a list to store words and their corresponding sprites
    [System.Serializable]
    public class WordSpritePair
    {
        public string word;
        public Sprite sprite;
    }

    // Add these pairs in the Inspector
    public List<WordSpritePair> wordSpritePairs;

    void Start()
    {
        enterButton.onClick.AddListener(OnEnterButtonClick);
        displayImage.gameObject.SetActive(false); // Hide the image initially
    }

    void OnEnterButtonClick()
    {
        string inputText = inputField.text.ToLower(); // Convert input to lowercase
        displayImage.gameObject.SetActive(false); // Hide the image by default

        // Loop through all the word-sprite pairs to find a match
        foreach (WordSpritePair pair in wordSpritePairs)
        {
            if (inputText.Contains(pair.word.ToLower())) // Match the input word
            {
                displayImage.sprite = pair.sprite; // Assign the matched sprite
                displayImage.gameObject.SetActive(true); // Show the image
                return; // Exit the loop when the word is matched
            }
        }

        // If no word matches, hide the image
        displayImage.gameObject.SetActive(false);
    }
}
