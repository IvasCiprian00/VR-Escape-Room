using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public Animator roomAnimator;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Lock")
        {
            Debug.Log("YEY");
            roomAnimator.SetTrigger("openDoorTrigger");
        }
    }
}
