using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("生成するコインのプレハブ")]
    [SerializeField] private GameObject coinPrefab;

    [Header("生成位置")]
    [SerializeField] private Transform spawnPoint;

    [Header("生成したコインの親")]
    [SerializeField] private Transform coinRoot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCoin();
        }
    }

    public void SpawnCoin()
    {
        Instantiate(coinPrefab, spawnPoint.position, spawnPoint.rotation, coinRoot);
    }
}
