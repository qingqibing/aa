// ********************************************************************************************************
// Product Name: DotSpatial.Topology.dll
// Description:  The basic topology module for the new dotSpatial libraries
// ********************************************************************************************************
// The contents of this file are subject to the Lesser GNU Public License (LGPL)
// you may not use this file except in compliance with the License. You may obtain a copy of the License at
// http://dotspatial.codeplex.com/license  Alternately, you can access an earlier version of this content from
// the Net Topology Suite, which is also protected by the GNU Lesser Public License and the sourcecode
// for the Net Topology Suite can be obtained here: http://sourceforge.net/projects/nts.
//
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF
// ANY KIND, either expressed or implied. See the License for the specific language governing rights and
// limitations under the License.
//
// The Original Code is from the Net Topology Suite, which is a C# port of the Java Topology Suite.
//
// The Initial Developer to integrate this code into MapWindow 6.0 is Ted Dunsford.
//
// Contributor(s): (Open source contributors should list themselves and their modifications here).
// |         Name         |    Date    |                              Comment
// |----------------------|------------|------------------------------------------------------------
// |                      |            |

using System.Collections.Generic;

namespace DotSpatial.Topology.Geometries
{
    /// <summary>
    /// Specific topology functions for Mutigeometry code
    /// </summary>
    public interface IGeometryCollection : IGeometry, IEnumerable<IGeometry>
    {
        #region Properties

        /// <summary>
        /// Returns the number of geometries contained by this <see cref="IGeometryCollection" />.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets a System.Array of all the geometries in this collection
        /// </summary>
        IGeometry[] Geometries { get; }

        /// <summary>
        /// Return <c>true</c> if all features in collection are of the same type.
        /// </summary>
        bool IsHomogeneous { get; }

        #endregion

        #region Indexers

        /// <summary>
        /// Returns the iTh <see cref="IGeometry"/> element in the collection.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        IGeometry this[int i] { get; }

        #endregion
    }
}