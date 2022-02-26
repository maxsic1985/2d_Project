using System;
using UnityEngine;

//TO DO for background
public class UnevirseHandler : MonoBehaviour
{
    // ������ �� ������� �����
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private GameObject space = null;

    // ������ ���������� ������ ������
    private float _spaceCircleRadius = 0;

    // �������� ������� ������� ����
    private float _backgroundOriginalSizeX = 0;
    private float _backgroundOriginalSizeY = 0;

    // ����������� ��������
    private Vector3 _moveVector;

    // ��������������� ����������
    private bool _mousePressed = false;
    private float _halfScreenWidth = 0;

    void Start()
    {
        // ��������� ����������� ��������
        _moveVector = new Vector3(0, 0, 0);
        // ������������ ��� ����������� ����������� ��������
        _halfScreenWidth = Screen.width / 2f;

        // �������� ������� ����
        SpriteRenderer sr = space.GetComponent<SpriteRenderer>();
        var originalSize = sr.size;
        _backgroundOriginalSizeX = originalSize.x;
        _backgroundOriginalSizeY = originalSize.y;

        // ������ ������ ����� ���������������� �������
        float orthographicSize = mainCamera.orthographicSize;
        // ������ ������ ����� ���������������� �������, ������������ �� ����������� ������
        float screenAspect = (float)Screen.width / (float)Screen.height;
        // ������ ����������, ����������� ������
        _spaceCircleRadius = Mathf.Sqrt(orthographicSize * screenAspect * orthographicSize * screenAspect + orthographicSize * orthographicSize);

        // �������� ������ ���� ������ ��������� ���������� �� ���� ������� ������ ���� � ����� ����������� + ��������� ������ ������ ����� �� ���� ������������
        sr.size = new Vector2(_spaceCircleRadius * 2 + _backgroundOriginalSizeX * 2, _spaceCircleRadius * 2 + _backgroundOriginalSizeY * 2);
    }

    void Update()
    {
        if (!Mathf.Approximately(Input.GetAxis("Horizontal"),0))
        {
            _mousePressed = true;
        }

       else
        {
            _mousePressed = false;
        }

        if (_mousePressed)
        {
            var rotation = Input.GetAxis("Horizontal");
            float xComp = (rotation * Time.deltaTime);
            _moveVector = new Vector3(xComp, 0, 0);
        }

        space.transform.Translate(-_moveVector.x * Time.deltaTime*100, 0, 0);

        if (space.transform.position.x >= _backgroundOriginalSizeX)
        {
            space.transform.Translate(-_backgroundOriginalSizeX, 0, 0);
        }
        if (space.transform.position.x <= -_backgroundOriginalSizeX)
        {
            space.transform.Translate(_backgroundOriginalSizeX, 0, 0);
        }
    }

    private void OnDrawGizmos()
    {
        // ����������, ����������� ������
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(Vector3.zero, Vector3.back, _spaceCircleRadius);

        // ����������� ��������
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawLine(Vector3.zero, _moveVector);
    }
}