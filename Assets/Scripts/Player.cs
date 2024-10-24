using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    
    
    //Movement
    [Header("Movement")]
    [SerializeField] private float speed;
    
    private Vector3 _moveDirection;

    [SerializeField] private float jumpForce;

    private bool isGrounded;

    private Rigidbody rb;

    //Camera
    [Header("Camera")]
    [SerializeField, Range(1,20)] private float mouseSensX;
    [SerializeField, Range(1,20)] private float mouseSensY;
    
    [SerializeField, Range(-90,0)] private float minViewAngle;
    [SerializeField, Range(0,90)] private float maxViewAngle;

    [SerializeField] private Transform followTarget; 
    
    private Vector2 currentAngle;

    //UI
    [Header("UI")]
    public TextMeshProUGUI countText;
    private int count;
    public GameObject winTextObject;
    public GameObject mainMenuButton;
    public GameObject playAgainButton;
   
    //Win state 
    private bool win = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        
        InputManager.SetGameControls();
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDirection);
        
        //calls the check ground method 
        checkGround();
        
        
    }

    public void SetMovementDirection(Vector3 currentDirection)
    {
        _moveDirection = currentDirection;
    }

    public void jump()
    {
        if (isGrounded)
        {
            //if player is grounded adds force to the rigidbody instantly 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    private void checkGround()
    {
        //checks to see if the object is touching the ground 
        isGrounded = Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.size.y);
        Debug.DrawRay(transform.position,Vector3.down * GetComponent<Collider>().bounds.size.y, Color.green,0,false);
        
    }
    
    public void SetLookRotation(Vector2 readValue)
    {
        currentAngle.x += readValue.x * Time.deltaTime * mouseSensX;
        currentAngle.y += readValue.y * Time.deltaTime * mouseSensY;

        currentAngle.y = Mathf.Clamp(currentAngle.y, minViewAngle, maxViewAngle);
        
        
        transform.rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up);
        followTarget.localRotation = Quaternion.AngleAxis(currentAngle.y, Vector3.right);
    
    }
    
    private void OnTriggerEnter(Collider other)
        {
    
            //if the player collides with a collectable do this 
            if (other.gameObject.CompareTag("Collectable"))
            {
                //Add 1 to the count, destroy the object, play the sound effect and update the text  
                other.gameObject.SetActive(false);
                count++;
                SetCountText();
            }
    
        }
    
    void SetCountText()
    {
        
        //Sets the coin count to be equal to the amount the player has gotten 
        countText.text = "Count: " + count.ToString();
        
        // if they got all the coins display the win text sounds and buttons 
        if (count >= 35) // can change number to the amount of collectables there are
        {
            //shows all the buttons 
            playAgainButton.SetActive(true);
            winTextObject.SetActive(true);
            mainMenuButton.SetActive(true);
            
            //sets win status to true and plays the win sound  
            win = true;
        }
        
        
    }
    
}