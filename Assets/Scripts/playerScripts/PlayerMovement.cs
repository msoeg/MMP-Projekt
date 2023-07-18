using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed;
    public CapsuleCollider2D capsuleCollider;

    private bool _canPressKey;
    private bool _isMoving;
    private const bool CanMoveHorizontally = true;
    private string _stairType = "";
    private Vector3 _targetPosition;
    private PlayerHealth _playerHealth;

    public Animator animator;
    private static readonly int TrStairDown = Animator.StringToHash("TrStairDown");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int TrStairUp = Animator.StringToHash("TrStairUp");
    private static readonly int TrClimb = Animator.StringToHash("TrClimb");
    private static readonly int Default = Animator.StringToHash("Default");

    void Start()
    {
        myRigidbody.freezeRotation = true;
        _playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (CanMoveHorizontally && !_isMoving)
        {
            animator.SetFloat(Horizontal, moveHorizontal);
            Vector3 movement = new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, 0, 0);
            transform.position += movement;
        }

        HandleInput();
        if(_isMoving) MovePlayer();
    }

    private void HandleInput()
    {
        if (_canPressKey)
        {
            if (!_isMoving)
            {
                if (CanMoveHorizontally)
                {
                    if (_stairType.Equals("StairUp") &&
                        (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
                    {
                        Vector3 goUp = new Vector3(0f, 3f, 0f);
                        _targetPosition = transform.position + goUp;
                        capsuleCollider.enabled = false;
                        _isMoving = true;
                        animator.SetFloat(Horizontal, 0f);
                        animator.SetTrigger(TrClimb);

                    }
                    else if (_stairType.Equals("StairDown") &&
                             (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
                    {
                        Vector3 goDown = new Vector3(0f, -3f, 0f);
                        _targetPosition = transform.position + goDown;
                        capsuleCollider.enabled = false;
                        _isMoving = true;
                        animator.SetFloat(Horizontal, 0f);
                        animator.SetTrigger(TrClimb);
                    }
                    else if (_stairType.Equals("StairDiagUp") &&
                             (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
                    {
                        Vector3 goUp = new Vector3(3.5f, 3f, 0f);
                        _targetPosition = transform.position + goUp;
                        capsuleCollider.enabled = false;
                        _isMoving = true;
                        animator.SetFloat(Horizontal, 0f);
                        animator.SetTrigger(TrStairUp);
                    }
                    else if (_stairType.Equals("StairDiagDown") &&
                             (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
                    {
                        Vector3 goDown = new Vector3(-3.5f, -3f, 0f);
                        _targetPosition = transform.position + goDown;
                        capsuleCollider.enabled = false;
                        _isMoving = true;
                        animator.SetFloat(Horizontal, 0f);
                        animator.SetTrigger(TrStairDown);
                    }
                }
            }
        }
    }
    
    private void MovePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);

        // Check if the player has reached the target position
        if (transform.position == _targetPosition)
        {
            capsuleCollider.enabled = true;
            animator.SetTrigger(Default);
            _isMoving = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "StairUp":
                _canPressKey = true;
                _stairType = "StairUp";
                Debug.Log("Can press key");
                break;
        
            case "StairDown":
                _canPressKey = true;
                _stairType = "StairDown";
                Debug.Log("Can press key");
                break;
        
            case "StairDiagUp":
                _canPressKey = true;
                _stairType = "StairDiagUp";
                Debug.Log("Can press key");
                break;
        
            case "StairDiagDown":
                _canPressKey = true;
                _stairType = "StairDiagDown";
                Debug.Log("Can press key");
                break;
        
            case "Ghost":
                if (this.gameObject.GetComponent<HideInteraction>().isHidden == false) Debug.Log("Player ran into ghost!");
                else Debug.Log("The Ghost didn't get you");
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "StairUp":
            case "StairDown":
            case "StairDiagDown":
            case "StairDiagUp":
                _stairType = "";
                _canPressKey = false;
                Debug.Log("Can't press key");
                break;
            case "Ghost":
                if (this.gameObject.GetComponent<HideInteraction>().isHidden == false)
                {
                    _playerHealth.SubtractHealth();
                    Debug.Log("Player ran into ghost!");
                }
                else Debug.Log("The Ghost didn't get you");
                break;
        }
    }
}