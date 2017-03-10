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

using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.Engine.V001
{
    public class Product3C : Product3BehaviourDefinition, Product3Behaviour, IDoNotImplementBaseBehaviour
    {
        public override StateMachine GetStateMachine()
        {
            return StateMachineBuilder.For<Product3C>()
                //.InsertAfter(typeof(Initialise), () => States.Product3State1, typeof(Product3ActionA))
                //.InsertAfter(typeof(Product3ActionA), () => States.Product3State2, typeof(Product3ActionC))
                //.InsertAction(() => States.Product3State2, typeof(Product3Action2), () => States.Product3State1)
                .GetStateMachine();
        }
    }
}
