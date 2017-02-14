/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct Meter : IQuantity<double>, IEquatable<Meter>, IComparable<Meter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Meter.Family; } }
        double IQuantity<double>.Factor { get { return Meter.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Meter.Symbol; } }
        #endregion

        #region Constructor(s)
        public Meter(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Meter(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Meter(double q) { return new Meter(q); }
        public static Meter From(IQuantity<double> q)
        {
            if (q.Family != Meter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Meter\"", q.GetType().Name));
            return new Meter((Meter.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Meter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter) && Equals((Meter)obj); }
        public bool /* IEquatable<Meter> */ Equals(Meter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Meter>
        public static bool operator ==(Meter lhs, Meter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Meter lhs, Meter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Meter lhs, Meter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Meter lhs, Meter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Meter lhs, Meter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Meter lhs, Meter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Meter> */ CompareTo(Meter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter operator +(Meter lhs, Meter rhs) { return new Meter(lhs.m_value + rhs.m_value); }
        public static Meter operator -(Meter lhs, Meter rhs) { return new Meter(lhs.m_value - rhs.m_value); }
        public static Meter operator ++(Meter q) { return new Meter(q.m_value + 1d); }
        public static Meter operator --(Meter q) { return new Meter(q.m_value - 1d); }
        public static Meter operator -(Meter q) { return new Meter(-q.m_value); }
        public static Meter operator *(double lhs, Meter rhs) { return new Meter(lhs * rhs.m_value); }
        public static Meter operator *(Meter lhs, double rhs) { return new Meter(lhs.m_value * rhs); }
        public static Meter operator /(Meter lhs, double rhs) { return new Meter(lhs.m_value / rhs); }
        public static double operator /(Meter lhs, Meter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static SquareMeter operator *(Meter lhs, Meter rhs) { return new SquareMeter(lhs.m_value * rhs.m_value); }
        public static Meter_Sec operator /(Meter lhs, Second rhs) { return new Meter_Sec(lhs.m_value / rhs.m_value); }
        public static Second operator /(Meter lhs, Meter_Sec rhs) { return new Second(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Meter.Format, m_value, Meter.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Length;
        private static readonly int s_family = 0;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m");

        private static readonly Meter s_one = new Meter(1d);
        private static readonly Meter s_zero = new Meter(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Meter One { get { return s_one; } }
        public static Meter Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Second : IQuantity<double>, IEquatable<Second>, IComparable<Second>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Second.Family; } }
        double IQuantity<double>.Factor { get { return Second.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Second.Symbol; } }
        #endregion

        #region Constructor(s)
        public Second(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Second(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Second(double q) { return new Second(q); }
        public static Second From(IQuantity<double> q)
        {
            if (q.Family != Second.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Second\"", q.GetType().Name));
            return new Second((Second.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Second>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Second) && Equals((Second)obj); }
        public bool /* IEquatable<Second> */ Equals(Second other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Second>
        public static bool operator ==(Second lhs, Second rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Second lhs, Second rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Second lhs, Second rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Second lhs, Second rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Second lhs, Second rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Second lhs, Second rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Second> */ CompareTo(Second other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Second operator +(Second lhs, Second rhs) { return new Second(lhs.m_value + rhs.m_value); }
        public static Second operator -(Second lhs, Second rhs) { return new Second(lhs.m_value - rhs.m_value); }
        public static Second operator ++(Second q) { return new Second(q.m_value + 1d); }
        public static Second operator --(Second q) { return new Second(q.m_value - 1d); }
        public static Second operator -(Second q) { return new Second(-q.m_value); }
        public static Second operator *(double lhs, Second rhs) { return new Second(lhs * rhs.m_value); }
        public static Second operator *(Second lhs, double rhs) { return new Second(lhs.m_value * rhs); }
        public static Second operator /(Second lhs, double rhs) { return new Second(lhs.m_value / rhs); }
        public static double operator /(Second lhs, Second rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Second.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Second.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Second.Format, m_value, Second.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Time;
        private static readonly int s_family = 1;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("s");

        private static readonly Second s_one = new Second(1d);
        private static readonly Second s_zero = new Second(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Second One { get { return s_one; } }
        public static Second Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Kilogram : IQuantity<double>, IEquatable<Kilogram>, IComparable<Kilogram>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Kilogram.Family; } }
        double IQuantity<double>.Factor { get { return Kilogram.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Kilogram.Symbol; } }
        #endregion

        #region Constructor(s)
        public Kilogram(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Kilogram(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Kilogram(double q) { return new Kilogram(q); }
        public static Kilogram From(IQuantity<double> q)
        {
            if (q.Family != Kilogram.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kilogram\"", q.GetType().Name));
            return new Kilogram((Kilogram.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Kilogram>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Kilogram) && Equals((Kilogram)obj); }
        public bool /* IEquatable<Kilogram> */ Equals(Kilogram other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Kilogram>
        public static bool operator ==(Kilogram lhs, Kilogram rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Kilogram lhs, Kilogram rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Kilogram lhs, Kilogram rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Kilogram lhs, Kilogram rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Kilogram lhs, Kilogram rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Kilogram lhs, Kilogram rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Kilogram> */ CompareTo(Kilogram other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Kilogram operator +(Kilogram lhs, Kilogram rhs) { return new Kilogram(lhs.m_value + rhs.m_value); }
        public static Kilogram operator -(Kilogram lhs, Kilogram rhs) { return new Kilogram(lhs.m_value - rhs.m_value); }
        public static Kilogram operator ++(Kilogram q) { return new Kilogram(q.m_value + 1d); }
        public static Kilogram operator --(Kilogram q) { return new Kilogram(q.m_value - 1d); }
        public static Kilogram operator -(Kilogram q) { return new Kilogram(-q.m_value); }
        public static Kilogram operator *(double lhs, Kilogram rhs) { return new Kilogram(lhs * rhs.m_value); }
        public static Kilogram operator *(Kilogram lhs, double rhs) { return new Kilogram(lhs.m_value * rhs); }
        public static Kilogram operator /(Kilogram lhs, double rhs) { return new Kilogram(lhs.m_value / rhs); }
        public static double operator /(Kilogram lhs, Kilogram rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Newton operator *(Kilogram lhs, Meter_Sec2 rhs) { return new Newton(lhs.m_value * rhs.m_value); }
        public static Newton operator *(Meter_Sec2 lhs, Kilogram rhs) { return new Newton(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Kilogram.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Kilogram.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Kilogram.Format, m_value, Kilogram.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Mass;
        private static readonly int s_family = 2;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("kg");

        private static readonly Kilogram s_one = new Kilogram(1d);
        private static readonly Kilogram s_zero = new Kilogram(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Kilogram One { get { return s_one; } }
        public static Kilogram Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct DegKelvin : IQuantity<double>, IEquatable<DegKelvin>, IComparable<DegKelvin>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return DegKelvin.Family; } }
        double IQuantity<double>.Factor { get { return DegKelvin.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return DegKelvin.Symbol; } }
        #endregion

        #region Constructor(s)
        public DegKelvin(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new DegKelvin(value);
        }
        #endregion

        #region Conversions
        public static explicit operator DegKelvin(double q) { return new DegKelvin(q); }
        public static explicit operator DegKelvin(DegFahrenheit q) { return new DegKelvin((DegKelvin.Factor / DegFahrenheit.Factor) * q.m_value); }
        public static explicit operator DegKelvin(DegRankine q) { return new DegKelvin((DegKelvin.Factor / DegRankine.Factor) * q.m_value); }
        public static explicit operator DegKelvin(DegCelsius q) { return new DegKelvin((DegKelvin.Factor / DegCelsius.Factor) * q.m_value); }
        public static DegKelvin From(IQuantity<double> q)
        {
            if (q.Family != DegKelvin.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegKelvin\"", q.GetType().Name));
            return new DegKelvin((DegKelvin.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<DegKelvin>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegKelvin) && Equals((DegKelvin)obj); }
        public bool /* IEquatable<DegKelvin> */ Equals(DegKelvin other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<DegKelvin>
        public static bool operator ==(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<DegKelvin> */ CompareTo(DegKelvin other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegKelvin operator +(DegKelvin lhs, DegKelvin rhs) { return new DegKelvin(lhs.m_value + rhs.m_value); }
        public static DegKelvin operator -(DegKelvin lhs, DegKelvin rhs) { return new DegKelvin(lhs.m_value - rhs.m_value); }
        public static DegKelvin operator ++(DegKelvin q) { return new DegKelvin(q.m_value + 1d); }
        public static DegKelvin operator --(DegKelvin q) { return new DegKelvin(q.m_value - 1d); }
        public static DegKelvin operator -(DegKelvin q) { return new DegKelvin(-q.m_value); }
        public static DegKelvin operator *(double lhs, DegKelvin rhs) { return new DegKelvin(lhs * rhs.m_value); }
        public static DegKelvin operator *(DegKelvin lhs, double rhs) { return new DegKelvin(lhs.m_value * rhs); }
        public static DegKelvin operator /(DegKelvin lhs, double rhs) { return new DegKelvin(lhs.m_value / rhs); }
        public static double operator /(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegKelvin.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegKelvin.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? DegKelvin.Format, m_value, DegKelvin.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Temperature;
        private static readonly int s_family = 3;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("K", "deg.K");

        private static readonly DegKelvin s_one = new DegKelvin(1d);
        private static readonly DegKelvin s_zero = new DegKelvin(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static DegKelvin One { get { return s_one; } }
        public static DegKelvin Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct DegCelsius : IQuantity<double>, IEquatable<DegCelsius>, IComparable<DegCelsius>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return DegCelsius.Family; } }
        double IQuantity<double>.Factor { get { return DegCelsius.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return DegCelsius.Symbol; } }
        #endregion

        #region Constructor(s)
        public DegCelsius(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new DegCelsius(value);
        }
        #endregion

        #region Conversions
        public static explicit operator DegCelsius(double q) { return new DegCelsius(q); }
        public static explicit operator DegCelsius(DegKelvin q) { return new DegCelsius((DegCelsius.Factor / DegKelvin.Factor) * q.m_value); }
        public static explicit operator DegCelsius(DegFahrenheit q) { return new DegCelsius((DegCelsius.Factor / DegFahrenheit.Factor) * q.m_value); }
        public static explicit operator DegCelsius(DegRankine q) { return new DegCelsius((DegCelsius.Factor / DegRankine.Factor) * q.m_value); }
        public static DegCelsius From(IQuantity<double> q)
        {
            if (q.Family != DegCelsius.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegCelsius\"", q.GetType().Name));
            return new DegCelsius((DegCelsius.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<DegCelsius>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegCelsius) && Equals((DegCelsius)obj); }
        public bool /* IEquatable<DegCelsius> */ Equals(DegCelsius other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<DegCelsius>
        public static bool operator ==(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<DegCelsius> */ CompareTo(DegCelsius other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegCelsius operator +(DegCelsius lhs, DegCelsius rhs) { return new DegCelsius(lhs.m_value + rhs.m_value); }
        public static DegCelsius operator -(DegCelsius lhs, DegCelsius rhs) { return new DegCelsius(lhs.m_value - rhs.m_value); }
        public static DegCelsius operator ++(DegCelsius q) { return new DegCelsius(q.m_value + 1d); }
        public static DegCelsius operator --(DegCelsius q) { return new DegCelsius(q.m_value - 1d); }
        public static DegCelsius operator -(DegCelsius q) { return new DegCelsius(-q.m_value); }
        public static DegCelsius operator *(double lhs, DegCelsius rhs) { return new DegCelsius(lhs * rhs.m_value); }
        public static DegCelsius operator *(DegCelsius lhs, double rhs) { return new DegCelsius(lhs.m_value * rhs); }
        public static DegCelsius operator /(DegCelsius lhs, double rhs) { return new DegCelsius(lhs.m_value / rhs); }
        public static double operator /(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegCelsius.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegCelsius.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? DegCelsius.Format, m_value, DegCelsius.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = DegKelvin.Family;
        private static /*mutable*/ double s_factor = DegKelvin.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u00B0C", "deg.C");

        private static readonly DegCelsius s_one = new DegCelsius(1d);
        private static readonly DegCelsius s_zero = new DegCelsius(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static DegCelsius One { get { return s_one; } }
        public static DegCelsius Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct DegRankine : IQuantity<double>, IEquatable<DegRankine>, IComparable<DegRankine>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return DegRankine.Family; } }
        double IQuantity<double>.Factor { get { return DegRankine.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return DegRankine.Symbol; } }
        #endregion

        #region Constructor(s)
        public DegRankine(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new DegRankine(value);
        }
        #endregion

        #region Conversions
        public static explicit operator DegRankine(double q) { return new DegRankine(q); }
        public static explicit operator DegRankine(DegCelsius q) { return new DegRankine((DegRankine.Factor / DegCelsius.Factor) * q.m_value); }
        public static explicit operator DegRankine(DegKelvin q) { return new DegRankine((DegRankine.Factor / DegKelvin.Factor) * q.m_value); }
        public static explicit operator DegRankine(DegFahrenheit q) { return new DegRankine((DegRankine.Factor / DegFahrenheit.Factor) * q.m_value); }
        public static DegRankine From(IQuantity<double> q)
        {
            if (q.Family != DegRankine.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegRankine\"", q.GetType().Name));
            return new DegRankine((DegRankine.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<DegRankine>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegRankine) && Equals((DegRankine)obj); }
        public bool /* IEquatable<DegRankine> */ Equals(DegRankine other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<DegRankine>
        public static bool operator ==(DegRankine lhs, DegRankine rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(DegRankine lhs, DegRankine rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(DegRankine lhs, DegRankine rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(DegRankine lhs, DegRankine rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(DegRankine lhs, DegRankine rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(DegRankine lhs, DegRankine rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<DegRankine> */ CompareTo(DegRankine other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegRankine operator +(DegRankine lhs, DegRankine rhs) { return new DegRankine(lhs.m_value + rhs.m_value); }
        public static DegRankine operator -(DegRankine lhs, DegRankine rhs) { return new DegRankine(lhs.m_value - rhs.m_value); }
        public static DegRankine operator ++(DegRankine q) { return new DegRankine(q.m_value + 1d); }
        public static DegRankine operator --(DegRankine q) { return new DegRankine(q.m_value - 1d); }
        public static DegRankine operator -(DegRankine q) { return new DegRankine(-q.m_value); }
        public static DegRankine operator *(double lhs, DegRankine rhs) { return new DegRankine(lhs * rhs.m_value); }
        public static DegRankine operator *(DegRankine lhs, double rhs) { return new DegRankine(lhs.m_value * rhs); }
        public static DegRankine operator /(DegRankine lhs, double rhs) { return new DegRankine(lhs.m_value / rhs); }
        public static double operator /(DegRankine lhs, DegRankine rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegRankine.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegRankine.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? DegRankine.Format, m_value, DegRankine.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = DegKelvin.Family;
        private static /*mutable*/ double s_factor = (9d / 5d) * DegKelvin.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u00B0R", "deg.R");

        private static readonly DegRankine s_one = new DegRankine(1d);
        private static readonly DegRankine s_zero = new DegRankine(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static DegRankine One { get { return s_one; } }
        public static DegRankine Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct DegFahrenheit : IQuantity<double>, IEquatable<DegFahrenheit>, IComparable<DegFahrenheit>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return DegFahrenheit.Family; } }
        double IQuantity<double>.Factor { get { return DegFahrenheit.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return DegFahrenheit.Symbol; } }
        #endregion

        #region Constructor(s)
        public DegFahrenheit(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new DegFahrenheit(value);
        }
        #endregion

        #region Conversions
        public static explicit operator DegFahrenheit(double q) { return new DegFahrenheit(q); }
        public static explicit operator DegFahrenheit(DegRankine q) { return new DegFahrenheit((DegFahrenheit.Factor / DegRankine.Factor) * q.m_value); }
        public static explicit operator DegFahrenheit(DegCelsius q) { return new DegFahrenheit((DegFahrenheit.Factor / DegCelsius.Factor) * q.m_value); }
        public static explicit operator DegFahrenheit(DegKelvin q) { return new DegFahrenheit((DegFahrenheit.Factor / DegKelvin.Factor) * q.m_value); }
        public static DegFahrenheit From(IQuantity<double> q)
        {
            if (q.Family != DegFahrenheit.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegFahrenheit\"", q.GetType().Name));
            return new DegFahrenheit((DegFahrenheit.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<DegFahrenheit>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegFahrenheit) && Equals((DegFahrenheit)obj); }
        public bool /* IEquatable<DegFahrenheit> */ Equals(DegFahrenheit other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<DegFahrenheit>
        public static bool operator ==(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<DegFahrenheit> */ CompareTo(DegFahrenheit other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegFahrenheit operator +(DegFahrenheit lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs.m_value + rhs.m_value); }
        public static DegFahrenheit operator -(DegFahrenheit lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs.m_value - rhs.m_value); }
        public static DegFahrenheit operator ++(DegFahrenheit q) { return new DegFahrenheit(q.m_value + 1d); }
        public static DegFahrenheit operator --(DegFahrenheit q) { return new DegFahrenheit(q.m_value - 1d); }
        public static DegFahrenheit operator -(DegFahrenheit q) { return new DegFahrenheit(-q.m_value); }
        public static DegFahrenheit operator *(double lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs * rhs.m_value); }
        public static DegFahrenheit operator *(DegFahrenheit lhs, double rhs) { return new DegFahrenheit(lhs.m_value * rhs); }
        public static DegFahrenheit operator /(DegFahrenheit lhs, double rhs) { return new DegFahrenheit(lhs.m_value / rhs); }
        public static double operator /(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegFahrenheit.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegFahrenheit.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? DegFahrenheit.Format, m_value, DegFahrenheit.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = DegKelvin.Family;
        private static /*mutable*/ double s_factor = (9d / 5d) * DegKelvin.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u00B0F", "deg.F");

        private static readonly DegFahrenheit s_one = new DegFahrenheit(1d);
        private static readonly DegFahrenheit s_zero = new DegFahrenheit(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static DegFahrenheit One { get { return s_one; } }
        public static DegFahrenheit Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct EUR : IQuantity<decimal>, IEquatable<EUR>, IComparable<EUR>, IFormattable
    {
        #region Fields
        internal readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        int IQuantity<decimal>.Family { get { return EUR.Family; } }
        decimal IQuantity<decimal>.Factor { get { return EUR.Factor; } }
        SymbolCollection IQuantity<decimal>.Symbol { get { return EUR.Symbol; } }
        #endregion

        #region Constructor(s)
        public EUR(decimal value)
        {
            m_value = value;
        }
        public static IQuantity<decimal> Create(decimal value)
        {
            return new EUR(value);
        }
        #endregion

        #region Conversions
        public static explicit operator EUR(decimal q) { return new EUR(q); }
        public static explicit operator EUR(PLN q) { return new EUR((EUR.Factor / PLN.Factor) * q.m_value); }
        public static explicit operator EUR(USD q) { return new EUR((EUR.Factor / USD.Factor) * q.m_value); }
        public static EUR From(IQuantity<decimal> q)
        {
            if (q.Family != EUR.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"EUR\"", q.GetType().Name));
            return new EUR((EUR.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<decimal> Convert(IQuantity<decimal> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<EUR>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is EUR) && Equals((EUR)obj); }
        public bool /* IEquatable<EUR> */ Equals(EUR other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<EUR>
        public static bool operator ==(EUR lhs, EUR rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(EUR lhs, EUR rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(EUR lhs, EUR rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(EUR lhs, EUR rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(EUR lhs, EUR rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(EUR lhs, EUR rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<EUR> */ CompareTo(EUR other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static EUR operator +(EUR lhs, EUR rhs) { return new EUR(lhs.m_value + rhs.m_value); }
        public static EUR operator -(EUR lhs, EUR rhs) { return new EUR(lhs.m_value - rhs.m_value); }
        public static EUR operator ++(EUR q) { return new EUR(q.m_value + decimal.One); }
        public static EUR operator --(EUR q) { return new EUR(q.m_value - decimal.One); }
        public static EUR operator -(EUR q) { return new EUR(-q.m_value); }
        public static EUR operator *(decimal lhs, EUR rhs) { return new EUR(lhs * rhs.m_value); }
        public static EUR operator *(EUR lhs, decimal rhs) { return new EUR(lhs.m_value * rhs); }
        public static EUR operator /(EUR lhs, decimal rhs) { return new EUR(lhs.m_value / rhs); }
        public static decimal operator /(EUR lhs, EUR rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(EUR.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(EUR.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? EUR.Format, m_value, EUR.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Other;
        private static readonly int s_family = 4;
        private static /*mutable*/ decimal s_factor = decimal.One;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("EUR");

        private static readonly EUR s_one = new EUR(decimal.One);
        private static readonly EUR s_zero = new EUR(decimal.Zero);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static EUR One { get { return s_one; } }
        public static EUR Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct USD : IQuantity<decimal>, IEquatable<USD>, IComparable<USD>, IFormattable
    {
        #region Fields
        internal readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        int IQuantity<decimal>.Family { get { return USD.Family; } }
        decimal IQuantity<decimal>.Factor { get { return USD.Factor; } }
        SymbolCollection IQuantity<decimal>.Symbol { get { return USD.Symbol; } }
        #endregion

        #region Constructor(s)
        public USD(decimal value)
        {
            m_value = value;
        }
        public static IQuantity<decimal> Create(decimal value)
        {
            return new USD(value);
        }
        #endregion

        #region Conversions
        public static explicit operator USD(decimal q) { return new USD(q); }
        public static explicit operator USD(EUR q) { return new USD((USD.Factor / EUR.Factor) * q.m_value); }
        public static explicit operator USD(PLN q) { return new USD((USD.Factor / PLN.Factor) * q.m_value); }
        public static USD From(IQuantity<decimal> q)
        {
            if (q.Family != USD.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"USD\"", q.GetType().Name));
            return new USD((USD.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<decimal> Convert(IQuantity<decimal> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<USD>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is USD) && Equals((USD)obj); }
        public bool /* IEquatable<USD> */ Equals(USD other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<USD>
        public static bool operator ==(USD lhs, USD rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(USD lhs, USD rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(USD lhs, USD rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(USD lhs, USD rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(USD lhs, USD rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(USD lhs, USD rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<USD> */ CompareTo(USD other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static USD operator +(USD lhs, USD rhs) { return new USD(lhs.m_value + rhs.m_value); }
        public static USD operator -(USD lhs, USD rhs) { return new USD(lhs.m_value - rhs.m_value); }
        public static USD operator ++(USD q) { return new USD(q.m_value + decimal.One); }
        public static USD operator --(USD q) { return new USD(q.m_value - decimal.One); }
        public static USD operator -(USD q) { return new USD(-q.m_value); }
        public static USD operator *(decimal lhs, USD rhs) { return new USD(lhs * rhs.m_value); }
        public static USD operator *(USD lhs, decimal rhs) { return new USD(lhs.m_value * rhs); }
        public static USD operator /(USD lhs, decimal rhs) { return new USD(lhs.m_value / rhs); }
        public static decimal operator /(USD lhs, USD rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(USD.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(USD.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? USD.Format, m_value, USD.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = EUR.Sense;
        private static readonly int s_family = EUR.Family;
        private static /*mutable*/ decimal s_factor = 1.3433m * EUR.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("USD");

        private static readonly USD s_one = new USD(decimal.One);
        private static readonly USD s_zero = new USD(decimal.Zero);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static USD One { get { return s_one; } }
        public static USD Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct PLN : IQuantity<decimal>, IEquatable<PLN>, IComparable<PLN>, IFormattable
    {
        #region Fields
        internal readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        int IQuantity<decimal>.Family { get { return PLN.Family; } }
        decimal IQuantity<decimal>.Factor { get { return PLN.Factor; } }
        SymbolCollection IQuantity<decimal>.Symbol { get { return PLN.Symbol; } }
        #endregion

        #region Constructor(s)
        public PLN(decimal value)
        {
            m_value = value;
        }
        public static IQuantity<decimal> Create(decimal value)
        {
            return new PLN(value);
        }
        #endregion

        #region Conversions
        public static explicit operator PLN(decimal q) { return new PLN(q); }
        public static explicit operator PLN(USD q) { return new PLN((PLN.Factor / USD.Factor) * q.m_value); }
        public static explicit operator PLN(EUR q) { return new PLN((PLN.Factor / EUR.Factor) * q.m_value); }
        public static PLN From(IQuantity<decimal> q)
        {
            if (q.Family != PLN.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"PLN\"", q.GetType().Name));
            return new PLN((PLN.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<decimal> Convert(IQuantity<decimal> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<PLN>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is PLN) && Equals((PLN)obj); }
        public bool /* IEquatable<PLN> */ Equals(PLN other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<PLN>
        public static bool operator ==(PLN lhs, PLN rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(PLN lhs, PLN rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(PLN lhs, PLN rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(PLN lhs, PLN rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(PLN lhs, PLN rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(PLN lhs, PLN rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<PLN> */ CompareTo(PLN other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static PLN operator +(PLN lhs, PLN rhs) { return new PLN(lhs.m_value + rhs.m_value); }
        public static PLN operator -(PLN lhs, PLN rhs) { return new PLN(lhs.m_value - rhs.m_value); }
        public static PLN operator ++(PLN q) { return new PLN(q.m_value + decimal.One); }
        public static PLN operator --(PLN q) { return new PLN(q.m_value - decimal.One); }
        public static PLN operator -(PLN q) { return new PLN(-q.m_value); }
        public static PLN operator *(decimal lhs, PLN rhs) { return new PLN(lhs * rhs.m_value); }
        public static PLN operator *(PLN lhs, decimal rhs) { return new PLN(lhs.m_value * rhs); }
        public static PLN operator /(PLN lhs, decimal rhs) { return new PLN(lhs.m_value / rhs); }
        public static decimal operator /(PLN lhs, PLN rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(PLN.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(PLN.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? PLN.Format, m_value, PLN.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = EUR.Sense;
        private static readonly int s_family = EUR.Family;
        private static /*mutable*/ decimal s_factor = 4.1437m * EUR.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("PLN");

        private static readonly PLN s_one = new PLN(decimal.One);
        private static readonly PLN s_zero = new PLN(decimal.Zero);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static PLN One { get { return s_one; } }
        public static PLN Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Radian : IQuantity<double>, IEquatable<Radian>, IComparable<Radian>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Radian.Family; } }
        double IQuantity<double>.Factor { get { return Radian.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Radian.Symbol; } }
        #endregion

        #region Constructor(s)
        public Radian(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Radian(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Radian(double q) { return new Radian(q); }
        public static explicit operator Radian(Cycles q) { return new Radian((Radian.Factor / Cycles.Factor) * q.m_value); }
        public static explicit operator Radian(Degree q) { return new Radian((Radian.Factor / Degree.Factor) * q.m_value); }
        public static Radian From(IQuantity<double> q)
        {
            if (q.Family != Radian.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Radian\"", q.GetType().Name));
            return new Radian((Radian.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Radian>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Radian) && Equals((Radian)obj); }
        public bool /* IEquatable<Radian> */ Equals(Radian other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Radian>
        public static bool operator ==(Radian lhs, Radian rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Radian lhs, Radian rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Radian lhs, Radian rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Radian lhs, Radian rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Radian lhs, Radian rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Radian lhs, Radian rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Radian> */ CompareTo(Radian other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Radian operator +(Radian lhs, Radian rhs) { return new Radian(lhs.m_value + rhs.m_value); }
        public static Radian operator -(Radian lhs, Radian rhs) { return new Radian(lhs.m_value - rhs.m_value); }
        public static Radian operator ++(Radian q) { return new Radian(q.m_value + 1d); }
        public static Radian operator --(Radian q) { return new Radian(q.m_value - 1d); }
        public static Radian operator -(Radian q) { return new Radian(-q.m_value); }
        public static Radian operator *(double lhs, Radian rhs) { return new Radian(lhs * rhs.m_value); }
        public static Radian operator *(Radian lhs, double rhs) { return new Radian(lhs.m_value * rhs); }
        public static Radian operator /(Radian lhs, double rhs) { return new Radian(lhs.m_value / rhs); }
        public static double operator /(Radian lhs, Radian rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Radian.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Radian.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Radian.Format, m_value, Radian.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.None;
        private static readonly int s_family = 5;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("rad");

        private static readonly Radian s_one = new Radian(1d);
        private static readonly Radian s_zero = new Radian(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Radian One { get { return s_one; } }
        public static Radian Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Degree : IQuantity<double>, IEquatable<Degree>, IComparable<Degree>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Degree.Family; } }
        double IQuantity<double>.Factor { get { return Degree.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Degree.Symbol; } }
        #endregion

        #region Constructor(s)
        public Degree(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Degree(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Degree(double q) { return new Degree(q); }
        public static explicit operator Degree(Radian q) { return new Degree((Degree.Factor / Radian.Factor) * q.m_value); }
        public static explicit operator Degree(Cycles q) { return new Degree((Degree.Factor / Cycles.Factor) * q.m_value); }
        public static Degree From(IQuantity<double> q)
        {
            if (q.Family != Degree.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Degree\"", q.GetType().Name));
            return new Degree((Degree.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Degree>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Degree) && Equals((Degree)obj); }
        public bool /* IEquatable<Degree> */ Equals(Degree other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Degree>
        public static bool operator ==(Degree lhs, Degree rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Degree lhs, Degree rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Degree lhs, Degree rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Degree lhs, Degree rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Degree lhs, Degree rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Degree lhs, Degree rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Degree> */ CompareTo(Degree other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Degree operator +(Degree lhs, Degree rhs) { return new Degree(lhs.m_value + rhs.m_value); }
        public static Degree operator -(Degree lhs, Degree rhs) { return new Degree(lhs.m_value - rhs.m_value); }
        public static Degree operator ++(Degree q) { return new Degree(q.m_value + 1d); }
        public static Degree operator --(Degree q) { return new Degree(q.m_value - 1d); }
        public static Degree operator -(Degree q) { return new Degree(-q.m_value); }
        public static Degree operator *(double lhs, Degree rhs) { return new Degree(lhs * rhs.m_value); }
        public static Degree operator *(Degree lhs, double rhs) { return new Degree(lhs.m_value * rhs); }
        public static Degree operator /(Degree lhs, double rhs) { return new Degree(lhs.m_value / rhs); }
        public static double operator /(Degree lhs, Degree rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Degree.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Degree.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Degree.Format, m_value, Degree.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Radian.Sense;
        private static readonly int s_family = Radian.Family;
        private static /*mutable*/ double s_factor = (180d / Math.PI) * Radian.Factor;
        private static /*mutable*/ string s_format = "{0}{1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u00B0", "deg");

        private static readonly Degree s_one = new Degree(1d);
        private static readonly Degree s_zero = new Degree(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Degree One { get { return s_one; } }
        public static Degree Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Cycles : IQuantity<double>, IEquatable<Cycles>, IComparable<Cycles>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Cycles.Family; } }
        double IQuantity<double>.Factor { get { return Cycles.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Cycles.Symbol; } }
        #endregion

        #region Constructor(s)
        public Cycles(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Cycles(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Cycles(double q) { return new Cycles(q); }
        public static explicit operator Cycles(Degree q) { return new Cycles((Cycles.Factor / Degree.Factor) * q.m_value); }
        public static explicit operator Cycles(Radian q) { return new Cycles((Cycles.Factor / Radian.Factor) * q.m_value); }
        public static Cycles From(IQuantity<double> q)
        {
            if (q.Family != Cycles.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Cycles\"", q.GetType().Name));
            return new Cycles((Cycles.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Cycles>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Cycles) && Equals((Cycles)obj); }
        public bool /* IEquatable<Cycles> */ Equals(Cycles other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Cycles>
        public static bool operator ==(Cycles lhs, Cycles rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Cycles lhs, Cycles rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Cycles lhs, Cycles rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Cycles lhs, Cycles rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Cycles lhs, Cycles rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Cycles lhs, Cycles rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Cycles> */ CompareTo(Cycles other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Cycles operator +(Cycles lhs, Cycles rhs) { return new Cycles(lhs.m_value + rhs.m_value); }
        public static Cycles operator -(Cycles lhs, Cycles rhs) { return new Cycles(lhs.m_value - rhs.m_value); }
        public static Cycles operator ++(Cycles q) { return new Cycles(q.m_value + 1d); }
        public static Cycles operator --(Cycles q) { return new Cycles(q.m_value - 1d); }
        public static Cycles operator -(Cycles q) { return new Cycles(-q.m_value); }
        public static Cycles operator *(double lhs, Cycles rhs) { return new Cycles(lhs * rhs.m_value); }
        public static Cycles operator *(Cycles lhs, double rhs) { return new Cycles(lhs.m_value * rhs); }
        public static Cycles operator /(Cycles lhs, double rhs) { return new Cycles(lhs.m_value / rhs); }
        public static double operator /(Cycles lhs, Cycles rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Hertz operator /(Cycles lhs, Second rhs) { return new Hertz(lhs.m_value / rhs.m_value); }
        public static Second operator /(Cycles lhs, Hertz rhs) { return new Second(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Cycles.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Cycles.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Cycles.Format, m_value, Cycles.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Radian.Sense;
        private static readonly int s_family = Radian.Family;
        private static /*mutable*/ double s_factor = Radian.Factor / (2d * Math.PI);
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("c");

        private static readonly Cycles s_one = new Cycles(1d);
        private static readonly Cycles s_zero = new Cycles(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Cycles One { get { return s_one; } }
        public static Cycles Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Hertz : IQuantity<double>, IEquatable<Hertz>, IComparable<Hertz>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Hertz.Family; } }
        double IQuantity<double>.Factor { get { return Hertz.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Hertz.Symbol; } }
        #endregion

        #region Constructor(s)
        public Hertz(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Hertz(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Hertz(double q) { return new Hertz(q); }
        public static Hertz From(IQuantity<double> q)
        {
            if (q.Family != Hertz.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Hertz\"", q.GetType().Name));
            return new Hertz((Hertz.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Hertz>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Hertz) && Equals((Hertz)obj); }
        public bool /* IEquatable<Hertz> */ Equals(Hertz other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Hertz>
        public static bool operator ==(Hertz lhs, Hertz rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Hertz lhs, Hertz rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Hertz lhs, Hertz rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Hertz lhs, Hertz rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Hertz lhs, Hertz rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Hertz lhs, Hertz rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Hertz> */ CompareTo(Hertz other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Hertz operator +(Hertz lhs, Hertz rhs) { return new Hertz(lhs.m_value + rhs.m_value); }
        public static Hertz operator -(Hertz lhs, Hertz rhs) { return new Hertz(lhs.m_value - rhs.m_value); }
        public static Hertz operator ++(Hertz q) { return new Hertz(q.m_value + 1d); }
        public static Hertz operator --(Hertz q) { return new Hertz(q.m_value - 1d); }
        public static Hertz operator -(Hertz q) { return new Hertz(-q.m_value); }
        public static Hertz operator *(double lhs, Hertz rhs) { return new Hertz(lhs * rhs.m_value); }
        public static Hertz operator *(Hertz lhs, double rhs) { return new Hertz(lhs.m_value * rhs); }
        public static Hertz operator /(Hertz lhs, double rhs) { return new Hertz(lhs.m_value / rhs); }
        public static double operator /(Hertz lhs, Hertz rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Cycles operator *(Hertz lhs, Second rhs) { return new Cycles(lhs.m_value * rhs.m_value); }
        public static Cycles operator *(Second lhs, Hertz rhs) { return new Cycles(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Hertz.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Hertz.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Hertz.Format, m_value, Hertz.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Cycles.Sense / Second.Sense;
        private static readonly int s_family = 6;
        private static /*mutable*/ double s_factor = Cycles.Factor / Second.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("Hz");

        private static readonly Hertz s_one = new Hertz(1d);
        private static readonly Hertz s_zero = new Hertz(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Hertz One { get { return s_one; } }
        public static Hertz Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct SquareMeter : IQuantity<double>, IEquatable<SquareMeter>, IComparable<SquareMeter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return SquareMeter.Family; } }
        double IQuantity<double>.Factor { get { return SquareMeter.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return SquareMeter.Symbol; } }
        #endregion

        #region Constructor(s)
        public SquareMeter(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new SquareMeter(value);
        }
        #endregion

        #region Conversions
        public static explicit operator SquareMeter(double q) { return new SquareMeter(q); }
        public static SquareMeter From(IQuantity<double> q)
        {
            if (q.Family != SquareMeter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"SquareMeter\"", q.GetType().Name));
            return new SquareMeter((SquareMeter.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<SquareMeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is SquareMeter) && Equals((SquareMeter)obj); }
        public bool /* IEquatable<SquareMeter> */ Equals(SquareMeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<SquareMeter>
        public static bool operator ==(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<SquareMeter> */ CompareTo(SquareMeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static SquareMeter operator +(SquareMeter lhs, SquareMeter rhs) { return new SquareMeter(lhs.m_value + rhs.m_value); }
        public static SquareMeter operator -(SquareMeter lhs, SquareMeter rhs) { return new SquareMeter(lhs.m_value - rhs.m_value); }
        public static SquareMeter operator ++(SquareMeter q) { return new SquareMeter(q.m_value + 1d); }
        public static SquareMeter operator --(SquareMeter q) { return new SquareMeter(q.m_value - 1d); }
        public static SquareMeter operator -(SquareMeter q) { return new SquareMeter(-q.m_value); }
        public static SquareMeter operator *(double lhs, SquareMeter rhs) { return new SquareMeter(lhs * rhs.m_value); }
        public static SquareMeter operator *(SquareMeter lhs, double rhs) { return new SquareMeter(lhs.m_value * rhs); }
        public static SquareMeter operator /(SquareMeter lhs, double rhs) { return new SquareMeter(lhs.m_value / rhs); }
        public static double operator /(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator /(SquareMeter lhs, Meter rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(SquareMeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(SquareMeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? SquareMeter.Format, m_value, SquareMeter.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense * Meter.Sense;
        private static readonly int s_family = 7;
        private static /*mutable*/ double s_factor = Meter.Factor * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m\u00B2", "m2");

        private static readonly SquareMeter s_one = new SquareMeter(1d);
        private static readonly SquareMeter s_zero = new SquareMeter(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static SquareMeter One { get { return s_one; } }
        public static SquareMeter Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Meter_Sec : IQuantity<double>, IEquatable<Meter_Sec>, IComparable<Meter_Sec>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Meter_Sec.Family; } }
        double IQuantity<double>.Factor { get { return Meter_Sec.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Meter_Sec.Symbol; } }
        #endregion

        #region Constructor(s)
        public Meter_Sec(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Meter_Sec(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Meter_Sec(double q) { return new Meter_Sec(q); }
        public static Meter_Sec From(IQuantity<double> q)
        {
            if (q.Family != Meter_Sec.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Meter_Sec\"", q.GetType().Name));
            return new Meter_Sec((Meter_Sec.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Meter_Sec>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter_Sec) && Equals((Meter_Sec)obj); }
        public bool /* IEquatable<Meter_Sec> */ Equals(Meter_Sec other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Meter_Sec>
        public static bool operator ==(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Meter_Sec> */ CompareTo(Meter_Sec other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter_Sec operator +(Meter_Sec lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.m_value + rhs.m_value); }
        public static Meter_Sec operator -(Meter_Sec lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.m_value - rhs.m_value); }
        public static Meter_Sec operator ++(Meter_Sec q) { return new Meter_Sec(q.m_value + 1d); }
        public static Meter_Sec operator --(Meter_Sec q) { return new Meter_Sec(q.m_value - 1d); }
        public static Meter_Sec operator -(Meter_Sec q) { return new Meter_Sec(-q.m_value); }
        public static Meter_Sec operator *(double lhs, Meter_Sec rhs) { return new Meter_Sec(lhs * rhs.m_value); }
        public static Meter_Sec operator *(Meter_Sec lhs, double rhs) { return new Meter_Sec(lhs.m_value * rhs); }
        public static Meter_Sec operator /(Meter_Sec lhs, double rhs) { return new Meter_Sec(lhs.m_value / rhs); }
        public static double operator /(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator *(Meter_Sec lhs, Second rhs) { return new Meter(lhs.m_value * rhs.m_value); }
        public static Meter operator *(Second lhs, Meter_Sec rhs) { return new Meter(lhs.m_value * rhs.m_value); }
        public static Meter_Sec2 operator /(Meter_Sec lhs, Second rhs) { return new Meter_Sec2(lhs.m_value / rhs.m_value); }
        public static Second operator /(Meter_Sec lhs, Meter_Sec2 rhs) { return new Second(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter_Sec.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter_Sec.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Meter_Sec.Format, m_value, Meter_Sec.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense / Second.Sense;
        private static readonly int s_family = 8;
        private static /*mutable*/ double s_factor = Meter.Factor / Second.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m/s");

        private static readonly Meter_Sec s_one = new Meter_Sec(1d);
        private static readonly Meter_Sec s_zero = new Meter_Sec(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Meter_Sec One { get { return s_one; } }
        public static Meter_Sec Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Meter_Sec2 : IQuantity<double>, IEquatable<Meter_Sec2>, IComparable<Meter_Sec2>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Meter_Sec2.Family; } }
        double IQuantity<double>.Factor { get { return Meter_Sec2.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Meter_Sec2.Symbol; } }
        #endregion

        #region Constructor(s)
        public Meter_Sec2(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Meter_Sec2(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Meter_Sec2(double q) { return new Meter_Sec2(q); }
        public static Meter_Sec2 From(IQuantity<double> q)
        {
            if (q.Family != Meter_Sec2.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Meter_Sec2\"", q.GetType().Name));
            return new Meter_Sec2((Meter_Sec2.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Meter_Sec2>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter_Sec2) && Equals((Meter_Sec2)obj); }
        public bool /* IEquatable<Meter_Sec2> */ Equals(Meter_Sec2 other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Meter_Sec2>
        public static bool operator ==(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Meter_Sec2> */ CompareTo(Meter_Sec2 other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter_Sec2 operator +(Meter_Sec2 lhs, Meter_Sec2 rhs) { return new Meter_Sec2(lhs.m_value + rhs.m_value); }
        public static Meter_Sec2 operator -(Meter_Sec2 lhs, Meter_Sec2 rhs) { return new Meter_Sec2(lhs.m_value - rhs.m_value); }
        public static Meter_Sec2 operator ++(Meter_Sec2 q) { return new Meter_Sec2(q.m_value + 1d); }
        public static Meter_Sec2 operator --(Meter_Sec2 q) { return new Meter_Sec2(q.m_value - 1d); }
        public static Meter_Sec2 operator -(Meter_Sec2 q) { return new Meter_Sec2(-q.m_value); }
        public static Meter_Sec2 operator *(double lhs, Meter_Sec2 rhs) { return new Meter_Sec2(lhs * rhs.m_value); }
        public static Meter_Sec2 operator *(Meter_Sec2 lhs, double rhs) { return new Meter_Sec2(lhs.m_value * rhs); }
        public static Meter_Sec2 operator /(Meter_Sec2 lhs, double rhs) { return new Meter_Sec2(lhs.m_value / rhs); }
        public static double operator /(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter_Sec operator *(Meter_Sec2 lhs, Second rhs) { return new Meter_Sec(lhs.m_value * rhs.m_value); }
        public static Meter_Sec operator *(Second lhs, Meter_Sec2 rhs) { return new Meter_Sec(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter_Sec2.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter_Sec2.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Meter_Sec2.Format, m_value, Meter_Sec2.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter_Sec.Sense / Second.Sense;
        private static readonly int s_family = 9;
        private static /*mutable*/ double s_factor = Meter_Sec.Factor / Second.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m/s2");

        private static readonly Meter_Sec2 s_one = new Meter_Sec2(1d);
        private static readonly Meter_Sec2 s_zero = new Meter_Sec2(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Meter_Sec2 One { get { return s_one; } }
        public static Meter_Sec2 Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Newton : IQuantity<double>, IEquatable<Newton>, IComparable<Newton>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Newton.Family; } }
        double IQuantity<double>.Factor { get { return Newton.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Newton.Symbol; } }
        #endregion

        #region Constructor(s)
        public Newton(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Newton(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Newton(double q) { return new Newton(q); }
        public static Newton From(IQuantity<double> q)
        {
            if (q.Family != Newton.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Newton\"", q.GetType().Name));
            return new Newton((Newton.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Newton>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Newton) && Equals((Newton)obj); }
        public bool /* IEquatable<Newton> */ Equals(Newton other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Newton>
        public static bool operator ==(Newton lhs, Newton rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Newton lhs, Newton rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Newton lhs, Newton rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Newton lhs, Newton rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Newton lhs, Newton rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Newton lhs, Newton rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Newton> */ CompareTo(Newton other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Newton operator +(Newton lhs, Newton rhs) { return new Newton(lhs.m_value + rhs.m_value); }
        public static Newton operator -(Newton lhs, Newton rhs) { return new Newton(lhs.m_value - rhs.m_value); }
        public static Newton operator ++(Newton q) { return new Newton(q.m_value + 1d); }
        public static Newton operator --(Newton q) { return new Newton(q.m_value - 1d); }
        public static Newton operator -(Newton q) { return new Newton(-q.m_value); }
        public static Newton operator *(double lhs, Newton rhs) { return new Newton(lhs * rhs.m_value); }
        public static Newton operator *(Newton lhs, double rhs) { return new Newton(lhs.m_value * rhs); }
        public static Newton operator /(Newton lhs, double rhs) { return new Newton(lhs.m_value / rhs); }
        public static double operator /(Newton lhs, Newton rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter_Sec2 operator /(Newton lhs, Kilogram rhs) { return new Meter_Sec2(lhs.m_value / rhs.m_value); }
        public static Kilogram operator /(Newton lhs, Meter_Sec2 rhs) { return new Kilogram(lhs.m_value / rhs.m_value); }
        public static Joule operator *(Newton lhs, Meter rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule operator *(Meter lhs, Newton rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static NewtonMeter operator ^(Newton lhs, Meter rhs) { return new NewtonMeter(lhs.m_value * rhs.m_value); }
        public static NewtonMeter operator ^(Meter lhs, Newton rhs) { return new NewtonMeter(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Newton.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Newton.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Newton.Format, m_value, Newton.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense * Meter_Sec2.Sense;
        private static readonly int s_family = 10;
        private static /*mutable*/ double s_factor = Kilogram.Factor * Meter_Sec2.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("N");

        private static readonly Newton s_one = new Newton(1d);
        private static readonly Newton s_zero = new Newton(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Newton One { get { return s_one; } }
        public static Newton Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Joule : IQuantity<double>, IEquatable<Joule>, IComparable<Joule>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Joule.Family; } }
        double IQuantity<double>.Factor { get { return Joule.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Joule.Symbol; } }
        #endregion

        #region Constructor(s)
        public Joule(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Joule(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Joule(double q) { return new Joule(q); }
        public static Joule From(IQuantity<double> q)
        {
            if (q.Family != Joule.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Joule\"", q.GetType().Name));
            return new Joule((Joule.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Joule>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Joule) && Equals((Joule)obj); }
        public bool /* IEquatable<Joule> */ Equals(Joule other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Joule>
        public static bool operator ==(Joule lhs, Joule rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Joule lhs, Joule rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Joule lhs, Joule rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Joule lhs, Joule rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Joule lhs, Joule rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Joule lhs, Joule rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Joule> */ CompareTo(Joule other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule operator +(Joule lhs, Joule rhs) { return new Joule(lhs.m_value + rhs.m_value); }
        public static Joule operator -(Joule lhs, Joule rhs) { return new Joule(lhs.m_value - rhs.m_value); }
        public static Joule operator ++(Joule q) { return new Joule(q.m_value + 1d); }
        public static Joule operator --(Joule q) { return new Joule(q.m_value - 1d); }
        public static Joule operator -(Joule q) { return new Joule(-q.m_value); }
        public static Joule operator *(double lhs, Joule rhs) { return new Joule(lhs * rhs.m_value); }
        public static Joule operator *(Joule lhs, double rhs) { return new Joule(lhs.m_value * rhs); }
        public static Joule operator /(Joule lhs, double rhs) { return new Joule(lhs.m_value / rhs); }
        public static double operator /(Joule lhs, Joule rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator /(Joule lhs, Newton rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        public static Newton operator /(Joule lhs, Meter rhs) { return new Newton(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Joule.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Joule.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Joule.Format, m_value, Joule.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense * Meter.Sense;
        private static readonly int s_family = 11;
        private static /*mutable*/ double s_factor = Newton.Factor * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("J");

        private static readonly Joule s_one = new Joule(1d);
        private static readonly Joule s_zero = new Joule(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Joule One { get { return s_one; } }
        public static Joule Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct NewtonMeter : IQuantity<double>, IEquatable<NewtonMeter>, IComparable<NewtonMeter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return NewtonMeter.Family; } }
        double IQuantity<double>.Factor { get { return NewtonMeter.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return NewtonMeter.Symbol; } }
        #endregion

        #region Constructor(s)
        public NewtonMeter(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new NewtonMeter(value);
        }
        #endregion

        #region Conversions
        public static explicit operator NewtonMeter(double q) { return new NewtonMeter(q); }
        public static NewtonMeter From(IQuantity<double> q)
        {
            if (q.Family != NewtonMeter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"NewtonMeter\"", q.GetType().Name));
            return new NewtonMeter((NewtonMeter.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<NewtonMeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is NewtonMeter) && Equals((NewtonMeter)obj); }
        public bool /* IEquatable<NewtonMeter> */ Equals(NewtonMeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<NewtonMeter>
        public static bool operator ==(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<NewtonMeter> */ CompareTo(NewtonMeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static NewtonMeter operator +(NewtonMeter lhs, NewtonMeter rhs) { return new NewtonMeter(lhs.m_value + rhs.m_value); }
        public static NewtonMeter operator -(NewtonMeter lhs, NewtonMeter rhs) { return new NewtonMeter(lhs.m_value - rhs.m_value); }
        public static NewtonMeter operator ++(NewtonMeter q) { return new NewtonMeter(q.m_value + 1d); }
        public static NewtonMeter operator --(NewtonMeter q) { return new NewtonMeter(q.m_value - 1d); }
        public static NewtonMeter operator -(NewtonMeter q) { return new NewtonMeter(-q.m_value); }
        public static NewtonMeter operator *(double lhs, NewtonMeter rhs) { return new NewtonMeter(lhs * rhs.m_value); }
        public static NewtonMeter operator *(NewtonMeter lhs, double rhs) { return new NewtonMeter(lhs.m_value * rhs); }
        public static NewtonMeter operator /(NewtonMeter lhs, double rhs) { return new NewtonMeter(lhs.m_value / rhs); }
        public static double operator /(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator /(NewtonMeter lhs, Newton rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        public static Newton operator /(NewtonMeter lhs, Meter rhs) { return new Newton(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(NewtonMeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(NewtonMeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? NewtonMeter.Format, m_value, NewtonMeter.Symbol.Default);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense * Meter.Sense;
        private static readonly int s_family = 12;
        private static /*mutable*/ double s_factor = Newton.Factor * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("N\u00B7m", "N*m");

        private static readonly NewtonMeter s_one = new NewtonMeter(1d);
        private static readonly NewtonMeter s_zero = new NewtonMeter(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static NewtonMeter One { get { return s_one; } }
        public static NewtonMeter Zero { get { return s_zero; } }
        #endregion
    }
    [ScaleReferencePoint("AbsoluteZero")]
    public partial struct Kelvin : ILevel<double>, IEquatable<Kelvin>, IComparable<Kelvin>, IFormattable
    {
        #region Fields
        internal readonly DegKelvin m_level;
        #endregion

        #region Properties
        public DegKelvin Level { get { return m_level; } }
        public DegKelvin NormalizedLevel { get { return (m_level - Kelvin.Offset); } }

        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
        int ILevel<double>.Family { get { return Kelvin.Family; } }
        SymbolCollection ILevel<double>.Symbol { get { return DegKelvin.Symbol; } }
        #endregion

        #region Constructor(s)
        public Kelvin(DegKelvin level)
        {
            m_level = level;
        }
        public Kelvin(double level) :
            this(new DegKelvin(level))
        {
        }
        public static ILevel<double> Create(double level)
        {
            return new Kelvin(level);
        }
        #endregion

        #region Conversions
        public static explicit operator Kelvin(double q) { return new Kelvin(q); }
        public static explicit operator Kelvin(DegKelvin q) { return new Kelvin(q); }

        public static explicit operator Kelvin(Fahrenheit q) { return new Kelvin((DegKelvin)(q.NormalizedLevel) + Kelvin.Offset); }
        public static explicit operator Kelvin(Rankine q) { return new Kelvin((DegKelvin)(q.NormalizedLevel) + Kelvin.Offset); }
        public static explicit operator Kelvin(Celsius q) { return new Kelvin((DegKelvin)(q.NormalizedLevel) + Kelvin.Offset); }

        public static Kelvin From(ILevel<double> q)
        {
            if (q.Family != Kelvin.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kelvin\"", q.GetType().Name));
            return new Kelvin(DegKelvin.From(q.NormalizedLevel) + Kelvin.Offset);
        }
        public static ILevel<double> Convert(ILevel<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Kelvin>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Kelvin) && Equals((Kelvin)obj); }
        public bool /* IEquatable<Kelvin> */ Equals(Kelvin other) { return this.m_level == other.m_level; }
        #endregion

        #region Comparison / IComparable<Kelvin>
        public static bool operator ==(Kelvin lhs, Kelvin rhs) { return lhs.m_level == rhs.m_level; }
        public static bool operator !=(Kelvin lhs, Kelvin rhs) { return lhs.m_level != rhs.m_level; }
        public static bool operator <(Kelvin lhs, Kelvin rhs) { return lhs.m_level < rhs.m_level; }
        public static bool operator >(Kelvin lhs, Kelvin rhs) { return lhs.m_level > rhs.m_level; }
        public static bool operator <=(Kelvin lhs, Kelvin rhs) { return lhs.m_level <= rhs.m_level; }
        public static bool operator >=(Kelvin lhs, Kelvin rhs) { return lhs.m_level >= rhs.m_level; }
        public int /* IComparable<Kelvin> */ CompareTo(Kelvin other) { return this.m_level.CompareTo(other.m_level); }
        #endregion

        #region Arithmetic
        public static Kelvin operator +(Kelvin lhs, DegKelvin rhs) { return new Kelvin(lhs.m_level + rhs); }
        public static Kelvin operator +(DegKelvin lhs, Kelvin rhs) { return new Kelvin(lhs + rhs.m_level); }
        public static Kelvin operator -(Kelvin lhs, DegKelvin rhs) { return new Kelvin(lhs.m_level - rhs); }
        public static DegKelvin operator -(Kelvin lhs, Kelvin rhs) { return (lhs.m_level - rhs.m_level); }
        public static Kelvin operator -(Kelvin q) { return new Kelvin(-q.m_level); }
        public static Kelvin operator ++(Kelvin q) { return q + DegKelvin.One; }
        public static Kelvin operator --(Kelvin q) { return q - DegKelvin.One; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Kelvin.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Kelvin.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return m_level.ToString(format ?? Kelvin.Format, fp);
        }
        #endregion

        #region Statics
        private static readonly DegKelvin s_offset = new DegKelvin(0d);  // offset to AbsoluteZero
        private static readonly int s_family = 13;
        private static /*mutable*/ string s_format = "{0} {1}";

        private static readonly Kelvin s_zero = new Kelvin(0d);
        
        public static DegKelvin Offset { get { return s_offset; } }
        public static int Family { get { return s_family; } }
        public static string Format { get { return s_format; } set { s_format = value; } }

        public static Kelvin Zero { get { return s_zero; } }
        #endregion
    }
    [ScaleReferencePoint("AbsoluteZero")]
    public partial struct Celsius : ILevel<double>, IEquatable<Celsius>, IComparable<Celsius>, IFormattable
    {
        #region Fields
        internal readonly DegCelsius m_level;
        #endregion

        #region Properties
        public DegCelsius Level { get { return m_level; } }
        public DegCelsius NormalizedLevel { get { return (m_level - Celsius.Offset); } }

        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
        int ILevel<double>.Family { get { return Celsius.Family; } }
        SymbolCollection ILevel<double>.Symbol { get { return DegCelsius.Symbol; } }
        #endregion

        #region Constructor(s)
        public Celsius(DegCelsius level)
        {
            m_level = level;
        }
        public Celsius(double level) :
            this(new DegCelsius(level))
        {
        }
        public static ILevel<double> Create(double level)
        {
            return new Celsius(level);
        }
        #endregion

        #region Conversions
        public static explicit operator Celsius(double q) { return new Celsius(q); }
        public static explicit operator Celsius(DegCelsius q) { return new Celsius(q); }

        public static explicit operator Celsius(Kelvin q) { return new Celsius((DegCelsius)(q.NormalizedLevel) + Celsius.Offset); }
        public static explicit operator Celsius(Fahrenheit q) { return new Celsius((DegCelsius)(q.NormalizedLevel) + Celsius.Offset); }
        public static explicit operator Celsius(Rankine q) { return new Celsius((DegCelsius)(q.NormalizedLevel) + Celsius.Offset); }

        public static Celsius From(ILevel<double> q)
        {
            if (q.Family != Celsius.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Celsius\"", q.GetType().Name));
            return new Celsius(DegCelsius.From(q.NormalizedLevel) + Celsius.Offset);
        }
        public static ILevel<double> Convert(ILevel<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Celsius>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Celsius) && Equals((Celsius)obj); }
        public bool /* IEquatable<Celsius> */ Equals(Celsius other) { return this.m_level == other.m_level; }
        #endregion

        #region Comparison / IComparable<Celsius>
        public static bool operator ==(Celsius lhs, Celsius rhs) { return lhs.m_level == rhs.m_level; }
        public static bool operator !=(Celsius lhs, Celsius rhs) { return lhs.m_level != rhs.m_level; }
        public static bool operator <(Celsius lhs, Celsius rhs) { return lhs.m_level < rhs.m_level; }
        public static bool operator >(Celsius lhs, Celsius rhs) { return lhs.m_level > rhs.m_level; }
        public static bool operator <=(Celsius lhs, Celsius rhs) { return lhs.m_level <= rhs.m_level; }
        public static bool operator >=(Celsius lhs, Celsius rhs) { return lhs.m_level >= rhs.m_level; }
        public int /* IComparable<Celsius> */ CompareTo(Celsius other) { return this.m_level.CompareTo(other.m_level); }
        #endregion

        #region Arithmetic
        public static Celsius operator +(Celsius lhs, DegCelsius rhs) { return new Celsius(lhs.m_level + rhs); }
        public static Celsius operator +(DegCelsius lhs, Celsius rhs) { return new Celsius(lhs + rhs.m_level); }
        public static Celsius operator -(Celsius lhs, DegCelsius rhs) { return new Celsius(lhs.m_level - rhs); }
        public static DegCelsius operator -(Celsius lhs, Celsius rhs) { return (lhs.m_level - rhs.m_level); }
        public static Celsius operator -(Celsius q) { return new Celsius(-q.m_level); }
        public static Celsius operator ++(Celsius q) { return q + DegCelsius.One; }
        public static Celsius operator --(Celsius q) { return q - DegCelsius.One; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Celsius.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Celsius.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return m_level.ToString(format ?? Celsius.Format, fp);
        }
        #endregion

        #region Statics
        private static readonly DegCelsius s_offset = new DegCelsius(-273.15d);  // offset to AbsoluteZero
        private static readonly int s_family = Kelvin.Family;
        private static /*mutable*/ string s_format = "{0} {1}";

        private static readonly Celsius s_zero = new Celsius(0d);
        
        public static DegCelsius Offset { get { return s_offset; } }
        public static int Family { get { return s_family; } }
        public static string Format { get { return s_format; } set { s_format = value; } }

        public static Celsius Zero { get { return s_zero; } }
        #endregion
    }
    [ScaleReferencePoint("AbsoluteZero")]
    public partial struct Rankine : ILevel<double>, IEquatable<Rankine>, IComparable<Rankine>, IFormattable
    {
        #region Fields
        internal readonly DegRankine m_level;
        #endregion

        #region Properties
        public DegRankine Level { get { return m_level; } }
        public DegRankine NormalizedLevel { get { return (m_level - Rankine.Offset); } }

        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
        int ILevel<double>.Family { get { return Rankine.Family; } }
        SymbolCollection ILevel<double>.Symbol { get { return DegRankine.Symbol; } }
        #endregion

        #region Constructor(s)
        public Rankine(DegRankine level)
        {
            m_level = level;
        }
        public Rankine(double level) :
            this(new DegRankine(level))
        {
        }
        public static ILevel<double> Create(double level)
        {
            return new Rankine(level);
        }
        #endregion

        #region Conversions
        public static explicit operator Rankine(double q) { return new Rankine(q); }
        public static explicit operator Rankine(DegRankine q) { return new Rankine(q); }

        public static explicit operator Rankine(Celsius q) { return new Rankine((DegRankine)(q.NormalizedLevel) + Rankine.Offset); }
        public static explicit operator Rankine(Kelvin q) { return new Rankine((DegRankine)(q.NormalizedLevel) + Rankine.Offset); }
        public static explicit operator Rankine(Fahrenheit q) { return new Rankine((DegRankine)(q.NormalizedLevel) + Rankine.Offset); }

        public static Rankine From(ILevel<double> q)
        {
            if (q.Family != Rankine.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Rankine\"", q.GetType().Name));
            return new Rankine(DegRankine.From(q.NormalizedLevel) + Rankine.Offset);
        }
        public static ILevel<double> Convert(ILevel<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Rankine>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Rankine) && Equals((Rankine)obj); }
        public bool /* IEquatable<Rankine> */ Equals(Rankine other) { return this.m_level == other.m_level; }
        #endregion

        #region Comparison / IComparable<Rankine>
        public static bool operator ==(Rankine lhs, Rankine rhs) { return lhs.m_level == rhs.m_level; }
        public static bool operator !=(Rankine lhs, Rankine rhs) { return lhs.m_level != rhs.m_level; }
        public static bool operator <(Rankine lhs, Rankine rhs) { return lhs.m_level < rhs.m_level; }
        public static bool operator >(Rankine lhs, Rankine rhs) { return lhs.m_level > rhs.m_level; }
        public static bool operator <=(Rankine lhs, Rankine rhs) { return lhs.m_level <= rhs.m_level; }
        public static bool operator >=(Rankine lhs, Rankine rhs) { return lhs.m_level >= rhs.m_level; }
        public int /* IComparable<Rankine> */ CompareTo(Rankine other) { return this.m_level.CompareTo(other.m_level); }
        #endregion

        #region Arithmetic
        public static Rankine operator +(Rankine lhs, DegRankine rhs) { return new Rankine(lhs.m_level + rhs); }
        public static Rankine operator +(DegRankine lhs, Rankine rhs) { return new Rankine(lhs + rhs.m_level); }
        public static Rankine operator -(Rankine lhs, DegRankine rhs) { return new Rankine(lhs.m_level - rhs); }
        public static DegRankine operator -(Rankine lhs, Rankine rhs) { return (lhs.m_level - rhs.m_level); }
        public static Rankine operator -(Rankine q) { return new Rankine(-q.m_level); }
        public static Rankine operator ++(Rankine q) { return q + DegRankine.One; }
        public static Rankine operator --(Rankine q) { return q - DegRankine.One; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Rankine.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Rankine.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return m_level.ToString(format ?? Rankine.Format, fp);
        }
        #endregion

        #region Statics
        private static readonly DegRankine s_offset = new DegRankine(0d);  // offset to AbsoluteZero
        private static readonly int s_family = Kelvin.Family;
        private static /*mutable*/ string s_format = "{0} {1}";

        private static readonly Rankine s_zero = new Rankine(0d);
        
        public static DegRankine Offset { get { return s_offset; } }
        public static int Family { get { return s_family; } }
        public static string Format { get { return s_format; } set { s_format = value; } }

        public static Rankine Zero { get { return s_zero; } }
        #endregion
    }
    [ScaleReferencePoint("AbsoluteZero")]
    public partial struct Fahrenheit : ILevel<double>, IEquatable<Fahrenheit>, IComparable<Fahrenheit>, IFormattable
    {
        #region Fields
        internal readonly DegFahrenheit m_level;
        #endregion

        #region Properties
        public DegFahrenheit Level { get { return m_level; } }
        public DegFahrenheit NormalizedLevel { get { return (m_level - Fahrenheit.Offset); } }

        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
        int ILevel<double>.Family { get { return Fahrenheit.Family; } }
        SymbolCollection ILevel<double>.Symbol { get { return DegFahrenheit.Symbol; } }
        #endregion

        #region Constructor(s)
        public Fahrenheit(DegFahrenheit level)
        {
            m_level = level;
        }
        public Fahrenheit(double level) :
            this(new DegFahrenheit(level))
        {
        }
        public static ILevel<double> Create(double level)
        {
            return new Fahrenheit(level);
        }
        #endregion

        #region Conversions
        public static explicit operator Fahrenheit(double q) { return new Fahrenheit(q); }
        public static explicit operator Fahrenheit(DegFahrenheit q) { return new Fahrenheit(q); }

        public static explicit operator Fahrenheit(Rankine q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }
        public static explicit operator Fahrenheit(Celsius q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }
        public static explicit operator Fahrenheit(Kelvin q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }

        public static Fahrenheit From(ILevel<double> q)
        {
            if (q.Family != Fahrenheit.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Fahrenheit\"", q.GetType().Name));
            return new Fahrenheit(DegFahrenheit.From(q.NormalizedLevel) + Fahrenheit.Offset);
        }
        public static ILevel<double> Convert(ILevel<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Fahrenheit>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Fahrenheit) && Equals((Fahrenheit)obj); }
        public bool /* IEquatable<Fahrenheit> */ Equals(Fahrenheit other) { return this.m_level == other.m_level; }
        #endregion

        #region Comparison / IComparable<Fahrenheit>
        public static bool operator ==(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level == rhs.m_level; }
        public static bool operator !=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level != rhs.m_level; }
        public static bool operator <(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level < rhs.m_level; }
        public static bool operator >(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level > rhs.m_level; }
        public static bool operator <=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level <= rhs.m_level; }
        public static bool operator >=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level >= rhs.m_level; }
        public int /* IComparable<Fahrenheit> */ CompareTo(Fahrenheit other) { return this.m_level.CompareTo(other.m_level); }
        #endregion

        #region Arithmetic
        public static Fahrenheit operator +(Fahrenheit lhs, DegFahrenheit rhs) { return new Fahrenheit(lhs.m_level + rhs); }
        public static Fahrenheit operator +(DegFahrenheit lhs, Fahrenheit rhs) { return new Fahrenheit(lhs + rhs.m_level); }
        public static Fahrenheit operator -(Fahrenheit lhs, DegFahrenheit rhs) { return new Fahrenheit(lhs.m_level - rhs); }
        public static DegFahrenheit operator -(Fahrenheit lhs, Fahrenheit rhs) { return (lhs.m_level - rhs.m_level); }
        public static Fahrenheit operator -(Fahrenheit q) { return new Fahrenheit(-q.m_level); }
        public static Fahrenheit operator ++(Fahrenheit q) { return q + DegFahrenheit.One; }
        public static Fahrenheit operator --(Fahrenheit q) { return q - DegFahrenheit.One; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Fahrenheit.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Fahrenheit.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return m_level.ToString(format ?? Fahrenheit.Format, fp);
        }
        #endregion

        #region Statics
        private static readonly DegFahrenheit s_offset = new DegFahrenheit(-273.15d * (9d / 5d) + 32d);  // offset to AbsoluteZero
        private static readonly int s_family = Kelvin.Family;
        private static /*mutable*/ string s_format = "{0} {1}";

        private static readonly Fahrenheit s_zero = new Fahrenheit(0d);
        
        public static DegFahrenheit Offset { get { return s_offset; } }
        public static int Family { get { return s_family; } }
        public static string Format { get { return s_format; } set { s_format = value; } }

        public static Fahrenheit Zero { get { return s_zero; } }
        #endregion
    }
}
