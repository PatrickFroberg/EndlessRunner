using UnityEngine;

namespace Assets.Scripts
{
    public  class MoveLeft : MonoBehaviour
    {
        private float _stdSpeed = 15f;
        private float _sprintSpeed;
        private float _speed;
        private float _leftBound = -15f;
        private PlayerController _playerController;

        private void Start()
        {
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();

            _speed = _stdSpeed;
            _sprintSpeed = _speed * _playerController.SprintModifier;
        }

        private void Update()
        {
            SetSpeed();

            if (_playerController.GameOver != true)
                transform.Translate(Vector3.left * Time.deltaTime * _speed);

            if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
                Destroy(gameObject);
        }

        private void SetSpeed()
        {
            if (_playerController.IsSprinting)
                _speed = _sprintSpeed;
            else
                _speed = _stdSpeed;
        }
    }
}
