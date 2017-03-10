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
    [BehaviourDefinitionFor(typeof(Product4Behaviour))]
    public class Product4BehaviourDefinition : BaseModel, Product4Behaviour
    {
        [SuppressMessage("ReSharper", "UnassignedReadonlyField")]
        public new class States : BaseModelStates
        {
            public static readonly ModelState Product3State1;
            public static readonly ModelState Product3State2;
        }

        public class Product4ActionA : BaseModelAction
        {
                
        }
                
        public class Product4ActionB : BaseModelAction
        {
                
        }
                
        public class Product4ActionC : BaseModelAction
        {
                
        }
                
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() =>
        {
            return StateMachineBuilder.For<Product4BehaviourDefinition>()
                .InsertAfter(typeof(Initialise), () => States.Product3State1, typeof(Product4ActionA))
                .InsertAfter(typeof(Product4ActionA), () => States.Product3State2, typeof(Product4ActionC))
                .InsertAction(() => States.Product3State2, typeof(Product4ActionB), () => States.Product3State1)
                .GetStateMachine();
        });

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }
    }
}
