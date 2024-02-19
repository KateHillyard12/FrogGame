using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Text scoreTextPlayerOne; // Assign this in the Inspector
    public Text scoreTextPlayerTwo; // Assign this in the Inspector
    public Text winningText; // Assign this in the Inspector for displaying the winning message

    private int scorePlayerOne;
    private int scorePlayerTwo;
    private int jumpsToWin = 4; // Number of jumps required to win

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerOneScored()
    {
        scorePlayerOne++;
        scoreTextPlayerOne.text = "Player1: " + scorePlayerOne; // Update the Text element
        CheckForWinner();
        Debug.Log("Player One Scored! New score: " + scorePlayerOne);
    }

    public void PlayerTwoScored()
    {
        scorePlayerTwo++;
        scoreTextPlayerTwo.text = "Player2: " + scorePlayerTwo; // Update the Text element
        CheckForWinner();
        Debug.Log("Player Two Scored! New score: " + scorePlayerTwo);
    }

    private void CheckForWinner()
    {
        if (scorePlayerOne >= jumpsToWin)
        {
            DisplayWinningMessage("Player1 Won!");
        }
        else if (scorePlayerTwo >= jumpsToWin)
        {
            DisplayWinningMessage("Player2 Won!");
        }
    }

    private void DisplayWinningMessage(string message)
    {
        winningText.text = message;
        winningText.gameObject.SetActive(true);
    }
}

