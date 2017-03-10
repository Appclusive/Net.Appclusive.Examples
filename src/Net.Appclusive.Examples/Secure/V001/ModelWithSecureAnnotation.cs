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
using biz.dfch.CS.Commons.Validation;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.Secure.V001
{
    public class ModelWithSecureAnnotation : BaseModel
    {
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() =>
            StateMachineBuilder
                .For<ModelWithSecureAnnotation>()
                .GetStateMachine()
        );

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        [AttributeName(Constants.Secure.ModelWithSecureAnnotation.NAME_NAME)]
        [Required]
        [DefaultValue(Constants.Secure.ModelWithSecureAnnotation.NAME_DEFAULT)]
        [StringLength(Constants.Secure.ModelWithSecureAnnotation.NAME_MAX, MinimumLength = Constants.Secure.ModelWithSecureAnnotation.NAME_MIN)]
        [SecureString]
        public string Name { get; set; }

        public class TransitionWithSecure : BaseModelAction
        {
            [AttributeName(Constants.Secure.ModelWithSecureAnnotation.SECURE_NAME)]
            [Required]
            [DefaultValue(Constants.Secure.ModelWithSecureAnnotation.NAME_DEFAULT)]
            [StringLength(Constants.Secure.ModelWithSecureAnnotation.NAME_MAX, MinimumLength = Constants.Secure.ModelWithSecureAnnotation.NAME_MIN)]
            [SecureString]
            public string Name { get; set; }
        }

        public class TransitionWithoutSecure : BaseModelAction
        {
            [AttributeName(Constants.Secure.ModelWithSecureAnnotation.UNSECURE_NAME)]
            [Required]
            [DefaultValue(Constants.Secure.ModelWithSecureAnnotation.NAME_DEFAULT)]
            [StringLength(Constants.Secure.ModelWithSecureAnnotation.NAME_MAX, MinimumLength = Constants.Secure.ModelWithSecureAnnotation.NAME_MIN)]
            public string Name { get; set; }
        }
    }
}
