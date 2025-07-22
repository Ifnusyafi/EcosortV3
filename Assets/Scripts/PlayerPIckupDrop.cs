using UnityEngine;

public class PlayerPickupDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabable objectGrabable;

    void Update()
    {
        if (objectGrabable == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                float pickupDistance = 5f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
                {
                    Debug.Log("Raycast hit: " + raycastHit.transform.name);
                    if (raycastHit.transform.TryGetComponent(out ObjectGrabable foundObject))
                    {
                        objectGrabable = foundObject;
                        objectGrabable.Grab(objectGrabPointTransform);
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            objectGrabable.Drop();
            objectGrabable = null;
        }
    }
}
