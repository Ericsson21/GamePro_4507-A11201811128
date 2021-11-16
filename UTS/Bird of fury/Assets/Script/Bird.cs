using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bird : MonoBehaviour
{
        Vector3 _initialPosition;
        private bool _birdIsLaunch;
        private float _timeSittingAround;
        [SerializeField]
        private float _launchPower = 500;
        

        
    private void Awake()
    {
        _initialPosition= transform.position;
    }
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
       
        if(_birdIsLaunch && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }
        
        if(transform.position.y > 130 || transform.position.y < -130 || transform.position.x > 400 || transform.position.x < -100 || _timeSittingAround > 6) 
        {
           string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        
        
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }
    private void OnMouseUp()
    {
        
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 10;
        _birdIsLaunch = true;
        GetComponent<LineRenderer>().enabled = false;
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y); 
    }


}
