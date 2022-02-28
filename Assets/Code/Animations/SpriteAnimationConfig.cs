using System.Collections.Generic;

using UnityEngine;
[CreateAssetMenu(fileName = "SpriteAnimationConfig", menuName = "Config/SpriteAnimationConfig", order = 1)]
public class SpriteAnimationConfig : ScriptableObject,ICongig<SpriteSequence>
{
    [SerializeField]
    private List<SpriteSequence> _sequences;
    public List<SpriteSequence> Sequences => _sequences;

}
