using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GemScript : MonoBehaviour
{
    public BookScript bookScript;
    private bool _wasGrabbed;
    private bool _wasPlacedInBook;
    [SerializeField] private Transform _initialGemSlot;
    [SerializeField] private Transform _bookGemSlot;
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

    private void Update()
    {
        if (_wasPlacedInBook)
        {
            transform.position = _bookGemSlot.position;
            transform.rotation = _bookGemSlot.rotation;
            _rigidbody.isKinematic = true;
            return;
        }

        if (_wasGrabbed)
        {
            return;
        }

        transform.position = _initialGemSlot.position;
        transform.rotation = _initialGemSlot.rotation;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        _wasGrabbed = true;
        transform.parent = null;
        Debug.Log(gameObject.name + " was grabbed!");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        _rigidbody.isKinematic = false;
        Debug.Log(gameObject.name + " was released!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gem Slot")
        {
            bookScript.OnGemPlaced();
            _rigidbody.isKinematic = true;
            GetComponent<SphereCollider>().enabled = false;
            transform.position = other.transform.position;
            _bookGemSlot = other.transform;
            other.GetComponent<SphereCollider>().enabled = false;
            _wasPlacedInBook = true;
        }
    }

    public bool IsObjectGrabbed()
    {
        return isGrabbed;
    }
}
