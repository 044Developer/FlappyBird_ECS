using FlappyBird.Core.Components;
using FlappyBird.Core.Components.Common.Input;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Core.Systems
{
    public class KeyboardInputSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        
        public void Run()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
                _world.NewEntity().Get<SpaceKeyDownTag>();
        }
    }
}