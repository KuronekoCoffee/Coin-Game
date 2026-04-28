using UnityEngine;

public class Boxmove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float moveDistance = 3f;

    private Vector3 startPosition;
    private bool movingForward = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 dir = movingForward ? Vector3.forward : Vector3.back;
        transform.Translate(dir * speed * Time.fixedDeltaTime);

        float distance = Vector3.Distance(startPosition, transform.position);

        if (movingForward && distance >= moveDistance)
        {
            movingForward = false;
        }
        else if (!movingForward && distance <= 0.1f)
        {
            movingForward = true;
        }
    }
}
