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
using System.Runtime.Serialization;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Naked.V001
{
    [BehaviourDefinition(typeof(ClassUsingBaseModel3BehaviourDefinition))]
    // ReSharper disable once InconsistentNaming
    public interface ClassUsingBaseModel3Behaviour : BaseBehaviour
    {
        // N/A
    }

    [Serializable]
    [BehaviourDefinitionFor(typeof(ClassUsingBaseModel3Behaviour))]
    public class ClassUsingBaseModel3BehaviourDefinition : BaseModel, ClassUsingBaseModel3Behaviour
    {
        public ClassUsingBaseModel3BehaviourDefinition()
        {
            // N/A
        }

        protected ClassUsingBaseModel3BehaviourDefinition(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // N/A
        }

        [AttributeName(ClassUsingBaseModel3.MODEL)]
        [DefaultValue(42)]
        public int StringProperty { get; set; }

        [AttributeName(ClassUsingBaseModel3.BEHAVIOUR)]
        [DefaultValue(5)]
        public int IntProperty { get; set; }
    }

    [Serializable]
    public class ClassUsingBaseModel3 : BaseModel
    {
        public const string NAME = "Net.Appclusive.Naked.ClassUsingBaseModel3.Name";
        public const string MODEL = "Net.Appclusive.Naked.ClassUsingBaseModel3.ValidationFromModel";
        public const string BEHAVIOUR = "Net.Appclusive.Naked.ClassUsingBaseModel3.ValidationFromBehaviour";

        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() =>
        {
            return new StateMachine
            {
                {() => BaseModelStates.InitialState, typeof(Initialise), () => BaseModelStates.DecommissionedState}
                ,
                {() => BaseModelStates.DecommissionedState, typeof(Finalise), () => BaseModelStates.FinalState}
                ,
                {() => BaseModelStates.ErrorState, typeof(Remedy), () => BaseModelStates.ErrorState}
            };
        });

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        public ClassUsingBaseModel3()
        {
            // N/A
        }

        protected ClassUsingBaseModel3(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // N/A
        }

        [AttributeName(NAME)]
        [Required]
        public string StringProperty { get; set; }

        [AttributeName(MODEL)]
        [UseValidationFromModel(typeof(ClassUsingBaseModel3BehaviourDefinition), UseDefaultValue = true)]
        public long LongProperty { get; set; }

        [AttributeName(BEHAVIOUR)]
        [UseValidationFromBehaviour(typeof(ClassUsingBaseModel3Behaviour), UseDefaultValue = true)]
        public int IntProperty { get; set; }
    }
}
