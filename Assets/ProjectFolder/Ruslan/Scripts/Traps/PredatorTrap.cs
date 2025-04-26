using UnityEngine;

public class PredatorTrap : TrapBase
{
    [SerializeField] private Sprite _moveSprite;
    [SerializeField] private Sprite _attackSprite;
    [SerializeField] private GameObject _claws;
    private bool _isActivated;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = _trapObject.GetComponentInChildren<SpriteRenderer>();
        _trapObject.gameObject.SetActive(false);
        _isActivated = false;
        _claws.SetActive(false);
        _spriteRenderer.sprite = _moveSprite;
    }

    protected override void ActivateTrap(CharacterFire characterFire)
    {
        if (!characterFire.IsBurning)
        {
            _trapObject.gameObject.SetActive(true);
            _isActivated = true;
            CheckFlip();
        }
        else
        {
            _animator.SetBool("isActive",  false);
        }
    }

    protected override void DiactivateTrap()
    {
        _isActivated = false;
        FlipSprite();
    }

    void Update()
    {
        Attack();
        GoBack();
    }

    private void Attack()
    {
        if (_isActivated)
        {
            _trapObject.position = Vector2.MoveTowards(_trapObject.position, _characterTransform.position, _speed * Time.deltaTime);
            SetSprite();
        }
    }

    private void GoBack()
    {
        if (!_isActivated)
        {
            _trapObject.position = Vector2.MoveTowards(_trapObject.position, transform.position, _speed * Time.deltaTime);
            if (Vector2.Distance(_trapObject.position, transform.position) < 0.1)
            {
                _trapObject.position = transform.position;
                _trapObject.gameObject.SetActive(false);
                _animator.SetBool("isActive", true);
            }
        }
    }

    private void SetSprite()
    {
        float distance = Vector2.Distance(_trapObject.position, _characterTransform.position);
        if (distance < 2)
        {
            _claws.SetActive(true);
            _claws.transform.position = _characterTransform.position;
        }
        else if (distance < 3)
        {
            _spriteRenderer.sprite = _attackSprite;
        }
        else
        {
            _claws.SetActive(false);
            _spriteRenderer.sprite = _moveSprite;
        }
    }

    private void CheckFlip()
    {
        if (_characterTransform.position.x < _trapObject.position.x) 
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void FlipSprite()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        Debug.Log("FlipRaptor");
    }
}
