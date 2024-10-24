using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [Header("Title Settings")]
    [SerializeField] private Text titleText;  // Reference to the Text component
    [SerializeField] private string beginnerTitle = "Beginner"; // Default title
    [SerializeField] private string proTitle = "Pro"; // Changed title

    [Header("Scene Settings")]
    [SerializeField] private string targetSceneName = "qwe"; // Scene that grants the Pro title
    [SerializeField] private string userInfoSceneName = "UserInfo"; // User info scene name

    private void Start()
    {
        // Log current scene name
        Debug.Log("Current Scene: " + SceneManager.GetActiveScene().name);

        // Check if the user has previously earned the Pro title
        if (PlayerPrefs.GetInt("PlayerTitle", 0) == 1)
        {
            titleText.text = proTitle; // Set title to Pro if previously earned
            Debug.Log("Title set to Pro from PlayerPrefs");
        }
        else if (SceneManager.GetActiveScene().name == targetSceneName || SceneManager.GetActiveScene().name == userInfoSceneName)
        {
            GiveProTitle(); // Grant Pro title if in the target or user info scene
            Debug.Log("Pro title granted");
        }
        else
        {
            titleText.text = beginnerTitle; // Default title for other scenes
            Debug.Log("Title set to Beginner");
        }
    }

    private void GiveProTitle()
    {
        titleText.text = proTitle; // Change title to Pro
        PlayerPrefs.SetInt("PlayerTitle", 1); // Save the Pro title status
        PlayerPrefs.Save(); // Ensure changes are saved
        Debug.Log("Pro title saved");
    }
}