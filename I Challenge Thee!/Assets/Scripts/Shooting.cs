using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject bulletPrefab; // Assign the bullet prefab in the Inspector.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootScript();
        }
    }
    private void ShootScript()
    {
        if (targetObject != null)
        {
            Vector3 targetPosition = targetObject.transform.position;
            Quaternion targetRotation = targetObject.transform.rotation;

            // Instantiate the bullet at the target position and rotation.
            GameObject bullet = Instantiate(bulletPrefab, targetPosition, targetRotation);

            // Apply a force to the bullet.
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.AddForce(bullet.transform.forward * 120, ForceMode.VelocityChange);
            }

            Destroy(bullet, 3f);
        }
    }
}
