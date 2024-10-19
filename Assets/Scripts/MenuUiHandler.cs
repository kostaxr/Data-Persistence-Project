using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUiHandler : MonoBehaviour
{

    // Public fields to be assigned in the Unity Editor (drag and drop)
    public TMP_Text highScoreText;
    public TMP_Text highScoreNameText;
    public TMP_InputField playerNameInput;
    public Button startButton;

    // High Score variables
    private int highScore; 
    private string highScoreName;

    // Player's name input
    private string playerName;

    void Start()
    {
        highScore = MainManager.Instance.highScore;
        highScoreName = MainManager.Instance.highName;
        // Set up initial high score display
        UpdateHighScoreDisplay();

        // Add listener to the input field to capture player name
        playerNameInput.onValueChanged.AddListener(OnNameInputChanged);

        // Add listener for the start button
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    // Update the displayed high score and name
    void UpdateHighScoreDisplay()
    {
        highScoreText.text = "High Score: " + highScore;
        highScoreNameText.text = "Name: " + highScoreName;
    }

    // Capture input from the name input field
    void OnNameInputChanged(string input)
    {
        playerName = input;
        MainManager.Instance.selName = playerName;
    }

    // Function for the start button, called when button is clicked
    void OnStartButtonClicked()
    {
        if (!string.IsNullOrEmpty(playerName))
        {
            SceneManager.LoadScene(1);
        }
    }
}

