using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public TargetManager targetManager;
    public float speed;
    public Vector3 initialPosition;


    public void Awake()
    {
        targetManager = GameObject.Find("Target Manager").GetComponent<TargetManager>();
        initialPosition = transform.position;
    }

    public void Update()
    {
        transform.position = initialPosition + new Vector3(0, 0, 1) * speed * Mathf.Sin(Time.time * 2);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            targetManager.StartNextTarget();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
