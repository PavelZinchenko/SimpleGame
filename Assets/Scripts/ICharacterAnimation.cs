using UnityEngine;

public interface ICharacterAnimation
{
    void Walk(Vector2 velocityNormalized);
    void Jump(float speed, bool grounded);
}
