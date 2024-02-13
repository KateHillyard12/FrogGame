using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

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

    public Text scoreTextPlayerOne; // Assign this in the Inspector
    public Text scoreTextPlayerTwo; // Assign this in the Inspector

    private int scorePlayerOne;
    private int scorePlayerTwo;


    public void PlayerOneScored()
    {
        scorePlayerOne++;
        scoreTextPlayerOne.text = "Player One: " + scorePlayerOne; // Update the Text element
        Debug.Log("Player One Scored! New score: " + scorePlayerOne);
    }

    public void PlayerTwoScored()
    {
        scorePlayerTwo++;
        scoreTextPlayerTwo.text = "Player Two: " + scorePlayerTwo; // Update the Text element
    }
}