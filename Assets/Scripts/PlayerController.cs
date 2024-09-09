using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Rigidbody rb;

	// ***** Method 1 ****************************
	// void FixedUpdate()
	// {
	// 	var pos = transform.position;
	// 	if (Input.GetKey(KeyCode.LeftArrow))
	// 	{
	// 		pos.x = pos.x - speed * Time.deltaTime;
	// 	}
	// 	if (Input.GetKey(KeyCode.RightArrow))
	// 	{
	// 		pos.x = pos.x + speed * Time.deltaTime;
	// 	}
	// 	if (Input.GetKey(KeyCode.UpArrow))
	// 	{
	// 		pos.z = pos.z + speed * Time.deltaTime;
	// 	}
	// 	if (Input.GetKey(KeyCode.DownArrow))
	// 	{
	// 		pos.z = pos.z - speed * Time.deltaTime;
	// 	}
	// 	transform.position = pos;

	// }

	// ***** Method 2 ****************************
	// void FixedUpdate()
	// {
	// 	if (Input.GetKey(KeyCode.UpArrow))
	// 	{
	// 		rb.AddForce(0, 0, speed * Time.deltaTime);
	// 	}
	// 	if (Input.GetKey(KeyCode.DownArrow))
	// 	{
	// 		rb.AddForce(0, 0, -speed * Time.deltaTime);
	// 	}
	// 	if (Input.GetKey(KeyCode.LeftArrow))
	// 	{
	// 		rb.AddForce(-speed * Time.deltaTime, 0, 0);
	// 	}
	// 	if (Input.GetKey(KeyCode.RightArrow))
	// 	{
	// 		rb.AddForce(speed * Time.deltaTime, 0, 0);
	// 	}
	// }


	// ***** Method 3  | Winner ****************************
	void FixedUpdate()
	{
		var xAxis = Input.GetAxis("Horizontal");
		var zAxis = Input.GetAxis("Vertical");

		var movementVector = new Vector3(xAxis, 0, zAxis);
		rb.AddForce(movementVector * speed);
	}
}
