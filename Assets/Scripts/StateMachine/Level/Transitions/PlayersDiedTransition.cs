using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Level.Transitions
{
    public class PlayersDiedTransition : Base.Transition<Context>
    {
        private List<GameObject> _players = new();

        public void OnPlayerCreated(GameObject player)
        {
            _players.Add(player);
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
