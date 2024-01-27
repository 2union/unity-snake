using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    private GameObject _tail;
    
    [SerializeField]
    private Transform _body;
    
    [SerializeField]
    private List<Transform> _segments = new List<Transform>();
    
    private Vector2 _direction = Vector2.right;
    
    public GameManager gm;
    
    void Start()
    {
        _segments.Add(_body.transform);
    }

    private void FixedUpdate()
    {
        _tail.transform.position = _segments[_segments.Count - 1].position;

        for (int i = _segments.Count - 1; i > 0; i--) {
            _segments[i].position = _segments[i - 1].position;
        }
        
        _segments[0].position = this.transform.position;

        this.transform.position = new Vector2(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y
         );
    }
    
    public void Grow()
    {
        Transform segment = Instantiate(_body);
        segment.position = _tail.transform.position;
        _segments.Add(segment.transform);
    }

    public void Reset()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(_body);
        
        //this.transform.parent.position = new Vector2(-6, 0);
        this.transform.position = new Vector2(-6, 0);
        this._body.position = new Vector2(-7, 0);
        this._tail.transform.position = new Vector2(-8, 0);
        _direction = Vector2.right;
    }

    public void MoveLeft()
    {
        _direction = Vector2.left;
    }
    
    public void MoveRight()
    {
        _direction = Vector2.right;
    }
    
    public void MoveUp()
    {
        _direction = Vector2.up;
    }
    
    public void MoveDown()
    {
        _direction = Vector2.down;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            gm.ResetGame();
        }
    }
}
