/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System.Collections.Generic;
using System.Linq;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class AbstractType
    {
        #region Properties
        public string Namespace { get; private set; }
        public string Name { get; private set; }
        public bool IsPredefined { get; private set; }
        #endregion

        #region Constructor(s)
        protected AbstractType(string nameSpace, string name, bool isPredefined)
        {
            Namespace = nameSpace;
            Name = name;
            IsPredefined = isPredefined;
        }
        #endregion
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class MeasureType : AbstractType
    {
        public static readonly string DefaultNamespace = typeof(MeasureType).Namespace;

        #region Properties
        /// <summary>
        /// A reference to the (next) relative.
        /// </summary>
        /// <remarks>
        /// Subsequent items linked by the property make a list <i>R</i> of relatives i.e. a <i><b>family</b></i>:
        /// <list type="bullet">
        /// <item><description>the list is <i>cyclic</i>: <c>∀r∈R: r.Relative[.Relative[.Relative[...]]] == r</c></description></item>
        /// <item><description>the list contains <i>this</i>: <c>∃r∈R: r == this</c></description></item>
        /// <item><description>items in the list are <i>unique</i>: <c>∀i,j∈I, i ≠ j: r[i] ≠ r[j]</c></description></item>
        /// <item><description>there is exactly one <i>prime</i>: <c>∃!p∈R: p.Prime == null</c></description></item>
        /// <item><description>all other items <i>reference</i> that <i>prime</i>: <c>∀r∈R, r ≠ p: r.Prime == p.</c></description></item>
        /// </list>
        /// </remarks>
        public MeasureType Relative { get; private set; }

        /// <summary>
        /// Reference to the primary measure (null if it is primary itself).
        /// </summary>
        public MeasureType Prime { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Creates measure of a given name, in a given namespace.
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <remarks>
        /// The newly created measure is a (one-element) family the other measures may join in;<br/>
        /// the measure may join other families as well.
        /// </remarks>
        protected MeasureType(string nameSpace, string name) :
            base(nameSpace, name, false)
        {
            Prime = null;       // Initially, no prime measure (it's a prime for itself and a candidate for the family prime)
            Relative = this;    // Initially, no relatives (except itself)
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add measure (together with its relatives) to the family
        /// </summary>
        /// <param name="other">measure entity to be included in the family</param>
        public void AddRelative(MeasureType other)
        {
            // Do nothing if the other is already among relatives
            if (!Relatives().Any(r => ReferenceEquals(other, r)) && !ReferenceEquals(other, this))
            {
                var thisRelative = this.Relative;
                this.Relative = other;
                other.Relative = thisRelative;
                other.Prime = this.Prime ?? this;
            }
        }

        /// <summary>
        /// Returns relatives enumerator
        /// </summary>
        /// <returns>Enumerator of all relatives (except itself)</returns>
        public IEnumerable<MeasureType> Relatives()
        {
            MeasureType next = this.Relative;
            while (!ReferenceEquals(next, this))
            {
                yield return next;
                next = next.Relative;
            }
        }
        #endregion
    }
}
