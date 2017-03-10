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
using System.Diagnostics;
using Net.Appclusive.Public.Engine;

namespace Net.Sharedop.Models.Grumpy.V667
{
    public class GreedyModel : BaseModel
    {
        public const string NAME = "Net.Sharedop.Models.Grumpy.V667.RogueModel.Name";
        public const int DELAY_MS = 15 * 1000;

        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() =>
            StateMachineBuilder
                .For<RogueModel>()
                .GetStateMachine()
        );

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        public GreedyModel()
        {
            var c = 0L;

            var stopWatch = Stopwatch.StartNew();
            do
            {
                c = (c - DateTimeOffset.Now.Ticks + 42L) * -1;
            }
            while (DELAY_MS > stopWatch.ElapsedMilliseconds);
        }

        [AttributeName(NAME)]
        [Required]
        public string Name { get; set; }
    }
}
