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
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;
using biz.dfch.CS.Commons;
using Net.Appclusive.Examples.Engine.V001;
using Net.Appclusive.Public.Engine;

namespace Net.Appclusive.Examples.Geometry.V001
{
    // this product is a completely working product
    // that derives from a set of upstream products and
    // implements 2 additional interfaces
    [Serializable]
    [Description("This is a sample model from the geometry package resembling a square.")]
    public class Square : Rectangle, CalculationBehaviour
    {
        #region ========== StateMachine ==========
        private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() => 
            StateMachineBuilder
                .For<Square>()
                .InsertAction(() => States.Initialised, typeof(SetBaseValue), () => States.Initialised)
                .GetStateMachine()
        );

        public override StateMachine GetStateMachine()
        {
            return _stateMachine.Value;
        }
        #endregion

        public Square()
        {
            // N/A
        }

        protected Square(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // N/A
        }

        [AttributeName(Constants.Geometry.Shape.Square.LENGTH_NAME)]
        [Required]
        [Range(0, int.MaxValue)]
        public virtual int Length
        {
            get { return base.SizeX; }
            set
            {
                base.SizeX = value;
                base.SizeY = value;
            }
        }

        [AttributeName(Constants.Engine.Location.LOCATION_NAME)]
        [DefaultValue(Constants.Engine.Location.LOCATION_DEFAULT)]
        [UseValidationFromBehaviour(typeof(LocationBehaviour))]
        public virtual string LocationName { get; set; }

        [AttributeName(Constants.Engine.CalculateValue.BASEVALUE_NAME)]
        [UseValidationFromBehaviour(typeof(CalculationBehaviour), UseDefaultValue = true)]
        public virtual int BaseValue { get; set; }

        public new class Resize : Rectangle.Resize
        {
            public Resize(DictionaryParameters parameters)
            {
                Contract.Requires(null != parameters);

                var rectangle = new AttributeConverter().Convert<Rectangle.Resize, AttributeNameAttribute>(parameters);
                Contract.Assert(rectangle.SizeX == rectangle.SizeY);

                this.Length = rectangle.SizeX;
            }

            [AttributeName(Constants.Geometry.Shape.Square.LENGTH_NAME)]
            [UseValidationFromModel(typeof(Square))]
            public virtual int Length { get; set; }
        }

        public class SetBaseValue : CalculationBehaviourDefinition.SetBaseValue
        {
            // intentionally left blank
        }
    }
}
