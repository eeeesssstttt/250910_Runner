using UnityEngine;

public class EndCourse : MonoBehaviour
{
    private Collider playerCollider;
    [SerializeField] GameObject plane;
    private Collider planeCollider;
    private float endOfPlane;
    private Vector3 endPosition;

    void Start()
    {
        playerCollider = GetComponent<Collider>();
        planeCollider = plane.GetComponent<Collider>();
        endOfPlane =
        plane.transform.position.z
        + planeCollider.bounds.extents.z
        - playerCollider.bounds.extents.z;
    }

    void Update()
    {
        Debug.Log(endOfPlane);
        if (transform.position.z >= endOfPlane)
        {
            Debug.Log("END!");
            endPosition = transform.position;
            GetComponent<ForwardMovement>().velocity = 0;
            GetComponent<PlayerControl>().lateralVelocity = 0;
            GetComponent<PlayerControl>().jumpVelocity = 0;
        }
    }
}
