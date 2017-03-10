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

using System.Diagnostics.CodeAnalysis;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.Engine.V001
{
    [BehaviourDefinitionFor(typeof(Product1Behaviour))]
    public class Product1BehaviourDefinition : BaseModel, Product1Behaviour
    {
        [SuppressMessage("ReSharper", "UnassignedReadonlyField")]
        public new class States : BaseModelStates
        {
            public static readonly ModelState Product1State1;
            public static readonly ModelState Product1State2;
        }

        public class Product1ActionA : BaseModelAction
        {
                
        }
                
        public class Product1ActionB : BaseModelAction
        {
                
        }
                
        public class Product1ActionC : BaseModelAction
        {
                
        }
                
        public override StateMachine GetStateMachine()
        {
            return StateMachineBuilder.For<Product1BehaviourDefinition>()
                .InsertAfter(typeof(Initialise), () => States.Product1State1, typeof(Product1ActionA))
                .InsertAfter(typeof(Product1ActionA), () => States.Product1State2, typeof(Product1ActionC))
                .InsertAction(() => States.Product1State2, typeof(Product1ActionB), () => States.Product1State1)
                .GetStateMachine();
        }
    }
}
