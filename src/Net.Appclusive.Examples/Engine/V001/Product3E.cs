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
    public class Product3E : Product3BehaviourDefinition, Product3Behaviour, Product3EHaveAdditionalPropertiesDefinedBehaviour
    {
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() => 
            StateMachineBuilder
                .For<Product3E>()
                .MergeWithBehaviour<Product3EHaveAdditionalPropertiesDefinedBehaviour>(typeof(Product3EActionMerge))
                .ChangeSourceState(() => BaseModelStates.InitialState, typeof(Product3EActionMerge), () => States.Product3State1)
                .GetStateMachine()
        );

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        public class Product3EActionMerge : BaseModelAction
        {
            // intentionally left blank
        }
    }
}
