using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    
    [SerializeField]
    private GameObject _spawner;
    
    [SerializeField]
    private GameObject _applePrefab;
    
    [SerializeField]
    private List<GameObject> _walls;
    
    [SerializeField]
    private TextMeshProUGUI _score;

    private int _points = 0;

    private void Start()
    {
        _player.GetComponent<Snake>().gm = this;
    }
    
    private void Update()
    {
        _score.text = _points.ToString();
        PlayerMovement();
    }

    private void FixedUpdate()
    {
        SpawnApple();
    }

    private void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _player.GetComponent<Snake>().MoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _player.GetComponent<Snake>().MoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _player.GetComponent<Snake>().MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _player.GetComponent<Snake>().MoveLeft();
        }
    }

    private void SpawnApple()
    {
        var apples = FindObjectsOfType<Apple>();
        if (apples.Length < 1)
        {
            _spawner.GetComponent<Spawner>().Spawn(_applePrefab);
            var apple = FindObjectsOfType<Apple>()[0];
            apple.gm = this;
        }
        
    }

    public void AddPoint()
    {
        _points++;
        _player.GetComponent<Snake>().Grow();
    }

    public void ResetGame()
    {
        _points = 0;
        _player.GetComponent<Snake>().Reset();
    }
}
