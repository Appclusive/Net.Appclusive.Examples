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

using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Appclusive.Examples.AccessViolation.V001;

namespace Net.Appclusive.Examples.Tests.AccessViolation.V001
{
    [TestClass]
    public class ModelWithFileAccessTest
    {
        [TestMethod]
        public void HasValidStateMachine()
        {
            var sut = new ModelWithFileAccess()
                .GetStateMachine();

            sut.GetErrorMessages().ToList().ForEach(e => Trace.WriteLine(e));
            Assert.IsTrue(sut.IsValid());
        }
    }
}
