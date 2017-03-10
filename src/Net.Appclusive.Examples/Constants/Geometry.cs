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
    public static class Geometry
    {
        public static class Shape
        {
            public const string AREA_NAME = "Net.Appclusive.Examples.Geometry.Shape.Area";
            public const double AREA_DEFAULT = 1;
            public const string VERTEX_NAME = "Net.Appclusive.Examples.Geometry.Shape.Vertex";

            public static class Rectangle
            {
                public const string WIDTH_NAME = "Net.Appclusive.Examples.Geometry.Rectangle.Width";
                public const string HEIGHT_NAME = "Net.Appclusive.Examples.Geometry.Rectangle.Heigth";
            }

            public static class Square
            {
                public const string LENGTH_NAME = "Net.Appclusive.Examples.Geometry.Square.Length";
            }
        }
    }
}
