using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Game.Ability
{
    public class Dash : BaseAbility
    {
        [Header("Dash Attributes")]
        [SerializeField, Range(0, 2500)] float _force;
        [SerializeField, Tooltip("Shadows that will appear when dashing")] Sprite[] _shadow;
        [SerializeField] float _shadowTransparency = .5f;
        [SerializeField] private GameObject _abilityOwner;
        [SerializeField] private RippleEffect _rippleEffect;

        private Rigidbody2D _rgb;
        private CharacterController2D _characterController;

        private Player _player;

        private CinemachineImpulseSource _impulseSource;

        private void Awake()
        {
            _rgb = _abilityOwner.GetComponent<Rigidbody2D>();
            _characterController = _abilityOwner.GetComponent<CharacterController2D>();
            _player = _abilityOwner.GetComponent<Player>();
            _impulseSource = GetComponent<CinemachineImpulseSource>();
        }

        public override void Ability()
        {
            //Generates Cinemachine Impulse
            _impulseSource.GenerateImpulse();

            //Stops the player, to avoid large pushes
            _rgb.velocity = Vector2.zero;

            _rgb.AddForce(new Vector2(CalculateCharacterDirection().x * _force,
                                      CalculateCharacterDirection().y * _force
                            ) / 100, ForceMode2D.Impulse);

            StartCoroutine(HandleCharacterController());

            #region Effects
            //Do Fade Effect
            StartCoroutine(FadeEffect());

            //Starts Ripple Effect
            _rippleEffect.Emit();
            #endregion
        }

        private Vector2 CalculateCharacterDirection()
        {
            Vector2 direction = new Vector2(_player.InputHandler.InputActions.Player.Move.ReadValue<Vector2>().x,
                                            _player.InputHandler.InputActions.Player.Move.ReadValue<Vector2>().y);

            if(direction.x == 0f && direction.y == 0f)
                direction = new Vector2(_abilityOwner.transform.localScale.x, 0f);

            return direction;
        }

        public IEnumerator HandleCharacterController()
        {
            //float gravityBeforeDash = _rgb.gravityScale;
            
            _characterController.CanMove = false;
            _rgb.gravityScale = 0f;

            yield return new WaitForSeconds(.25f);

            _rgb.gravityScale = 3f;
            _characterController.CanMove = true;
        }

        /// <summary>
        /// instantiate X amount of shadows in the position of the character to produce a shadow effect
        /// while doing the dash.
        /// </summary>
        /// <returns></returns>
        IEnumerator FadeEffect()
        {
            int i = 0;

            while(i < _shadow.Length)
            {
                GameObject fadeObj = new GameObject("Fade");

                fadeObj.transform.position = _abilityOwner.transform.position;
                fadeObj.transform.localScale = _abilityOwner.transform.localScale;

                SpriteRenderer fadeSprite = fadeObj.AddComponent<SpriteRenderer>();

                fadeSprite.sprite = _shadow[i];
                fadeSprite.color = Color.white * _shadowTransparency;
                fadeSprite.sortingLayerName = "Characters";

                i++;

                Destroy(fadeObj, .5f);
                yield return new WaitForSeconds(.05f);
            }
        }
    }
}