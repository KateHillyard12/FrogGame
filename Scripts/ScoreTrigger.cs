using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Get the PlayerMovement component attached to the other object
        PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();

        // Check if the player is jumping
        if (playerMovement != null && playerMovement.isJumping)
        {
            // Check which player it is and increment the appropriate score
            if (other.gameObject.CompareTag("PlayerOne"))
            {
                ScoreManager.Instance.PlayerOneScored();
            }
            else if (other.gameObject.CompareTag("PlayerTwo"))
            {
                ScoreManager.Instance.PlayerTwoScored();
            }
        }
    }
}