using System.Collections.Generic;
using DotSpatial.Topology.Geometries;
using DotSpatial.Topology.IO;

namespace DotSpatial.Topology.Index.IntervalRTree
{
    public abstract class IntervalRTreeNode<T>
    {
        #region Constructors

        protected IntervalRTreeNode()
        {
            Min = double.PositiveInfinity;
            Max = double.NegativeInfinity;
        }

        protected IntervalRTreeNode(double min, double max)
        {
            Min = min;
            Max = max;
        }

        #endregion

        #region Properties

        public double Max { get; protected set; }
        public double Min { get; protected set; }

        #endregion

        #region Methods

        protected bool Intersects(double queryMin, double queryMax)
        {
            return (!(Min > queryMax || Max < queryMin));
        }

        public abstract void Query(double queryMin, double queryMax, IItemVisitor<T> visitor);

        public override string ToString()
        {
            return WKTWriter.ToLineString(new Coordinate(Min, 0), new Coordinate(Max, 0));
        }

        #endregion

        #region Classes

        public class NodeComparator : IComparer<IntervalRTreeNode<T>>
        {
            #region Fields

            public static NodeComparator Instance = new NodeComparator();

            #endregion

            #region Methods

            public int Compare(IntervalRTreeNode<T> n1, IntervalRTreeNode<T> n2)
            {
                double mid1 = (n1.Min + n1.Max) / 2;
                double mid2 = (n2.Min + n2.Max) / 2;
                if (mid1 < mid2) return -1;
                return mid1 > mid2 ? 1 : 0;
            }

            #endregion
        }

        #endregion
    }
}