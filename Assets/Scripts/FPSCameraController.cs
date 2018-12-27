using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FPSCameraController : base_character
{

    #region attributes
    public bool enable = true;                  //allows to disable the update method, without disabling the entire component

          
    public float cameraSensitvity = 1.0f;       


    //default key bindings
    public KeyCode moveForwardKey = KeyCode.W;
    public KeyCode moveBackwardKey = KeyCode.S;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;

    public GameObject cameraRig;            //The camera should be on a seperate gameObject that is a child to this component, allowing for the camera to be moved
                                            //independently from the player.


    private CharacterController characterController;    //use for the move command, collision detection, etc.
    
    //we track the euler angles independently for easy math on the camera
    private float cameraYaw;        
    private float cameraPitch;
    private float cameraRoll;       //unused for now

    //tracks the current direction that the player is moving
    private Vector3 movementDirection = Vector3.zero;

    #endregion


    #region Private Methods


    //Immediately set up references, and check to see that the setup is correct.
    void Awake()
    {
        //get the component reference. This component is required automatically by the base_character class
        characterController = GetComponent<CharacterController>();
        

        //check to see that the camera rig reference exists
        if (cameraRig == null)
        {
            Debug.LogError("No camera rig reference found. Please add a reference to the player's gameobject that contains a camera.");
        }
        else
        {
            //Check to see if anything else is fishy about the setup.
            if(cameraRig.GetComponent<Camera>() == null)
            {
                Debug.LogWarning("No camera found on camera rig gameobject. First Person Camera Controller may behave unexpectedly.");
            }
            if(cameraRig.transform.parent != transform)
            {
                Debug.LogWarning("The Camera Rig is not a child of the FPS character controller, which may behave unexpectedly as a result.");
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
        //check to see if movement is enabled
        if (!enable) return;

        handleMouseRotation();
        handleMovementWalking();
    }


    //Checks mouse input, and moves the camera object and character for 1 frame.
    private void handleMouseRotation()
    {
        //prevent the player from looking too high, or too low
        const float PITCH_LIMIT = 70f;

        
        cameraYaw += Input.GetAxis("Mouse X") * cameraSensitvity;       // Compute new horizontal rotation (yaw)
        cameraPitch -=  Input.GetAxis("Mouse Y")* cameraSensitvity;     // Compute new vertical rotation (pitch)

        //limit the pitch
        cameraPitch = clampValue(cameraPitch, -PITCH_LIMIT, PITCH_LIMIT);

        cameraRig.gameObject.transform.localEulerAngles = new Vector3(cameraPitch, 0, 0);       //rotate the camera locally (just the camera gameobject)
        gameObject.transform.eulerAngles = new Vector3(0, cameraYaw, 0);                        //rotate the entire character, not just the camera
    }

    //Checks keyboard input based on keybindings, and moves the character for 1 frame.
    private void handleMovementWalking()
    {

        //Vectors used to track movement
        Vector3 forwardMovement = Vector3.zero;
        Vector3 lateralMovement = Vector3.zero;
        Vector3 verticalMovement = Vector3.zero;




        //Get vector for forward/back
        if (Input.GetKey(moveForwardKey) )
        {
            forwardMovement = transform.forward * baseMovespeed;
        }
        if (Input.GetKey(moveBackwardKey) )
        {
            forwardMovement += transform.forward * -baseMovespeed;
        }

        //Get vector for left/right
        if (Input.GetKey(moveLeftKey))
        {
            lateralMovement = transform.right * -baseMovespeed;
        }
        if (Input.GetKey(moveRightKey))
        {
            lateralMovement += transform.right * baseMovespeed;
        }

        //Get the vector for the vertical movement
        if (characterController.isGrounded)         //you are not allowed to jump while falling
        {
            movementDirection = forwardMovement + lateralMovement;

            //Get vector for jumping
            if (Input.GetKeyDown(jumpKey))
            {
                movementDirection.y = baseJumpStrength;
            }
        }

        //Apply gravity
        movementDirection.y = movementDirection.y + (GRAVITY * Time.deltaTime);


        //now that all of our vectors have been calculated, we can actually move the character using Unity's character controller.
        characterController.Move(movementDirection * Time.deltaTime);

    }


    private float clampValue(float val, float min, float max)
    {
        if (val > max) return max;
        if (val < min) return min;
        return val;
    }
#endregion

}
