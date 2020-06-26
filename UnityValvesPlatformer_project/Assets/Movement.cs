using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float deceleration;

    public float jumpSpeed;
    public float gravity;

    public float sensitivity = 15;
    public float maxYAngle = 85f;

    private float camAngleX;
    private float camAngleY;
    private Vector3 velocity;

    public GameObject player_camera;
    public CharacterController characterController;

    [System.NonSerialized]
    public bool onMovingPlatform;
    [System.NonSerialized]
    public PlatformAttach movingPlatform;


    void Start() {

        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        // Horizontal movement
        float vert = Input.GetAxisRaw("Vertical");
        float hor = Input.GetAxisRaw("Horizontal");

        Vector3 targetVelocity = (transform.forward * vert + transform.right * hor).normalized * maxSpeed;

        // If the player stops the velocity should decrease by "decelerate", otherwise it should increase by "accelerate"
        float t = targetVelocity == Vector3.zero ? deceleration : acceleration;

        Vector3 velocity_xz = Vector3.Lerp(velocity, targetVelocity, t);
        velocity = new Vector3(velocity_xz.x, velocity.y, velocity_xz.z);


        // Vertical movement

        if (characterController.isGrounded || onMovingPlatform)
        {
            velocity.y = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                velocity.y += jumpSpeed;
                if (onMovingPlatform)
                {
                    velocity += movingPlatform.rb.velocity;
                }
            }

            
        }
        else
        {
            velocity.y -= gravity*Time.deltaTime;
            
        }

        // Debug vector
        //Debug.DrawRay(transform.position, targetSpeed, Color.red);
        //Debug.DrawRay(transform.position, velocity, Color.black);

        //Apply rotation and update camera
        camAngleX += Input.GetAxis("Mouse X") * sensitivity;
        camAngleY += Input.GetAxis("Mouse Y") * sensitivity;
        camAngleY = Mathf.Clamp(camAngleY, -maxYAngle, maxYAngle);
        player_camera.transform.localRotation = Quaternion.Euler(-camAngleY, 0, 0);

        transform.rotation = Quaternion.Euler(0, camAngleX, 0);
    
        characterController.Move(velocity * Time.deltaTime);
    }
}