using System;
using UnityEngine;

public class QuestObjectView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Color _completedColor;

    [SerializeField]
    private int _id;

    private Color _defaultColor;

    public int Id => _id;

    public Action<PlayerProvider> OnLevelObjectContact;

    private void Awake()
    {
        _defaultColor = _spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerProvider player))
            OnLevelObjectContact?.Invoke(player);
    }

    public void ProcessComplete()
    {
        _spriteRenderer.color = _completedColor;
    }

    public void ProcessActivate()
    {
        _spriteRenderer.color = _defaultColor;
    }
}
