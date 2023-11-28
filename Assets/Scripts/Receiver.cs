using UnityEngine;

public class Receiver : MonoBehaviour
{
    [SerializeField] private GameObject door;

    public void Open()
    {
        door.GetComponent<UnlockDoor>().Unlock();
    }
    
    public void Close()
    {
        door.GetComponent<UnlockDoor>().Close();
    }
}
