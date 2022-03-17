using UnityEngine;

public class BackGroundController : MonoBehaviour
{

    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private GameObject space = null;

    // Радиус возможного обзора камеры
    private float _spaceCircleRadius = 0;

    // Исходные размеры объекта фона
    private float _backgroundOriginalSizeX = 0f;
    private float _backgroundOriginalSizeY = 0f;

    // Направление движения
    private Vector3 _moveVector;

    void Start()
    {
        // Стартовое направление движения
        _moveVector = new Vector3(0, 0, 0);
        // Исходные размеры фона
        SpriteRenderer sr = space.GetComponent<SpriteRenderer>();
        var originalSize = sr.size;
        _backgroundOriginalSizeX = originalSize.x;
        _backgroundOriginalSizeY = originalSize.y-0.5f;

        // Высота камеры равна ортографическому размеру
        float orthographicSize = mainCamera.orthographicSize;
        // Ширина камеры равна ортографическому размеру, помноженному на соотношение сторон
        float screenAspect = (float)Screen.width / (float)Screen.height;
        // Радиус окружности, описывающей камеру
        _spaceCircleRadius = Mathf.Sqrt(orthographicSize * screenAspect * orthographicSize * screenAspect + orthographicSize * orthographicSize);

        // Конечный размер фона должен позволять сдвинуться на один базовый размер фона в любом направлении + перекрыть радиус камеры также во всех направлениях
        sr.size = new Vector2(_spaceCircleRadius * 2 + _backgroundOriginalSizeX * 2, _spaceCircleRadius * 2 + _backgroundOriginalSizeY * 2);
    }


    public void MoveBackGround(Transform transform)
    {

        if (transform.position.x >= _backgroundOriginalSizeX+space.transform.position.x)
        {
            space.transform.position= space.transform.position.Change(x: space.transform.position.x+_backgroundOriginalSizeX);
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
        UnityEditor.Handles.DrawLine(Vector3.zero, _moveVector);
    }
}