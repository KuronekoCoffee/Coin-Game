using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if (coin != null)
        {
            ScoreManager.Instance.AddScore(coin.ScoreValue);
            Destroy(other.gameObject);
        }
    }
}