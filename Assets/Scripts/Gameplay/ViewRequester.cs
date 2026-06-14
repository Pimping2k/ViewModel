using Additions;
using UnityEngine;
using Views;

namespace Gameplay
{
    public class ViewRequester : MonoBehaviour
    {
        [SerializeField] private ViewManager _viewManager;
        [SerializeField] private Player _player;
        
        private void Start()
        {
            var health = _player.HealthComponent.HealthModel;
            var mana = _player.ManaComponent.ManaModel;
            var stamina = _player.StaminaComponent.StaminaModel;
            var score = _player.ScoreComponent.ScoreModel;

            var hudModel = new HudModel(health, mana, stamina, score);

            _viewManager.ShowView<HudView, HudModel>(hudModel);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _player.HealthComponent.ChangeHealth(Random.Range(-5,5));
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                _player.ManaComponent.ChangeMana(Random.Range(-5,5));
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                _player.StaminaComponent.ChangeStamina(Random.Range(-5,5));
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                _player.ScoreComponent.ChangeScore(Random.Range(-5,5));
            }
            
            if (Input.GetKeyDown(KeyCode.P))
            {
                _player.HealthComponent.ChangeHealth(5);
            }
        }
    }
}