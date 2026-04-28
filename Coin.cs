using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;

    public int ScoreValue => scoreValue;
}