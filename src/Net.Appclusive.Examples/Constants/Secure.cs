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

namespace Net.Appclusive.Examples.Constants
{
    public static class Secure
    {
        public static class ModelWithSecureAnnotation
        {
            public const string NAME_NAME = "Net.Appclusive.Examples.Constants.Secure.ModelWithSecureAnnotation.Name";
            public const string NAME_DEFAULT = "I am a very clandestine string.";
            public const int NAME_MIN = 31;
            public const int NAME_MAX = 31;
            public const string SECURE_NAME = "Net.Appclusive.Examples.Constants.Secure.ModelWithSecureAnnotation.Secure";
            public const string UNSECURE_NAME = "Net.Appclusive.Examples.Constants.Secure.ModelWithSecureAnnotation.Unsecure";
        }
    }
        
}
