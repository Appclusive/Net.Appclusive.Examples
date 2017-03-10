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
    [BehaviourDefinitionFor(typeof(Product3EHaveAdditionalPropertiesDefinedBehaviour))]
    public class Product3EHaveAdditionalPropertiesDefinedBehaviourDefinition : BaseModel, Product3EHaveAdditionalPropertiesDefinedBehaviour
    {
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() => 
            StateMachineBuilder
                .For<Product3EHaveAdditionalPropertiesDefinedBehaviourDefinition>()
                .InsertAfter(typeof(Initialise), () => States.Product3EState1, typeof(Product3EAction1))
                .InsertAfter(typeof(Product3EAction1), () => States.Product3EState2, typeof(Product3EAction3))
                .GetStateMachine());

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        [SuppressMessage("ReSharper", "UnassignedReadonlyField")]
        public new class States : Product3BehaviourDefinition.States
        {
            public static readonly ModelState Product3EState1;
            public static readonly ModelState Product3EState2;
        }

        public class Product3EAction1 : BaseModelAction
        {
            // intentionally left blank
        }

        public class Product3EAction2 : BaseModelAction
        {
            // intentionally left blank
        }

        public class Product3EAction3 : BaseModelAction
        {
            // intentionally left blank
        }
    }
}
