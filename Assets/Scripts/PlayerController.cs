using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed = 100f;
	public Rigidbody rb;
	private int score;
	public int health;
    public Text scoreText;
    public Text healthText;

    // ***** Method 3  | Winner ****************************

    void Start()
	{
		score = 0;
		health = 5;
	}
	void FixedUpdate()
	{
		var xAxis = Input.GetAxis("Horizontal");
		var zAxis = Input.GetAxis("Vertical");

		var movementVector = new Vector3(xAxis, 0, zAxis);
		rb.AddForce(movementVector * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pickup"))
		{
			score++;
            SetScoreText();
			Destroy(other.gameObject);
		}

		if (other.gameObject.CompareTag("Trap"))
		{
			health--;
            SetHealthText();
		}

		if (other.gameObject.CompareTag("Goal"))
		{
			Debug.Log("You win");
		}
	}

    void Update()
    {
        // Check if health is zero or less
        if (health <= 0)
        {
            Debug.Log("Game Over!");

            // Call the ReloadScene method to handle scene reloading and resetting
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetScoreText()
    {
        scoreText.text = "Score: "+ score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

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


}
