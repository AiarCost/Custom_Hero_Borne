using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotateSpeed = 15f;

    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundlayer;

    public GameObject bullet;
    public float bulletSpeed = 100f;

    private float vInput;
    private float hInput;
    private CapsuleCollider col;
    private Rigidbody _rb;

    public GameBehavior gameManager;

    void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        _rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }
 
    // Update is called once per frame
    void Update()
    {

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

   /*   transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        transform.Rotate(Vector3.up * hInput * Time.deltaTime);  */
    }

    void FixedUpdate()
    {
        //Jump Mechanic
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }

        //bullet Mechanic
        if (Input.GetMouseButtonDown(0))
        {   if (gameManager.Ammo > 0)
            {
                GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(1, 0, 0), transform.rotation) as GameObject;
                Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
                bulletRB.velocity = transform.forward * bulletSpeed;
                gameManager.Ammo--;
            }
            else
                Debug.Log("You ran out of Ammo!!!");

        }


        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(col.bounds.center, capsuleBottom, distanceToGround, groundlayer, QueryTriggerInteraction.Ignore);

        return grounded;

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            gameManager.HP -= 1;
        }
    }

}
