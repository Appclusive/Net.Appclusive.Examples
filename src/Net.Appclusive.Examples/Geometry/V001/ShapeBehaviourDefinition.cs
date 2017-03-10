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

namespace Net.Appclusive.Examples.Geometry.V001
{
    [Serializable]
    [BehaviourDefinitionFor(typeof(ShapeBehaviour))]
    public class ShapeBehaviourDefinition : BaseModel, ShapeBehaviour
    {
        public ShapeBehaviourDefinition()
        {
            // N/A
        }

        protected ShapeBehaviourDefinition(SerializationInfo info, StreamingContext context)
             : base(info, context)
        {
            // N/A
        }

        [AttributeName(Constants.Geometry.Shape.AREA_NAME)]
        [Required]
        [DefaultValue(Constants.Geometry.Shape.AREA_DEFAULT)]
        [Range(0, double.MaxValue)]
        public virtual double Area { get; set; }
    }
}