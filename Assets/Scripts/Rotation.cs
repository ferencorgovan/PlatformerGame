using UnityEngine;

public class Rotation : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.back, 360 * Time.deltaTime);
    }
}
