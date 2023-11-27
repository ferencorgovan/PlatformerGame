using UnityEngine;

public class LaserEnable : MonoBehaviour
{
    private LaserControls controls;
    private LaserController laserController;
    private void OnEnable()
    {
        controls = new LaserControls();
        controls.Enable();

        laserController = GetComponent<LaserController>();

        controls.Laser.MoveUp.performed += ctx => laserController.MoveEndpoint(Vector2.up);
        controls.Laser.MoveDown.performed += ctx => laserController.MoveEndpoint(Vector2.down);
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
