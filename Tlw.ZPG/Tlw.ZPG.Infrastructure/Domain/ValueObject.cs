using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Reflection;
using System.Collections;

namespace Tlw.ZPG.Infrastructure
{
    /// <summary>
    /// Abstract Base Class for Value Objects
    /// Based on CodeCamp Server codebase http://code.google.com/p/codecampserver
    /// </summary>
    /// <typeparam name="TObject">The type of the object.</typeparam>
    [Serializable]
    public class ValueObject<TObject> : IEquatable<TObject> where TObject : class
    {

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(ValueObject<TObject> left, ValueObject<TObject> right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);

            return left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ValueObject<TObject> left, ValueObject<TObject> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Equalses the specified candidate.
        /// </summary>
        /// <param name="candidate">The candidate.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="candidate"/> parameter; otherwise, false.
        /// </returns>
        public override bool Equals(object candidate)
        {
            if (candidate == null)
                return false;

            var other = candidate as TObject;

            return Equals(other);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public virtual bool Equals(TObject other)
        {
            if (other == null)
                return false;

            Type t = GetType();

            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                object otherValue = field.GetValue(other);
                object thisValue = field.GetValue(this);

                //if the value is null...
                if (otherValue == null)
                {
                    if (thisValue != null)
                        return false;
                }
                //if the value is a datetime-related type...
                else if ((typeof(DateTime).IsAssignableFrom(field.FieldType)) ||
                         ((typeof(DateTime?).IsAssignableFrom(field.FieldType))))
                {
                    string dateString1 = ((DateTime)otherValue).ToLongDateString();
                    string dateString2 = ((DateTime)thisValue).ToLongDateString();
                    if (!dateString1.Equals(dateString2))
                    {
                        return false;
                    }
                    continue;
                }
                //if the value is any collection...
                else if (typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                {
                    IEnumerable otherEnumerable = (IEnumerable)otherValue;
                    IEnumerable thisEnumerable = (IEnumerable)thisValue;

                    if (!otherEnumerable.Cast<object>().SequenceEqual(thisEnumerable.Cast<object>()))
                        return false;
                }
                //if we get this far, just compare the two values...
                else if (!otherValue.Equals(thisValue))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            IEnumerable<FieldInfo> fields = GetFields();

            const int startValue = 17;
            const int multiplier = 59;

            int hashCode = startValue;

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(this);

                if (value != null)
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <returns>FieldInfo collection</returns>
        private IEnumerable<FieldInfo> GetFields()
        {
            Type t = GetType();

            var fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

                t = t.BaseType;
            }

            return fields;
        }

    }
}