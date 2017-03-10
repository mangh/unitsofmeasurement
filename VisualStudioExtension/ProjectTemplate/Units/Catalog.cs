/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Linq;
using System.Collections.Generic;

namespace $safeprojectname$
{
    /// <summary>
    /// Catalog of all unit and scale proxies available at compile-time, possibly supplemented with late proxies at run-time.
    /// </summary>
    public static partial class Catalog
    {
        #region Fields
        private static List<Unit> m_units;
        private static List<Scale> m_scales;
        #endregion

        #region Properties
        public static IEnumerable<Unit> AllUnits { get { return m_units; } }
        public static IEnumerable<Scale> AllScales { get { return m_scales; } }
        public static IEnumerable<Measure> All { get { return (m_units as IEnumerable<Measure>).Union(m_scales); } }
        #endregion

        #region Constructor(s)
        //
        // Constructor itself is generated (from the template) in Catalog.Populate.cs file.
        //
        private static void Allocate(int numberOfUnits, int numberOfScales)
        {
            m_units = new List<Unit>(numberOfUnits);
            m_scales = new List<Scale>(numberOfScales);
        }
        #endregion

        #region Populate
        /// <summary>
        /// Adds measure (unit or scale proxy) to the collection.
        /// </summary>
        /// <param name="measure">Unit or scale proxy.</param>
        /// <exception cref="ArgumentException">Thrown when the measure is neither unit nor scale.</exception>
        /// <remarks>
        /// This method assumes that all measures originate from the Parser and relies on the validations made there i.e.:
        /// 1. unit and scale names are unique (no unit has the same name as other unit or scale),
        /// 2. units are identified uniquely by their symbols (no unit has the same symbol as other unit).
        /// </remarks>
        public static void Add(Measure measure)
        {
            if (Contains(measure))
            {
                throw new ArgumentException(string.Format("{0}: duplicate proxy.", measure));
            }
            else if (measure is Unit)
            {
                m_units.Add(measure as Unit);
            }
            else if(measure is Scale)
            {
                m_scales.Add(measure as Scale);
            }
            else
            {
                throw new ArgumentException(string.Format("{0}: neither unit nor scale.", measure));
            }
        }
        public static void Clear()
        {
            m_units.Clear();
            m_scales.Clear();
        }
        public static void Reset()
        {
            Clear();
            Populate();
        }
        public static void AppendFromAssembly(System.Reflection.Assembly assembly)
        {
            foreach(Type t in assembly.GetExportedTypes())
            {
                Measure proxy = Measure.TryRetrieveFrom(t);
                if(proxy != null)
                {
                    Add(proxy);
                }
            }
        }
        public static bool Contains(Measure measure)
        {
            Func<Measure, bool> equals = m => m.Equals(measure);
            return m_units.Any(equals) || m_scales.Any(equals);
        }
        #endregion

        #region Unit<T>, IEnumerable<Unit<T>>
        /// <summary>Returns unit of the given type and symbol.</summary>
        /// <typeparam name="T">Type of the unit to be selected.</typeparam>
        /// <param name="symbol">Symbol (tag) of the unit to be selected.</param>
        public static Unit<T> Unit<T>(string symbol)
            where T : struct
        {
            return Units<T>().FirstOrDefault(u => u.Symbol.IndexOf(symbol) >= 0);
        }

        /// <summary>Returns units of the required type and matching the given predicate.</summary>
        /// <typeparam name="T">Type of units to be selected.</typeparam>
        /// <param name="match">Predicate to be applied for selecting units.</param>
        public static IEnumerable<Unit<T>> Units<T>(Predicate<Unit<T>> match = null)
            where T : struct
        {
            IEnumerable<Unit<T>> units = m_units.OfType<Unit<T>>();
            return match == null ? units : units.Where(u => match(u));
        }

        /// <summary>Returns units of the required type and family.</summary>
        /// <typeparam name="T">Type of units to be selected.</typeparam>
        /// <param name="family">Family of units to be selected.</param>
        public static IEnumerable<Unit<T>> Units<T>(int family)
            where T : struct
        {
            return Units<T>(u => u.Family == family);
        }

        /// <summary>Returns units of the required type and dimension.</summary>
        /// <typeparam name="T">Type of units to be selected.</typeparam>
        /// <param name="sense">Required dimension.</param>
        public static IEnumerable<Unit<T>> Units<T>(Dimension sense)
            where T : struct
        {
            return Units<T>(u => u.Sense == sense);
        }

        /// <summary>Returns units underlying selected scales.</summary>
        /// <typeparam name="T">Type of units to be selected.</typeparam>
        /// <param name="scales">Selected scales.</param>
        public static IEnumerable<Unit<T>> Units<T>(IEnumerable<Scale<T>> scales)
            where T : struct
        {
            return scales.Select(s => s.Unit as Unit<T>);
        }
        #endregion

        #region Scale<T>, IEnumerable<Scale<T>>
        /// <summary>Returns scale of the given type, family and symbol.</summary>
        /// <typeparam name="T">Type of the scale to be selected.</typeparam>
        /// <param name="family">Family of the scale to be selected.</param>
        /// <param name="symbol">Symbol (tag) of unit that underlies the required scale.</param>
        public static Scale<T> Scale<T>(int family, string symbol)
            where T : struct
        {
            return Scales<T>(family).FirstOrDefault(s => s.Unit.Symbol.IndexOf(symbol) >= 0);
        }

        /// <summary>Returns scale of the given type, family and unit.</summary>
        /// <typeparam name="T">Type of the scale to be selected.</typeparam>
        /// <param name="family">Family of the scale to be selected.</param>
        /// <param name="unit">Unit of the scale to be selected.</param>
        public static Scale<T> Scale<T>(int family, Unit<T> unit)
            where T : struct
        {
            return Scales<T>(family).FirstOrDefault(s => s.Unit.Equals(unit));
        }

        /// <summary>Returns scales of the given type and matching the given predicate.</summary>
        /// <typeparam name="T">Type of scales.</typeparam>
        /// <param name="match">Predicate to be applied for selecting scales.</param>
        public static IEnumerable<Scale<T>> Scales<T>(Predicate<Scale<T>> match = null)
            where T : struct
        {
            IEnumerable<Scale<T>> scales = m_scales.OfType<Scale<T>>();
            return match == null ? scales : scales.Where(s => match(s));
        }

        /// <summary>Returns scales of the required type and family.</summary>
        /// <typeparam name="T">Type of scales to be selected.</typeparam>
        /// <param name="family">Family of scales to be selected.</param>
        public static IEnumerable<Scale<T>> Scales<T>(int family)
            where T : struct
        {
            return Scales<T>(u => u.Family == family);
        }

        /// <summary>Returns scales of the given type and dimension.</summary>
        /// <typeparam name="T">Type of scales to be selected.</typeparam>
        /// <param name="sense">Dimension of scales to be selected.</param>
        /// <returns></returns>
        public static IEnumerable<Scale<T>> Scales<T>(Dimension sense)
            where T : struct
        {
            return Scales<T>(s => s.Unit.Sense == sense);
        }
        #endregion
    }
}
