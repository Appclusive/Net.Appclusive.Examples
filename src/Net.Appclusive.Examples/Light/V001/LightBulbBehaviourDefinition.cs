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
using System.Diagnostics.CodeAnalysis;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.Light.V001
{
    [BehaviourDefinitionFor(typeof(LightBulbBehaviour))]
    public class LightBulbBehaviourDefinition : BaseModel, LightBulbBehaviour
    {
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() => 
            StateMachineBuilder.For<BaseModel>()
                .InsertAfter(typeof(Initialise), () => States.Off, typeof(SwitchOff))
                .InsertAfter(typeof(SwitchOff), () => States.On, typeof(SwitchOn))
                .InsertAction(() => States.On, typeof(Pulse), () => States.On)
                .GetStateMachine()
        );

        [AttributeName(Constants.Light.LightBulb.NAME_NAME)]
        [Description(Constants.Light.LightBulb.NAME_DESCRIPTION)]
        [Required]
        [StringLength(Constants.Light.LightBulb.NAME_MAX, MinimumLength = Constants.Light.LightBulb.NAME_MIN)]
        [DefaultValue(Constants.Light.LightBulb.NAME_DEFAULT)]
        public string Name { get; set; }

        [AttributeName(Constants.Light.LightBulb.BRIGHTNESS_NAME)]
        [Description(Constants.Light.LightBulb.BRIGHTNESS_DESCRIPTION)]
        [Required]
        [Range(Constants.Light.LightBulb.BRIGHTNESS_MIN, Constants.Light.LightBulb.BRIGHTNESS_MAX)]
        [DefaultValue(Constants.Light.LightBulb.BRIGHTNESS_DEFAULT)]
        public double Brightness { get; set; }

        [SuppressMessage("ReSharper", "UnassignedReadonlyField")]
        protected new class States : BaseModel.States
        {
            public static readonly ModelState Off;
            public static readonly ModelState On;
        }

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        public class SwitchOn : BaseModelAction
        {
            
        }

        public class SwitchOff : BaseModelAction
        {
            
        }

        public class Pulse : BaseModelAction
        {
            
        }
    }
}
