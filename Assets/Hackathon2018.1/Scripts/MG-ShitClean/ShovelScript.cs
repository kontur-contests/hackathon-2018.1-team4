using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : MonoBehaviour {

    GameObject shovel;
    HingeJoint2D joint;
    Rigidbody2D rigidbody;
    private GameObject LeftUpPoint;
    private GameObject RightDownPoint;
    bool rotation = false;

    float moveSpeed = 0.2f;

    // Use this for initialization
    void Start ()
    {
        LeftUpPoint = GameObject.Find("LeftUpPoint");
        RightDownPoint = GameObject.Find("RightDownPoint");
        shovel = GameObject.Find("Shovel");
        joint = shovel.GetComponent<HingeJoint2D>();
        rigidbody = shovel.GetComponent<Rigidbody2D>();

        var leftWall = GameObject.Find("LeftWall").GetComponent<Renderer>().enabled = false;
        var rightWall = GameObject.Find("RightWall").GetComponent<Renderer>().enabled = false;
        var ground = GameObject.Find("Ground").GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotationLogic();
        MoveLogic();
    }

    private void MoveLogic()
    {
        var x = shovel.transform.position.x;
        var y = shovel.transform.position.y;
        var z = shovel.transform.position.z;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            y += moveSpeed;
        }
        if (x - 0.3 >= LeftUpPoint.transform.position.x && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            x -= moveSpeed;
        }
        if (y - 0.3 >= 0 && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            y -= moveSpeed;
        }
        if (x + 0.3 <= RightDownPoint.transform.position.x && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            x += moveSpeed;
        }

        shovel.transform.position = new Vector3(x, y, z);
    }

    private void RotationLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            joint.useMotor = true;
            rotation = true;
        }

        var moduleRotation = Mathf.Abs(shovel.transform.localRotation.z);

        if (moduleRotation >= 0.8)
            rotation = false;

        if (!rotation && moduleRotation <= 0.05 && moduleRotation >= 0)
        {
            joint.useMotor = false;
            rigidbody.angularVelocity = 0;
        }
    }
}
