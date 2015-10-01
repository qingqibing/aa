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
// ********************************************************************************************************

using System.Collections.Generic;
using DotSpatial.Topology.Geometries;

namespace DotSpatial.Topology.GeometriesGraph.Index
{
    /// <summary>
    ///
    /// </summary>
    public class SweepLineSegment
    {
        #region Fields

        private readonly Edge edge;
        readonly int ptIndex;
        private readonly IList<Coordinate> pts;

        #endregion

        #region Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="ptIndex"></param>
        public SweepLineSegment(Edge edge, int ptIndex)
        {
            this.edge = edge;
            this.ptIndex = ptIndex;
            pts = edge.Coordinates;
        }

        #endregion

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public double MaxX
        {
            get
            {
                double x1 = pts[ptIndex].X;
                double x2 = pts[ptIndex + 1].X;
                return x1 > x2 ? x1 : x2;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public double MinX
        {
            get
            {
                double x1 = pts[ptIndex].X;
                double x2 = pts[ptIndex + 1].X;
                return x1 < x2 ? x1 : x2;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="si"></param>
        public void ComputeIntersections(SweepLineSegment ss, SegmentIntersector si)
        {
            si.AddIntersections(edge, ptIndex, ss.edge, ss.ptIndex);
        }

        #endregion
    }
}