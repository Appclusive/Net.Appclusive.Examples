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
using Net.Appclusive.Public.Engine;

namespace Org.Sharedop.Models.Relaxed.V001
{
    public class UpdatingIsNotAPriority : BaseModel
    {
        public const string NAME = "Org.Sharedop.Models.Relaxed.V001.UpdatingIsNotAPriority.Name";

        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() =>
            StateMachineBuilder
                .For<UpdatingIsNotAPriority>()
                .GetStateMachine()
        );

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        [AttributeName(NAME)]
        public string Name { get; set; }
    }
}
