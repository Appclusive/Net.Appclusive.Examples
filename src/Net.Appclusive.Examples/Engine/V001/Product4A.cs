/**
 * Copyright 2017 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.Engine.V001
{
    // this product is intentionally defined in a sub-optimal way, but nevertheless correct
    // cause:
    // it inherits from Product4Behaviour (which in turn hast Product4BehaviourDefinition as the the BehaviourDefinition)
    // however, the merged state machines should really be defined in the underlying base model
    public class Product4A : Product4BehaviourDefinition, Product4Behaviour
    {
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() => 
            StateMachineBuilder
                .For<Product4A>()
                .MergeWithBehaviour<Product1Behaviour>(typeof(ActionMergingStateMachineWithIProduct1))
                .MergeWithBehaviour<Product2Behaviour>(typeof(ActionMergingStateMachineWithIProduct2))
                .GetStateMachine()
        );

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        public class ActionMergingStateMachineWithIProduct1 : BaseModelAction
        {
            
        }

        public class ActionMergingStateMachineWithIProduct2 : BaseModelAction
        {
            
        }
    }
}
