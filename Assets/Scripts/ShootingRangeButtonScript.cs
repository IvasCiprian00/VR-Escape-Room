using UnityEngine;

public class ShootingRangeButtonScript : MonoBehaviour
{
    public GameObject blocker;
    public bool shouldMove;

    public void Update()
    {
        if (!shouldMove)
        {
            return;
        }

        blocker.transform.Translate(Vector3.up / 3 * Time.deltaTime);
    }

    public void MoveBlocker()
    {
        shouldMove = true;
        Invoke("CancelMove", 10f);
    }

    public void CancelMove()
    {
        shouldMove = false;
    }
}
