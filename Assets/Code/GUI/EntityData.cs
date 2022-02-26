using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "EntityGame")]
public class EntityData : ScriptableObject
{
    [SerializeField]
    public static Entity GameSetting = new Entity
    (GameConstants.ANIMATION_SPEED, GameConstants.PARALAX_COEF, GameConstants.ANIMATION_SPEED_MAX, GameConstants.PARALAX_COEF_MAX);

}

