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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Net.Appclusive.Examples.Geometry.V001;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.Engine.V001
{
    [BehaviourDefinitionFor(typeof(CalculationBehaviour))]
    public class CalculationBehaviourDefinition : BaseModel, CalculationBehaviour
    {
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() =>
            StateMachineBuilder
                .For<ShapeBehaviourDefinition>()
                .InsertAction(() => BaseModelStates.InitialState, typeof(SetBaseValue), () => BaseModelStates.DecommissionedState)
                .GetStateMachine()
        );

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        [AttributeName(Constants.Engine.CalculateValue.BASEVALUE_NAME)]
        [Range(0, int.MaxValue)]
        [DefaultValue(5)]
        public virtual int BaseValue { get; set; }

        public class SetBaseValue : BaseModelAction
        {
            [AttributeName(Constants.Engine.CalculateValue.BASEVALUE_NAME)]
            [UseValidationFromModel(typeof(CalculationBehaviourDefinition))]
            public virtual int BaseValue { get; set; }
        }
    }
}
