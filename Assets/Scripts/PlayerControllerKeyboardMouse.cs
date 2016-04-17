using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControllerKeyboardMouse : MonoBehaviour
{
    PlayerHealth playerHealth;
    public static Vector3 movement;

    public Rigidbody rb;
    float camRayLength = 100f;
    int floorMask;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        floorMask = LayerMask.GetMask("Floor");
    }

    void FixedUpdate()
    {
        Turning();
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

         transform.rotation = newRotation;
        }
    }
}