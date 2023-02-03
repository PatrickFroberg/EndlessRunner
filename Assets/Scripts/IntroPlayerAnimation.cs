using UnityEngine;

public class IntroPlayerAnimation : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _endPos;
    private Animator _animator;
    private float introductionSecs = 2.0f;
    private float elapsedSecs;
    private bool _isGameStart;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find(nameof(GameManager)).GetComponent<GameManager>();

        _startPos = new Vector3(-7f, 0f, 0f);
        _endPos = new Vector3(0f, 0f, 0f);
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed_f", 0.4f);
    }

    private void Update()
    {
        elapsedSecs += Time.deltaTime;

        if (!_isGameStart)
        {
            transform.position = Vector3.Lerp(_startPos, _endPos, elapsedSecs / introductionSecs);

            if (elapsedSecs > introductionSecs)
            {
                _isGameStart = true;
                _animator.SetFloat("Speed_f", 1f);
                _gameManager.StartGame();

                this.enabled= false;
            }
        }
    }
}