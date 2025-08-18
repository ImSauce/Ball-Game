using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    [Header("-------------[ Camera X and Z ]-------------")]
    public Vector3 offset = new Vector3(0, 5, -10);

    [Header("-------------[ Camera Rotation Y ]-------------")]
    public Vector3 rotation = new Vector3(20, 0, 0);

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.Euler(rotation);
    }
}




//------                 [ DEFAULT CAMERA ANGLE ]              ------//
//using UnityEngine;

// public class CameraController : MonoBehaviour
// {
//     public GameObject player;
//     private Vector3 offset;
//     void Start()
//     {
//         offset = transform.position - player.transform.position;
//     }

//     void LateUpdate()
//     {
//         transform.position = player.transform.position + offset;
//     }
// }


















//------                 [ CAMERA ROTATION USING MOUSE ]              ------//

// using UnityEngine;

// public class CameraController : MonoBehaviour
// {
//     public GameObject player;
//     public float mouseSensitivity = 3f; // how fast camera rotates
//     private Vector3 offset;
//     private float yaw = 0f; // horizontal rotation

//     void Start()
//     {
//         offset = transform.position - player.transform.position;
//         Cursor.lockState = CursorLockMode.Locked; // hide + lock cursor to screen center
//     }

//     void LateUpdate()
//     {
//         // Get horizontal mouse movement (X axis)
//         float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

//         // Add it to yaw (rotation around Y axis)
//         yaw += mouseX;

//         // Rotate offset vector around player based on yaw
//         Quaternion rotation = Quaternion.Euler(0, yaw, 0);
//         Vector3 rotatedOffset = rotation * offset;

//         // Position camera around player
//         transform.position = player.transform.position + rotatedOffset;

//         // Make camera look at player
//         transform.LookAt(player.transform);
//     }
// }