/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
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
        public static explicit operator Meter(Inch q) { return new Meter((Meter.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Meter(Foot q) { return new Meter((Meter.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Meter(Yard q) { return new Meter((Meter.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Meter(Mile q) { return new Meter((Meter.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Meter(Kilometer q) { return new Meter((Meter.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Meter(Millimeter q) { return new Meter((Meter.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Meter(Centimeter q) { return new Meter((Meter.Factor / Centimeter.Factor) * q.m_value); }
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
            return string.Format(fp, format ?? Meter.Format, m_value, Meter.Symbol[0]);
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
    public partial struct Centimeter : IQuantity<double>, IEquatable<Centimeter>, IComparable<Centimeter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Centimeter.Family; } }
        double IQuantity<double>.Factor { get { return Centimeter.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Centimeter.Symbol; } }
        #endregion

        #region Constructor(s)
        public Centimeter(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Centimeter(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Centimeter(double q) { return new Centimeter(q); }
        public static explicit operator Centimeter(Meter q) { return new Centimeter((Centimeter.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Centimeter(Inch q) { return new Centimeter((Centimeter.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Centimeter(Foot q) { return new Centimeter((Centimeter.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Centimeter(Yard q) { return new Centimeter((Centimeter.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Centimeter(Mile q) { return new Centimeter((Centimeter.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Centimeter(Kilometer q) { return new Centimeter((Centimeter.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Centimeter(Millimeter q) { return new Centimeter((Centimeter.Factor / Millimeter.Factor) * q.m_value); }
        public static Centimeter From(IQuantity<double> q)
        {
            if (q.Family != Centimeter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Centimeter\"", q.GetType().Name));
            return new Centimeter((Centimeter.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Centimeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Centimeter) && Equals((Centimeter)obj); }
        public bool /* IEquatable<Centimeter> */ Equals(Centimeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Centimeter>
        public static bool operator ==(Centimeter lhs, Centimeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Centimeter lhs, Centimeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Centimeter lhs, Centimeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Centimeter lhs, Centimeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Centimeter lhs, Centimeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Centimeter lhs, Centimeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Centimeter> */ CompareTo(Centimeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Centimeter operator +(Centimeter lhs, Centimeter rhs) { return new Centimeter(lhs.m_value + rhs.m_value); }
        public static Centimeter operator -(Centimeter lhs, Centimeter rhs) { return new Centimeter(lhs.m_value - rhs.m_value); }
        public static Centimeter operator ++(Centimeter q) { return new Centimeter(q.m_value + 1d); }
        public static Centimeter operator --(Centimeter q) { return new Centimeter(q.m_value - 1d); }
        public static Centimeter operator -(Centimeter q) { return new Centimeter(-q.m_value); }
        public static Centimeter operator *(double lhs, Centimeter rhs) { return new Centimeter(lhs * rhs.m_value); }
        public static Centimeter operator *(Centimeter lhs, double rhs) { return new Centimeter(lhs.m_value * rhs); }
        public static Centimeter operator /(Centimeter lhs, double rhs) { return new Centimeter(lhs.m_value / rhs); }
        public static double operator /(Centimeter lhs, Centimeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Centimeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Centimeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Centimeter.Format, m_value, Centimeter.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = 100d * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("cm");

        private static readonly Centimeter s_one = new Centimeter(1d);
        private static readonly Centimeter s_zero = new Centimeter(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Centimeter One { get { return s_one; } }
        public static Centimeter Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Millimeter : IQuantity<double>, IEquatable<Millimeter>, IComparable<Millimeter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Millimeter.Family; } }
        double IQuantity<double>.Factor { get { return Millimeter.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Millimeter.Symbol; } }
        #endregion

        #region Constructor(s)
        public Millimeter(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Millimeter(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Millimeter(double q) { return new Millimeter(q); }
        public static explicit operator Millimeter(Centimeter q) { return new Millimeter((Millimeter.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Millimeter(Meter q) { return new Millimeter((Millimeter.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Millimeter(Inch q) { return new Millimeter((Millimeter.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Millimeter(Foot q) { return new Millimeter((Millimeter.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Millimeter(Yard q) { return new Millimeter((Millimeter.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Millimeter(Mile q) { return new Millimeter((Millimeter.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Millimeter(Kilometer q) { return new Millimeter((Millimeter.Factor / Kilometer.Factor) * q.m_value); }
        public static Millimeter From(IQuantity<double> q)
        {
            if (q.Family != Millimeter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Millimeter\"", q.GetType().Name));
            return new Millimeter((Millimeter.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Millimeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Millimeter) && Equals((Millimeter)obj); }
        public bool /* IEquatable<Millimeter> */ Equals(Millimeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Millimeter>
        public static bool operator ==(Millimeter lhs, Millimeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Millimeter lhs, Millimeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Millimeter lhs, Millimeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Millimeter lhs, Millimeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Millimeter lhs, Millimeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Millimeter lhs, Millimeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Millimeter> */ CompareTo(Millimeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Millimeter operator +(Millimeter lhs, Millimeter rhs) { return new Millimeter(lhs.m_value + rhs.m_value); }
        public static Millimeter operator -(Millimeter lhs, Millimeter rhs) { return new Millimeter(lhs.m_value - rhs.m_value); }
        public static Millimeter operator ++(Millimeter q) { return new Millimeter(q.m_value + 1d); }
        public static Millimeter operator --(Millimeter q) { return new Millimeter(q.m_value - 1d); }
        public static Millimeter operator -(Millimeter q) { return new Millimeter(-q.m_value); }
        public static Millimeter operator *(double lhs, Millimeter rhs) { return new Millimeter(lhs * rhs.m_value); }
        public static Millimeter operator *(Millimeter lhs, double rhs) { return new Millimeter(lhs.m_value * rhs); }
        public static Millimeter operator /(Millimeter lhs, double rhs) { return new Millimeter(lhs.m_value / rhs); }
        public static double operator /(Millimeter lhs, Millimeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Millimeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Millimeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Millimeter.Format, m_value, Millimeter.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = 1000d * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mm");

        private static readonly Millimeter s_one = new Millimeter(1d);
        private static readonly Millimeter s_zero = new Millimeter(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Millimeter One { get { return s_one; } }
        public static Millimeter Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Kilometer : IQuantity<double>, IEquatable<Kilometer>, IComparable<Kilometer>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Kilometer.Family; } }
        double IQuantity<double>.Factor { get { return Kilometer.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Kilometer.Symbol; } }
        #endregion

        #region Constructor(s)
        public Kilometer(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Kilometer(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Kilometer(double q) { return new Kilometer(q); }
        public static explicit operator Kilometer(Millimeter q) { return new Kilometer((Kilometer.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Kilometer(Centimeter q) { return new Kilometer((Kilometer.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Kilometer(Meter q) { return new Kilometer((Kilometer.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Kilometer(Inch q) { return new Kilometer((Kilometer.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Kilometer(Foot q) { return new Kilometer((Kilometer.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Kilometer(Yard q) { return new Kilometer((Kilometer.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Kilometer(Mile q) { return new Kilometer((Kilometer.Factor / Mile.Factor) * q.m_value); }
        public static Kilometer From(IQuantity<double> q)
        {
            if (q.Family != Kilometer.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kilometer\"", q.GetType().Name));
            return new Kilometer((Kilometer.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Kilometer>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Kilometer) && Equals((Kilometer)obj); }
        public bool /* IEquatable<Kilometer> */ Equals(Kilometer other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Kilometer>
        public static bool operator ==(Kilometer lhs, Kilometer rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Kilometer lhs, Kilometer rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Kilometer lhs, Kilometer rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Kilometer lhs, Kilometer rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Kilometer lhs, Kilometer rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Kilometer lhs, Kilometer rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Kilometer> */ CompareTo(Kilometer other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Kilometer operator +(Kilometer lhs, Kilometer rhs) { return new Kilometer(lhs.m_value + rhs.m_value); }
        public static Kilometer operator -(Kilometer lhs, Kilometer rhs) { return new Kilometer(lhs.m_value - rhs.m_value); }
        public static Kilometer operator ++(Kilometer q) { return new Kilometer(q.m_value + 1d); }
        public static Kilometer operator --(Kilometer q) { return new Kilometer(q.m_value - 1d); }
        public static Kilometer operator -(Kilometer q) { return new Kilometer(-q.m_value); }
        public static Kilometer operator *(double lhs, Kilometer rhs) { return new Kilometer(lhs * rhs.m_value); }
        public static Kilometer operator *(Kilometer lhs, double rhs) { return new Kilometer(lhs.m_value * rhs); }
        public static Kilometer operator /(Kilometer lhs, double rhs) { return new Kilometer(lhs.m_value / rhs); }
        public static double operator /(Kilometer lhs, Kilometer rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Kilometer_Hour operator /(Kilometer lhs, Hour rhs) { return new Kilometer_Hour(lhs.m_value / rhs.m_value); }
        public static Hour operator /(Kilometer lhs, Kilometer_Hour rhs) { return new Hour(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Kilometer.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Kilometer.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Kilometer.Format, m_value, Kilometer.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = Meter.Factor / 1000d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("km");

        private static readonly Kilometer s_one = new Kilometer(1d);
        private static readonly Kilometer s_zero = new Kilometer(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Kilometer One { get { return s_one; } }
        public static Kilometer Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Inch : IQuantity<double>, IEquatable<Inch>, IComparable<Inch>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Inch.Family; } }
        double IQuantity<double>.Factor { get { return Inch.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Inch.Symbol; } }
        #endregion

        #region Constructor(s)
        public Inch(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Inch(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Inch(double q) { return new Inch(q); }
        public static explicit operator Inch(Foot q) { return new Inch((Inch.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Inch(Yard q) { return new Inch((Inch.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Inch(Mile q) { return new Inch((Inch.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Inch(Kilometer q) { return new Inch((Inch.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Inch(Millimeter q) { return new Inch((Inch.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Inch(Centimeter q) { return new Inch((Inch.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Inch(Meter q) { return new Inch((Inch.Factor / Meter.Factor) * q.m_value); }
        public static Inch From(IQuantity<double> q)
        {
            if (q.Family != Inch.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Inch\"", q.GetType().Name));
            return new Inch((Inch.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Inch>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Inch) && Equals((Inch)obj); }
        public bool /* IEquatable<Inch> */ Equals(Inch other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Inch>
        public static bool operator ==(Inch lhs, Inch rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Inch lhs, Inch rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Inch lhs, Inch rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Inch lhs, Inch rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Inch lhs, Inch rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Inch lhs, Inch rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Inch> */ CompareTo(Inch other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Inch operator +(Inch lhs, Inch rhs) { return new Inch(lhs.m_value + rhs.m_value); }
        public static Inch operator -(Inch lhs, Inch rhs) { return new Inch(lhs.m_value - rhs.m_value); }
        public static Inch operator ++(Inch q) { return new Inch(q.m_value + 1d); }
        public static Inch operator --(Inch q) { return new Inch(q.m_value - 1d); }
        public static Inch operator -(Inch q) { return new Inch(-q.m_value); }
        public static Inch operator *(double lhs, Inch rhs) { return new Inch(lhs * rhs.m_value); }
        public static Inch operator *(Inch lhs, double rhs) { return new Inch(lhs.m_value * rhs); }
        public static Inch operator /(Inch lhs, double rhs) { return new Inch(lhs.m_value / rhs); }
        public static double operator /(Inch lhs, Inch rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Inch.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Inch.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Inch.Format, m_value, Inch.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = 100d * Meter.Factor / 2.54d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("in");

        private static readonly Inch s_one = new Inch(1d);
        private static readonly Inch s_zero = new Inch(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Inch One { get { return s_one; } }
        public static Inch Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Foot : IQuantity<double>, IEquatable<Foot>, IComparable<Foot>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Foot.Family; } }
        double IQuantity<double>.Factor { get { return Foot.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Foot.Symbol; } }
        #endregion

        #region Constructor(s)
        public Foot(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Foot(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Foot(double q) { return new Foot(q); }
        public static explicit operator Foot(Yard q) { return new Foot((Foot.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Foot(Mile q) { return new Foot((Foot.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Foot(Kilometer q) { return new Foot((Foot.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Foot(Millimeter q) { return new Foot((Foot.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Foot(Centimeter q) { return new Foot((Foot.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Foot(Meter q) { return new Foot((Foot.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Foot(Inch q) { return new Foot((Foot.Factor / Inch.Factor) * q.m_value); }
        public static Foot From(IQuantity<double> q)
        {
            if (q.Family != Foot.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Foot\"", q.GetType().Name));
            return new Foot((Foot.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Foot>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Foot) && Equals((Foot)obj); }
        public bool /* IEquatable<Foot> */ Equals(Foot other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Foot>
        public static bool operator ==(Foot lhs, Foot rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Foot lhs, Foot rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Foot lhs, Foot rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Foot lhs, Foot rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Foot lhs, Foot rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Foot lhs, Foot rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Foot> */ CompareTo(Foot other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Foot operator +(Foot lhs, Foot rhs) { return new Foot(lhs.m_value + rhs.m_value); }
        public static Foot operator -(Foot lhs, Foot rhs) { return new Foot(lhs.m_value - rhs.m_value); }
        public static Foot operator ++(Foot q) { return new Foot(q.m_value + 1d); }
        public static Foot operator --(Foot q) { return new Foot(q.m_value - 1d); }
        public static Foot operator -(Foot q) { return new Foot(-q.m_value); }
        public static Foot operator *(double lhs, Foot rhs) { return new Foot(lhs * rhs.m_value); }
        public static Foot operator *(Foot lhs, double rhs) { return new Foot(lhs.m_value * rhs); }
        public static Foot operator /(Foot lhs, double rhs) { return new Foot(lhs.m_value / rhs); }
        public static double operator /(Foot lhs, Foot rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static SquareFoot operator *(Foot lhs, Foot rhs) { return new SquareFoot(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Foot.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Foot.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Foot.Format, m_value, Foot.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Inch.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = Inch.Factor / 12d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("ft");

        private static readonly Foot s_one = new Foot(1d);
        private static readonly Foot s_zero = new Foot(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Foot One { get { return s_one; } }
        public static Foot Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Yard : IQuantity<double>, IEquatable<Yard>, IComparable<Yard>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Yard.Family; } }
        double IQuantity<double>.Factor { get { return Yard.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Yard.Symbol; } }
        #endregion

        #region Constructor(s)
        public Yard(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Yard(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Yard(double q) { return new Yard(q); }
        public static explicit operator Yard(Mile q) { return new Yard((Yard.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Yard(Kilometer q) { return new Yard((Yard.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Yard(Millimeter q) { return new Yard((Yard.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Yard(Centimeter q) { return new Yard((Yard.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Yard(Meter q) { return new Yard((Yard.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Yard(Inch q) { return new Yard((Yard.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Yard(Foot q) { return new Yard((Yard.Factor / Foot.Factor) * q.m_value); }
        public static Yard From(IQuantity<double> q)
        {
            if (q.Family != Yard.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Yard\"", q.GetType().Name));
            return new Yard((Yard.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Yard>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Yard) && Equals((Yard)obj); }
        public bool /* IEquatable<Yard> */ Equals(Yard other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Yard>
        public static bool operator ==(Yard lhs, Yard rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Yard lhs, Yard rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Yard lhs, Yard rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Yard lhs, Yard rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Yard lhs, Yard rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Yard lhs, Yard rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Yard> */ CompareTo(Yard other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Yard operator +(Yard lhs, Yard rhs) { return new Yard(lhs.m_value + rhs.m_value); }
        public static Yard operator -(Yard lhs, Yard rhs) { return new Yard(lhs.m_value - rhs.m_value); }
        public static Yard operator ++(Yard q) { return new Yard(q.m_value + 1d); }
        public static Yard operator --(Yard q) { return new Yard(q.m_value - 1d); }
        public static Yard operator -(Yard q) { return new Yard(-q.m_value); }
        public static Yard operator *(double lhs, Yard rhs) { return new Yard(lhs * rhs.m_value); }
        public static Yard operator *(Yard lhs, double rhs) { return new Yard(lhs.m_value * rhs); }
        public static Yard operator /(Yard lhs, double rhs) { return new Yard(lhs.m_value / rhs); }
        public static double operator /(Yard lhs, Yard rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Yard.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Yard.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Yard.Format, m_value, Yard.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Foot.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = Foot.Factor / 3d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("yd");

        private static readonly Yard s_one = new Yard(1d);
        private static readonly Yard s_zero = new Yard(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Yard One { get { return s_one; } }
        public static Yard Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Mile : IQuantity<double>, IEquatable<Mile>, IComparable<Mile>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Mile.Family; } }
        double IQuantity<double>.Factor { get { return Mile.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Mile.Symbol; } }
        #endregion

        #region Constructor(s)
        public Mile(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Mile(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Mile(double q) { return new Mile(q); }
        public static explicit operator Mile(Kilometer q) { return new Mile((Mile.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Mile(Millimeter q) { return new Mile((Mile.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Mile(Centimeter q) { return new Mile((Mile.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Mile(Meter q) { return new Mile((Mile.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Mile(Inch q) { return new Mile((Mile.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Mile(Foot q) { return new Mile((Mile.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Mile(Yard q) { return new Mile((Mile.Factor / Yard.Factor) * q.m_value); }
        public static Mile From(IQuantity<double> q)
        {
            if (q.Family != Mile.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Mile\"", q.GetType().Name));
            return new Mile((Mile.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Mile>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Mile) && Equals((Mile)obj); }
        public bool /* IEquatable<Mile> */ Equals(Mile other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Mile>
        public static bool operator ==(Mile lhs, Mile rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Mile lhs, Mile rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Mile lhs, Mile rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Mile lhs, Mile rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Mile lhs, Mile rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Mile lhs, Mile rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Mile> */ CompareTo(Mile other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Mile operator +(Mile lhs, Mile rhs) { return new Mile(lhs.m_value + rhs.m_value); }
        public static Mile operator -(Mile lhs, Mile rhs) { return new Mile(lhs.m_value - rhs.m_value); }
        public static Mile operator ++(Mile q) { return new Mile(q.m_value + 1d); }
        public static Mile operator --(Mile q) { return new Mile(q.m_value - 1d); }
        public static Mile operator -(Mile q) { return new Mile(-q.m_value); }
        public static Mile operator *(double lhs, Mile rhs) { return new Mile(lhs * rhs.m_value); }
        public static Mile operator *(Mile lhs, double rhs) { return new Mile(lhs.m_value * rhs); }
        public static Mile operator /(Mile lhs, double rhs) { return new Mile(lhs.m_value / rhs); }
        public static double operator /(Mile lhs, Mile rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static MPH operator /(Mile lhs, Hour rhs) { return new MPH(lhs.m_value / rhs.m_value); }
        public static Hour operator /(Mile lhs, MPH rhs) { return new Hour(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Mile.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Mile.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Mile.Format, m_value, Mile.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Yard.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = Yard.Factor / 1760d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mil");

        private static readonly Mile s_one = new Mile(1d);
        private static readonly Mile s_zero = new Mile(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Mile One { get { return s_one; } }
        public static Mile Zero { get { return s_zero; } }
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
        public static explicit operator Second(Minute q) { return new Second((Second.Factor / Minute.Factor) * q.m_value); }
        public static explicit operator Second(Hour q) { return new Second((Second.Factor / Hour.Factor) * q.m_value); }
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
        public static Farad operator /(Second lhs, Ohm rhs) { return new Farad(lhs.m_value / rhs.m_value); }
        public static Ohm operator /(Second lhs, Farad rhs) { return new Ohm(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Second.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Second.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Second.Format, m_value, Second.Symbol[0]);
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
    public partial struct Minute : IQuantity<double>, IEquatable<Minute>, IComparable<Minute>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Minute.Family; } }
        double IQuantity<double>.Factor { get { return Minute.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Minute.Symbol; } }
        #endregion

        #region Constructor(s)
        public Minute(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Minute(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Minute(double q) { return new Minute(q); }
        public static explicit operator Minute(Hour q) { return new Minute((Minute.Factor / Hour.Factor) * q.m_value); }
        public static explicit operator Minute(Second q) { return new Minute((Minute.Factor / Second.Factor) * q.m_value); }
        public static Minute From(IQuantity<double> q)
        {
            if (q.Family != Minute.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Minute\"", q.GetType().Name));
            return new Minute((Minute.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Minute>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Minute) && Equals((Minute)obj); }
        public bool /* IEquatable<Minute> */ Equals(Minute other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Minute>
        public static bool operator ==(Minute lhs, Minute rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Minute lhs, Minute rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Minute lhs, Minute rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Minute lhs, Minute rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Minute lhs, Minute rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Minute lhs, Minute rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Minute> */ CompareTo(Minute other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Minute operator +(Minute lhs, Minute rhs) { return new Minute(lhs.m_value + rhs.m_value); }
        public static Minute operator -(Minute lhs, Minute rhs) { return new Minute(lhs.m_value - rhs.m_value); }
        public static Minute operator ++(Minute q) { return new Minute(q.m_value + 1d); }
        public static Minute operator --(Minute q) { return new Minute(q.m_value - 1d); }
        public static Minute operator -(Minute q) { return new Minute(-q.m_value); }
        public static Minute operator *(double lhs, Minute rhs) { return new Minute(lhs * rhs.m_value); }
        public static Minute operator *(Minute lhs, double rhs) { return new Minute(lhs.m_value * rhs); }
        public static Minute operator /(Minute lhs, double rhs) { return new Minute(lhs.m_value / rhs); }
        public static double operator /(Minute lhs, Minute rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Minute.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Minute.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Minute.Format, m_value, Minute.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Second.Sense;
        private static readonly int s_family = Second.Family;
        private static /*mutable*/ double s_factor = Second.Factor / 60d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("min");

        private static readonly Minute s_one = new Minute(1d);
        private static readonly Minute s_zero = new Minute(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Minute One { get { return s_one; } }
        public static Minute Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Hour : IQuantity<double>, IEquatable<Hour>, IComparable<Hour>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Hour.Family; } }
        double IQuantity<double>.Factor { get { return Hour.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Hour.Symbol; } }
        #endregion

        #region Constructor(s)
        public Hour(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Hour(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Hour(double q) { return new Hour(q); }
        public static explicit operator Hour(Second q) { return new Hour((Hour.Factor / Second.Factor) * q.m_value); }
        public static explicit operator Hour(Minute q) { return new Hour((Hour.Factor / Minute.Factor) * q.m_value); }
        public static Hour From(IQuantity<double> q)
        {
            if (q.Family != Hour.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Hour\"", q.GetType().Name));
            return new Hour((Hour.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Hour>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Hour) && Equals((Hour)obj); }
        public bool /* IEquatable<Hour> */ Equals(Hour other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Hour>
        public static bool operator ==(Hour lhs, Hour rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Hour lhs, Hour rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Hour lhs, Hour rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Hour lhs, Hour rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Hour lhs, Hour rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Hour lhs, Hour rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Hour> */ CompareTo(Hour other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Hour operator +(Hour lhs, Hour rhs) { return new Hour(lhs.m_value + rhs.m_value); }
        public static Hour operator -(Hour lhs, Hour rhs) { return new Hour(lhs.m_value - rhs.m_value); }
        public static Hour operator ++(Hour q) { return new Hour(q.m_value + 1d); }
        public static Hour operator --(Hour q) { return new Hour(q.m_value - 1d); }
        public static Hour operator -(Hour q) { return new Hour(-q.m_value); }
        public static Hour operator *(double lhs, Hour rhs) { return new Hour(lhs * rhs.m_value); }
        public static Hour operator *(Hour lhs, double rhs) { return new Hour(lhs.m_value * rhs); }
        public static Hour operator /(Hour lhs, double rhs) { return new Hour(lhs.m_value / rhs); }
        public static double operator /(Hour lhs, Hour rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Hour.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Hour.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Hour.Format, m_value, Hour.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Minute.Sense;
        private static readonly int s_family = Second.Family;
        private static /*mutable*/ double s_factor = Minute.Factor / 60d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("h");

        private static readonly Hour s_one = new Hour(1d);
        private static readonly Hour s_zero = new Hour(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Hour One { get { return s_one; } }
        public static Hour Zero { get { return s_zero; } }
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
        public static explicit operator Kilogram(Pound q) { return new Kilogram((Kilogram.Factor / Pound.Factor) * q.m_value); }
        public static explicit operator Kilogram(Ounce q) { return new Kilogram((Kilogram.Factor / Ounce.Factor) * q.m_value); }
        public static explicit operator Kilogram(Tonne q) { return new Kilogram((Kilogram.Factor / Tonne.Factor) * q.m_value); }
        public static explicit operator Kilogram(Gram q) { return new Kilogram((Kilogram.Factor / Gram.Factor) * q.m_value); }
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
            return string.Format(fp, format ?? Kilogram.Format, m_value, Kilogram.Symbol[0]);
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
    public partial struct Gram : IQuantity<double>, IEquatable<Gram>, IComparable<Gram>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Gram.Family; } }
        double IQuantity<double>.Factor { get { return Gram.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Gram.Symbol; } }
        #endregion

        #region Constructor(s)
        public Gram(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Gram(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Gram(double q) { return new Gram(q); }
        public static explicit operator Gram(Kilogram q) { return new Gram((Gram.Factor / Kilogram.Factor) * q.m_value); }
        public static explicit operator Gram(Pound q) { return new Gram((Gram.Factor / Pound.Factor) * q.m_value); }
        public static explicit operator Gram(Ounce q) { return new Gram((Gram.Factor / Ounce.Factor) * q.m_value); }
        public static explicit operator Gram(Tonne q) { return new Gram((Gram.Factor / Tonne.Factor) * q.m_value); }
        public static Gram From(IQuantity<double> q)
        {
            if (q.Family != Gram.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Gram\"", q.GetType().Name));
            return new Gram((Gram.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Gram>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Gram) && Equals((Gram)obj); }
        public bool /* IEquatable<Gram> */ Equals(Gram other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Gram>
        public static bool operator ==(Gram lhs, Gram rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Gram lhs, Gram rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Gram lhs, Gram rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Gram lhs, Gram rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Gram lhs, Gram rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Gram lhs, Gram rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Gram> */ CompareTo(Gram other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Gram operator +(Gram lhs, Gram rhs) { return new Gram(lhs.m_value + rhs.m_value); }
        public static Gram operator -(Gram lhs, Gram rhs) { return new Gram(lhs.m_value - rhs.m_value); }
        public static Gram operator ++(Gram q) { return new Gram(q.m_value + 1d); }
        public static Gram operator --(Gram q) { return new Gram(q.m_value - 1d); }
        public static Gram operator -(Gram q) { return new Gram(-q.m_value); }
        public static Gram operator *(double lhs, Gram rhs) { return new Gram(lhs * rhs.m_value); }
        public static Gram operator *(Gram lhs, double rhs) { return new Gram(lhs.m_value * rhs); }
        public static Gram operator /(Gram lhs, double rhs) { return new Gram(lhs.m_value / rhs); }
        public static double operator /(Gram lhs, Gram rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Gram.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Gram.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Gram.Format, m_value, Gram.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static /*mutable*/ double s_factor = 1000d * Kilogram.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("g");

        private static readonly Gram s_one = new Gram(1d);
        private static readonly Gram s_zero = new Gram(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Gram One { get { return s_one; } }
        public static Gram Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Tonne : IQuantity<double>, IEquatable<Tonne>, IComparable<Tonne>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Tonne.Family; } }
        double IQuantity<double>.Factor { get { return Tonne.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Tonne.Symbol; } }
        #endregion

        #region Constructor(s)
        public Tonne(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Tonne(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Tonne(double q) { return new Tonne(q); }
        public static explicit operator Tonne(Gram q) { return new Tonne((Tonne.Factor / Gram.Factor) * q.m_value); }
        public static explicit operator Tonne(Kilogram q) { return new Tonne((Tonne.Factor / Kilogram.Factor) * q.m_value); }
        public static explicit operator Tonne(Pound q) { return new Tonne((Tonne.Factor / Pound.Factor) * q.m_value); }
        public static explicit operator Tonne(Ounce q) { return new Tonne((Tonne.Factor / Ounce.Factor) * q.m_value); }
        public static Tonne From(IQuantity<double> q)
        {
            if (q.Family != Tonne.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Tonne\"", q.GetType().Name));
            return new Tonne((Tonne.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Tonne>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Tonne) && Equals((Tonne)obj); }
        public bool /* IEquatable<Tonne> */ Equals(Tonne other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Tonne>
        public static bool operator ==(Tonne lhs, Tonne rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Tonne lhs, Tonne rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Tonne lhs, Tonne rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Tonne lhs, Tonne rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Tonne lhs, Tonne rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Tonne lhs, Tonne rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Tonne> */ CompareTo(Tonne other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Tonne operator +(Tonne lhs, Tonne rhs) { return new Tonne(lhs.m_value + rhs.m_value); }
        public static Tonne operator -(Tonne lhs, Tonne rhs) { return new Tonne(lhs.m_value - rhs.m_value); }
        public static Tonne operator ++(Tonne q) { return new Tonne(q.m_value + 1d); }
        public static Tonne operator --(Tonne q) { return new Tonne(q.m_value - 1d); }
        public static Tonne operator -(Tonne q) { return new Tonne(-q.m_value); }
        public static Tonne operator *(double lhs, Tonne rhs) { return new Tonne(lhs * rhs.m_value); }
        public static Tonne operator *(Tonne lhs, double rhs) { return new Tonne(lhs.m_value * rhs); }
        public static Tonne operator /(Tonne lhs, double rhs) { return new Tonne(lhs.m_value / rhs); }
        public static double operator /(Tonne lhs, Tonne rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Tonne.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Tonne.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Tonne.Format, m_value, Tonne.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static /*mutable*/ double s_factor = Kilogram.Factor / 1000d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("t");

        private static readonly Tonne s_one = new Tonne(1d);
        private static readonly Tonne s_zero = new Tonne(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Tonne One { get { return s_one; } }
        public static Tonne Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Pound : IQuantity<double>, IEquatable<Pound>, IComparable<Pound>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Pound.Family; } }
        double IQuantity<double>.Factor { get { return Pound.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Pound.Symbol; } }
        #endregion

        #region Constructor(s)
        public Pound(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Pound(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Pound(double q) { return new Pound(q); }
        public static explicit operator Pound(Ounce q) { return new Pound((Pound.Factor / Ounce.Factor) * q.m_value); }
        public static explicit operator Pound(Tonne q) { return new Pound((Pound.Factor / Tonne.Factor) * q.m_value); }
        public static explicit operator Pound(Gram q) { return new Pound((Pound.Factor / Gram.Factor) * q.m_value); }
        public static explicit operator Pound(Kilogram q) { return new Pound((Pound.Factor / Kilogram.Factor) * q.m_value); }
        public static Pound From(IQuantity<double> q)
        {
            if (q.Family != Pound.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Pound\"", q.GetType().Name));
            return new Pound((Pound.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Pound>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Pound) && Equals((Pound)obj); }
        public bool /* IEquatable<Pound> */ Equals(Pound other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Pound>
        public static bool operator ==(Pound lhs, Pound rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Pound lhs, Pound rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Pound lhs, Pound rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Pound lhs, Pound rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Pound lhs, Pound rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Pound lhs, Pound rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Pound> */ CompareTo(Pound other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Pound operator +(Pound lhs, Pound rhs) { return new Pound(lhs.m_value + rhs.m_value); }
        public static Pound operator -(Pound lhs, Pound rhs) { return new Pound(lhs.m_value - rhs.m_value); }
        public static Pound operator ++(Pound q) { return new Pound(q.m_value + 1d); }
        public static Pound operator --(Pound q) { return new Pound(q.m_value - 1d); }
        public static Pound operator -(Pound q) { return new Pound(-q.m_value); }
        public static Pound operator *(double lhs, Pound rhs) { return new Pound(lhs * rhs.m_value); }
        public static Pound operator *(Pound lhs, double rhs) { return new Pound(lhs.m_value * rhs); }
        public static Pound operator /(Pound lhs, double rhs) { return new Pound(lhs.m_value / rhs); }
        public static double operator /(Pound lhs, Pound rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Pound.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Pound.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Pound.Format, m_value, Pound.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static /*mutable*/ double s_factor = Kilogram.Factor / 0.45359237d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("lb");

        private static readonly Pound s_one = new Pound(1d);
        private static readonly Pound s_zero = new Pound(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Pound One { get { return s_one; } }
        public static Pound Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Ounce : IQuantity<double>, IEquatable<Ounce>, IComparable<Ounce>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Ounce.Family; } }
        double IQuantity<double>.Factor { get { return Ounce.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Ounce.Symbol; } }
        #endregion

        #region Constructor(s)
        public Ounce(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Ounce(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Ounce(double q) { return new Ounce(q); }
        public static explicit operator Ounce(Tonne q) { return new Ounce((Ounce.Factor / Tonne.Factor) * q.m_value); }
        public static explicit operator Ounce(Gram q) { return new Ounce((Ounce.Factor / Gram.Factor) * q.m_value); }
        public static explicit operator Ounce(Kilogram q) { return new Ounce((Ounce.Factor / Kilogram.Factor) * q.m_value); }
        public static explicit operator Ounce(Pound q) { return new Ounce((Ounce.Factor / Pound.Factor) * q.m_value); }
        public static Ounce From(IQuantity<double> q)
        {
            if (q.Family != Ounce.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Ounce\"", q.GetType().Name));
            return new Ounce((Ounce.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Ounce>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Ounce) && Equals((Ounce)obj); }
        public bool /* IEquatable<Ounce> */ Equals(Ounce other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Ounce>
        public static bool operator ==(Ounce lhs, Ounce rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Ounce lhs, Ounce rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Ounce lhs, Ounce rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Ounce lhs, Ounce rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Ounce lhs, Ounce rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Ounce lhs, Ounce rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Ounce> */ CompareTo(Ounce other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Ounce operator +(Ounce lhs, Ounce rhs) { return new Ounce(lhs.m_value + rhs.m_value); }
        public static Ounce operator -(Ounce lhs, Ounce rhs) { return new Ounce(lhs.m_value - rhs.m_value); }
        public static Ounce operator ++(Ounce q) { return new Ounce(q.m_value + 1d); }
        public static Ounce operator --(Ounce q) { return new Ounce(q.m_value - 1d); }
        public static Ounce operator -(Ounce q) { return new Ounce(-q.m_value); }
        public static Ounce operator *(double lhs, Ounce rhs) { return new Ounce(lhs * rhs.m_value); }
        public static Ounce operator *(Ounce lhs, double rhs) { return new Ounce(lhs.m_value * rhs); }
        public static Ounce operator /(Ounce lhs, double rhs) { return new Ounce(lhs.m_value / rhs); }
        public static double operator /(Ounce lhs, Ounce rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Ounce.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Ounce.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Ounce.Format, m_value, Ounce.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Pound.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static /*mutable*/ double s_factor = Pound.Factor * 16d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("ou");

        private static readonly Ounce s_one = new Ounce(1d);
        private static readonly Ounce s_zero = new Ounce(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Ounce One { get { return s_one; } }
        public static Ounce Zero { get { return s_zero; } }
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
            return string.Format(fp, format ?? DegKelvin.Format, m_value, DegKelvin.Symbol[0]);
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
            return string.Format(fp, format ?? DegCelsius.Format, m_value, DegCelsius.Symbol[0]);
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
            return string.Format(fp, format ?? DegRankine.Format, m_value, DegRankine.Symbol[0]);
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
            return string.Format(fp, format ?? DegFahrenheit.Format, m_value, DegFahrenheit.Symbol[0]);
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
    public partial struct Ampere : IQuantity<double>, IEquatable<Ampere>, IComparable<Ampere>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Ampere.Family; } }
        double IQuantity<double>.Factor { get { return Ampere.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Ampere.Symbol; } }
        #endregion

        #region Constructor(s)
        public Ampere(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Ampere(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Ampere(double q) { return new Ampere(q); }
        public static Ampere From(IQuantity<double> q)
        {
            if (q.Family != Ampere.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Ampere\"", q.GetType().Name));
            return new Ampere((Ampere.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Ampere>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Ampere) && Equals((Ampere)obj); }
        public bool /* IEquatable<Ampere> */ Equals(Ampere other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Ampere>
        public static bool operator ==(Ampere lhs, Ampere rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Ampere lhs, Ampere rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Ampere lhs, Ampere rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Ampere lhs, Ampere rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Ampere lhs, Ampere rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Ampere lhs, Ampere rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Ampere> */ CompareTo(Ampere other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Ampere operator +(Ampere lhs, Ampere rhs) { return new Ampere(lhs.m_value + rhs.m_value); }
        public static Ampere operator -(Ampere lhs, Ampere rhs) { return new Ampere(lhs.m_value - rhs.m_value); }
        public static Ampere operator ++(Ampere q) { return new Ampere(q.m_value + 1d); }
        public static Ampere operator --(Ampere q) { return new Ampere(q.m_value - 1d); }
        public static Ampere operator -(Ampere q) { return new Ampere(-q.m_value); }
        public static Ampere operator *(double lhs, Ampere rhs) { return new Ampere(lhs * rhs.m_value); }
        public static Ampere operator *(Ampere lhs, double rhs) { return new Ampere(lhs.m_value * rhs); }
        public static Ampere operator /(Ampere lhs, double rhs) { return new Ampere(lhs.m_value / rhs); }
        public static double operator /(Ampere lhs, Ampere rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Coulomb operator *(Ampere lhs, Second rhs) { return new Coulomb(lhs.m_value * rhs.m_value); }
        public static Coulomb operator *(Second lhs, Ampere rhs) { return new Coulomb(lhs.m_value * rhs.m_value); }
        public static Siemens operator /(Ampere lhs, Volt rhs) { return new Siemens(lhs.m_value / rhs.m_value); }
        public static Volt operator /(Ampere lhs, Siemens rhs) { return new Volt(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Ampere.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Ampere.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Ampere.Format, m_value, Ampere.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.ElectricCurrent;
        private static readonly int s_family = 4;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("A");

        private static readonly Ampere s_one = new Ampere(1d);
        private static readonly Ampere s_zero = new Ampere(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Ampere One { get { return s_one; } }
        public static Ampere Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Mole : IQuantity<double>, IEquatable<Mole>, IComparable<Mole>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Mole.Family; } }
        double IQuantity<double>.Factor { get { return Mole.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Mole.Symbol; } }
        #endregion

        #region Constructor(s)
        public Mole(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Mole(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Mole(double q) { return new Mole(q); }
        public static Mole From(IQuantity<double> q)
        {
            if (q.Family != Mole.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Mole\"", q.GetType().Name));
            return new Mole((Mole.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Mole>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Mole) && Equals((Mole)obj); }
        public bool /* IEquatable<Mole> */ Equals(Mole other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Mole>
        public static bool operator ==(Mole lhs, Mole rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Mole lhs, Mole rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Mole lhs, Mole rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Mole lhs, Mole rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Mole lhs, Mole rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Mole lhs, Mole rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Mole> */ CompareTo(Mole other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Mole operator +(Mole lhs, Mole rhs) { return new Mole(lhs.m_value + rhs.m_value); }
        public static Mole operator -(Mole lhs, Mole rhs) { return new Mole(lhs.m_value - rhs.m_value); }
        public static Mole operator ++(Mole q) { return new Mole(q.m_value + 1d); }
        public static Mole operator --(Mole q) { return new Mole(q.m_value - 1d); }
        public static Mole operator -(Mole q) { return new Mole(-q.m_value); }
        public static Mole operator *(double lhs, Mole rhs) { return new Mole(lhs * rhs.m_value); }
        public static Mole operator *(Mole lhs, double rhs) { return new Mole(lhs.m_value * rhs); }
        public static Mole operator /(Mole lhs, double rhs) { return new Mole(lhs.m_value / rhs); }
        public static double operator /(Mole lhs, Mole rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Mole.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Mole.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Mole.Format, m_value, Mole.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.AmountOfSubstance;
        private static readonly int s_family = 5;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mol");

        private static readonly Mole s_one = new Mole(1d);
        private static readonly Mole s_zero = new Mole(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Mole One { get { return s_one; } }
        public static Mole Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Candela : IQuantity<double>, IEquatable<Candela>, IComparable<Candela>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Candela.Family; } }
        double IQuantity<double>.Factor { get { return Candela.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Candela.Symbol; } }
        #endregion

        #region Constructor(s)
        public Candela(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Candela(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Candela(double q) { return new Candela(q); }
        public static Candela From(IQuantity<double> q)
        {
            if (q.Family != Candela.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Candela\"", q.GetType().Name));
            return new Candela((Candela.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Candela>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Candela) && Equals((Candela)obj); }
        public bool /* IEquatable<Candela> */ Equals(Candela other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Candela>
        public static bool operator ==(Candela lhs, Candela rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Candela lhs, Candela rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Candela lhs, Candela rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Candela lhs, Candela rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Candela lhs, Candela rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Candela lhs, Candela rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Candela> */ CompareTo(Candela other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Candela operator +(Candela lhs, Candela rhs) { return new Candela(lhs.m_value + rhs.m_value); }
        public static Candela operator -(Candela lhs, Candela rhs) { return new Candela(lhs.m_value - rhs.m_value); }
        public static Candela operator ++(Candela q) { return new Candela(q.m_value + 1d); }
        public static Candela operator --(Candela q) { return new Candela(q.m_value - 1d); }
        public static Candela operator -(Candela q) { return new Candela(-q.m_value); }
        public static Candela operator *(double lhs, Candela rhs) { return new Candela(lhs * rhs.m_value); }
        public static Candela operator *(Candela lhs, double rhs) { return new Candela(lhs.m_value * rhs); }
        public static Candela operator /(Candela lhs, double rhs) { return new Candela(lhs.m_value / rhs); }
        public static double operator /(Candela lhs, Candela rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Candela.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Candela.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Candela.Format, m_value, Candela.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.LuminousIntensity;
        private static readonly int s_family = 6;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("cd");

        private static readonly Candela s_one = new Candela(1d);
        private static readonly Candela s_zero = new Candela(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Candela One { get { return s_one; } }
        public static Candela Zero { get { return s_zero; } }
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
        public static explicit operator EUR(GBP q) { return new EUR((EUR.Factor / GBP.Factor) * q.m_value); }
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
            return string.Format(fp, format ?? EUR.Format, m_value, EUR.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Other;
        private static readonly int s_family = 7;
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
        public static explicit operator USD(GBP q) { return new USD((USD.Factor / GBP.Factor) * q.m_value); }
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
            return string.Format(fp, format ?? USD.Format, m_value, USD.Symbol[0]);
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
    public partial struct GBP : IQuantity<decimal>, IEquatable<GBP>, IComparable<GBP>, IFormattable
    {
        #region Fields
        internal readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        int IQuantity<decimal>.Family { get { return GBP.Family; } }
        decimal IQuantity<decimal>.Factor { get { return GBP.Factor; } }
        SymbolCollection IQuantity<decimal>.Symbol { get { return GBP.Symbol; } }
        #endregion

        #region Constructor(s)
        public GBP(decimal value)
        {
            m_value = value;
        }
        public static IQuantity<decimal> Create(decimal value)
        {
            return new GBP(value);
        }
        #endregion

        #region Conversions
        public static explicit operator GBP(decimal q) { return new GBP(q); }
        public static explicit operator GBP(USD q) { return new GBP((GBP.Factor / USD.Factor) * q.m_value); }
        public static explicit operator GBP(EUR q) { return new GBP((GBP.Factor / EUR.Factor) * q.m_value); }
        public static explicit operator GBP(PLN q) { return new GBP((GBP.Factor / PLN.Factor) * q.m_value); }
        public static GBP From(IQuantity<decimal> q)
        {
            if (q.Family != GBP.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"GBP\"", q.GetType().Name));
            return new GBP((GBP.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<decimal> Convert(IQuantity<decimal> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<GBP>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is GBP) && Equals((GBP)obj); }
        public bool /* IEquatable<GBP> */ Equals(GBP other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<GBP>
        public static bool operator ==(GBP lhs, GBP rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(GBP lhs, GBP rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(GBP lhs, GBP rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(GBP lhs, GBP rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(GBP lhs, GBP rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(GBP lhs, GBP rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<GBP> */ CompareTo(GBP other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static GBP operator +(GBP lhs, GBP rhs) { return new GBP(lhs.m_value + rhs.m_value); }
        public static GBP operator -(GBP lhs, GBP rhs) { return new GBP(lhs.m_value - rhs.m_value); }
        public static GBP operator ++(GBP q) { return new GBP(q.m_value + decimal.One); }
        public static GBP operator --(GBP q) { return new GBP(q.m_value - decimal.One); }
        public static GBP operator -(GBP q) { return new GBP(-q.m_value); }
        public static GBP operator *(decimal lhs, GBP rhs) { return new GBP(lhs * rhs.m_value); }
        public static GBP operator *(GBP lhs, decimal rhs) { return new GBP(lhs.m_value * rhs); }
        public static GBP operator /(GBP lhs, decimal rhs) { return new GBP(lhs.m_value / rhs); }
        public static decimal operator /(GBP lhs, GBP rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(GBP.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(GBP.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? GBP.Format, m_value, GBP.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = EUR.Sense;
        private static readonly int s_family = EUR.Family;
        private static /*mutable*/ decimal s_factor = 0.79055m * EUR.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("GBP");

        private static readonly GBP s_one = new GBP(decimal.One);
        private static readonly GBP s_zero = new GBP(decimal.Zero);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static GBP One { get { return s_one; } }
        public static GBP Zero { get { return s_zero; } }
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
        public static explicit operator PLN(GBP q) { return new PLN((PLN.Factor / GBP.Factor) * q.m_value); }
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
            return string.Format(fp, format ?? PLN.Format, m_value, PLN.Symbol[0]);
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
        public static explicit operator Radian(Grad q) { return new Radian((Radian.Factor / Grad.Factor) * q.m_value); }
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
        public static Radian_Sec operator /(Radian lhs, Second rhs) { return new Radian_Sec(lhs.m_value / rhs.m_value); }
        public static Second operator /(Radian lhs, Radian_Sec rhs) { return new Second(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Radian.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Radian.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Radian.Format, m_value, Radian.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.None;
        private static readonly int s_family = 8;
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
        public static explicit operator Degree(Grad q) { return new Degree((Degree.Factor / Grad.Factor) * q.m_value); }
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
            return string.Format(fp, format ?? Degree.Format, m_value, Degree.Symbol[0]);
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
    public partial struct Grad : IQuantity<double>, IEquatable<Grad>, IComparable<Grad>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Grad.Family; } }
        double IQuantity<double>.Factor { get { return Grad.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Grad.Symbol; } }
        #endregion

        #region Constructor(s)
        public Grad(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Grad(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Grad(double q) { return new Grad(q); }
        public static explicit operator Grad(Degree q) { return new Grad((Grad.Factor / Degree.Factor) * q.m_value); }
        public static explicit operator Grad(Radian q) { return new Grad((Grad.Factor / Radian.Factor) * q.m_value); }
        public static explicit operator Grad(Cycles q) { return new Grad((Grad.Factor / Cycles.Factor) * q.m_value); }
        public static Grad From(IQuantity<double> q)
        {
            if (q.Family != Grad.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Grad\"", q.GetType().Name));
            return new Grad((Grad.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Grad>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Grad) && Equals((Grad)obj); }
        public bool /* IEquatable<Grad> */ Equals(Grad other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Grad>
        public static bool operator ==(Grad lhs, Grad rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Grad lhs, Grad rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Grad lhs, Grad rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Grad lhs, Grad rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Grad lhs, Grad rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Grad lhs, Grad rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Grad> */ CompareTo(Grad other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Grad operator +(Grad lhs, Grad rhs) { return new Grad(lhs.m_value + rhs.m_value); }
        public static Grad operator -(Grad lhs, Grad rhs) { return new Grad(lhs.m_value - rhs.m_value); }
        public static Grad operator ++(Grad q) { return new Grad(q.m_value + 1d); }
        public static Grad operator --(Grad q) { return new Grad(q.m_value - 1d); }
        public static Grad operator -(Grad q) { return new Grad(-q.m_value); }
        public static Grad operator *(double lhs, Grad rhs) { return new Grad(lhs * rhs.m_value); }
        public static Grad operator *(Grad lhs, double rhs) { return new Grad(lhs.m_value * rhs); }
        public static Grad operator /(Grad lhs, double rhs) { return new Grad(lhs.m_value / rhs); }
        public static double operator /(Grad lhs, Grad rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Grad.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Grad.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Grad.Format, m_value, Grad.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Radian.Sense;
        private static readonly int s_family = Radian.Family;
        private static /*mutable*/ double s_factor = (200d / Math.PI) * Radian.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("grad");

        private static readonly Grad s_one = new Grad(1d);
        private static readonly Grad s_zero = new Grad(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Grad One { get { return s_one; } }
        public static Grad Zero { get { return s_zero; } }
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
        public static explicit operator Cycles(Grad q) { return new Cycles((Cycles.Factor / Grad.Factor) * q.m_value); }
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
        public static RPM operator /(Cycles lhs, Minute rhs) { return new RPM(lhs.m_value / rhs.m_value); }
        public static Minute operator /(Cycles lhs, RPM rhs) { return new Minute(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Cycles.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Cycles.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Cycles.Format, m_value, Cycles.Symbol[0]);
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
    public partial struct Steradian : IQuantity<double>, IEquatable<Steradian>, IComparable<Steradian>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Steradian.Family; } }
        double IQuantity<double>.Factor { get { return Steradian.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Steradian.Symbol; } }
        #endregion

        #region Constructor(s)
        public Steradian(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Steradian(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Steradian(double q) { return new Steradian(q); }
        public static Steradian From(IQuantity<double> q)
        {
            if (q.Family != Steradian.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Steradian\"", q.GetType().Name));
            return new Steradian((Steradian.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Steradian>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Steradian) && Equals((Steradian)obj); }
        public bool /* IEquatable<Steradian> */ Equals(Steradian other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Steradian>
        public static bool operator ==(Steradian lhs, Steradian rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Steradian lhs, Steradian rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Steradian lhs, Steradian rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Steradian lhs, Steradian rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Steradian lhs, Steradian rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Steradian lhs, Steradian rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Steradian> */ CompareTo(Steradian other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Steradian operator +(Steradian lhs, Steradian rhs) { return new Steradian(lhs.m_value + rhs.m_value); }
        public static Steradian operator -(Steradian lhs, Steradian rhs) { return new Steradian(lhs.m_value - rhs.m_value); }
        public static Steradian operator ++(Steradian q) { return new Steradian(q.m_value + 1d); }
        public static Steradian operator --(Steradian q) { return new Steradian(q.m_value - 1d); }
        public static Steradian operator -(Steradian q) { return new Steradian(-q.m_value); }
        public static Steradian operator *(double lhs, Steradian rhs) { return new Steradian(lhs * rhs.m_value); }
        public static Steradian operator *(Steradian lhs, double rhs) { return new Steradian(lhs.m_value * rhs); }
        public static Steradian operator /(Steradian lhs, double rhs) { return new Steradian(lhs.m_value / rhs); }
        public static double operator /(Steradian lhs, Steradian rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Steradian.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Steradian.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Steradian.Format, m_value, Steradian.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.None;
        private static readonly int s_family = 9;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("sr");

        private static readonly Steradian s_one = new Steradian(1d);
        private static readonly Steradian s_zero = new Steradian(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Steradian One { get { return s_one; } }
        public static Steradian Zero { get { return s_zero; } }
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
        public static explicit operator Hertz(Radian_Sec q) { return new Hertz((Hertz.Factor / Radian_Sec.Factor) * q.m_value); }
        public static explicit operator Hertz(RPM q) { return new Hertz((Hertz.Factor / RPM.Factor) * q.m_value); }
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
            return string.Format(fp, format ?? Hertz.Format, m_value, Hertz.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Cycles.Sense / Second.Sense;
        private static readonly int s_family = 10;
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
    public partial struct Radian_Sec : IQuantity<double>, IEquatable<Radian_Sec>, IComparable<Radian_Sec>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Radian_Sec.Family; } }
        double IQuantity<double>.Factor { get { return Radian_Sec.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Radian_Sec.Symbol; } }
        #endregion

        #region Constructor(s)
        public Radian_Sec(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Radian_Sec(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Radian_Sec(double q) { return new Radian_Sec(q); }
        public static explicit operator Radian_Sec(RPM q) { return new Radian_Sec((Radian_Sec.Factor / RPM.Factor) * q.m_value); }
        public static explicit operator Radian_Sec(Hertz q) { return new Radian_Sec((Radian_Sec.Factor / Hertz.Factor) * q.m_value); }
        public static Radian_Sec From(IQuantity<double> q)
        {
            if (q.Family != Radian_Sec.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Radian_Sec\"", q.GetType().Name));
            return new Radian_Sec((Radian_Sec.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Radian_Sec>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Radian_Sec) && Equals((Radian_Sec)obj); }
        public bool /* IEquatable<Radian_Sec> */ Equals(Radian_Sec other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Radian_Sec>
        public static bool operator ==(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Radian_Sec> */ CompareTo(Radian_Sec other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Radian_Sec operator +(Radian_Sec lhs, Radian_Sec rhs) { return new Radian_Sec(lhs.m_value + rhs.m_value); }
        public static Radian_Sec operator -(Radian_Sec lhs, Radian_Sec rhs) { return new Radian_Sec(lhs.m_value - rhs.m_value); }
        public static Radian_Sec operator ++(Radian_Sec q) { return new Radian_Sec(q.m_value + 1d); }
        public static Radian_Sec operator --(Radian_Sec q) { return new Radian_Sec(q.m_value - 1d); }
        public static Radian_Sec operator -(Radian_Sec q) { return new Radian_Sec(-q.m_value); }
        public static Radian_Sec operator *(double lhs, Radian_Sec rhs) { return new Radian_Sec(lhs * rhs.m_value); }
        public static Radian_Sec operator *(Radian_Sec lhs, double rhs) { return new Radian_Sec(lhs.m_value * rhs); }
        public static Radian_Sec operator /(Radian_Sec lhs, double rhs) { return new Radian_Sec(lhs.m_value / rhs); }
        public static double operator /(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Radian operator *(Radian_Sec lhs, Second rhs) { return new Radian(lhs.m_value * rhs.m_value); }
        public static Radian operator *(Second lhs, Radian_Sec rhs) { return new Radian(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Radian_Sec.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Radian_Sec.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Radian_Sec.Format, m_value, Radian_Sec.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Radian.Sense / Second.Sense;
        private static readonly int s_family = Hertz.Family;
        private static /*mutable*/ double s_factor = Radian.Factor / Second.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("rad/s");

        private static readonly Radian_Sec s_one = new Radian_Sec(1d);
        private static readonly Radian_Sec s_zero = new Radian_Sec(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Radian_Sec One { get { return s_one; } }
        public static Radian_Sec Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct RPM : IQuantity<double>, IEquatable<RPM>, IComparable<RPM>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return RPM.Family; } }
        double IQuantity<double>.Factor { get { return RPM.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return RPM.Symbol; } }
        #endregion

        #region Constructor(s)
        public RPM(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new RPM(value);
        }
        #endregion

        #region Conversions
        public static explicit operator RPM(double q) { return new RPM(q); }
        public static explicit operator RPM(Hertz q) { return new RPM((RPM.Factor / Hertz.Factor) * q.m_value); }
        public static explicit operator RPM(Radian_Sec q) { return new RPM((RPM.Factor / Radian_Sec.Factor) * q.m_value); }
        public static RPM From(IQuantity<double> q)
        {
            if (q.Family != RPM.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"RPM\"", q.GetType().Name));
            return new RPM((RPM.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<RPM>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is RPM) && Equals((RPM)obj); }
        public bool /* IEquatable<RPM> */ Equals(RPM other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<RPM>
        public static bool operator ==(RPM lhs, RPM rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(RPM lhs, RPM rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(RPM lhs, RPM rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(RPM lhs, RPM rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(RPM lhs, RPM rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(RPM lhs, RPM rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<RPM> */ CompareTo(RPM other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static RPM operator +(RPM lhs, RPM rhs) { return new RPM(lhs.m_value + rhs.m_value); }
        public static RPM operator -(RPM lhs, RPM rhs) { return new RPM(lhs.m_value - rhs.m_value); }
        public static RPM operator ++(RPM q) { return new RPM(q.m_value + 1d); }
        public static RPM operator --(RPM q) { return new RPM(q.m_value - 1d); }
        public static RPM operator -(RPM q) { return new RPM(-q.m_value); }
        public static RPM operator *(double lhs, RPM rhs) { return new RPM(lhs * rhs.m_value); }
        public static RPM operator *(RPM lhs, double rhs) { return new RPM(lhs.m_value * rhs); }
        public static RPM operator /(RPM lhs, double rhs) { return new RPM(lhs.m_value / rhs); }
        public static double operator /(RPM lhs, RPM rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Cycles operator *(RPM lhs, Minute rhs) { return new Cycles(lhs.m_value * rhs.m_value); }
        public static Cycles operator *(Minute lhs, RPM rhs) { return new Cycles(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(RPM.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(RPM.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? RPM.Format, m_value, RPM.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Cycles.Sense / Minute.Sense;
        private static readonly int s_family = Hertz.Family;
        private static /*mutable*/ double s_factor = Cycles.Factor / Minute.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("rpm");

        private static readonly RPM s_one = new RPM(1d);
        private static readonly RPM s_zero = new RPM(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static RPM One { get { return s_one; } }
        public static RPM Zero { get { return s_zero; } }
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
        public static explicit operator SquareMeter(SquareFoot q) { return new SquareMeter((SquareMeter.Factor / SquareFoot.Factor) * q.m_value); }
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
        public static CubicMeter operator *(SquareMeter lhs, Meter rhs) { return new CubicMeter(lhs.m_value * rhs.m_value); }
        public static CubicMeter operator *(Meter lhs, SquareMeter rhs) { return new CubicMeter(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(SquareMeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(SquareMeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? SquareMeter.Format, m_value, SquareMeter.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense * Meter.Sense;
        private static readonly int s_family = 11;
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
    public partial struct SquareFoot : IQuantity<double>, IEquatable<SquareFoot>, IComparable<SquareFoot>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return SquareFoot.Family; } }
        double IQuantity<double>.Factor { get { return SquareFoot.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return SquareFoot.Symbol; } }
        #endregion

        #region Constructor(s)
        public SquareFoot(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new SquareFoot(value);
        }
        #endregion

        #region Conversions
        public static explicit operator SquareFoot(double q) { return new SquareFoot(q); }
        public static explicit operator SquareFoot(SquareMeter q) { return new SquareFoot((SquareFoot.Factor / SquareMeter.Factor) * q.m_value); }
        public static SquareFoot From(IQuantity<double> q)
        {
            if (q.Family != SquareFoot.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"SquareFoot\"", q.GetType().Name));
            return new SquareFoot((SquareFoot.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<SquareFoot>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is SquareFoot) && Equals((SquareFoot)obj); }
        public bool /* IEquatable<SquareFoot> */ Equals(SquareFoot other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<SquareFoot>
        public static bool operator ==(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<SquareFoot> */ CompareTo(SquareFoot other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static SquareFoot operator +(SquareFoot lhs, SquareFoot rhs) { return new SquareFoot(lhs.m_value + rhs.m_value); }
        public static SquareFoot operator -(SquareFoot lhs, SquareFoot rhs) { return new SquareFoot(lhs.m_value - rhs.m_value); }
        public static SquareFoot operator ++(SquareFoot q) { return new SquareFoot(q.m_value + 1d); }
        public static SquareFoot operator --(SquareFoot q) { return new SquareFoot(q.m_value - 1d); }
        public static SquareFoot operator -(SquareFoot q) { return new SquareFoot(-q.m_value); }
        public static SquareFoot operator *(double lhs, SquareFoot rhs) { return new SquareFoot(lhs * rhs.m_value); }
        public static SquareFoot operator *(SquareFoot lhs, double rhs) { return new SquareFoot(lhs.m_value * rhs); }
        public static SquareFoot operator /(SquareFoot lhs, double rhs) { return new SquareFoot(lhs.m_value / rhs); }
        public static double operator /(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Foot operator /(SquareFoot lhs, Foot rhs) { return new Foot(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(SquareFoot.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(SquareFoot.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? SquareFoot.Format, m_value, SquareFoot.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Foot.Sense * Foot.Sense;
        private static readonly int s_family = SquareMeter.Family;
        private static /*mutable*/ double s_factor = Foot.Factor * Foot.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("ft\u00B2", "sq ft");

        private static readonly SquareFoot s_one = new SquareFoot(1d);
        private static readonly SquareFoot s_zero = new SquareFoot(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static SquareFoot One { get { return s_one; } }
        public static SquareFoot Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct CubicMeter : IQuantity<double>, IEquatable<CubicMeter>, IComparable<CubicMeter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return CubicMeter.Family; } }
        double IQuantity<double>.Factor { get { return CubicMeter.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return CubicMeter.Symbol; } }
        #endregion

        #region Constructor(s)
        public CubicMeter(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new CubicMeter(value);
        }
        #endregion

        #region Conversions
        public static explicit operator CubicMeter(double q) { return new CubicMeter(q); }
        public static CubicMeter From(IQuantity<double> q)
        {
            if (q.Family != CubicMeter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"CubicMeter\"", q.GetType().Name));
            return new CubicMeter((CubicMeter.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<CubicMeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is CubicMeter) && Equals((CubicMeter)obj); }
        public bool /* IEquatable<CubicMeter> */ Equals(CubicMeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<CubicMeter>
        public static bool operator ==(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<CubicMeter> */ CompareTo(CubicMeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static CubicMeter operator +(CubicMeter lhs, CubicMeter rhs) { return new CubicMeter(lhs.m_value + rhs.m_value); }
        public static CubicMeter operator -(CubicMeter lhs, CubicMeter rhs) { return new CubicMeter(lhs.m_value - rhs.m_value); }
        public static CubicMeter operator ++(CubicMeter q) { return new CubicMeter(q.m_value + 1d); }
        public static CubicMeter operator --(CubicMeter q) { return new CubicMeter(q.m_value - 1d); }
        public static CubicMeter operator -(CubicMeter q) { return new CubicMeter(-q.m_value); }
        public static CubicMeter operator *(double lhs, CubicMeter rhs) { return new CubicMeter(lhs * rhs.m_value); }
        public static CubicMeter operator *(CubicMeter lhs, double rhs) { return new CubicMeter(lhs.m_value * rhs); }
        public static CubicMeter operator /(CubicMeter lhs, double rhs) { return new CubicMeter(lhs.m_value / rhs); }
        public static double operator /(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator /(CubicMeter lhs, SquareMeter rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        public static SquareMeter operator /(CubicMeter lhs, Meter rhs) { return new SquareMeter(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(CubicMeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(CubicMeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? CubicMeter.Format, m_value, CubicMeter.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = SquareMeter.Sense * Meter.Sense;
        private static readonly int s_family = 12;
        private static /*mutable*/ double s_factor = SquareMeter.Factor * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m\u00B3", "m3");

        private static readonly CubicMeter s_one = new CubicMeter(1d);
        private static readonly CubicMeter s_zero = new CubicMeter(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static CubicMeter One { get { return s_one; } }
        public static CubicMeter Zero { get { return s_zero; } }
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
        public static explicit operator Meter_Sec(MPH q) { return new Meter_Sec((Meter_Sec.Factor / MPH.Factor) * q.m_value); }
        public static explicit operator Meter_Sec(Kilometer_Hour q) { return new Meter_Sec((Meter_Sec.Factor / Kilometer_Hour.Factor) * q.m_value); }
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
        public static Meter2_Sec2 operator *(Meter_Sec lhs, Meter_Sec rhs) { return new Meter2_Sec2(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter_Sec.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter_Sec.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Meter_Sec.Format, m_value, Meter_Sec.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense / Second.Sense;
        private static readonly int s_family = 13;
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
    public partial struct Kilometer_Hour : IQuantity<double>, IEquatable<Kilometer_Hour>, IComparable<Kilometer_Hour>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Kilometer_Hour.Family; } }
        double IQuantity<double>.Factor { get { return Kilometer_Hour.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Kilometer_Hour.Symbol; } }
        #endregion

        #region Constructor(s)
        public Kilometer_Hour(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Kilometer_Hour(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Kilometer_Hour(double q) { return new Kilometer_Hour(q); }
        public static explicit operator Kilometer_Hour(Meter_Sec q) { return new Kilometer_Hour((Kilometer_Hour.Factor / Meter_Sec.Factor) * q.m_value); }
        public static explicit operator Kilometer_Hour(MPH q) { return new Kilometer_Hour((Kilometer_Hour.Factor / MPH.Factor) * q.m_value); }
        public static Kilometer_Hour From(IQuantity<double> q)
        {
            if (q.Family != Kilometer_Hour.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kilometer_Hour\"", q.GetType().Name));
            return new Kilometer_Hour((Kilometer_Hour.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Kilometer_Hour>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Kilometer_Hour) && Equals((Kilometer_Hour)obj); }
        public bool /* IEquatable<Kilometer_Hour> */ Equals(Kilometer_Hour other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Kilometer_Hour>
        public static bool operator ==(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Kilometer_Hour> */ CompareTo(Kilometer_Hour other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Kilometer_Hour operator +(Kilometer_Hour lhs, Kilometer_Hour rhs) { return new Kilometer_Hour(lhs.m_value + rhs.m_value); }
        public static Kilometer_Hour operator -(Kilometer_Hour lhs, Kilometer_Hour rhs) { return new Kilometer_Hour(lhs.m_value - rhs.m_value); }
        public static Kilometer_Hour operator ++(Kilometer_Hour q) { return new Kilometer_Hour(q.m_value + 1d); }
        public static Kilometer_Hour operator --(Kilometer_Hour q) { return new Kilometer_Hour(q.m_value - 1d); }
        public static Kilometer_Hour operator -(Kilometer_Hour q) { return new Kilometer_Hour(-q.m_value); }
        public static Kilometer_Hour operator *(double lhs, Kilometer_Hour rhs) { return new Kilometer_Hour(lhs * rhs.m_value); }
        public static Kilometer_Hour operator *(Kilometer_Hour lhs, double rhs) { return new Kilometer_Hour(lhs.m_value * rhs); }
        public static Kilometer_Hour operator /(Kilometer_Hour lhs, double rhs) { return new Kilometer_Hour(lhs.m_value / rhs); }
        public static double operator /(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Kilometer operator *(Kilometer_Hour lhs, Hour rhs) { return new Kilometer(lhs.m_value * rhs.m_value); }
        public static Kilometer operator *(Hour lhs, Kilometer_Hour rhs) { return new Kilometer(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Kilometer_Hour.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Kilometer_Hour.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Kilometer_Hour.Format, m_value, Kilometer_Hour.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilometer.Sense / Hour.Sense;
        private static readonly int s_family = Meter_Sec.Family;
        private static /*mutable*/ double s_factor = Kilometer.Factor / Hour.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("km/h");

        private static readonly Kilometer_Hour s_one = new Kilometer_Hour(1d);
        private static readonly Kilometer_Hour s_zero = new Kilometer_Hour(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Kilometer_Hour One { get { return s_one; } }
        public static Kilometer_Hour Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct MPH : IQuantity<double>, IEquatable<MPH>, IComparable<MPH>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return MPH.Family; } }
        double IQuantity<double>.Factor { get { return MPH.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return MPH.Symbol; } }
        #endregion

        #region Constructor(s)
        public MPH(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new MPH(value);
        }
        #endregion

        #region Conversions
        public static explicit operator MPH(double q) { return new MPH(q); }
        public static explicit operator MPH(Kilometer_Hour q) { return new MPH((MPH.Factor / Kilometer_Hour.Factor) * q.m_value); }
        public static explicit operator MPH(Meter_Sec q) { return new MPH((MPH.Factor / Meter_Sec.Factor) * q.m_value); }
        public static MPH From(IQuantity<double> q)
        {
            if (q.Family != MPH.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"MPH\"", q.GetType().Name));
            return new MPH((MPH.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<MPH>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is MPH) && Equals((MPH)obj); }
        public bool /* IEquatable<MPH> */ Equals(MPH other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<MPH>
        public static bool operator ==(MPH lhs, MPH rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(MPH lhs, MPH rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(MPH lhs, MPH rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(MPH lhs, MPH rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(MPH lhs, MPH rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(MPH lhs, MPH rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<MPH> */ CompareTo(MPH other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static MPH operator +(MPH lhs, MPH rhs) { return new MPH(lhs.m_value + rhs.m_value); }
        public static MPH operator -(MPH lhs, MPH rhs) { return new MPH(lhs.m_value - rhs.m_value); }
        public static MPH operator ++(MPH q) { return new MPH(q.m_value + 1d); }
        public static MPH operator --(MPH q) { return new MPH(q.m_value - 1d); }
        public static MPH operator -(MPH q) { return new MPH(-q.m_value); }
        public static MPH operator *(double lhs, MPH rhs) { return new MPH(lhs * rhs.m_value); }
        public static MPH operator *(MPH lhs, double rhs) { return new MPH(lhs.m_value * rhs); }
        public static MPH operator /(MPH lhs, double rhs) { return new MPH(lhs.m_value / rhs); }
        public static double operator /(MPH lhs, MPH rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Mile operator *(MPH lhs, Hour rhs) { return new Mile(lhs.m_value * rhs.m_value); }
        public static Mile operator *(Hour lhs, MPH rhs) { return new Mile(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(MPH.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(MPH.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? MPH.Format, m_value, MPH.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Mile.Sense / Hour.Sense;
        private static readonly int s_family = Meter_Sec.Family;
        private static /*mutable*/ double s_factor = Mile.Factor / Hour.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mph", "mi/h");

        private static readonly MPH s_one = new MPH(1d);
        private static readonly MPH s_zero = new MPH(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static MPH One { get { return s_one; } }
        public static MPH Zero { get { return s_zero; } }
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
        public static Meter2_Sec2 operator *(Meter_Sec2 lhs, Meter rhs) { return new Meter2_Sec2(lhs.m_value * rhs.m_value); }
        public static Meter2_Sec2 operator *(Meter lhs, Meter_Sec2 rhs) { return new Meter2_Sec2(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter_Sec2.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter_Sec2.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Meter_Sec2.Format, m_value, Meter_Sec2.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter_Sec.Sense / Second.Sense;
        private static readonly int s_family = 14;
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
        public static explicit operator Newton(Dyne q) { return new Newton((Newton.Factor / Dyne.Factor) * q.m_value); }
        public static explicit operator Newton(Poundal q) { return new Newton((Newton.Factor / Poundal.Factor) * q.m_value); }
        public static explicit operator Newton(PoundForce q) { return new Newton((Newton.Factor / PoundForce.Factor) * q.m_value); }
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
        public static Pascal operator /(Newton lhs, SquareMeter rhs) { return new Pascal(lhs.m_value / rhs.m_value); }
        public static SquareMeter operator /(Newton lhs, Pascal rhs) { return new SquareMeter(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Newton.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Newton.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Newton.Format, m_value, Newton.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense * Meter_Sec2.Sense;
        private static readonly int s_family = 15;
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
    public partial struct PoundForce : IQuantity<double>, IEquatable<PoundForce>, IComparable<PoundForce>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return PoundForce.Family; } }
        double IQuantity<double>.Factor { get { return PoundForce.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return PoundForce.Symbol; } }
        #endregion

        #region Constructor(s)
        public PoundForce(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new PoundForce(value);
        }
        #endregion

        #region Conversions
        public static explicit operator PoundForce(double q) { return new PoundForce(q); }
        public static explicit operator PoundForce(Newton q) { return new PoundForce((PoundForce.Factor / Newton.Factor) * q.m_value); }
        public static explicit operator PoundForce(Dyne q) { return new PoundForce((PoundForce.Factor / Dyne.Factor) * q.m_value); }
        public static explicit operator PoundForce(Poundal q) { return new PoundForce((PoundForce.Factor / Poundal.Factor) * q.m_value); }
        public static PoundForce From(IQuantity<double> q)
        {
            if (q.Family != PoundForce.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"PoundForce\"", q.GetType().Name));
            return new PoundForce((PoundForce.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<PoundForce>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is PoundForce) && Equals((PoundForce)obj); }
        public bool /* IEquatable<PoundForce> */ Equals(PoundForce other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<PoundForce>
        public static bool operator ==(PoundForce lhs, PoundForce rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(PoundForce lhs, PoundForce rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(PoundForce lhs, PoundForce rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(PoundForce lhs, PoundForce rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(PoundForce lhs, PoundForce rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(PoundForce lhs, PoundForce rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<PoundForce> */ CompareTo(PoundForce other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static PoundForce operator +(PoundForce lhs, PoundForce rhs) { return new PoundForce(lhs.m_value + rhs.m_value); }
        public static PoundForce operator -(PoundForce lhs, PoundForce rhs) { return new PoundForce(lhs.m_value - rhs.m_value); }
        public static PoundForce operator ++(PoundForce q) { return new PoundForce(q.m_value + 1d); }
        public static PoundForce operator --(PoundForce q) { return new PoundForce(q.m_value - 1d); }
        public static PoundForce operator -(PoundForce q) { return new PoundForce(-q.m_value); }
        public static PoundForce operator *(double lhs, PoundForce rhs) { return new PoundForce(lhs * rhs.m_value); }
        public static PoundForce operator *(PoundForce lhs, double rhs) { return new PoundForce(lhs.m_value * rhs); }
        public static PoundForce operator /(PoundForce lhs, double rhs) { return new PoundForce(lhs.m_value / rhs); }
        public static double operator /(PoundForce lhs, PoundForce rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(PoundForce.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(PoundForce.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? PoundForce.Format, m_value, PoundForce.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense;
        private static readonly int s_family = Newton.Family;
        private static /*mutable*/ double s_factor = Newton.Factor / 4.4482216152605d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("lbf");

        private static readonly PoundForce s_one = new PoundForce(1d);
        private static readonly PoundForce s_zero = new PoundForce(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static PoundForce One { get { return s_one; } }
        public static PoundForce Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Poundal : IQuantity<double>, IEquatable<Poundal>, IComparable<Poundal>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Poundal.Family; } }
        double IQuantity<double>.Factor { get { return Poundal.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Poundal.Symbol; } }
        #endregion

        #region Constructor(s)
        public Poundal(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Poundal(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Poundal(double q) { return new Poundal(q); }
        public static explicit operator Poundal(PoundForce q) { return new Poundal((Poundal.Factor / PoundForce.Factor) * q.m_value); }
        public static explicit operator Poundal(Newton q) { return new Poundal((Poundal.Factor / Newton.Factor) * q.m_value); }
        public static explicit operator Poundal(Dyne q) { return new Poundal((Poundal.Factor / Dyne.Factor) * q.m_value); }
        public static Poundal From(IQuantity<double> q)
        {
            if (q.Family != Poundal.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Poundal\"", q.GetType().Name));
            return new Poundal((Poundal.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Poundal>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Poundal) && Equals((Poundal)obj); }
        public bool /* IEquatable<Poundal> */ Equals(Poundal other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Poundal>
        public static bool operator ==(Poundal lhs, Poundal rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Poundal lhs, Poundal rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Poundal lhs, Poundal rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Poundal lhs, Poundal rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Poundal lhs, Poundal rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Poundal lhs, Poundal rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Poundal> */ CompareTo(Poundal other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Poundal operator +(Poundal lhs, Poundal rhs) { return new Poundal(lhs.m_value + rhs.m_value); }
        public static Poundal operator -(Poundal lhs, Poundal rhs) { return new Poundal(lhs.m_value - rhs.m_value); }
        public static Poundal operator ++(Poundal q) { return new Poundal(q.m_value + 1d); }
        public static Poundal operator --(Poundal q) { return new Poundal(q.m_value - 1d); }
        public static Poundal operator -(Poundal q) { return new Poundal(-q.m_value); }
        public static Poundal operator *(double lhs, Poundal rhs) { return new Poundal(lhs * rhs.m_value); }
        public static Poundal operator *(Poundal lhs, double rhs) { return new Poundal(lhs.m_value * rhs); }
        public static Poundal operator /(Poundal lhs, double rhs) { return new Poundal(lhs.m_value / rhs); }
        public static double operator /(Poundal lhs, Poundal rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Poundal.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Poundal.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Poundal.Format, m_value, Poundal.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense;
        private static readonly int s_family = Newton.Family;
        private static /*mutable*/ double s_factor = Newton.Factor / 0.138254954376d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("pdl");

        private static readonly Poundal s_one = new Poundal(1d);
        private static readonly Poundal s_zero = new Poundal(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Poundal One { get { return s_one; } }
        public static Poundal Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Dyne : IQuantity<double>, IEquatable<Dyne>, IComparable<Dyne>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Dyne.Family; } }
        double IQuantity<double>.Factor { get { return Dyne.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Dyne.Symbol; } }
        #endregion

        #region Constructor(s)
        public Dyne(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Dyne(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Dyne(double q) { return new Dyne(q); }
        public static explicit operator Dyne(Poundal q) { return new Dyne((Dyne.Factor / Poundal.Factor) * q.m_value); }
        public static explicit operator Dyne(PoundForce q) { return new Dyne((Dyne.Factor / PoundForce.Factor) * q.m_value); }
        public static explicit operator Dyne(Newton q) { return new Dyne((Dyne.Factor / Newton.Factor) * q.m_value); }
        public static Dyne From(IQuantity<double> q)
        {
            if (q.Family != Dyne.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Dyne\"", q.GetType().Name));
            return new Dyne((Dyne.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Dyne>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Dyne) && Equals((Dyne)obj); }
        public bool /* IEquatable<Dyne> */ Equals(Dyne other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Dyne>
        public static bool operator ==(Dyne lhs, Dyne rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Dyne lhs, Dyne rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Dyne lhs, Dyne rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Dyne lhs, Dyne rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Dyne lhs, Dyne rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Dyne lhs, Dyne rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Dyne> */ CompareTo(Dyne other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Dyne operator +(Dyne lhs, Dyne rhs) { return new Dyne(lhs.m_value + rhs.m_value); }
        public static Dyne operator -(Dyne lhs, Dyne rhs) { return new Dyne(lhs.m_value - rhs.m_value); }
        public static Dyne operator ++(Dyne q) { return new Dyne(q.m_value + 1d); }
        public static Dyne operator --(Dyne q) { return new Dyne(q.m_value - 1d); }
        public static Dyne operator -(Dyne q) { return new Dyne(-q.m_value); }
        public static Dyne operator *(double lhs, Dyne rhs) { return new Dyne(lhs * rhs.m_value); }
        public static Dyne operator *(Dyne lhs, double rhs) { return new Dyne(lhs.m_value * rhs); }
        public static Dyne operator /(Dyne lhs, double rhs) { return new Dyne(lhs.m_value / rhs); }
        public static double operator /(Dyne lhs, Dyne rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Dyne.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Dyne.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Dyne.Format, m_value, Dyne.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense;
        private static readonly int s_family = Newton.Family;
        private static /*mutable*/ double s_factor = 100000d * Newton.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("dyn");

        private static readonly Dyne s_one = new Dyne(1d);
        private static readonly Dyne s_zero = new Dyne(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Dyne One { get { return s_one; } }
        public static Dyne Zero { get { return s_zero; } }
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
        public static Watt operator /(Joule lhs, Second rhs) { return new Watt(lhs.m_value / rhs.m_value); }
        public static Second operator /(Joule lhs, Watt rhs) { return new Second(lhs.m_value / rhs.m_value); }
        public static Joule_Kelvin operator /(Joule lhs, DegKelvin rhs) { return new Joule_Kelvin(lhs.m_value / rhs.m_value); }
        public static DegKelvin operator /(Joule lhs, Joule_Kelvin rhs) { return new DegKelvin(lhs.m_value / rhs.m_value); }
        public static Volt operator /(Joule lhs, Coulomb rhs) { return new Volt(lhs.m_value / rhs.m_value); }
        public static Coulomb operator /(Joule lhs, Volt rhs) { return new Coulomb(lhs.m_value / rhs.m_value); }
        public static Weber operator /(Joule lhs, Ampere rhs) { return new Weber(lhs.m_value / rhs.m_value); }
        public static Ampere operator /(Joule lhs, Weber rhs) { return new Ampere(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Joule.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Joule.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Joule.Format, m_value, Joule.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense * Meter.Sense;
        private static readonly int s_family = 16;
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
    public partial struct Watt : IQuantity<double>, IEquatable<Watt>, IComparable<Watt>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Watt.Family; } }
        double IQuantity<double>.Factor { get { return Watt.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Watt.Symbol; } }
        #endregion

        #region Constructor(s)
        public Watt(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Watt(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Watt(double q) { return new Watt(q); }
        public static Watt From(IQuantity<double> q)
        {
            if (q.Family != Watt.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Watt\"", q.GetType().Name));
            return new Watt((Watt.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Watt>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Watt) && Equals((Watt)obj); }
        public bool /* IEquatable<Watt> */ Equals(Watt other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Watt>
        public static bool operator ==(Watt lhs, Watt rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Watt lhs, Watt rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Watt lhs, Watt rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Watt lhs, Watt rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Watt lhs, Watt rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Watt lhs, Watt rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Watt> */ CompareTo(Watt other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Watt operator +(Watt lhs, Watt rhs) { return new Watt(lhs.m_value + rhs.m_value); }
        public static Watt operator -(Watt lhs, Watt rhs) { return new Watt(lhs.m_value - rhs.m_value); }
        public static Watt operator ++(Watt q) { return new Watt(q.m_value + 1d); }
        public static Watt operator --(Watt q) { return new Watt(q.m_value - 1d); }
        public static Watt operator -(Watt q) { return new Watt(-q.m_value); }
        public static Watt operator *(double lhs, Watt rhs) { return new Watt(lhs * rhs.m_value); }
        public static Watt operator *(Watt lhs, double rhs) { return new Watt(lhs.m_value * rhs); }
        public static Watt operator /(Watt lhs, double rhs) { return new Watt(lhs.m_value / rhs); }
        public static double operator /(Watt lhs, Watt rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Joule operator *(Watt lhs, Second rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule operator *(Second lhs, Watt rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Volt operator /(Watt lhs, Ampere rhs) { return new Volt(lhs.m_value / rhs.m_value); }
        public static Ampere operator /(Watt lhs, Volt rhs) { return new Ampere(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Watt.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Watt.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Watt.Format, m_value, Watt.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Joule.Sense / Second.Sense;
        private static readonly int s_family = 17;
        private static /*mutable*/ double s_factor = Joule.Factor / Second.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("W");

        private static readonly Watt s_one = new Watt(1d);
        private static readonly Watt s_zero = new Watt(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Watt One { get { return s_one; } }
        public static Watt Zero { get { return s_zero; } }
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
            return string.Format(fp, format ?? NewtonMeter.Format, m_value, NewtonMeter.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense * Meter.Sense;
        private static readonly int s_family = 18;
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
    public partial struct Joule_Kelvin : IQuantity<double>, IEquatable<Joule_Kelvin>, IComparable<Joule_Kelvin>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Joule_Kelvin.Family; } }
        double IQuantity<double>.Factor { get { return Joule_Kelvin.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Joule_Kelvin.Symbol; } }
        #endregion

        #region Constructor(s)
        public Joule_Kelvin(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Joule_Kelvin(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Joule_Kelvin(double q) { return new Joule_Kelvin(q); }
        public static Joule_Kelvin From(IQuantity<double> q)
        {
            if (q.Family != Joule_Kelvin.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Joule_Kelvin\"", q.GetType().Name));
            return new Joule_Kelvin((Joule_Kelvin.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Joule_Kelvin>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Joule_Kelvin) && Equals((Joule_Kelvin)obj); }
        public bool /* IEquatable<Joule_Kelvin> */ Equals(Joule_Kelvin other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Joule_Kelvin>
        public static bool operator ==(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Joule_Kelvin> */ CompareTo(Joule_Kelvin other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule_Kelvin operator +(Joule_Kelvin lhs, Joule_Kelvin rhs) { return new Joule_Kelvin(lhs.m_value + rhs.m_value); }
        public static Joule_Kelvin operator -(Joule_Kelvin lhs, Joule_Kelvin rhs) { return new Joule_Kelvin(lhs.m_value - rhs.m_value); }
        public static Joule_Kelvin operator ++(Joule_Kelvin q) { return new Joule_Kelvin(q.m_value + 1d); }
        public static Joule_Kelvin operator --(Joule_Kelvin q) { return new Joule_Kelvin(q.m_value - 1d); }
        public static Joule_Kelvin operator -(Joule_Kelvin q) { return new Joule_Kelvin(-q.m_value); }
        public static Joule_Kelvin operator *(double lhs, Joule_Kelvin rhs) { return new Joule_Kelvin(lhs * rhs.m_value); }
        public static Joule_Kelvin operator *(Joule_Kelvin lhs, double rhs) { return new Joule_Kelvin(lhs.m_value * rhs); }
        public static Joule_Kelvin operator /(Joule_Kelvin lhs, double rhs) { return new Joule_Kelvin(lhs.m_value / rhs); }
        public static double operator /(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Joule operator *(Joule_Kelvin lhs, DegKelvin rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule operator *(DegKelvin lhs, Joule_Kelvin rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule_Kelvin_Kilogram operator /(Joule_Kelvin lhs, Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs.m_value / rhs.m_value); }
        public static Kilogram operator /(Joule_Kelvin lhs, Joule_Kelvin_Kilogram rhs) { return new Kilogram(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Joule_Kelvin.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Joule_Kelvin.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Joule_Kelvin.Format, m_value, Joule_Kelvin.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Joule.Sense / DegKelvin.Sense;
        private static readonly int s_family = 19;
        private static /*mutable*/ double s_factor = Joule.Factor / DegKelvin.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("J/K");

        private static readonly Joule_Kelvin s_one = new Joule_Kelvin(1d);
        private static readonly Joule_Kelvin s_zero = new Joule_Kelvin(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Joule_Kelvin One { get { return s_one; } }
        public static Joule_Kelvin Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Joule_Kelvin_Kilogram : IQuantity<double>, IEquatable<Joule_Kelvin_Kilogram>, IComparable<Joule_Kelvin_Kilogram>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Joule_Kelvin_Kilogram.Family; } }
        double IQuantity<double>.Factor { get { return Joule_Kelvin_Kilogram.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Joule_Kelvin_Kilogram.Symbol; } }
        #endregion

        #region Constructor(s)
        public Joule_Kelvin_Kilogram(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Joule_Kelvin_Kilogram(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Joule_Kelvin_Kilogram(double q) { return new Joule_Kelvin_Kilogram(q); }
        public static Joule_Kelvin_Kilogram From(IQuantity<double> q)
        {
            if (q.Family != Joule_Kelvin_Kilogram.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Joule_Kelvin_Kilogram\"", q.GetType().Name));
            return new Joule_Kelvin_Kilogram((Joule_Kelvin_Kilogram.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Joule_Kelvin_Kilogram>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Joule_Kelvin_Kilogram) && Equals((Joule_Kelvin_Kilogram)obj); }
        public bool /* IEquatable<Joule_Kelvin_Kilogram> */ Equals(Joule_Kelvin_Kilogram other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Joule_Kelvin_Kilogram>
        public static bool operator ==(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Joule_Kelvin_Kilogram> */ CompareTo(Joule_Kelvin_Kilogram other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule_Kelvin_Kilogram operator +(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs.m_value + rhs.m_value); }
        public static Joule_Kelvin_Kilogram operator -(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs.m_value - rhs.m_value); }
        public static Joule_Kelvin_Kilogram operator ++(Joule_Kelvin_Kilogram q) { return new Joule_Kelvin_Kilogram(q.m_value + 1d); }
        public static Joule_Kelvin_Kilogram operator --(Joule_Kelvin_Kilogram q) { return new Joule_Kelvin_Kilogram(q.m_value - 1d); }
        public static Joule_Kelvin_Kilogram operator -(Joule_Kelvin_Kilogram q) { return new Joule_Kelvin_Kilogram(-q.m_value); }
        public static Joule_Kelvin_Kilogram operator *(double lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs * rhs.m_value); }
        public static Joule_Kelvin_Kilogram operator *(Joule_Kelvin_Kilogram lhs, double rhs) { return new Joule_Kelvin_Kilogram(lhs.m_value * rhs); }
        public static Joule_Kelvin_Kilogram operator /(Joule_Kelvin_Kilogram lhs, double rhs) { return new Joule_Kelvin_Kilogram(lhs.m_value / rhs); }
        public static double operator /(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Joule_Kelvin operator *(Joule_Kelvin_Kilogram lhs, Kilogram rhs) { return new Joule_Kelvin(lhs.m_value * rhs.m_value); }
        public static Joule_Kelvin operator *(Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Joule_Kelvin_Kilogram.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Joule_Kelvin_Kilogram.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Joule_Kelvin_Kilogram.Format, m_value, Joule_Kelvin_Kilogram.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Joule_Kelvin.Sense / Kilogram.Sense;
        private static readonly int s_family = 20;
        private static /*mutable*/ double s_factor = Joule_Kelvin.Factor / Kilogram.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("J/kg/K");

        private static readonly Joule_Kelvin_Kilogram s_one = new Joule_Kelvin_Kilogram(1d);
        private static readonly Joule_Kelvin_Kilogram s_zero = new Joule_Kelvin_Kilogram(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Joule_Kelvin_Kilogram One { get { return s_one; } }
        public static Joule_Kelvin_Kilogram Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Pascal : IQuantity<double>, IEquatable<Pascal>, IComparable<Pascal>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Pascal.Family; } }
        double IQuantity<double>.Factor { get { return Pascal.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Pascal.Symbol; } }
        #endregion

        #region Constructor(s)
        public Pascal(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Pascal(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Pascal(double q) { return new Pascal(q); }
        public static explicit operator Pascal(MillimeterHg q) { return new Pascal((Pascal.Factor / MillimeterHg.Factor) * q.m_value); }
        public static explicit operator Pascal(AtmStandard q) { return new Pascal((Pascal.Factor / AtmStandard.Factor) * q.m_value); }
        public static explicit operator Pascal(AtmTechnical q) { return new Pascal((Pascal.Factor / AtmTechnical.Factor) * q.m_value); }
        public static explicit operator Pascal(Bar q) { return new Pascal((Pascal.Factor / Bar.Factor) * q.m_value); }
        public static Pascal From(IQuantity<double> q)
        {
            if (q.Family != Pascal.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Pascal\"", q.GetType().Name));
            return new Pascal((Pascal.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Pascal>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Pascal) && Equals((Pascal)obj); }
        public bool /* IEquatable<Pascal> */ Equals(Pascal other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Pascal>
        public static bool operator ==(Pascal lhs, Pascal rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Pascal lhs, Pascal rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Pascal lhs, Pascal rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Pascal lhs, Pascal rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Pascal lhs, Pascal rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Pascal lhs, Pascal rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Pascal> */ CompareTo(Pascal other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Pascal operator +(Pascal lhs, Pascal rhs) { return new Pascal(lhs.m_value + rhs.m_value); }
        public static Pascal operator -(Pascal lhs, Pascal rhs) { return new Pascal(lhs.m_value - rhs.m_value); }
        public static Pascal operator ++(Pascal q) { return new Pascal(q.m_value + 1d); }
        public static Pascal operator --(Pascal q) { return new Pascal(q.m_value - 1d); }
        public static Pascal operator -(Pascal q) { return new Pascal(-q.m_value); }
        public static Pascal operator *(double lhs, Pascal rhs) { return new Pascal(lhs * rhs.m_value); }
        public static Pascal operator *(Pascal lhs, double rhs) { return new Pascal(lhs.m_value * rhs); }
        public static Pascal operator /(Pascal lhs, double rhs) { return new Pascal(lhs.m_value / rhs); }
        public static double operator /(Pascal lhs, Pascal rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Newton operator *(Pascal lhs, SquareMeter rhs) { return new Newton(lhs.m_value * rhs.m_value); }
        public static Newton operator *(SquareMeter lhs, Pascal rhs) { return new Newton(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Pascal.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Pascal.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Pascal.Format, m_value, Pascal.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense / SquareMeter.Sense;
        private static readonly int s_family = 21;
        private static /*mutable*/ double s_factor = Newton.Factor / SquareMeter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("Pa");

        private static readonly Pascal s_one = new Pascal(1d);
        private static readonly Pascal s_zero = new Pascal(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Pascal One { get { return s_one; } }
        public static Pascal Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Bar : IQuantity<double>, IEquatable<Bar>, IComparable<Bar>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Bar.Family; } }
        double IQuantity<double>.Factor { get { return Bar.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Bar.Symbol; } }
        #endregion

        #region Constructor(s)
        public Bar(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Bar(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Bar(double q) { return new Bar(q); }
        public static explicit operator Bar(Pascal q) { return new Bar((Bar.Factor / Pascal.Factor) * q.m_value); }
        public static explicit operator Bar(MillimeterHg q) { return new Bar((Bar.Factor / MillimeterHg.Factor) * q.m_value); }
        public static explicit operator Bar(AtmStandard q) { return new Bar((Bar.Factor / AtmStandard.Factor) * q.m_value); }
        public static explicit operator Bar(AtmTechnical q) { return new Bar((Bar.Factor / AtmTechnical.Factor) * q.m_value); }
        public static Bar From(IQuantity<double> q)
        {
            if (q.Family != Bar.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Bar\"", q.GetType().Name));
            return new Bar((Bar.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Bar>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Bar) && Equals((Bar)obj); }
        public bool /* IEquatable<Bar> */ Equals(Bar other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Bar>
        public static bool operator ==(Bar lhs, Bar rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Bar lhs, Bar rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Bar lhs, Bar rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Bar lhs, Bar rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Bar lhs, Bar rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Bar lhs, Bar rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Bar> */ CompareTo(Bar other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Bar operator +(Bar lhs, Bar rhs) { return new Bar(lhs.m_value + rhs.m_value); }
        public static Bar operator -(Bar lhs, Bar rhs) { return new Bar(lhs.m_value - rhs.m_value); }
        public static Bar operator ++(Bar q) { return new Bar(q.m_value + 1d); }
        public static Bar operator --(Bar q) { return new Bar(q.m_value - 1d); }
        public static Bar operator -(Bar q) { return new Bar(-q.m_value); }
        public static Bar operator *(double lhs, Bar rhs) { return new Bar(lhs * rhs.m_value); }
        public static Bar operator *(Bar lhs, double rhs) { return new Bar(lhs.m_value * rhs); }
        public static Bar operator /(Bar lhs, double rhs) { return new Bar(lhs.m_value / rhs); }
        public static double operator /(Bar lhs, Bar rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Bar.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Bar.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Bar.Format, m_value, Bar.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Pascal.Sense;
        private static readonly int s_family = Pascal.Family;
        private static /*mutable*/ double s_factor = Pascal.Factor / 100000d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("bar");

        private static readonly Bar s_one = new Bar(1d);
        private static readonly Bar s_zero = new Bar(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Bar One { get { return s_one; } }
        public static Bar Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct AtmTechnical : IQuantity<double>, IEquatable<AtmTechnical>, IComparable<AtmTechnical>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return AtmTechnical.Family; } }
        double IQuantity<double>.Factor { get { return AtmTechnical.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return AtmTechnical.Symbol; } }
        #endregion

        #region Constructor(s)
        public AtmTechnical(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new AtmTechnical(value);
        }
        #endregion

        #region Conversions
        public static explicit operator AtmTechnical(double q) { return new AtmTechnical(q); }
        public static explicit operator AtmTechnical(Bar q) { return new AtmTechnical((AtmTechnical.Factor / Bar.Factor) * q.m_value); }
        public static explicit operator AtmTechnical(Pascal q) { return new AtmTechnical((AtmTechnical.Factor / Pascal.Factor) * q.m_value); }
        public static explicit operator AtmTechnical(MillimeterHg q) { return new AtmTechnical((AtmTechnical.Factor / MillimeterHg.Factor) * q.m_value); }
        public static explicit operator AtmTechnical(AtmStandard q) { return new AtmTechnical((AtmTechnical.Factor / AtmStandard.Factor) * q.m_value); }
        public static AtmTechnical From(IQuantity<double> q)
        {
            if (q.Family != AtmTechnical.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"AtmTechnical\"", q.GetType().Name));
            return new AtmTechnical((AtmTechnical.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<AtmTechnical>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is AtmTechnical) && Equals((AtmTechnical)obj); }
        public bool /* IEquatable<AtmTechnical> */ Equals(AtmTechnical other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<AtmTechnical>
        public static bool operator ==(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<AtmTechnical> */ CompareTo(AtmTechnical other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static AtmTechnical operator +(AtmTechnical lhs, AtmTechnical rhs) { return new AtmTechnical(lhs.m_value + rhs.m_value); }
        public static AtmTechnical operator -(AtmTechnical lhs, AtmTechnical rhs) { return new AtmTechnical(lhs.m_value - rhs.m_value); }
        public static AtmTechnical operator ++(AtmTechnical q) { return new AtmTechnical(q.m_value + 1d); }
        public static AtmTechnical operator --(AtmTechnical q) { return new AtmTechnical(q.m_value - 1d); }
        public static AtmTechnical operator -(AtmTechnical q) { return new AtmTechnical(-q.m_value); }
        public static AtmTechnical operator *(double lhs, AtmTechnical rhs) { return new AtmTechnical(lhs * rhs.m_value); }
        public static AtmTechnical operator *(AtmTechnical lhs, double rhs) { return new AtmTechnical(lhs.m_value * rhs); }
        public static AtmTechnical operator /(AtmTechnical lhs, double rhs) { return new AtmTechnical(lhs.m_value / rhs); }
        public static double operator /(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(AtmTechnical.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(AtmTechnical.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? AtmTechnical.Format, m_value, AtmTechnical.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Pascal.Sense;
        private static readonly int s_family = Pascal.Family;
        private static /*mutable*/ double s_factor = Pascal.Factor / 98066.5d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("at");

        private static readonly AtmTechnical s_one = new AtmTechnical(1d);
        private static readonly AtmTechnical s_zero = new AtmTechnical(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static AtmTechnical One { get { return s_one; } }
        public static AtmTechnical Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct AtmStandard : IQuantity<double>, IEquatable<AtmStandard>, IComparable<AtmStandard>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return AtmStandard.Family; } }
        double IQuantity<double>.Factor { get { return AtmStandard.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return AtmStandard.Symbol; } }
        #endregion

        #region Constructor(s)
        public AtmStandard(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new AtmStandard(value);
        }
        #endregion

        #region Conversions
        public static explicit operator AtmStandard(double q) { return new AtmStandard(q); }
        public static explicit operator AtmStandard(AtmTechnical q) { return new AtmStandard((AtmStandard.Factor / AtmTechnical.Factor) * q.m_value); }
        public static explicit operator AtmStandard(Bar q) { return new AtmStandard((AtmStandard.Factor / Bar.Factor) * q.m_value); }
        public static explicit operator AtmStandard(Pascal q) { return new AtmStandard((AtmStandard.Factor / Pascal.Factor) * q.m_value); }
        public static explicit operator AtmStandard(MillimeterHg q) { return new AtmStandard((AtmStandard.Factor / MillimeterHg.Factor) * q.m_value); }
        public static AtmStandard From(IQuantity<double> q)
        {
            if (q.Family != AtmStandard.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"AtmStandard\"", q.GetType().Name));
            return new AtmStandard((AtmStandard.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<AtmStandard>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is AtmStandard) && Equals((AtmStandard)obj); }
        public bool /* IEquatable<AtmStandard> */ Equals(AtmStandard other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<AtmStandard>
        public static bool operator ==(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<AtmStandard> */ CompareTo(AtmStandard other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static AtmStandard operator +(AtmStandard lhs, AtmStandard rhs) { return new AtmStandard(lhs.m_value + rhs.m_value); }
        public static AtmStandard operator -(AtmStandard lhs, AtmStandard rhs) { return new AtmStandard(lhs.m_value - rhs.m_value); }
        public static AtmStandard operator ++(AtmStandard q) { return new AtmStandard(q.m_value + 1d); }
        public static AtmStandard operator --(AtmStandard q) { return new AtmStandard(q.m_value - 1d); }
        public static AtmStandard operator -(AtmStandard q) { return new AtmStandard(-q.m_value); }
        public static AtmStandard operator *(double lhs, AtmStandard rhs) { return new AtmStandard(lhs * rhs.m_value); }
        public static AtmStandard operator *(AtmStandard lhs, double rhs) { return new AtmStandard(lhs.m_value * rhs); }
        public static AtmStandard operator /(AtmStandard lhs, double rhs) { return new AtmStandard(lhs.m_value / rhs); }
        public static double operator /(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(AtmStandard.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(AtmStandard.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? AtmStandard.Format, m_value, AtmStandard.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Pascal.Sense;
        private static readonly int s_family = Pascal.Family;
        private static /*mutable*/ double s_factor = Pascal.Factor / 101325d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("atm");

        private static readonly AtmStandard s_one = new AtmStandard(1d);
        private static readonly AtmStandard s_zero = new AtmStandard(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static AtmStandard One { get { return s_one; } }
        public static AtmStandard Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct MillimeterHg : IQuantity<double>, IEquatable<MillimeterHg>, IComparable<MillimeterHg>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return MillimeterHg.Family; } }
        double IQuantity<double>.Factor { get { return MillimeterHg.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return MillimeterHg.Symbol; } }
        #endregion

        #region Constructor(s)
        public MillimeterHg(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new MillimeterHg(value);
        }
        #endregion

        #region Conversions
        public static explicit operator MillimeterHg(double q) { return new MillimeterHg(q); }
        public static explicit operator MillimeterHg(AtmStandard q) { return new MillimeterHg((MillimeterHg.Factor / AtmStandard.Factor) * q.m_value); }
        public static explicit operator MillimeterHg(AtmTechnical q) { return new MillimeterHg((MillimeterHg.Factor / AtmTechnical.Factor) * q.m_value); }
        public static explicit operator MillimeterHg(Bar q) { return new MillimeterHg((MillimeterHg.Factor / Bar.Factor) * q.m_value); }
        public static explicit operator MillimeterHg(Pascal q) { return new MillimeterHg((MillimeterHg.Factor / Pascal.Factor) * q.m_value); }
        public static MillimeterHg From(IQuantity<double> q)
        {
            if (q.Family != MillimeterHg.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"MillimeterHg\"", q.GetType().Name));
            return new MillimeterHg((MillimeterHg.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<MillimeterHg>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is MillimeterHg) && Equals((MillimeterHg)obj); }
        public bool /* IEquatable<MillimeterHg> */ Equals(MillimeterHg other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<MillimeterHg>
        public static bool operator ==(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<MillimeterHg> */ CompareTo(MillimeterHg other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static MillimeterHg operator +(MillimeterHg lhs, MillimeterHg rhs) { return new MillimeterHg(lhs.m_value + rhs.m_value); }
        public static MillimeterHg operator -(MillimeterHg lhs, MillimeterHg rhs) { return new MillimeterHg(lhs.m_value - rhs.m_value); }
        public static MillimeterHg operator ++(MillimeterHg q) { return new MillimeterHg(q.m_value + 1d); }
        public static MillimeterHg operator --(MillimeterHg q) { return new MillimeterHg(q.m_value - 1d); }
        public static MillimeterHg operator -(MillimeterHg q) { return new MillimeterHg(-q.m_value); }
        public static MillimeterHg operator *(double lhs, MillimeterHg rhs) { return new MillimeterHg(lhs * rhs.m_value); }
        public static MillimeterHg operator *(MillimeterHg lhs, double rhs) { return new MillimeterHg(lhs.m_value * rhs); }
        public static MillimeterHg operator /(MillimeterHg lhs, double rhs) { return new MillimeterHg(lhs.m_value / rhs); }
        public static double operator /(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(MillimeterHg.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(MillimeterHg.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? MillimeterHg.Format, m_value, MillimeterHg.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Pascal.Sense;
        private static readonly int s_family = Pascal.Family;
        private static /*mutable*/ double s_factor = Pascal.Factor * (13.5951d * 9.80665d);
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mmHg");

        private static readonly MillimeterHg s_one = new MillimeterHg(1d);
        private static readonly MillimeterHg s_zero = new MillimeterHg(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static MillimeterHg One { get { return s_one; } }
        public static MillimeterHg Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Coulomb : IQuantity<double>, IEquatable<Coulomb>, IComparable<Coulomb>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Coulomb.Family; } }
        double IQuantity<double>.Factor { get { return Coulomb.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Coulomb.Symbol; } }
        #endregion

        #region Constructor(s)
        public Coulomb(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Coulomb(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Coulomb(double q) { return new Coulomb(q); }
        public static Coulomb From(IQuantity<double> q)
        {
            if (q.Family != Coulomb.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Coulomb\"", q.GetType().Name));
            return new Coulomb((Coulomb.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Coulomb>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Coulomb) && Equals((Coulomb)obj); }
        public bool /* IEquatable<Coulomb> */ Equals(Coulomb other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Coulomb>
        public static bool operator ==(Coulomb lhs, Coulomb rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Coulomb lhs, Coulomb rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Coulomb lhs, Coulomb rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Coulomb lhs, Coulomb rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Coulomb lhs, Coulomb rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Coulomb lhs, Coulomb rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Coulomb> */ CompareTo(Coulomb other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Coulomb operator +(Coulomb lhs, Coulomb rhs) { return new Coulomb(lhs.m_value + rhs.m_value); }
        public static Coulomb operator -(Coulomb lhs, Coulomb rhs) { return new Coulomb(lhs.m_value - rhs.m_value); }
        public static Coulomb operator ++(Coulomb q) { return new Coulomb(q.m_value + 1d); }
        public static Coulomb operator --(Coulomb q) { return new Coulomb(q.m_value - 1d); }
        public static Coulomb operator -(Coulomb q) { return new Coulomb(-q.m_value); }
        public static Coulomb operator *(double lhs, Coulomb rhs) { return new Coulomb(lhs * rhs.m_value); }
        public static Coulomb operator *(Coulomb lhs, double rhs) { return new Coulomb(lhs.m_value * rhs); }
        public static Coulomb operator /(Coulomb lhs, double rhs) { return new Coulomb(lhs.m_value / rhs); }
        public static double operator /(Coulomb lhs, Coulomb rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Second operator /(Coulomb lhs, Ampere rhs) { return new Second(lhs.m_value / rhs.m_value); }
        public static Ampere operator /(Coulomb lhs, Second rhs) { return new Ampere(lhs.m_value / rhs.m_value); }
        public static Farad operator /(Coulomb lhs, Volt rhs) { return new Farad(lhs.m_value / rhs.m_value); }
        public static Volt operator /(Coulomb lhs, Farad rhs) { return new Volt(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Coulomb.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Coulomb.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Coulomb.Format, m_value, Coulomb.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Ampere.Sense * Second.Sense;
        private static readonly int s_family = 22;
        private static /*mutable*/ double s_factor = Ampere.Factor * Second.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("C");

        private static readonly Coulomb s_one = new Coulomb(1d);
        private static readonly Coulomb s_zero = new Coulomb(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Coulomb One { get { return s_one; } }
        public static Coulomb Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Volt : IQuantity<double>, IEquatable<Volt>, IComparable<Volt>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Volt.Family; } }
        double IQuantity<double>.Factor { get { return Volt.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Volt.Symbol; } }
        #endregion

        #region Constructor(s)
        public Volt(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Volt(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Volt(double q) { return new Volt(q); }
        public static Volt From(IQuantity<double> q)
        {
            if (q.Family != Volt.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Volt\"", q.GetType().Name));
            return new Volt((Volt.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Volt>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Volt) && Equals((Volt)obj); }
        public bool /* IEquatable<Volt> */ Equals(Volt other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Volt>
        public static bool operator ==(Volt lhs, Volt rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Volt lhs, Volt rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Volt lhs, Volt rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Volt lhs, Volt rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Volt lhs, Volt rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Volt lhs, Volt rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Volt> */ CompareTo(Volt other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Volt operator +(Volt lhs, Volt rhs) { return new Volt(lhs.m_value + rhs.m_value); }
        public static Volt operator -(Volt lhs, Volt rhs) { return new Volt(lhs.m_value - rhs.m_value); }
        public static Volt operator ++(Volt q) { return new Volt(q.m_value + 1d); }
        public static Volt operator --(Volt q) { return new Volt(q.m_value - 1d); }
        public static Volt operator -(Volt q) { return new Volt(-q.m_value); }
        public static Volt operator *(double lhs, Volt rhs) { return new Volt(lhs * rhs.m_value); }
        public static Volt operator *(Volt lhs, double rhs) { return new Volt(lhs.m_value * rhs); }
        public static Volt operator /(Volt lhs, double rhs) { return new Volt(lhs.m_value / rhs); }
        public static double operator /(Volt lhs, Volt rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Joule operator *(Volt lhs, Coulomb rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule operator *(Coulomb lhs, Volt rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Watt operator *(Volt lhs, Ampere rhs) { return new Watt(lhs.m_value * rhs.m_value); }
        public static Watt operator *(Ampere lhs, Volt rhs) { return new Watt(lhs.m_value * rhs.m_value); }
        public static Ohm operator /(Volt lhs, Ampere rhs) { return new Ohm(lhs.m_value / rhs.m_value); }
        public static Ampere operator /(Volt lhs, Ohm rhs) { return new Ampere(lhs.m_value / rhs.m_value); }
        public static Weber operator *(Volt lhs, Second rhs) { return new Weber(lhs.m_value * rhs.m_value); }
        public static Weber operator *(Second lhs, Volt rhs) { return new Weber(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Volt.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Volt.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Volt.Format, m_value, Volt.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Joule.Sense / Coulomb.Sense;
        private static readonly int s_family = 23;
        private static /*mutable*/ double s_factor = Joule.Factor / Coulomb.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("V");

        private static readonly Volt s_one = new Volt(1d);
        private static readonly Volt s_zero = new Volt(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Volt One { get { return s_one; } }
        public static Volt Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Ohm : IQuantity<double>, IEquatable<Ohm>, IComparable<Ohm>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Ohm.Family; } }
        double IQuantity<double>.Factor { get { return Ohm.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Ohm.Symbol; } }
        #endregion

        #region Constructor(s)
        public Ohm(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Ohm(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Ohm(double q) { return new Ohm(q); }
        public static Ohm From(IQuantity<double> q)
        {
            if (q.Family != Ohm.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Ohm\"", q.GetType().Name));
            return new Ohm((Ohm.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Ohm>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Ohm) && Equals((Ohm)obj); }
        public bool /* IEquatable<Ohm> */ Equals(Ohm other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Ohm>
        public static bool operator ==(Ohm lhs, Ohm rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Ohm lhs, Ohm rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Ohm lhs, Ohm rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Ohm lhs, Ohm rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Ohm lhs, Ohm rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Ohm lhs, Ohm rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Ohm> */ CompareTo(Ohm other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Ohm operator +(Ohm lhs, Ohm rhs) { return new Ohm(lhs.m_value + rhs.m_value); }
        public static Ohm operator -(Ohm lhs, Ohm rhs) { return new Ohm(lhs.m_value - rhs.m_value); }
        public static Ohm operator ++(Ohm q) { return new Ohm(q.m_value + 1d); }
        public static Ohm operator --(Ohm q) { return new Ohm(q.m_value - 1d); }
        public static Ohm operator -(Ohm q) { return new Ohm(-q.m_value); }
        public static Ohm operator *(double lhs, Ohm rhs) { return new Ohm(lhs * rhs.m_value); }
        public static Ohm operator *(Ohm lhs, double rhs) { return new Ohm(lhs.m_value * rhs); }
        public static Ohm operator /(Ohm lhs, double rhs) { return new Ohm(lhs.m_value / rhs); }
        public static double operator /(Ohm lhs, Ohm rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Volt operator *(Ohm lhs, Ampere rhs) { return new Volt(lhs.m_value * rhs.m_value); }
        public static Volt operator *(Ampere lhs, Ohm rhs) { return new Volt(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Ohm.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Ohm.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Ohm.Format, m_value, Ohm.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Volt.Sense / Ampere.Sense;
        private static readonly int s_family = 24;
        private static /*mutable*/ double s_factor = Volt.Factor / Ampere.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u03A9", "ohm");

        private static readonly Ohm s_one = new Ohm(1d);
        private static readonly Ohm s_zero = new Ohm(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Ohm One { get { return s_one; } }
        public static Ohm Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Siemens : IQuantity<double>, IEquatable<Siemens>, IComparable<Siemens>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Siemens.Family; } }
        double IQuantity<double>.Factor { get { return Siemens.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Siemens.Symbol; } }
        #endregion

        #region Constructor(s)
        public Siemens(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Siemens(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Siemens(double q) { return new Siemens(q); }
        public static Siemens From(IQuantity<double> q)
        {
            if (q.Family != Siemens.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Siemens\"", q.GetType().Name));
            return new Siemens((Siemens.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Siemens>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Siemens) && Equals((Siemens)obj); }
        public bool /* IEquatable<Siemens> */ Equals(Siemens other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Siemens>
        public static bool operator ==(Siemens lhs, Siemens rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Siemens lhs, Siemens rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Siemens lhs, Siemens rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Siemens lhs, Siemens rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Siemens lhs, Siemens rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Siemens lhs, Siemens rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Siemens> */ CompareTo(Siemens other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Siemens operator +(Siemens lhs, Siemens rhs) { return new Siemens(lhs.m_value + rhs.m_value); }
        public static Siemens operator -(Siemens lhs, Siemens rhs) { return new Siemens(lhs.m_value - rhs.m_value); }
        public static Siemens operator ++(Siemens q) { return new Siemens(q.m_value + 1d); }
        public static Siemens operator --(Siemens q) { return new Siemens(q.m_value - 1d); }
        public static Siemens operator -(Siemens q) { return new Siemens(-q.m_value); }
        public static Siemens operator *(double lhs, Siemens rhs) { return new Siemens(lhs * rhs.m_value); }
        public static Siemens operator *(Siemens lhs, double rhs) { return new Siemens(lhs.m_value * rhs); }
        public static Siemens operator /(Siemens lhs, double rhs) { return new Siemens(lhs.m_value / rhs); }
        public static double operator /(Siemens lhs, Siemens rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Ampere operator *(Siemens lhs, Volt rhs) { return new Ampere(lhs.m_value * rhs.m_value); }
        public static Ampere operator *(Volt lhs, Siemens rhs) { return new Ampere(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Siemens.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Siemens.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Siemens.Format, m_value, Siemens.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Ampere.Sense / Volt.Sense;
        private static readonly int s_family = 25;
        private static /*mutable*/ double s_factor = Ampere.Factor / Volt.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("S");

        private static readonly Siemens s_one = new Siemens(1d);
        private static readonly Siemens s_zero = new Siemens(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Siemens One { get { return s_one; } }
        public static Siemens Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Farad : IQuantity<double>, IEquatable<Farad>, IComparable<Farad>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Farad.Family; } }
        double IQuantity<double>.Factor { get { return Farad.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Farad.Symbol; } }
        #endregion

        #region Constructor(s)
        public Farad(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Farad(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Farad(double q) { return new Farad(q); }
        public static Farad From(IQuantity<double> q)
        {
            if (q.Family != Farad.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Farad\"", q.GetType().Name));
            return new Farad((Farad.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Farad>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Farad) && Equals((Farad)obj); }
        public bool /* IEquatable<Farad> */ Equals(Farad other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Farad>
        public static bool operator ==(Farad lhs, Farad rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Farad lhs, Farad rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Farad lhs, Farad rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Farad lhs, Farad rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Farad lhs, Farad rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Farad lhs, Farad rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Farad> */ CompareTo(Farad other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Farad operator +(Farad lhs, Farad rhs) { return new Farad(lhs.m_value + rhs.m_value); }
        public static Farad operator -(Farad lhs, Farad rhs) { return new Farad(lhs.m_value - rhs.m_value); }
        public static Farad operator ++(Farad q) { return new Farad(q.m_value + 1d); }
        public static Farad operator --(Farad q) { return new Farad(q.m_value - 1d); }
        public static Farad operator -(Farad q) { return new Farad(-q.m_value); }
        public static Farad operator *(double lhs, Farad rhs) { return new Farad(lhs * rhs.m_value); }
        public static Farad operator *(Farad lhs, double rhs) { return new Farad(lhs.m_value * rhs); }
        public static Farad operator /(Farad lhs, double rhs) { return new Farad(lhs.m_value / rhs); }
        public static double operator /(Farad lhs, Farad rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Coulomb operator *(Farad lhs, Volt rhs) { return new Coulomb(lhs.m_value * rhs.m_value); }
        public static Coulomb operator *(Volt lhs, Farad rhs) { return new Coulomb(lhs.m_value * rhs.m_value); }
        public static Second operator *(Farad lhs, Ohm rhs) { return new Second(lhs.m_value * rhs.m_value); }
        public static Second operator *(Ohm lhs, Farad rhs) { return new Second(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Farad.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Farad.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Farad.Format, m_value, Farad.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Coulomb.Sense / Volt.Sense;
        private static readonly int s_family = 26;
        private static /*mutable*/ double s_factor = Coulomb.Factor / Volt.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("F");

        private static readonly Farad s_one = new Farad(1d);
        private static readonly Farad s_zero = new Farad(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Farad One { get { return s_one; } }
        public static Farad Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Weber : IQuantity<double>, IEquatable<Weber>, IComparable<Weber>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Weber.Family; } }
        double IQuantity<double>.Factor { get { return Weber.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Weber.Symbol; } }
        #endregion

        #region Constructor(s)
        public Weber(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Weber(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Weber(double q) { return new Weber(q); }
        public static Weber From(IQuantity<double> q)
        {
            if (q.Family != Weber.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Weber\"", q.GetType().Name));
            return new Weber((Weber.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Weber>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Weber) && Equals((Weber)obj); }
        public bool /* IEquatable<Weber> */ Equals(Weber other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Weber>
        public static bool operator ==(Weber lhs, Weber rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Weber lhs, Weber rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Weber lhs, Weber rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Weber lhs, Weber rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Weber lhs, Weber rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Weber lhs, Weber rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Weber> */ CompareTo(Weber other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Weber operator +(Weber lhs, Weber rhs) { return new Weber(lhs.m_value + rhs.m_value); }
        public static Weber operator -(Weber lhs, Weber rhs) { return new Weber(lhs.m_value - rhs.m_value); }
        public static Weber operator ++(Weber q) { return new Weber(q.m_value + 1d); }
        public static Weber operator --(Weber q) { return new Weber(q.m_value - 1d); }
        public static Weber operator -(Weber q) { return new Weber(-q.m_value); }
        public static Weber operator *(double lhs, Weber rhs) { return new Weber(lhs * rhs.m_value); }
        public static Weber operator *(Weber lhs, double rhs) { return new Weber(lhs.m_value * rhs); }
        public static Weber operator /(Weber lhs, double rhs) { return new Weber(lhs.m_value / rhs); }
        public static double operator /(Weber lhs, Weber rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Joule operator *(Weber lhs, Ampere rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule operator *(Ampere lhs, Weber rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Second operator /(Weber lhs, Volt rhs) { return new Second(lhs.m_value / rhs.m_value); }
        public static Volt operator /(Weber lhs, Second rhs) { return new Volt(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Weber.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Weber.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Weber.Format, m_value, Weber.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Joule.Sense / Ampere.Sense;
        private static readonly int s_family = 27;
        private static /*mutable*/ double s_factor = Joule.Factor / Ampere.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("Wb");

        private static readonly Weber s_one = new Weber(1d);
        private static readonly Weber s_zero = new Weber(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Weber One { get { return s_one; } }
        public static Weber Zero { get { return s_zero; } }
        #endregion
    }
    public partial struct Meter2_Sec2 : IQuantity<double>, IEquatable<Meter2_Sec2>, IComparable<Meter2_Sec2>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        int IQuantity<double>.Family { get { return Meter2_Sec2.Family; } }
        double IQuantity<double>.Factor { get { return Meter2_Sec2.Factor; } }
        SymbolCollection IQuantity<double>.Symbol { get { return Meter2_Sec2.Symbol; } }
        #endregion

        #region Constructor(s)
        public Meter2_Sec2(double value)
        {
            m_value = value;
        }
        public static IQuantity<double> Create(double value)
        {
            return new Meter2_Sec2(value);
        }
        #endregion

        #region Conversions
        public static explicit operator Meter2_Sec2(double q) { return new Meter2_Sec2(q); }
        public static Meter2_Sec2 From(IQuantity<double> q)
        {
            if (q.Family != Meter2_Sec2.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Meter2_Sec2\"", q.GetType().Name));
            return new Meter2_Sec2((Meter2_Sec2.Factor / q.Factor) * q.Value);
        }
        public static IQuantity<double> Convert(IQuantity<double> q)
        {
            return From(q);
        }
        #endregion

        #region IObject / IEquatable<Meter2_Sec2>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter2_Sec2) && Equals((Meter2_Sec2)obj); }
        public bool /* IEquatable<Meter2_Sec2> */ Equals(Meter2_Sec2 other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Meter2_Sec2>
        public static bool operator ==(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Meter2_Sec2> */ CompareTo(Meter2_Sec2 other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter2_Sec2 operator +(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return new Meter2_Sec2(lhs.m_value + rhs.m_value); }
        public static Meter2_Sec2 operator -(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return new Meter2_Sec2(lhs.m_value - rhs.m_value); }
        public static Meter2_Sec2 operator ++(Meter2_Sec2 q) { return new Meter2_Sec2(q.m_value + 1d); }
        public static Meter2_Sec2 operator --(Meter2_Sec2 q) { return new Meter2_Sec2(q.m_value - 1d); }
        public static Meter2_Sec2 operator -(Meter2_Sec2 q) { return new Meter2_Sec2(-q.m_value); }
        public static Meter2_Sec2 operator *(double lhs, Meter2_Sec2 rhs) { return new Meter2_Sec2(lhs * rhs.m_value); }
        public static Meter2_Sec2 operator *(Meter2_Sec2 lhs, double rhs) { return new Meter2_Sec2(lhs.m_value * rhs); }
        public static Meter2_Sec2 operator /(Meter2_Sec2 lhs, double rhs) { return new Meter2_Sec2(lhs.m_value / rhs); }
        public static double operator /(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter_Sec operator /(Meter2_Sec2 lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.m_value / rhs.m_value); }
        public static Meter operator /(Meter2_Sec2 lhs, Meter_Sec2 rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        public static Meter_Sec2 operator /(Meter2_Sec2 lhs, Meter rhs) { return new Meter_Sec2(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter2_Sec2.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter2_Sec2.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Meter2_Sec2.Format, m_value, Meter2_Sec2.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter_Sec.Sense * Meter_Sec.Sense;
        private static readonly int s_family = 28;
        private static /*mutable*/ double s_factor = Meter_Sec.Factor * Meter_Sec.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m2/s2");

        private static readonly Meter2_Sec2 s_one = new Meter2_Sec2(1d);
        private static readonly Meter2_Sec2 s_zero = new Meter2_Sec2(0d);

        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Meter2_Sec2 One { get { return s_one; } }
        public static Meter2_Sec2 Zero { get { return s_zero; } }
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
        private static readonly int s_family = 29;
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
