using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
