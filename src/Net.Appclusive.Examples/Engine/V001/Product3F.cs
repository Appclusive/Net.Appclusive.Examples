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
using System.Diagnostics.CodeAnalysis;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.Engine.V001
{
    public class Product3F : Product3BehaviourDefinition, Product3Behaviour, Product3EHaveAdditionalPropertiesDefinedBehaviour
    {
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() => 
            StateMachineBuilder
                .For<Product3F>()
                .InsertAfter(typeof(Initialise), () => States.Product3FState1, typeof(Product1Action1))
                .MergeWithBehaviour<Product3EHaveAdditionalPropertiesDefinedBehaviour>(typeof(Product1Action2))
                .ChangeSourceState(() => BaseModelStates.InitialState, typeof(Product1Action2), () => States.Product3FState1)
                .GetStateMachine()
        );

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        [SuppressMessage("ReSharper", "UnassignedReadonlyField")]
        public new class States : BaseModelStates
        {
            public static readonly ModelState Product3FState1;
        }

        public class Product1Action1 : BaseModelAction
        {
            // intentionally left blank
        }

        public class Product1Action2 : BaseModelAction
        {
            // intentionally left blank
        }
    }
}
