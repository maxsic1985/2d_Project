using UnityEngine;

public class EntityData
{

    [SerializeField]
    public static Entity GameSetting = new Entity(GameConstants.PLAYER_ANIMATION_SPEED, GameConstants.PARALAX_COEF,
        GameConstants.PLAYER_ANIMATION_SPEED_MAX, GameConstants.PARALAX_COEF_MAX);

}

