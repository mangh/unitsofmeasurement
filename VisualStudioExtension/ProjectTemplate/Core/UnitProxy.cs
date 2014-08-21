using System;
using System.Reflection;

namespace $safeprojectname$
{
    public class UnitProxy : IEquatable<UnitProxy>
    {
        #region Fields
        private RuntimeTypeHandle m_handle;
        #endregion

        #region Properties
        public RuntimeTypeHandle Handle { get { return m_handle; } }
        public Type Unit { get { return Type.GetTypeFromHandle(m_handle); } }

        public Dimension Sense
        {
            get { return (Dimension)GetProperty(SensePropertyName); }
        }
        public int Family
        {
            get { return (int)GetProperty(FamilyPropertyName); }
        }
        public object Factor
        {
            get { return GetProperty(FactorPropertyName); }
            set { SetProperty(FactorPropertyName, value); }
        }
        public string Format
        {
            get { return (string)GetProperty(FormatPropertyName); }
            set { SetProperty(FormatPropertyName, value); }
        }
        public SymbolCollection Symbol
        {
            get { return (SymbolCollection)GetProperty(SymbolPropertyName); }
        }
        #endregion

        #region Constructor(s)
        public UnitProxy(Type t)
        {
            m_handle = t.TypeHandle;
        }
        #endregion

        #region IEquatable<UnitProxy>
        public override int GetHashCode() { return m_handle.GetHashCode(); }
        public override bool Equals(object obj) { return (obj != null) && (obj is UnitProxy) && Equals((UnitProxy)obj); }
        public bool Equals(UnitProxy other) { return this.m_handle.Equals(other.Handle); }
        #endregion

        #region Methods
        /// <exception cref="System.NullReferenceException">Thrown when name refers to non-existent property</exception>
        private object GetProperty(string name)
        {
            Type unit = this.Unit;
            PropertyInfo property = unit.GetProperty(name);
            return property.GetValue(unit, null);
        }
        /// <exception cref="System.NullReferenceException">Thrown when name refers to non-existent property</exception>
        private void SetProperty(string name, object value)
        {
            Type unit = this.Unit;
            PropertyInfo property = unit.GetProperty(name);
            property.SetValue(unit, value, null);
        }
        /// <exception cref="System.NullReferenceException">Thrown when name refers to non-existent property</exception>
        public object CreateInstance(object value)
        {
            // Constructor argument types
            Type[] argTypes = { value.GetType() };
            // Constructor argument values
            object[] argValues = { value };
            // Get constructor
            ConstructorInfo ctor = Unit.GetConstructor(argTypes);
            // Return unit instance
            return ctor.Invoke(argValues);
        }
        #endregion

        #region Statics
        // Constants
        private static readonly string s_sensePropertyName = "Sense";
        private static readonly string s_familyPropertyName = "Family";
        private static readonly string s_factorPropertyName = "Factor";
        private static readonly string s_formatPropertyName = "Format";
        private static readonly string s_symbolPropertyName = "Symbol";

        public static string SensePropertyName { get { return s_sensePropertyName; } }
        public static string FamilyPropertyName { get { return s_familyPropertyName; } }
        public static string FactorPropertyName { get { return s_factorPropertyName; } }
        public static string FormatPropertyName { get { return s_formatPropertyName; } }
        public static string SymbolPropertyName { get { return s_symbolPropertyName; } }
        // Methods
        public static bool IsAssignableFrom(Type t)
        {
            return t.IsValueType && (
                typeof(IQuantity<double>).IsAssignableFrom(t) ||
                typeof(IQuantity<decimal>).IsAssignableFrom(t) ||
                typeof(IQuantity<float>).IsAssignableFrom(t)
            );
        }
        #endregion
    }
}
