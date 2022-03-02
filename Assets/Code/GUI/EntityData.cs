using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "EntityGame")]
public class EntityData : ScriptableObject
{
    [SerializeField]
    public static Entity GameSetting = new Entity
    (GameConstants.PLAYER_ANIMATION_SPEED, GameConstants.PARALAX_COEF, GameConstants.PLAYER_ANIMATION_SPEED_MAX, GameConstants.PARALAX_COEF_MAX,GameConstants.PLAYER_MOVETRESH,
        GameConstants.PLAYER_WALK_SPEED,GameConstants.PLAYER_JUMPSTART_SPEED,GameConstants.PLAYER_FLYTRESH,GameConstants.GROUND_LEVEL,GameConstants.PLAYER_ACCELERATION,GameConstants.BULLET_RADIUS,
        GameConstants.BULLET_ACCELERATION,GameConstants.BULLET_GROUND_LEVEL);


  
}

