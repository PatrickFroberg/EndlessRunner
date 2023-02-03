using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] SpawnPrefab;

        private Vector3 _spawnPos = new Vector3(25f, 1f, 0f);
        private float _startDelay = 2f;
        private float _spawnRate = 2f;
        private PlayerController _playerController;

        private void Start()
        {
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            InvokeRepeating(nameof(Spawn), _startDelay, _spawnRate);
        }

        private void Spawn()
        {
            if (_playerController.GameOver != true)
            {
                int rIndex = Random.Range(0, SpawnPrefab.Length);
                Instantiate(SpawnPrefab[rIndex], _spawnPos, SpawnPrefab[rIndex].transform.rotation);
            }
        }
    }
}