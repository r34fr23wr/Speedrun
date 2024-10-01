using UnityEngine;
using Source.Gameplay.Character;

namespace Source.Gameplay.Platform
{
    public class PlatformCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.GetComponent<Character.Character>()) collision.transform.SetParent(transform);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if(collision.gameObject.GetComponent<Character.Character>()) collision.transform.SetParent(null);
        }
    }
}