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
    [BehaviourDefinitionFor(typeof(Product2Behaviour))]
    public class Product2BehaviourDefinition : BaseModel, Product2Behaviour
    {
        [SuppressMessage("ReSharper", "UnassignedReadonlyField")]
        public new class States : BaseModelStates
        {
            public static readonly ModelState Product2State1;
            public static readonly ModelState Product2State2;
        }

        public class Product2ActionA : BaseModelAction
        {
                
        }
                
        public class Product2ActionB : BaseModelAction
        {
                
        }
                
        public class Product2ActionC : BaseModelAction
        {
                
        }
                
        public override StateMachine GetStateMachine()
        {
            return StateMachineBuilder.For<Product2BehaviourDefinition>()
                .InsertAfter(typeof(Initialise), () => States.Product2State1, typeof(Product2ActionA))
                .InsertAfter(typeof(Product2ActionA), () => States.Product2State2, typeof(Product2ActionC))
                .InsertAction(() => States.Product2State2, typeof(Product2ActionB), () => States.Product2State2)
                .GetStateMachine();
        }
    }
}