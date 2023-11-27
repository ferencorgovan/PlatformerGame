using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private LayerMask ignoreLayer;

    private float laserMoveSpeed = 50.0f;

    private LineRenderer lineRenderer;
    private Vector2 currentEndPoint;

    
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        currentEndPoint = new Vector2(startPoint.position.x + 10f, startPoint.position.y);
    }

    public void MoveEndpoint(Vector2 moveDirection)
    {
        currentEndPoint += moveDirection * laserMoveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        Vector2 direction = currentEndPoint - (Vector2)startPoint.position;
        float rayLength = direction.magnitude;
        RaycastHit2D hit = Physics2D.Raycast(startPoint.position, direction, rayLength, ~ignoreLayer);
        Vector2 endpoint = hit.collider != null ? hit.point : currentEndPoint;
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endpoint);

        if (hit.collider != null)
        {
           PuzzleManager.instance.SolveLaserPuzzle(hit.collider.gameObject);
        }
        else
        {
            PuzzleManager.instance.SolveLaserPuzzle(null);
        }
        
    }
}
