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
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Naked.V001
{
    [Serializable]
    public class ClassUsingBaseModel2 : BaseModel
    {
        public const string NAME = "Net.Appclusive.Naked.ClassUsingBaseModel2.Name";

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

        public ClassUsingBaseModel2()
        {
            // N/A
        }


        protected ClassUsingBaseModel2(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // N/A
        }

        [AttributeName(NAME)]
        [Required]
        public string StringProperty { get; set; }
    }
}
