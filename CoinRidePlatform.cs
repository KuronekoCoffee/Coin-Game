using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CoinRidePlatform : MonoBehaviour
{
    [SerializeField] private string movingFloorTag = "MovingFloor";

    private Rigidbody rb;
    private Transform currentPlatform;
    private Vector3 lastPlatformPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(movingFloorTag)) return;

        currentPlatform = collision.transform;
        lastPlatformPosition = currentPlatform.position;

        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag(movingFloorTag)) return;

        currentPlatform = collision.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (currentPlatform != null && collision.transform == currentPlatform)
        {
            currentPlatform = null;
        }
    }

    private void FixedUpdate()
    {
        if (currentPlatform == null) return;

        Vector3 delta = currentPlatform.position - lastPlatformPosition;

        // YÇÕìÆÇ©Ç≥Ç∏ÅAè∞ÇÃâ°à⁄ìÆÇæÇØèÊÇπÇÈ
        delta.y = 0f;

        rb.MovePosition(rb.position + delta);
        rb.angularVelocity = Vector3.zero;

        lastPlatformPosition = currentPlatform.position;
    }
}