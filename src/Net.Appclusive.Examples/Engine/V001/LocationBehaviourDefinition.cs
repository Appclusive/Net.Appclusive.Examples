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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using biz.dfch.CS.Commons.Validation;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.Engine.V001
{
    [BehaviourDefinitionFor(typeof(LocationBehaviour))]
    public class LocationBehaviourDefinition : BaseModel, LocationBehaviour
    {
        [AttributeName(Constants.Engine.Location.LOCATION_NAME)]
        [Required]
        [DefaultValue(Constants.Engine.Location.LOCATION_DEFAULT)]
        [ValidateSetIfNotDefault(Constants.Engine.Location.LOCATION_SET)]
        public virtual string Name { get; set; }
    }
}
