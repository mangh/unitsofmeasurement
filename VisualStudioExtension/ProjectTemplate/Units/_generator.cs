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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Meter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Meter(double q) { return new Meter(q); }
        public static Meter From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Meter.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Meter\"", q.GetType().Name));
            return new Meter((Meter.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Meter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter) && Equals((Meter)obj); }
        public bool /* IEquatable<Meter> */ Equals(Meter other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Meter>
        public static bool operator ==(Meter lhs, Meter rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Meter lhs, Meter rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Meter lhs, Meter rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Meter lhs, Meter rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Meter lhs, Meter rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Meter lhs, Meter rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Meter> */ CompareTo(Meter other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter operator +(Meter lhs, Meter rhs) { return new Meter(lhs.Value + rhs.Value); }
        public static Meter operator -(Meter lhs, Meter rhs) { return new Meter(lhs.Value - rhs.Value); }
        public static Meter operator ++(Meter q) { return new Meter(q.Value + 1d); }
        public static Meter operator --(Meter q) { return new Meter(q.Value - 1d); }
        public static Meter operator -(Meter q) { return new Meter(-q.Value); }
        public static Meter operator *(double lhs, Meter rhs) { return new Meter(lhs * rhs.Value); }
        public static Meter operator *(Meter lhs, double rhs) { return new Meter(lhs.Value * rhs); }
        public static Meter operator /(Meter lhs, double rhs) { return new Meter(lhs.Value / rhs); }
        public static double operator /(Meter lhs, Meter rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static SquareMeter operator *(Meter lhs, Meter rhs) { return new SquareMeter(lhs.Value * rhs.Value); }
        public static Meter_Sec operator /(Meter lhs, Second rhs) { return new Meter_Sec(lhs.Value / rhs.Value); }
        public static Second operator /(Meter lhs, Meter_Sec rhs) { return new Second(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Meter.Format, Value, Meter.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Length;
        private static readonly int s_family = 0;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Second(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Second(double q) { return new Second(q); }
        public static Second From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Second.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Second\"", q.GetType().Name));
            return new Second((Second.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Second>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Second) && Equals((Second)obj); }
        public bool /* IEquatable<Second> */ Equals(Second other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Second>
        public static bool operator ==(Second lhs, Second rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Second lhs, Second rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Second lhs, Second rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Second lhs, Second rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Second lhs, Second rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Second lhs, Second rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Second> */ CompareTo(Second other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Second operator +(Second lhs, Second rhs) { return new Second(lhs.Value + rhs.Value); }
        public static Second operator -(Second lhs, Second rhs) { return new Second(lhs.Value - rhs.Value); }
        public static Second operator ++(Second q) { return new Second(q.Value + 1d); }
        public static Second operator --(Second q) { return new Second(q.Value - 1d); }
        public static Second operator -(Second q) { return new Second(-q.Value); }
        public static Second operator *(double lhs, Second rhs) { return new Second(lhs * rhs.Value); }
        public static Second operator *(Second lhs, double rhs) { return new Second(lhs.Value * rhs); }
        public static Second operator /(Second lhs, double rhs) { return new Second(lhs.Value / rhs); }
        public static double operator /(Second lhs, Second rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Second.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Second.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Second.Format, Value, Second.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Time;
        private static readonly int s_family = 1;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Kilogram(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Kilogram(double q) { return new Kilogram(q); }
        public static Kilogram From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Kilogram.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Kilogram\"", q.GetType().Name));
            return new Kilogram((Kilogram.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Kilogram>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Kilogram) && Equals((Kilogram)obj); }
        public bool /* IEquatable<Kilogram> */ Equals(Kilogram other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Kilogram>
        public static bool operator ==(Kilogram lhs, Kilogram rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Kilogram lhs, Kilogram rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Kilogram lhs, Kilogram rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Kilogram lhs, Kilogram rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Kilogram lhs, Kilogram rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Kilogram lhs, Kilogram rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Kilogram> */ CompareTo(Kilogram other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Kilogram operator +(Kilogram lhs, Kilogram rhs) { return new Kilogram(lhs.Value + rhs.Value); }
        public static Kilogram operator -(Kilogram lhs, Kilogram rhs) { return new Kilogram(lhs.Value - rhs.Value); }
        public static Kilogram operator ++(Kilogram q) { return new Kilogram(q.Value + 1d); }
        public static Kilogram operator --(Kilogram q) { return new Kilogram(q.Value - 1d); }
        public static Kilogram operator -(Kilogram q) { return new Kilogram(-q.Value); }
        public static Kilogram operator *(double lhs, Kilogram rhs) { return new Kilogram(lhs * rhs.Value); }
        public static Kilogram operator *(Kilogram lhs, double rhs) { return new Kilogram(lhs.Value * rhs); }
        public static Kilogram operator /(Kilogram lhs, double rhs) { return new Kilogram(lhs.Value / rhs); }
        public static double operator /(Kilogram lhs, Kilogram rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Newton operator *(Kilogram lhs, Meter_Sec2 rhs) { return new Newton(lhs.Value * rhs.Value); }
        public static Newton operator *(Meter_Sec2 lhs, Kilogram rhs) { return new Newton(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Kilogram.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Kilogram.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Kilogram.Format, Value, Kilogram.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Mass;
        private static readonly int s_family = 2;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public DegKelvin(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegKelvin(double q) { return new DegKelvin(q); }
        public static explicit operator DegKelvin(DegFahrenheit q) { return new DegKelvin((DegKelvin.Factor / DegFahrenheit.Factor) * q.Value); }
        public static explicit operator DegKelvin(DegRankine q) { return new DegKelvin((DegKelvin.Factor / DegRankine.Factor) * q.Value); }
        public static explicit operator DegKelvin(DegCelsius q) { return new DegKelvin((DegKelvin.Factor / DegCelsius.Factor) * q.Value); }
        public static DegKelvin From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != DegKelvin.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"DegKelvin\"", q.GetType().Name));
            return new DegKelvin((DegKelvin.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegKelvin>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegKelvin) && Equals((DegKelvin)obj); }
        public bool /* IEquatable<DegKelvin> */ Equals(DegKelvin other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<DegKelvin>
        public static bool operator ==(DegKelvin lhs, DegKelvin rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(DegKelvin lhs, DegKelvin rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(DegKelvin lhs, DegKelvin rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(DegKelvin lhs, DegKelvin rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(DegKelvin lhs, DegKelvin rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(DegKelvin lhs, DegKelvin rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<DegKelvin> */ CompareTo(DegKelvin other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegKelvin operator +(DegKelvin lhs, DegKelvin rhs) { return new DegKelvin(lhs.Value + rhs.Value); }
        public static DegKelvin operator -(DegKelvin lhs, DegKelvin rhs) { return new DegKelvin(lhs.Value - rhs.Value); }
        public static DegKelvin operator ++(DegKelvin q) { return new DegKelvin(q.Value + 1d); }
        public static DegKelvin operator --(DegKelvin q) { return new DegKelvin(q.Value - 1d); }
        public static DegKelvin operator -(DegKelvin q) { return new DegKelvin(-q.Value); }
        public static DegKelvin operator *(double lhs, DegKelvin rhs) { return new DegKelvin(lhs * rhs.Value); }
        public static DegKelvin operator *(DegKelvin lhs, double rhs) { return new DegKelvin(lhs.Value * rhs); }
        public static DegKelvin operator /(DegKelvin lhs, double rhs) { return new DegKelvin(lhs.Value / rhs); }
        public static double operator /(DegKelvin lhs, DegKelvin rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegKelvin.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegKelvin.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? DegKelvin.Format, Value, DegKelvin.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Temperature;
        private static readonly int s_family = 3;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public DegCelsius(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegCelsius(double q) { return new DegCelsius(q); }
        public static explicit operator DegCelsius(DegKelvin q) { return new DegCelsius((DegCelsius.Factor / DegKelvin.Factor) * q.Value); }
        public static explicit operator DegCelsius(DegFahrenheit q) { return new DegCelsius((DegCelsius.Factor / DegFahrenheit.Factor) * q.Value); }
        public static explicit operator DegCelsius(DegRankine q) { return new DegCelsius((DegCelsius.Factor / DegRankine.Factor) * q.Value); }
        public static DegCelsius From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != DegCelsius.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"DegCelsius\"", q.GetType().Name));
            return new DegCelsius((DegCelsius.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegCelsius>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegCelsius) && Equals((DegCelsius)obj); }
        public bool /* IEquatable<DegCelsius> */ Equals(DegCelsius other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<DegCelsius>
        public static bool operator ==(DegCelsius lhs, DegCelsius rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(DegCelsius lhs, DegCelsius rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(DegCelsius lhs, DegCelsius rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(DegCelsius lhs, DegCelsius rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(DegCelsius lhs, DegCelsius rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(DegCelsius lhs, DegCelsius rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<DegCelsius> */ CompareTo(DegCelsius other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegCelsius operator +(DegCelsius lhs, DegCelsius rhs) { return new DegCelsius(lhs.Value + rhs.Value); }
        public static DegCelsius operator -(DegCelsius lhs, DegCelsius rhs) { return new DegCelsius(lhs.Value - rhs.Value); }
        public static DegCelsius operator ++(DegCelsius q) { return new DegCelsius(q.Value + 1d); }
        public static DegCelsius operator --(DegCelsius q) { return new DegCelsius(q.Value - 1d); }
        public static DegCelsius operator -(DegCelsius q) { return new DegCelsius(-q.Value); }
        public static DegCelsius operator *(double lhs, DegCelsius rhs) { return new DegCelsius(lhs * rhs.Value); }
        public static DegCelsius operator *(DegCelsius lhs, double rhs) { return new DegCelsius(lhs.Value * rhs); }
        public static DegCelsius operator /(DegCelsius lhs, double rhs) { return new DegCelsius(lhs.Value / rhs); }
        public static double operator /(DegCelsius lhs, DegCelsius rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegCelsius.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegCelsius.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? DegCelsius.Format, Value, DegCelsius.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = DegKelvin.Family;
        private static double s_factor = DegKelvin.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public DegRankine(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegRankine(double q) { return new DegRankine(q); }
        public static explicit operator DegRankine(DegCelsius q) { return new DegRankine((DegRankine.Factor / DegCelsius.Factor) * q.Value); }
        public static explicit operator DegRankine(DegKelvin q) { return new DegRankine((DegRankine.Factor / DegKelvin.Factor) * q.Value); }
        public static explicit operator DegRankine(DegFahrenheit q) { return new DegRankine((DegRankine.Factor / DegFahrenheit.Factor) * q.Value); }
        public static DegRankine From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != DegRankine.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"DegRankine\"", q.GetType().Name));
            return new DegRankine((DegRankine.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegRankine>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegRankine) && Equals((DegRankine)obj); }
        public bool /* IEquatable<DegRankine> */ Equals(DegRankine other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<DegRankine>
        public static bool operator ==(DegRankine lhs, DegRankine rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(DegRankine lhs, DegRankine rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(DegRankine lhs, DegRankine rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(DegRankine lhs, DegRankine rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(DegRankine lhs, DegRankine rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(DegRankine lhs, DegRankine rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<DegRankine> */ CompareTo(DegRankine other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegRankine operator +(DegRankine lhs, DegRankine rhs) { return new DegRankine(lhs.Value + rhs.Value); }
        public static DegRankine operator -(DegRankine lhs, DegRankine rhs) { return new DegRankine(lhs.Value - rhs.Value); }
        public static DegRankine operator ++(DegRankine q) { return new DegRankine(q.Value + 1d); }
        public static DegRankine operator --(DegRankine q) { return new DegRankine(q.Value - 1d); }
        public static DegRankine operator -(DegRankine q) { return new DegRankine(-q.Value); }
        public static DegRankine operator *(double lhs, DegRankine rhs) { return new DegRankine(lhs * rhs.Value); }
        public static DegRankine operator *(DegRankine lhs, double rhs) { return new DegRankine(lhs.Value * rhs); }
        public static DegRankine operator /(DegRankine lhs, double rhs) { return new DegRankine(lhs.Value / rhs); }
        public static double operator /(DegRankine lhs, DegRankine rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegRankine.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegRankine.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? DegRankine.Format, Value, DegRankine.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = DegKelvin.Family;
        private static double s_factor = (9d / 5d) * DegKelvin.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public DegFahrenheit(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegFahrenheit(double q) { return new DegFahrenheit(q); }
        public static explicit operator DegFahrenheit(DegRankine q) { return new DegFahrenheit((DegFahrenheit.Factor / DegRankine.Factor) * q.Value); }
        public static explicit operator DegFahrenheit(DegCelsius q) { return new DegFahrenheit((DegFahrenheit.Factor / DegCelsius.Factor) * q.Value); }
        public static explicit operator DegFahrenheit(DegKelvin q) { return new DegFahrenheit((DegFahrenheit.Factor / DegKelvin.Factor) * q.Value); }
        public static DegFahrenheit From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != DegFahrenheit.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"DegFahrenheit\"", q.GetType().Name));
            return new DegFahrenheit((DegFahrenheit.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegFahrenheit>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegFahrenheit) && Equals((DegFahrenheit)obj); }
        public bool /* IEquatable<DegFahrenheit> */ Equals(DegFahrenheit other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<DegFahrenheit>
        public static bool operator ==(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<DegFahrenheit> */ CompareTo(DegFahrenheit other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegFahrenheit operator +(DegFahrenheit lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs.Value + rhs.Value); }
        public static DegFahrenheit operator -(DegFahrenheit lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs.Value - rhs.Value); }
        public static DegFahrenheit operator ++(DegFahrenheit q) { return new DegFahrenheit(q.Value + 1d); }
        public static DegFahrenheit operator --(DegFahrenheit q) { return new DegFahrenheit(q.Value - 1d); }
        public static DegFahrenheit operator -(DegFahrenheit q) { return new DegFahrenheit(-q.Value); }
        public static DegFahrenheit operator *(double lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs * rhs.Value); }
        public static DegFahrenheit operator *(DegFahrenheit lhs, double rhs) { return new DegFahrenheit(lhs.Value * rhs); }
        public static DegFahrenheit operator /(DegFahrenheit lhs, double rhs) { return new DegFahrenheit(lhs.Value / rhs); }
        public static double operator /(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegFahrenheit.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegFahrenheit.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? DegFahrenheit.Format, Value, DegFahrenheit.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = DegKelvin.Family;
        private static double s_factor = (9d / 5d) * DegKelvin.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public EUR(decimal value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator EUR(decimal q) { return new EUR(q); }
        public static explicit operator EUR(PLN q) { return new EUR((EUR.Factor / PLN.Factor) * q.Value); }
        public static explicit operator EUR(USD q) { return new EUR((EUR.Factor / USD.Factor) * q.Value); }
        public static EUR From(IQuantity<decimal> q)
        {
            Unit<decimal> source = new Unit<decimal>(q);
            if (source.Family != EUR.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"EUR\"", q.GetType().Name));
            return new EUR((EUR.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<EUR>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is EUR) && Equals((EUR)obj); }
        public bool /* IEquatable<EUR> */ Equals(EUR other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<EUR>
        public static bool operator ==(EUR lhs, EUR rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(EUR lhs, EUR rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(EUR lhs, EUR rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(EUR lhs, EUR rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(EUR lhs, EUR rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(EUR lhs, EUR rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<EUR> */ CompareTo(EUR other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static EUR operator +(EUR lhs, EUR rhs) { return new EUR(lhs.Value + rhs.Value); }
        public static EUR operator -(EUR lhs, EUR rhs) { return new EUR(lhs.Value - rhs.Value); }
        public static EUR operator ++(EUR q) { return new EUR(q.Value + decimal.One); }
        public static EUR operator --(EUR q) { return new EUR(q.Value - decimal.One); }
        public static EUR operator -(EUR q) { return new EUR(-q.Value); }
        public static EUR operator *(decimal lhs, EUR rhs) { return new EUR(lhs * rhs.Value); }
        public static EUR operator *(EUR lhs, decimal rhs) { return new EUR(lhs.Value * rhs); }
        public static EUR operator /(EUR lhs, decimal rhs) { return new EUR(lhs.Value / rhs); }
        public static decimal operator /(EUR lhs, EUR rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(EUR.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(EUR.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? EUR.Format, Value, EUR.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Other;
        private static readonly int s_family = 4;
        private static decimal s_factor = decimal.One;
        private static string s_format = "{0} {1}";
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
        private readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public USD(decimal value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator USD(decimal q) { return new USD(q); }
        public static explicit operator USD(EUR q) { return new USD((USD.Factor / EUR.Factor) * q.Value); }
        public static explicit operator USD(PLN q) { return new USD((USD.Factor / PLN.Factor) * q.Value); }
        public static USD From(IQuantity<decimal> q)
        {
            Unit<decimal> source = new Unit<decimal>(q);
            if (source.Family != USD.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"USD\"", q.GetType().Name));
            return new USD((USD.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<USD>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is USD) && Equals((USD)obj); }
        public bool /* IEquatable<USD> */ Equals(USD other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<USD>
        public static bool operator ==(USD lhs, USD rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(USD lhs, USD rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(USD lhs, USD rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(USD lhs, USD rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(USD lhs, USD rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(USD lhs, USD rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<USD> */ CompareTo(USD other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static USD operator +(USD lhs, USD rhs) { return new USD(lhs.Value + rhs.Value); }
        public static USD operator -(USD lhs, USD rhs) { return new USD(lhs.Value - rhs.Value); }
        public static USD operator ++(USD q) { return new USD(q.Value + decimal.One); }
        public static USD operator --(USD q) { return new USD(q.Value - decimal.One); }
        public static USD operator -(USD q) { return new USD(-q.Value); }
        public static USD operator *(decimal lhs, USD rhs) { return new USD(lhs * rhs.Value); }
        public static USD operator *(USD lhs, decimal rhs) { return new USD(lhs.Value * rhs); }
        public static USD operator /(USD lhs, decimal rhs) { return new USD(lhs.Value / rhs); }
        public static decimal operator /(USD lhs, USD rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(USD.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(USD.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? USD.Format, Value, USD.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = EUR.Sense;
        private static readonly int s_family = EUR.Family;
        private static decimal s_factor = 1.3433m * EUR.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public PLN(decimal value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator PLN(decimal q) { return new PLN(q); }
        public static explicit operator PLN(USD q) { return new PLN((PLN.Factor / USD.Factor) * q.Value); }
        public static explicit operator PLN(EUR q) { return new PLN((PLN.Factor / EUR.Factor) * q.Value); }
        public static PLN From(IQuantity<decimal> q)
        {
            Unit<decimal> source = new Unit<decimal>(q);
            if (source.Family != PLN.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"PLN\"", q.GetType().Name));
            return new PLN((PLN.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<PLN>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is PLN) && Equals((PLN)obj); }
        public bool /* IEquatable<PLN> */ Equals(PLN other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<PLN>
        public static bool operator ==(PLN lhs, PLN rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(PLN lhs, PLN rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(PLN lhs, PLN rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(PLN lhs, PLN rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(PLN lhs, PLN rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(PLN lhs, PLN rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<PLN> */ CompareTo(PLN other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static PLN operator +(PLN lhs, PLN rhs) { return new PLN(lhs.Value + rhs.Value); }
        public static PLN operator -(PLN lhs, PLN rhs) { return new PLN(lhs.Value - rhs.Value); }
        public static PLN operator ++(PLN q) { return new PLN(q.Value + decimal.One); }
        public static PLN operator --(PLN q) { return new PLN(q.Value - decimal.One); }
        public static PLN operator -(PLN q) { return new PLN(-q.Value); }
        public static PLN operator *(decimal lhs, PLN rhs) { return new PLN(lhs * rhs.Value); }
        public static PLN operator *(PLN lhs, decimal rhs) { return new PLN(lhs.Value * rhs); }
        public static PLN operator /(PLN lhs, decimal rhs) { return new PLN(lhs.Value / rhs); }
        public static decimal operator /(PLN lhs, PLN rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(PLN.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(PLN.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? PLN.Format, Value, PLN.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = EUR.Sense;
        private static readonly int s_family = EUR.Family;
        private static decimal s_factor = 4.1437m * EUR.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Radian(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Radian(double q) { return new Radian(q); }
        public static explicit operator Radian(Cycles q) { return new Radian((Radian.Factor / Cycles.Factor) * q.Value); }
        public static explicit operator Radian(Degree q) { return new Radian((Radian.Factor / Degree.Factor) * q.Value); }
        public static Radian From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Radian.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Radian\"", q.GetType().Name));
            return new Radian((Radian.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Radian>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Radian) && Equals((Radian)obj); }
        public bool /* IEquatable<Radian> */ Equals(Radian other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Radian>
        public static bool operator ==(Radian lhs, Radian rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Radian lhs, Radian rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Radian lhs, Radian rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Radian lhs, Radian rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Radian lhs, Radian rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Radian lhs, Radian rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Radian> */ CompareTo(Radian other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Radian operator +(Radian lhs, Radian rhs) { return new Radian(lhs.Value + rhs.Value); }
        public static Radian operator -(Radian lhs, Radian rhs) { return new Radian(lhs.Value - rhs.Value); }
        public static Radian operator ++(Radian q) { return new Radian(q.Value + 1d); }
        public static Radian operator --(Radian q) { return new Radian(q.Value - 1d); }
        public static Radian operator -(Radian q) { return new Radian(-q.Value); }
        public static Radian operator *(double lhs, Radian rhs) { return new Radian(lhs * rhs.Value); }
        public static Radian operator *(Radian lhs, double rhs) { return new Radian(lhs.Value * rhs); }
        public static Radian operator /(Radian lhs, double rhs) { return new Radian(lhs.Value / rhs); }
        public static double operator /(Radian lhs, Radian rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Radian.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Radian.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Radian.Format, Value, Radian.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.None;
        private static readonly int s_family = 5;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Degree(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Degree(double q) { return new Degree(q); }
        public static explicit operator Degree(Radian q) { return new Degree((Degree.Factor / Radian.Factor) * q.Value); }
        public static explicit operator Degree(Cycles q) { return new Degree((Degree.Factor / Cycles.Factor) * q.Value); }
        public static Degree From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Degree.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Degree\"", q.GetType().Name));
            return new Degree((Degree.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Degree>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Degree) && Equals((Degree)obj); }
        public bool /* IEquatable<Degree> */ Equals(Degree other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Degree>
        public static bool operator ==(Degree lhs, Degree rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Degree lhs, Degree rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Degree lhs, Degree rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Degree lhs, Degree rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Degree lhs, Degree rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Degree lhs, Degree rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Degree> */ CompareTo(Degree other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Degree operator +(Degree lhs, Degree rhs) { return new Degree(lhs.Value + rhs.Value); }
        public static Degree operator -(Degree lhs, Degree rhs) { return new Degree(lhs.Value - rhs.Value); }
        public static Degree operator ++(Degree q) { return new Degree(q.Value + 1d); }
        public static Degree operator --(Degree q) { return new Degree(q.Value - 1d); }
        public static Degree operator -(Degree q) { return new Degree(-q.Value); }
        public static Degree operator *(double lhs, Degree rhs) { return new Degree(lhs * rhs.Value); }
        public static Degree operator *(Degree lhs, double rhs) { return new Degree(lhs.Value * rhs); }
        public static Degree operator /(Degree lhs, double rhs) { return new Degree(lhs.Value / rhs); }
        public static double operator /(Degree lhs, Degree rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Degree.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Degree.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Degree.Format, Value, Degree.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Radian.Sense;
        private static readonly int s_family = Radian.Family;
        private static double s_factor = (180d / Math.PI) * Radian.Factor;
        private static string s_format = "{0}{1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Cycles(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Cycles(double q) { return new Cycles(q); }
        public static explicit operator Cycles(Degree q) { return new Cycles((Cycles.Factor / Degree.Factor) * q.Value); }
        public static explicit operator Cycles(Radian q) { return new Cycles((Cycles.Factor / Radian.Factor) * q.Value); }
        public static Cycles From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Cycles.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Cycles\"", q.GetType().Name));
            return new Cycles((Cycles.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Cycles>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Cycles) && Equals((Cycles)obj); }
        public bool /* IEquatable<Cycles> */ Equals(Cycles other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Cycles>
        public static bool operator ==(Cycles lhs, Cycles rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Cycles lhs, Cycles rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Cycles lhs, Cycles rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Cycles lhs, Cycles rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Cycles lhs, Cycles rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Cycles lhs, Cycles rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Cycles> */ CompareTo(Cycles other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Cycles operator +(Cycles lhs, Cycles rhs) { return new Cycles(lhs.Value + rhs.Value); }
        public static Cycles operator -(Cycles lhs, Cycles rhs) { return new Cycles(lhs.Value - rhs.Value); }
        public static Cycles operator ++(Cycles q) { return new Cycles(q.Value + 1d); }
        public static Cycles operator --(Cycles q) { return new Cycles(q.Value - 1d); }
        public static Cycles operator -(Cycles q) { return new Cycles(-q.Value); }
        public static Cycles operator *(double lhs, Cycles rhs) { return new Cycles(lhs * rhs.Value); }
        public static Cycles operator *(Cycles lhs, double rhs) { return new Cycles(lhs.Value * rhs); }
        public static Cycles operator /(Cycles lhs, double rhs) { return new Cycles(lhs.Value / rhs); }
        public static double operator /(Cycles lhs, Cycles rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Hertz operator /(Cycles lhs, Second rhs) { return new Hertz(lhs.Value / rhs.Value); }
        public static Second operator /(Cycles lhs, Hertz rhs) { return new Second(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Cycles.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Cycles.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Cycles.Format, Value, Cycles.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Radian.Sense;
        private static readonly int s_family = Radian.Family;
        private static double s_factor = Radian.Factor / (2d * Math.PI);
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Hertz(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Hertz(double q) { return new Hertz(q); }
        public static Hertz From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Hertz.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Hertz\"", q.GetType().Name));
            return new Hertz((Hertz.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Hertz>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Hertz) && Equals((Hertz)obj); }
        public bool /* IEquatable<Hertz> */ Equals(Hertz other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Hertz>
        public static bool operator ==(Hertz lhs, Hertz rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Hertz lhs, Hertz rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Hertz lhs, Hertz rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Hertz lhs, Hertz rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Hertz lhs, Hertz rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Hertz lhs, Hertz rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Hertz> */ CompareTo(Hertz other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Hertz operator +(Hertz lhs, Hertz rhs) { return new Hertz(lhs.Value + rhs.Value); }
        public static Hertz operator -(Hertz lhs, Hertz rhs) { return new Hertz(lhs.Value - rhs.Value); }
        public static Hertz operator ++(Hertz q) { return new Hertz(q.Value + 1d); }
        public static Hertz operator --(Hertz q) { return new Hertz(q.Value - 1d); }
        public static Hertz operator -(Hertz q) { return new Hertz(-q.Value); }
        public static Hertz operator *(double lhs, Hertz rhs) { return new Hertz(lhs * rhs.Value); }
        public static Hertz operator *(Hertz lhs, double rhs) { return new Hertz(lhs.Value * rhs); }
        public static Hertz operator /(Hertz lhs, double rhs) { return new Hertz(lhs.Value / rhs); }
        public static double operator /(Hertz lhs, Hertz rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Cycles operator *(Hertz lhs, Second rhs) { return new Cycles(lhs.Value * rhs.Value); }
        public static Cycles operator *(Second lhs, Hertz rhs) { return new Cycles(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Hertz.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Hertz.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Hertz.Format, Value, Hertz.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Cycles.Sense / Second.Sense;
        private static readonly int s_family = 6;
        private static double s_factor = Cycles.Factor / Second.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public SquareMeter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator SquareMeter(double q) { return new SquareMeter(q); }
        public static SquareMeter From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != SquareMeter.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"SquareMeter\"", q.GetType().Name));
            return new SquareMeter((SquareMeter.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<SquareMeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is SquareMeter) && Equals((SquareMeter)obj); }
        public bool /* IEquatable<SquareMeter> */ Equals(SquareMeter other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<SquareMeter>
        public static bool operator ==(SquareMeter lhs, SquareMeter rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(SquareMeter lhs, SquareMeter rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(SquareMeter lhs, SquareMeter rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(SquareMeter lhs, SquareMeter rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(SquareMeter lhs, SquareMeter rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(SquareMeter lhs, SquareMeter rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<SquareMeter> */ CompareTo(SquareMeter other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static SquareMeter operator +(SquareMeter lhs, SquareMeter rhs) { return new SquareMeter(lhs.Value + rhs.Value); }
        public static SquareMeter operator -(SquareMeter lhs, SquareMeter rhs) { return new SquareMeter(lhs.Value - rhs.Value); }
        public static SquareMeter operator ++(SquareMeter q) { return new SquareMeter(q.Value + 1d); }
        public static SquareMeter operator --(SquareMeter q) { return new SquareMeter(q.Value - 1d); }
        public static SquareMeter operator -(SquareMeter q) { return new SquareMeter(-q.Value); }
        public static SquareMeter operator *(double lhs, SquareMeter rhs) { return new SquareMeter(lhs * rhs.Value); }
        public static SquareMeter operator *(SquareMeter lhs, double rhs) { return new SquareMeter(lhs.Value * rhs); }
        public static SquareMeter operator /(SquareMeter lhs, double rhs) { return new SquareMeter(lhs.Value / rhs); }
        public static double operator /(SquareMeter lhs, SquareMeter rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Meter operator /(SquareMeter lhs, Meter rhs) { return new Meter(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(SquareMeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(SquareMeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? SquareMeter.Format, Value, SquareMeter.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense * Meter.Sense;
        private static readonly int s_family = 7;
        private static double s_factor = Meter.Factor * Meter.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Meter_Sec(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Meter_Sec(double q) { return new Meter_Sec(q); }
        public static Meter_Sec From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Meter_Sec.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Meter_Sec\"", q.GetType().Name));
            return new Meter_Sec((Meter_Sec.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Meter_Sec>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter_Sec) && Equals((Meter_Sec)obj); }
        public bool /* IEquatable<Meter_Sec> */ Equals(Meter_Sec other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Meter_Sec>
        public static bool operator ==(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Meter_Sec> */ CompareTo(Meter_Sec other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter_Sec operator +(Meter_Sec lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.Value + rhs.Value); }
        public static Meter_Sec operator -(Meter_Sec lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.Value - rhs.Value); }
        public static Meter_Sec operator ++(Meter_Sec q) { return new Meter_Sec(q.Value + 1d); }
        public static Meter_Sec operator --(Meter_Sec q) { return new Meter_Sec(q.Value - 1d); }
        public static Meter_Sec operator -(Meter_Sec q) { return new Meter_Sec(-q.Value); }
        public static Meter_Sec operator *(double lhs, Meter_Sec rhs) { return new Meter_Sec(lhs * rhs.Value); }
        public static Meter_Sec operator *(Meter_Sec lhs, double rhs) { return new Meter_Sec(lhs.Value * rhs); }
        public static Meter_Sec operator /(Meter_Sec lhs, double rhs) { return new Meter_Sec(lhs.Value / rhs); }
        public static double operator /(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Meter operator *(Meter_Sec lhs, Second rhs) { return new Meter(lhs.Value * rhs.Value); }
        public static Meter operator *(Second lhs, Meter_Sec rhs) { return new Meter(lhs.Value * rhs.Value); }
        public static Meter_Sec2 operator /(Meter_Sec lhs, Second rhs) { return new Meter_Sec2(lhs.Value / rhs.Value); }
        public static Second operator /(Meter_Sec lhs, Meter_Sec2 rhs) { return new Second(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter_Sec.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter_Sec.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Meter_Sec.Format, Value, Meter_Sec.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense / Second.Sense;
        private static readonly int s_family = 8;
        private static double s_factor = Meter.Factor / Second.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Meter_Sec2(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Meter_Sec2(double q) { return new Meter_Sec2(q); }
        public static Meter_Sec2 From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Meter_Sec2.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Meter_Sec2\"", q.GetType().Name));
            return new Meter_Sec2((Meter_Sec2.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Meter_Sec2>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter_Sec2) && Equals((Meter_Sec2)obj); }
        public bool /* IEquatable<Meter_Sec2> */ Equals(Meter_Sec2 other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Meter_Sec2>
        public static bool operator ==(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Meter_Sec2> */ CompareTo(Meter_Sec2 other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter_Sec2 operator +(Meter_Sec2 lhs, Meter_Sec2 rhs) { return new Meter_Sec2(lhs.Value + rhs.Value); }
        public static Meter_Sec2 operator -(Meter_Sec2 lhs, Meter_Sec2 rhs) { return new Meter_Sec2(lhs.Value - rhs.Value); }
        public static Meter_Sec2 operator ++(Meter_Sec2 q) { return new Meter_Sec2(q.Value + 1d); }
        public static Meter_Sec2 operator --(Meter_Sec2 q) { return new Meter_Sec2(q.Value - 1d); }
        public static Meter_Sec2 operator -(Meter_Sec2 q) { return new Meter_Sec2(-q.Value); }
        public static Meter_Sec2 operator *(double lhs, Meter_Sec2 rhs) { return new Meter_Sec2(lhs * rhs.Value); }
        public static Meter_Sec2 operator *(Meter_Sec2 lhs, double rhs) { return new Meter_Sec2(lhs.Value * rhs); }
        public static Meter_Sec2 operator /(Meter_Sec2 lhs, double rhs) { return new Meter_Sec2(lhs.Value / rhs); }
        public static double operator /(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Meter_Sec operator *(Meter_Sec2 lhs, Second rhs) { return new Meter_Sec(lhs.Value * rhs.Value); }
        public static Meter_Sec operator *(Second lhs, Meter_Sec2 rhs) { return new Meter_Sec(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter_Sec2.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter_Sec2.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Meter_Sec2.Format, Value, Meter_Sec2.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter_Sec.Sense / Second.Sense;
        private static readonly int s_family = 9;
        private static double s_factor = Meter_Sec.Factor / Second.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Newton(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Newton(double q) { return new Newton(q); }
        public static Newton From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Newton.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Newton\"", q.GetType().Name));
            return new Newton((Newton.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Newton>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Newton) && Equals((Newton)obj); }
        public bool /* IEquatable<Newton> */ Equals(Newton other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Newton>
        public static bool operator ==(Newton lhs, Newton rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Newton lhs, Newton rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Newton lhs, Newton rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Newton lhs, Newton rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Newton lhs, Newton rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Newton lhs, Newton rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Newton> */ CompareTo(Newton other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Newton operator +(Newton lhs, Newton rhs) { return new Newton(lhs.Value + rhs.Value); }
        public static Newton operator -(Newton lhs, Newton rhs) { return new Newton(lhs.Value - rhs.Value); }
        public static Newton operator ++(Newton q) { return new Newton(q.Value + 1d); }
        public static Newton operator --(Newton q) { return new Newton(q.Value - 1d); }
        public static Newton operator -(Newton q) { return new Newton(-q.Value); }
        public static Newton operator *(double lhs, Newton rhs) { return new Newton(lhs * rhs.Value); }
        public static Newton operator *(Newton lhs, double rhs) { return new Newton(lhs.Value * rhs); }
        public static Newton operator /(Newton lhs, double rhs) { return new Newton(lhs.Value / rhs); }
        public static double operator /(Newton lhs, Newton rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Meter_Sec2 operator /(Newton lhs, Kilogram rhs) { return new Meter_Sec2(lhs.Value / rhs.Value); }
        public static Kilogram operator /(Newton lhs, Meter_Sec2 rhs) { return new Kilogram(lhs.Value / rhs.Value); }
        public static Joule operator *(Newton lhs, Meter rhs) { return new Joule(lhs.Value * rhs.Value); }
        public static Joule operator *(Meter lhs, Newton rhs) { return new Joule(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Newton.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Newton.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Newton.Format, Value, Newton.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense * Meter_Sec2.Sense;
        private static readonly int s_family = 10;
        private static double s_factor = Kilogram.Factor * Meter_Sec2.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Joule(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Joule(double q) { return new Joule(q); }
        public static Joule From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Joule.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Joule\"", q.GetType().Name));
            return new Joule((Joule.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Joule>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Joule) && Equals((Joule)obj); }
        public bool /* IEquatable<Joule> */ Equals(Joule other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Joule>
        public static bool operator ==(Joule lhs, Joule rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Joule lhs, Joule rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Joule lhs, Joule rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Joule lhs, Joule rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Joule lhs, Joule rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Joule lhs, Joule rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Joule> */ CompareTo(Joule other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule operator +(Joule lhs, Joule rhs) { return new Joule(lhs.Value + rhs.Value); }
        public static Joule operator -(Joule lhs, Joule rhs) { return new Joule(lhs.Value - rhs.Value); }
        public static Joule operator ++(Joule q) { return new Joule(q.Value + 1d); }
        public static Joule operator --(Joule q) { return new Joule(q.Value - 1d); }
        public static Joule operator -(Joule q) { return new Joule(-q.Value); }
        public static Joule operator *(double lhs, Joule rhs) { return new Joule(lhs * rhs.Value); }
        public static Joule operator *(Joule lhs, double rhs) { return new Joule(lhs.Value * rhs); }
        public static Joule operator /(Joule lhs, double rhs) { return new Joule(lhs.Value / rhs); }
        public static double operator /(Joule lhs, Joule rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Meter operator /(Joule lhs, Newton rhs) { return new Meter(lhs.Value / rhs.Value); }
        public static Newton operator /(Joule lhs, Meter rhs) { return new Newton(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Joule.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Joule.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Joule.Format, Value, Joule.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense * Meter.Sense;
        private static readonly int s_family = 11;
        private static double s_factor = Newton.Factor * Meter.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public NewtonMeter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator NewtonMeter(double q) { return new NewtonMeter(q); }
        public static NewtonMeter From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != NewtonMeter.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"NewtonMeter\"", q.GetType().Name));
            return new NewtonMeter((NewtonMeter.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<NewtonMeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is NewtonMeter) && Equals((NewtonMeter)obj); }
        public bool /* IEquatable<NewtonMeter> */ Equals(NewtonMeter other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<NewtonMeter>
        public static bool operator ==(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<NewtonMeter> */ CompareTo(NewtonMeter other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static NewtonMeter operator +(NewtonMeter lhs, NewtonMeter rhs) { return new NewtonMeter(lhs.Value + rhs.Value); }
        public static NewtonMeter operator -(NewtonMeter lhs, NewtonMeter rhs) { return new NewtonMeter(lhs.Value - rhs.Value); }
        public static NewtonMeter operator ++(NewtonMeter q) { return new NewtonMeter(q.Value + 1d); }
        public static NewtonMeter operator --(NewtonMeter q) { return new NewtonMeter(q.Value - 1d); }
        public static NewtonMeter operator -(NewtonMeter q) { return new NewtonMeter(-q.Value); }
        public static NewtonMeter operator *(double lhs, NewtonMeter rhs) { return new NewtonMeter(lhs * rhs.Value); }
        public static NewtonMeter operator *(NewtonMeter lhs, double rhs) { return new NewtonMeter(lhs.Value * rhs); }
        public static NewtonMeter operator /(NewtonMeter lhs, double rhs) { return new NewtonMeter(lhs.Value / rhs); }
        public static double operator /(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(NewtonMeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(NewtonMeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? NewtonMeter.Format, Value, NewtonMeter.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense * Meter_Sec2.Sense * Meter.Sense;
        private static readonly int s_family = 12;
        private static double s_factor = Kilogram.Factor * Meter_Sec2.Factor * Meter.Factor;
        private static string s_format = "{0} {1}";
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
        private readonly DegKelvin m_level;
        #endregion

        #region Properties
        // instance properties
        public DegKelvin Level { get { return m_level; } }
        public DegKelvin NormalizedLevel { get { return (m_level - Kelvin.Offset); } }
        // ILevel<double> properties
        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
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
        #endregion

        #region Conversions
        public static explicit operator Kelvin(double q) { return new Kelvin(q); }
        public static explicit operator Kelvin(DegKelvin q) { return new Kelvin(q); }

        public static explicit operator Kelvin(Fahrenheit q) { return new Kelvin((DegKelvin)(q.NormalizedLevel) + Kelvin.Offset); }
        public static explicit operator Kelvin(Rankine q) { return new Kelvin((DegKelvin)(q.NormalizedLevel) + Kelvin.Offset); }
        public static explicit operator Kelvin(Celsius q) { return new Kelvin((DegKelvin)(q.NormalizedLevel) + Kelvin.Offset); }

        public static Kelvin From(ILevel<double> q)
        {
            /* The following 2 statements might be required if you have two (or more) scale families derived from the same units
               but bound to different reference levels. E.g. two families of temperature scales: one with common reference level
               set to absolute zero and the other one with common reference level set to water freeze point.
               This is rather unlikely and the statements are commented out to avoid (likely) superfluous checks. */
               
            // Scale<double> source = new Scale<double>(q);
            // if (source.Family != Kelvin.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Kelvin\"", q.GetType().Name));

            return new Kelvin(DegKelvin.From(q.NormalizedLevel) + Kelvin.Offset);
        }
        #endregion

        #region IObject / IEquatable<Kelvin>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Kelvin) && Equals((Kelvin)obj); }
        public bool /* IEquatable<Kelvin> */ Equals(Kelvin other) { return this.Level == other.Level; }
        #endregion

        #region Comparison / IComparable<Kelvin>
        public static bool operator ==(Kelvin lhs, Kelvin rhs) { return lhs.Level == rhs.Level; }
        public static bool operator !=(Kelvin lhs, Kelvin rhs) { return lhs.Level != rhs.Level; }
        public static bool operator <(Kelvin lhs, Kelvin rhs) { return lhs.Level < rhs.Level; }
        public static bool operator >(Kelvin lhs, Kelvin rhs) { return lhs.Level > rhs.Level; }
        public static bool operator <=(Kelvin lhs, Kelvin rhs) { return lhs.Level <= rhs.Level; }
        public static bool operator >=(Kelvin lhs, Kelvin rhs) { return lhs.Level >= rhs.Level; }
        public int /* IComparable<Kelvin> */ CompareTo(Kelvin other) { return this.Level.CompareTo(other.Level); }
        #endregion

        #region Arithmetic
        public static Kelvin operator +(Kelvin lhs, DegKelvin rhs) { return new Kelvin(lhs.Level + rhs); }
        public static Kelvin operator +(DegKelvin lhs, Kelvin rhs) { return new Kelvin(lhs + rhs.Level); }
        public static Kelvin operator -(Kelvin lhs, DegKelvin rhs) { return new Kelvin(lhs.Level - rhs); }
        public static DegKelvin operator -(Kelvin lhs, Kelvin rhs) { return (lhs.Level - rhs.Level); }
        public static Kelvin operator -(Kelvin q) { return new Kelvin(-q.Level); }
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
        private static string s_format = "{0} {1}";
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
        private readonly DegCelsius m_level;
        #endregion

        #region Properties
        // instance properties
        public DegCelsius Level { get { return m_level; } }
        public DegCelsius NormalizedLevel { get { return (m_level - Celsius.Offset); } }
        // ILevel<double> properties
        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
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
        #endregion

        #region Conversions
        public static explicit operator Celsius(double q) { return new Celsius(q); }
        public static explicit operator Celsius(DegCelsius q) { return new Celsius(q); }

        public static explicit operator Celsius(Kelvin q) { return new Celsius((DegCelsius)(q.NormalizedLevel) + Celsius.Offset); }
        public static explicit operator Celsius(Fahrenheit q) { return new Celsius((DegCelsius)(q.NormalizedLevel) + Celsius.Offset); }
        public static explicit operator Celsius(Rankine q) { return new Celsius((DegCelsius)(q.NormalizedLevel) + Celsius.Offset); }

        public static Celsius From(ILevel<double> q)
        {
            /* The following 2 statements might be required if you have two (or more) scale families derived from the same units
               but bound to different reference levels. E.g. two families of temperature scales: one with common reference level
               set to absolute zero and the other one with common reference level set to water freeze point.
               This is rather unlikely and the statements are commented out to avoid (likely) superfluous checks. */
               
            // Scale<double> source = new Scale<double>(q);
            // if (source.Family != Celsius.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Celsius\"", q.GetType().Name));

            return new Celsius(DegCelsius.From(q.NormalizedLevel) + Celsius.Offset);
        }
        #endregion

        #region IObject / IEquatable<Celsius>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Celsius) && Equals((Celsius)obj); }
        public bool /* IEquatable<Celsius> */ Equals(Celsius other) { return this.Level == other.Level; }
        #endregion

        #region Comparison / IComparable<Celsius>
        public static bool operator ==(Celsius lhs, Celsius rhs) { return lhs.Level == rhs.Level; }
        public static bool operator !=(Celsius lhs, Celsius rhs) { return lhs.Level != rhs.Level; }
        public static bool operator <(Celsius lhs, Celsius rhs) { return lhs.Level < rhs.Level; }
        public static bool operator >(Celsius lhs, Celsius rhs) { return lhs.Level > rhs.Level; }
        public static bool operator <=(Celsius lhs, Celsius rhs) { return lhs.Level <= rhs.Level; }
        public static bool operator >=(Celsius lhs, Celsius rhs) { return lhs.Level >= rhs.Level; }
        public int /* IComparable<Celsius> */ CompareTo(Celsius other) { return this.Level.CompareTo(other.Level); }
        #endregion

        #region Arithmetic
        public static Celsius operator +(Celsius lhs, DegCelsius rhs) { return new Celsius(lhs.Level + rhs); }
        public static Celsius operator +(DegCelsius lhs, Celsius rhs) { return new Celsius(lhs + rhs.Level); }
        public static Celsius operator -(Celsius lhs, DegCelsius rhs) { return new Celsius(lhs.Level - rhs); }
        public static DegCelsius operator -(Celsius lhs, Celsius rhs) { return (lhs.Level - rhs.Level); }
        public static Celsius operator -(Celsius q) { return new Celsius(-q.Level); }
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
        private static string s_format = "{0} {1}";
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
        private readonly DegRankine m_level;
        #endregion

        #region Properties
        // instance properties
        public DegRankine Level { get { return m_level; } }
        public DegRankine NormalizedLevel { get { return (m_level - Rankine.Offset); } }
        // ILevel<double> properties
        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
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
        #endregion

        #region Conversions
        public static explicit operator Rankine(double q) { return new Rankine(q); }
        public static explicit operator Rankine(DegRankine q) { return new Rankine(q); }

        public static explicit operator Rankine(Celsius q) { return new Rankine((DegRankine)(q.NormalizedLevel) + Rankine.Offset); }
        public static explicit operator Rankine(Kelvin q) { return new Rankine((DegRankine)(q.NormalizedLevel) + Rankine.Offset); }
        public static explicit operator Rankine(Fahrenheit q) { return new Rankine((DegRankine)(q.NormalizedLevel) + Rankine.Offset); }

        public static Rankine From(ILevel<double> q)
        {
            /* The following 2 statements might be required if you have two (or more) scale families derived from the same units
               but bound to different reference levels. E.g. two families of temperature scales: one with common reference level
               set to absolute zero and the other one with common reference level set to water freeze point.
               This is rather unlikely and the statements are commented out to avoid (likely) superfluous checks. */
               
            // Scale<double> source = new Scale<double>(q);
            // if (source.Family != Rankine.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Rankine\"", q.GetType().Name));

            return new Rankine(DegRankine.From(q.NormalizedLevel) + Rankine.Offset);
        }
        #endregion

        #region IObject / IEquatable<Rankine>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Rankine) && Equals((Rankine)obj); }
        public bool /* IEquatable<Rankine> */ Equals(Rankine other) { return this.Level == other.Level; }
        #endregion

        #region Comparison / IComparable<Rankine>
        public static bool operator ==(Rankine lhs, Rankine rhs) { return lhs.Level == rhs.Level; }
        public static bool operator !=(Rankine lhs, Rankine rhs) { return lhs.Level != rhs.Level; }
        public static bool operator <(Rankine lhs, Rankine rhs) { return lhs.Level < rhs.Level; }
        public static bool operator >(Rankine lhs, Rankine rhs) { return lhs.Level > rhs.Level; }
        public static bool operator <=(Rankine lhs, Rankine rhs) { return lhs.Level <= rhs.Level; }
        public static bool operator >=(Rankine lhs, Rankine rhs) { return lhs.Level >= rhs.Level; }
        public int /* IComparable<Rankine> */ CompareTo(Rankine other) { return this.Level.CompareTo(other.Level); }
        #endregion

        #region Arithmetic
        public static Rankine operator +(Rankine lhs, DegRankine rhs) { return new Rankine(lhs.Level + rhs); }
        public static Rankine operator +(DegRankine lhs, Rankine rhs) { return new Rankine(lhs + rhs.Level); }
        public static Rankine operator -(Rankine lhs, DegRankine rhs) { return new Rankine(lhs.Level - rhs); }
        public static DegRankine operator -(Rankine lhs, Rankine rhs) { return (lhs.Level - rhs.Level); }
        public static Rankine operator -(Rankine q) { return new Rankine(-q.Level); }
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
        private static string s_format = "{0} {1}";
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
        private readonly DegFahrenheit m_level;
        #endregion

        #region Properties
        // instance properties
        public DegFahrenheit Level { get { return m_level; } }
        public DegFahrenheit NormalizedLevel { get { return (m_level - Fahrenheit.Offset); } }
        // ILevel<double> properties
        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
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
        #endregion

        #region Conversions
        public static explicit operator Fahrenheit(double q) { return new Fahrenheit(q); }
        public static explicit operator Fahrenheit(DegFahrenheit q) { return new Fahrenheit(q); }

        public static explicit operator Fahrenheit(Rankine q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }
        public static explicit operator Fahrenheit(Celsius q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }
        public static explicit operator Fahrenheit(Kelvin q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }

        public static Fahrenheit From(ILevel<double> q)
        {
            /* The following 2 statements might be required if you have two (or more) scale families derived from the same units
               but bound to different reference levels. E.g. two families of temperature scales: one with common reference level
               set to absolute zero and the other one with common reference level set to water freeze point.
               This is rather unlikely and the statements are commented out to avoid (likely) superfluous checks. */
               
            // Scale<double> source = new Scale<double>(q);
            // if (source.Family != Fahrenheit.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Fahrenheit\"", q.GetType().Name));

            return new Fahrenheit(DegFahrenheit.From(q.NormalizedLevel) + Fahrenheit.Offset);
        }
        #endregion

        #region IObject / IEquatable<Fahrenheit>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Fahrenheit) && Equals((Fahrenheit)obj); }
        public bool /* IEquatable<Fahrenheit> */ Equals(Fahrenheit other) { return this.Level == other.Level; }
        #endregion

        #region Comparison / IComparable<Fahrenheit>
        public static bool operator ==(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level == rhs.Level; }
        public static bool operator !=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level != rhs.Level; }
        public static bool operator <(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level < rhs.Level; }
        public static bool operator >(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level > rhs.Level; }
        public static bool operator <=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level <= rhs.Level; }
        public static bool operator >=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level >= rhs.Level; }
        public int /* IComparable<Fahrenheit> */ CompareTo(Fahrenheit other) { return this.Level.CompareTo(other.Level); }
        #endregion

        #region Arithmetic
        public static Fahrenheit operator +(Fahrenheit lhs, DegFahrenheit rhs) { return new Fahrenheit(lhs.Level + rhs); }
        public static Fahrenheit operator +(DegFahrenheit lhs, Fahrenheit rhs) { return new Fahrenheit(lhs + rhs.Level); }
        public static Fahrenheit operator -(Fahrenheit lhs, DegFahrenheit rhs) { return new Fahrenheit(lhs.Level - rhs); }
        public static DegFahrenheit operator -(Fahrenheit lhs, Fahrenheit rhs) { return (lhs.Level - rhs.Level); }
        public static Fahrenheit operator -(Fahrenheit q) { return new Fahrenheit(-q.Level); }
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
        private static string s_format = "{0} {1}";
        private static readonly Fahrenheit s_zero = new Fahrenheit(0d);
        
        public static DegFahrenheit Offset { get { return s_offset; } }
        public static int Family { get { return s_family; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static Fahrenheit Zero { get { return s_zero; } }
        #endregion
    }
}
