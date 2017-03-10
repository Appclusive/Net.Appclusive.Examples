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
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.AccessViolation.V001
{
    public class ModelWithFileAccess : BaseModel
    {
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() => 
            StateMachineBuilder
                .For<ModelWithFileAccess>()
                .InsertAfter(typeof(Initialise), () => States.Created, typeof(Remove))
                .GetStateMachine()
        );

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        protected new class States : BaseModel.States
        {
            // ReSharper disable once InconsistentNaming
            // ReSharper disable once UnassignedReadonlyField
            public static readonly ModelState Created;
        }

        [AttributeName(Constants.AccessViolation.ModelWithFileAccess.NAME_NAME)]
        [Required]
        [DefaultValue(Constants.AccessViolation.ModelWithFileAccess.NAME_DEFAULT)]
        [StringLength(Constants.AccessViolation.ModelWithFileAccess.NAME_MAX, MinimumLength = Constants.AccessViolation.ModelWithFileAccess.NAME_MIN)]
        public string Name { get; set; }

        public class Remove : BaseModelAction
        {
            // no attributes needed
        }
    }
}
