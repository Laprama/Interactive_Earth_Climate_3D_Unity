using UnityEngine;
 namespace getReal3D
{
public class User_Rotates_EarthCAVE : MonoBehaviour
{
    // Drag your main camera from the Hierarchy into this slot in the Inspector.
    public Camera viewCamera;

    // You can adjust the rotation speed in the Unity Inspector.
    public float rotationSpeed = 50f;

    void Start()
    {
        // This message will appear in your console if you forget to assign the camera.
        if (viewCamera == null)
        {
            Debug.LogError("The 'View Camera' has not been assigned in the Inspector. Please drag your main camera to the script's slot.", this);
        }
    }

    void Update()
    {
        // Stop the script from running if the camera has not been assigned.
        if (viewCamera == null)
        {
            return;
        }

        // Get the camera's transform directions
        Transform cameraTransform = viewCamera.transform;

        // Horizontal Rotation (J and L keys)
        if (Input.GetAxis("LeftRight")>0.5f)
        {
            transform.Rotate(cameraTransform.up, -rotationSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetAxis("LeftRight")<-0.5f)
        {
            transform.Rotate(cameraTransform.up, rotationSpeed * Time.deltaTime, Space.World);
        }

        // Vertical Rotation (I and K keys)
         if (Input.GetAxis("UpDown")>0.5f)
        {
            transform.Rotate(cameraTransform.right, rotationSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetAxis("UpDown")<-0.5f)
        {
            transform.Rotate(cameraTransform.right, -rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}
}