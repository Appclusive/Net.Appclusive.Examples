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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Net.Appclusive.Examples.Engine.V001;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.Geometry.V001
{
    [Serializable]
    public class Rectangle : Shape, LocationBehaviour
    {
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() =>
            StateMachineBuilder
                .For<Rectangle>()
                .InsertAfter(typeof(Initialise), () => States.Initialised, typeof(Destroy))
                .InsertAction(() => States.Initialised, typeof(Resize), () => States.Initialised)
                .GetStateMachine()
        );

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }

        public Rectangle()
        {
            // N/A
        }

        protected Rectangle(SerializationInfo info, StreamingContext context)
             : base(info, context)
        {
            // N/A
        }

        [SuppressMessage("ReSharper", "UnassignedReadonlyField")]
        public new class States : BaseModelStates
        {
            // ReSharper disable once InconsistentNaming
            public static readonly ModelState Initialised;
        }

        public class Resize : BaseModelAction
        {
            [AttributeName(Constants.Geometry.Shape.Rectangle.WIDTH_NAME)]
            [UseValidationFromModel(typeof(Rectangle))]
            public virtual int SizeX { get; set; }

            [AttributeName(Constants.Geometry.Shape.Rectangle.HEIGHT_NAME)]
            [UseValidationFromModel(typeof(Rectangle))]
            public virtual int SizeY { get; set; }
        }

        public class Destroy : BaseModelAction
        {
            // no properties
        }

        [AttributeName(Constants.Geometry.Shape.VERTEX_NAME)]
        [Required]
        [Range(4, 4)]
        [DefaultValue(4)]
        public override int Vertex { get; set; }

        [AttributeName(Constants.Geometry.Shape.Rectangle.WIDTH_NAME)]
        [Required]
        [Range(0, int.MaxValue)]
        public virtual int SizeX { get; set; }

        [AttributeName(Constants.Geometry.Shape.Rectangle.HEIGHT_NAME)]
        [Required]
        [Range(0, int.MaxValue)]
        public virtual int SizeY { get; set; }
    }
}