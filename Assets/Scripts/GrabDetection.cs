using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabDetection : MonoBehaviour
{
    protected XRGrabInteractable grabInteractable;
    protected bool isGrabbed = false;
    [SerializeField] protected Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }

    protected void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        Debug.Log(gameObject.name + " was grabbed!");
    }

    protected void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        Debug.Log(gameObject.name + " was released!");
        _rigidbody.isKinematic = false;
    }

    public bool IsObjectGrabbed()
    {
        return isGrabbed;
    }
}
