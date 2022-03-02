using UnityEngine;
public static class GameConstants 
{
    public  const float PLAYER_ANIMATION_SPEED = 5;
    public const float PLAYER_ANIMATION_SPEED_MAX = 25;
    public  const float PARALAX_COEF = 1;
    public const float PARALAX_COEF_MAX = 5;
    public const float PLAYER_WALK_SPEED = 1;
    public const float PLAYER_JUMPSTART_SPEED = 2;
    public const float PLAYER_MOVETRESH = 0.1f;
    public const float PLAYER_FLYTRESH = 0.1f;
    public const float GROUND_LEVEL = -0.2f;
    public const float PLAYER_ACCELERATION = -10f;

    public const float BULLET_RADIUS = 0.03f;
    public const float BULLET_ACCELERATION = -5;
    public const float BULLET_GROUND_LEVEL = -0.14f;

    public const string Horizontal = nameof(Horizontal);
    public const string Vertical = nameof(Vertical);
}
