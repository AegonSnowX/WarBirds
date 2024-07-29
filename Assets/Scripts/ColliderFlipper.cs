using UnityEngine;

public class ColliderFlipper : MonoBehaviour
{
    public PolygonCollider2D engineCollider;
    public PolygonCollider2D backCollider;
    public PolygonCollider2D middleBackCollider;
    public PolygonCollider2D middleFrontCollider;

    private Vector3 engineColliderLocalPos;
    private Vector3 backColliderLocalPos;
    private Vector3 middleBackColliderLocalPos;
    private Vector3 middleFrontColliderLocalPos;

    void Start()
    {
        // Save initial local positions of the colliders relative to the car
        engineColliderLocalPos = engineCollider.transform.localPosition;
        backColliderLocalPos = backCollider.transform.localPosition;
        middleBackColliderLocalPos = middleBackCollider.transform.localPosition;
        middleFrontColliderLocalPos = middleFrontCollider.transform.localPosition;
    }

    void Update()
    {
        // Update the positions of the colliders to match their initial local positions
        engineCollider.transform.localPosition = engineColliderLocalPos;
        backCollider.transform.localPosition = backColliderLocalPos;
        middleBackCollider.transform.localPosition = middleBackColliderLocalPos;
        middleFrontCollider.transform.localPosition = middleFrontColliderLocalPos;

        // Optionally, if you have rotation to handle, you can update their rotation as well
        // Example: engineCollider.transform.localRotation = Quaternion.identity;
    }
}
