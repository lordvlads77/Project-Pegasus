using UnityEngine;

public class Attacks : MonoBehaviour
{
     [SerializeField] private GameObject _smallFist = default;
     [SerializeField] private GameObject _mediumFist = default;
     [SerializeField] private GameObject _bigFist = default;
     [SerializeField] private KeyCode _lightAttack = default;
     [SerializeField] private KeyCode _mediumAttack = default;
     [SerializeField] private KeyCode _hardAttack = default;
     [SerializeField] private GameObject _ComboFist = default;
     [SerializeField] private KeyCode _ComboAttack = default;
     [SerializeField] private KeyCode _CombondKey = default;
     [SerializeField] private GameObject _blockFist = default;
     [SerializeField] private GameObject _Playercol = default;
     [SerializeField] private KeyCode _blockMove = default;
     [Header("Idle Managament")]
     [SerializeField] private SpriteRenderer _idleMove = default;
     [SerializeField] private BoxCollider2D _idlecollider = default;

     void Update()
    {
        if (Input.GetKeyDown(_lightAttack))
        {
            _smallFist.SetActive(true);
            _idleMove.enabled = false;
        }
        if (Input.GetKeyUp(_lightAttack))
        {
            _smallFist.SetActive(false);
            _idleMove.enabled = true;
            _idlecollider.enabled = true;
        }
        if (Input.GetKeyDown(_ComboAttack) && (Input.GetKeyDown(_CombondKey)))
        {
            _ComboFist.SetActive(true);
            _idleMove.enabled = false;
            _idlecollider.enabled = false;
        }
        if (Input.GetKeyUp(_ComboAttack))
        {
            _ComboFist.SetActive(false);
            _idleMove.enabled = true;
            _idlecollider.enabled = true;
        }
        if (Input.GetKeyDown(_mediumAttack))
        {
            _mediumFist.SetActive(true);
            _idleMove.enabled = false;
            _idlecollider.enabled = false;
        }
        if (Input.GetKeyUp(_mediumAttack))
        {
            _mediumFist.SetActive(false);
            _idleMove.enabled = true;
            _idlecollider.enabled = true;
        }
        if (Input.GetKeyDown(_hardAttack))
        {
            _bigFist.SetActive(true);
            _idleMove.enabled = false;
            _idlecollider.enabled = false;
        }
        if (Input.GetKeyUp(_hardAttack))
        {
            _bigFist.SetActive(false);
            _idleMove.enabled = true;
            _idlecollider.enabled = true;
        }
        if (Input.GetKeyDown(_blockMove))
        {
            _blockFist.SetActive(true);
            _Playercol.GetComponent<BoxCollider2D>().enabled = false;
            _idleMove.enabled = false;
        }
        if (Input.GetKeyUp(_blockMove))
        {
            _blockFist.SetActive(false);
            _Playercol.GetComponent<BoxCollider2D>().enabled = true;
            _idleMove.enabled = true;
        }
    }
}
