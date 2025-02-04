using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class GunScript : GrabDetection
{
    public GameObject bullet;
    public float bulletSpeed;
    public bool canShoot;
    public Transform bulletSpawnLocation;
    public XRNode controllerNode = XRNode.RightHand; // Change to LeftHand if needed

    void Update()
    {
        if (!isGrabbed)
        {
            return;
        }

        UnityEngine.XR.InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);

        if (device.isValid) // Ensure the controller is detected
        {
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out float triggerValue))
            {
                if(triggerValue > 0.5)
                {
                    if (canShoot)
                    {
                        GameObject reference = Instantiate(bullet, bulletSpawnLocation.position, bulletSpawnLocation.rotation);
                        reference.GetComponent<Rigidbody>().linearVelocity = -reference.transform.up * bulletSpeed;
                        StartCoroutine(DestroyAfterDelay(reference, 1f));
                        canShoot = false;
                    }
                }
                else
                {
                    canShoot = true;
                }
            }
            else
            {
                Debug.Log("Trigger feature not available.");
            }
        }
        else
        {
            Debug.Log("Controller not detected.");
        }
    }

    public IEnumerator DestroyAfterDelay(GameObject objectToDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(objectToDestroy);
    }
}
