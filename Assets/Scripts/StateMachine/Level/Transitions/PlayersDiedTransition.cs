using System.Collections.Generic;
using UnityEngine;
using Characters;

namespace StateMachine.Level.Transitions
{
    public class PlayersDiedTransition : Base.Transition<Context>
    {
        private List<GameObject> _players = new();

        public void OnCharacterCreated(CharacterConfigurator player)
        {
            _players.Add(player.gameObject);
        }

        public override bool NeedTransit 
        {
            get
            {
                foreach (var player in _players)
                {
                    if (player != null)
                        return false;
                }

                return true;
            }
        }
    }
}
