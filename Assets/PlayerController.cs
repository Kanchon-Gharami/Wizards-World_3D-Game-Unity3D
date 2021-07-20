using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {
    public Transform bullet_spawn_position;
    CharacterController cr;
    private float speed = 5f;
    private Vector3 prev_angles;
    public GameObject bullet;

    // Use this for initialization
    void Start () {
        cr = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float x_axis = CrossPlatformInputManager.GetAxis("Horizontal");
        float z_axis = CrossPlatformInputManager.GetAxis("Vertical");
        //Debug.Log(x_axis + "  " + z_axis);
        Vector3 move_details = new Vector3(x_axis * speed * Time.deltaTime, 0, z_axis * speed * Time.deltaTime);
        cr.Move(move_details);


        //angle of the player
        if (x_axis != 0 || z_axis != 0)
        {
            float inputAngle = 90 - (Mathf.Atan2(z_axis, x_axis)) * Mathf.Rad2Deg;

            transform.eulerAngles = Vector3.up * inputAngle;
            prev_angles = transform.eulerAngles;

        }
        else
        {
            transform.eulerAngles = prev_angles;
        }




    }
    public void instantiate_Bullet()
    {
        GameObject bl = Instantiate(bullet, bullet_spawn_position.position, transform.rotation) as GameObject;
        //shoot_sound.Play();
    }

}
