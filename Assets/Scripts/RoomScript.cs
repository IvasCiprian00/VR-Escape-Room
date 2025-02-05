using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameObject safeDoorPivot;
    public bool safeOpened;

    public void Update()
    {
        if (safeOpened)
        {
            safeDoorPivot.transform.eulerAngles = new Vector3(0, 145, 0);
        }
        else
        {
            safeDoorPivot.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void SetSafeDoorRotation()
    {
        safeOpened = true;
        safeDoorPivot.transform.eulerAngles = new Vector3(0, 145, 0);
    }
}
