using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float startPosition;
    private float backgroundLength;
    [SerializeField] private Camera _camera;

    private void Start()
    {
        startPosition = transform.position.x;
        backgroundLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        Vector3 position = _camera.transform.position;
        float temp = position.x * 0.9f;
        float distance = position.x * 0.1f;

        Vector3 newPosition = new Vector3(startPosition + distance, position.y, transform.position.z);

        transform.position = newPosition;

        if (temp > startPosition + (backgroundLength / 2))
        {
            startPosition += backgroundLength;
        }
        else if (temp < startPosition - (backgroundLength / 2))
        {
            startPosition -= backgroundLength;
        }
    }
}
