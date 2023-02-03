using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public Text ScoreText;

    private int _score = 0;
    private float _elapsedTime = 0f;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!_playerController.GameOver)
        {
            CalculateScore();
        }
    }

    private void CalculateScore()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= 1f)
        {
            if (_playerController.IsSprinting == true)
                _score += 2;
            else
                _score += 1;

            _elapsedTime = 0f;

            ScoreText.text = $"SCORE: {_score}";
        }

    }
}