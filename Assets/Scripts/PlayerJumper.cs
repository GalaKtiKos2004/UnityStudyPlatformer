using System.Collections;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private float _height;
    [SerializeField] private float _duration;

    private bool _isJumping = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_isJumping == false)
            {
                StartCoroutine(JumpByTime(_duration, _height));
                _isJumping = true;
            }
        }

    }

    private IEnumerator JumpByTime(float duration, float height)
    {
        float expiredSeconds = 0f;
        float progress = 0f;
        float maxProgress = 1f;

        Vector3 previousPosition = new Vector3(0f, transform.position.y, 0f);

        while (progress < maxProgress)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            transform.Translate(new Vector3(0f, _yAnimation.Evaluate(progress) * height, 0f) - previousPosition);
            previousPosition = new Vector3(0f, _yAnimation.Evaluate(progress) * height, 0f);

            yield return null;
        }

        _isJumping = false;
    }
}