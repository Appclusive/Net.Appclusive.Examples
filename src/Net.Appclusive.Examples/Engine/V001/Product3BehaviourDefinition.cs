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
    [BehaviourDefinitionFor(typeof(Product3Behaviour))]
    public class Product3BehaviourDefinition : BaseModel, Product3Behaviour
    {
        [SuppressMessage("ReSharper", "UnassignedReadonlyField")]
        public new class States : BaseModelStates
        {
            public static readonly ModelState Product1State1;
            public static readonly ModelState Product1State2;

            public static readonly ModelState Product2State1;
            public static readonly ModelState Product2State2;

            public static readonly ModelState Product3State1;
            public static readonly ModelState Product3State2;
        }

        public class Product1ActionA : Product1BehaviourDefinition.Product1ActionA
        {
                
        }
                
        public class Product1ActionB : Product1BehaviourDefinition.Product1ActionB
        {
                
        }
                
        public class Product1ActionC : Product1BehaviourDefinition.Product1ActionC
        {
                
        }
                
        public class Product2ActionA : Product2BehaviourDefinition.Product2ActionA
        {
                
        }
                
        public class Product2ActionB : Product2BehaviourDefinition.Product2ActionB
        {
                
        }
                
        public class Product2ActionC : Product2BehaviourDefinition.Product2ActionC
        {
                
        }
                
        public class Product3ActionA : BaseModelAction
        {
                
        }
                
        public class Product3ActionB : BaseModelAction
        {
                
        }
                
        public class Product3ActionC : BaseModelAction
        {
                
        }
                
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() =>
        {
            return StateMachineBuilder.For<Product3BehaviourDefinition>()
                .InsertAfter(typeof(Initialise), () => States.Product3State1, typeof(Product3ActionA))
                .InsertAfter(typeof(Product3ActionA), () => States.Product3State2, typeof(Product3ActionC))
                .InsertAction(() => States.Product3State2, typeof(Product3ActionB), () => States.Product3State1)
                
                .InsertAfter(typeof(Product3ActionC), () => States.Product1State1, typeof(Product1ActionA))
                .InsertAfter(typeof(Product1ActionA), () => States.Product1State2, typeof(Product1ActionB))
                .InsertAction(() => States.Product1State2, typeof(Product1ActionC), () => States.Product1State1)
                
                .InsertAfter(typeof(Product1ActionB), () => States.Product2State1, typeof(Product2ActionA))
                .InsertAfter(typeof(Product1ActionA), () => States.Product2State2, typeof(Product2ActionB))
                .InsertAction(() => States.Product2State2, typeof(Product2ActionC), () => States.Product2State1)
                .GetStateMachine();
        });

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }
    }
}