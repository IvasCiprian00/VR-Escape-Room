using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabDetection : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;
    [SerializeField] private Rigidbody _rigidbody;

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

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        Debug.Log(gameObject.name + " was grabbed!");
    }

    private void OnRelease(SelectExitEventArgs args)
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
