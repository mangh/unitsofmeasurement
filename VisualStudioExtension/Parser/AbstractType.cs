/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


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
        public MeasureType Relative { get; private set; }
        public MeasureType Prime { get; private set; }
        #endregion

        #region Constructor(s)
        protected MeasureType(string nameSpace, string name) :
            base(nameSpace, name, false)
        {
            Prime = null;       // Initially, no prime measure (it's a prime for itself and a candidate for the family prime)
            Relative = this;    // Initially, no relatives
        }
        #endregion

        #region Methods
        public void AddRelative(MeasureType relative)
        {
            relative.Prime = this;

            MeasureType otherrelative = this.Relative;
            this.Relative = relative;
            relative.Relative = otherrelative;
        }
        public MeasureType FamilyPrime()
        {
            return (this.Prime == null) ? this : this.Relatives().First(m => m.Prime == null);
        }
        public IEnumerable<MeasureType> Relatives()
        {
            MeasureType next = this.Relative;
            while (!object.ReferenceEquals(next, this))
            {
                yield return next;
                next = next.Relative;
            }
        }
        #endregion
    }
}
