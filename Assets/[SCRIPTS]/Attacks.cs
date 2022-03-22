using UnityEngine;

public class Attacks : MonoBehaviour
{
     [SerializeField] private GameObject _smallFist = default;
     [SerializeField] private GameObject _mediumFist = default;
     [SerializeField] private GameObject _bigFist = default;
     [SerializeField] private GameObject _blockFist = default;
     [SerializeField] private GameObject _Playercol = default;
     [SerializeField] private KeyCode _lightAttack = default;
     [SerializeField] private KeyCode _mediumAttack = default;
     [SerializeField] private KeyCode _hardAttack = default;
     [SerializeField] private KeyCode _blockMove = default;

     void Update()
    {
        if (Input.GetKeyDown(_lightAttack))
        {
            _smallFist.SetActive(true);
        }
        if (Input.GetKeyUp(_lightAttack))
        {
            _smallFist.SetActive(false);
        }
        if (Input.GetKeyDown(_mediumAttack))
        {
            _smallFist.SetActive(true);
            _smallFist.GetComponent<BoxCollider2D>().enabled = false;
            _mediumFist.SetActive(true);
        }
        if (Input.GetKeyUp(_mediumAttack))
        {
            _smallFist.SetActive(false);
            _smallFist.GetComponent<BoxCollider2D>().enabled = true;
            _mediumFist.SetActive(false);
        }
        if (Input.GetKeyDown(_hardAttack))
        {
            _smallFist.SetActive(true);
            _smallFist.GetComponent<BoxCollider2D>().enabled = false;
            _mediumFist.SetActive(true);
            _mediumFist.GetComponent<BoxCollider2D>().enabled = false;
            _bigFist.SetActive(true);
        }
        if (Input.GetKeyUp(_hardAttack))
        {
            _smallFist.SetActive(false);
            _smallFist.GetComponent<BoxCollider2D>().enabled = true;
            _mediumFist.SetActive(false);
            _mediumFist.GetComponent<BoxCollider2D>().enabled = true;
            _bigFist.SetActive(false);
        }
        if (Input.GetKeyDown(_blockMove))
        {
            _blockFist.SetActive(true);
            _Playercol.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (Input.GetKeyUp(_blockMove))
        {
            _blockFist.SetActive(false);
            _Playercol.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
