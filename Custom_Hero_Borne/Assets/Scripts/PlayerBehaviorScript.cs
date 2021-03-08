using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotateSpeed = 15f;

    public float jumpVelocity = 25f;
    public float distanceToGround = 0.1f;
    public LayerMask groundlayer;

    public GameObject bullet;
    public float bulletSpeed = 1f;
    public bool JumpNow = false;
    public bool BulletNow = false;

    private float vInput;
    private float hInput;
    private CapsuleCollider col;
    private Rigidbody _rb;
    public float HealthTickingDown = .25f;

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
        //Jump Detection
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            JumpNow = true;
        }

        //Shoot Detection and conditionals
        if (Input.GetMouseButtonDown(0))
        {
            if (gameManager.Ammo > 0)
            {
                BulletNow = true;
            }
            else
                Debug.Log("You ran out of Ammo!!!");

        }

        if (HealthTickingDown > 0)
            HealthTickingDown -= Time.deltaTime;
        /*   transform.Translate(Vector3.forward * vInput * Time.deltaTime);
             transform.Rotate(Vector3.up * hInput * Time.deltaTime);  */
    }

    void FixedUpdate()
    {
        //Jump Mechanic
        if (JumpNow)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            JumpNow = false;
        }

        //bullet Mechanic
        if (BulletNow)
        {
            GameObject newBullet = Instantiate(bullet, transform.position + transform.forward + new Vector3(0,.25f,0), transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = transform.forward * bulletSpeed;
            gameManager.Ammo--;
            BulletNow = false;
        }

        //Movement Mechanic
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
        if (col.gameObject.CompareTag("Enemy"))
        {
            gameManager.HP -= 1;
            HealthTickingDown = .25f;
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if(col.gameObject.CompareTag("Enemy") && HealthTickingDown<=0)
        {
            gameManager.HP -= 1;
            HealthTickingDown = .25f;
        }
    }

}
