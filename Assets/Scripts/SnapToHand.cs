using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SnapToHand : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Get the interactor (hand/controller) grabbing the object
        Transform handTransform = args.interactorObject.transform;

        // Snap object to the hand's position and rotation
        transform.position = handTransform.position;
        transform.rotation = handTransform.rotation;
    }
}
