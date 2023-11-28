using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    private GameObject level2_block;
    public int enemiesDefeated;
    public int level3_levers;
    private GameObject[] lights;

    private Receiver lastHit;
    private GameObject waypoint1;
    private GameObject waypoint2;
    private GameObject active_waypoint;


    private Vector2 startPosition;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        enemiesDefeated = 0;
        level3_levers = 0;

        if (SceneManager.GetActiveScene().buildIndex == 5)
            startPosition = GameObject.Find("ReceiverWaypoint1").transform.position;
    }
    public void SolveLeverPuzzle(int level, bool switched)
    {
        switch (level)
        {
            case 2:
                Level2LeverPuzzle(switched);
                break;
            case 3:
                Level3LeverPuzzle(switched);
                break;
            case 4:
                waypoint1 = GameObject.Find("ReceiverWaypoint1");
                waypoint2 = GameObject.Find("ReceiverWaypoint2");
                active_waypoint = switched ? waypoint2 : waypoint1;
                break;
        }
    }

    private void Level3LeverPuzzle(bool switched)
    {
        lights = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.name == "Circle").ToArray();

        int amount = switched ? 1 : -1;
        level3_levers += amount;

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponent<SpriteRenderer>().color =
                (i < level3_levers) ? UnityEngine.Color.green : UnityEngine.Color.red;
        }

        if (level3_levers == 5)
        {
            Destroy(GameObject.Find("Door"));
        }
    }

    private void Level2LeverPuzzle(bool switched)
    {
        level2_block = GameObject.Find("SwordPuzzleBlock");
        level2_block.GetComponent<SpriteRenderer>().enabled = switched;
        level2_block.GetComponent<BoxCollider2D>().enabled = switched;
    }

    private void Level2PlatformPuzzle()
    {
        GameObject.Find("EnemyPuzzleBlock").GetComponent<Animator>().SetTrigger("up");
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        if (SceneManager.GetActiveScene().buildIndex == 2 && enemiesDefeated == 3)
        {
            Level2PlatformPuzzle();
        }
    }

    public void SolveLaserPuzzle(GameObject receiver)
    {
        if (receiver != null)
        {
            if (receiver.TryGetComponent<Receiver>(out Receiver laserreceiver))
            {
                laserreceiver.Open();
                lastHit = laserreceiver;
            }
            else
            {
                if (lastHit != null)
                {
                    lastHit.Close();
                }
            }
        }
    }

    public void Level4ButtonPuzzle(ButtonDirection direction)
    {
        waypoint1 = GameObject.Find("ReceiverWaypoint1");
        waypoint2 = GameObject.Find("ReceiverWaypoint2");
        if (active_waypoint == null)
        {
            active_waypoint = waypoint1;
        }
        switch (direction)
        {
            case ButtonDirection.TopLeft:
                active_waypoint.transform.position = new Vector2(startPosition.x - 3.5f, startPosition.y + 3.5f);
                break;
            case ButtonDirection.Top:
                active_waypoint.transform.position = new Vector2(startPosition.x, startPosition.y + 3.5f);
                break;
            case ButtonDirection.TopRight:
                active_waypoint.transform.position = new Vector2(startPosition.x + 3.5f, startPosition.y + 3.5f);
                break;
            case ButtonDirection.BottomLeft:
                active_waypoint.transform.position = new Vector2(startPosition.x - 3.5f, startPosition.y - 3.5f);
                break;
            case ButtonDirection.Bottom:
                active_waypoint.transform.position = new Vector2(startPosition.x, startPosition.y - 3.5f);
                break;
            case ButtonDirection.BottomRight:
                active_waypoint.transform.position = new Vector2(startPosition.x + 3.5f, startPosition.y - 3.5f);
                break;
        }
    }
}
