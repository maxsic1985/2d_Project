using UnityEngine;

public static class Extenshion
{
    public static Vector3 Change(this Vector3 org, object x = null, object y = null, object z = null)
    {
        return new Vector3((float?)x ?? org.x, (float?)y ?? org.y, (float?)z ?? org.z);
    }
    public static Vector2 Change(this Vector2 org, object x = null, object y = null)
    {
        return new Vector2((float?)x ?? org.x, (float?)y ?? org.y);
    }
    public static (float weight, float height) GetCameraWeight(this Camera camera)
    {
        var weight = ((camera.orthographicSize * 2) * camera.aspect) / 2;
        var height = camera.orthographicSize;
        var result = (weight: weight, height: height);
        return result;
    }
    public static Vector3 GetRandomVectorAccordingCamera(this Camera camera, float offsetX, float offsetY)
    {
        var weight = ((camera.orthographicSize * 2) * camera.aspect) / 2;
        var height = camera.orthographicSize;
        var randomX = Random.Range(-1 * weight + offsetX, weight - offsetX);
        var vector = new Vector2(randomX, Mathf.Abs(height) - offsetY);
        return vector;
    }
}
