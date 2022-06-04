using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private GameObject space = null;
    private float _spaceCircleRadius = 0;
    private float _backgroundOriginalSizeX = 0f;
    private float _backgroundOriginalSizeY = 0f;
    private Vector3 _startMoveVector;

    void Start()
    {
        _startMoveVector = new Vector3(0, 0, 0);
        SpriteRenderer sr = space.GetComponent<SpriteRenderer>();
        var originalSize = sr.size;
        _backgroundOriginalSizeX = originalSize.x;
        _backgroundOriginalSizeY = originalSize.y - 0.5f;
        float orthographicSize = mainCamera.orthographicSize;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        _spaceCircleRadius = Mathf.Sqrt(orthographicSize * screenAspect * orthographicSize * screenAspect + orthographicSize * orthographicSize);
        sr.size = new Vector2(_spaceCircleRadius * 2 + _backgroundOriginalSizeX * 2, _spaceCircleRadius * 2 + _backgroundOriginalSizeY * 2);
    }
    public void MoveBackGround(Transform transform)
    {
        if (transform.position.x >= _backgroundOriginalSizeX + space.transform.position.x)
        {
            space.transform.position = space.transform.position.Change(x: space.transform.position.x + _backgroundOriginalSizeX);
            return;
        }
        if (transform.position.x <= -_backgroundOriginalSizeX + space.transform.position.x)
        {
            space.transform.position = space.transform.position.Change(x: space.transform.position.x - _backgroundOriginalSizeX);
            return;
        }
    }
    private void OnDrawGizmos()
    {
        // Окружность, описывающая камеру
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(Vector3.zero, Vector3.back, _spaceCircleRadius);

        // Направление движения
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawLine(Vector3.zero, _startMoveVector);
    }
}