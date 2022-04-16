using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;

namespace OblivionSaveReader.web
{
    /// <summary>
    /// Custom dynamic object class for js compatability. Would use ExpandoObject, but that can't use bracket dereference.
    /// </summary>
    public class DObject : DynamicObject, IDictionary<string, object>
    {
        Dictionary<string, object?> data = new Dictionary<string, object?>();

        /// <summary>
        /// Helper method to convert an object to a string for key lookup.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string? ObjToString(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            if (obj.GetType() == typeof(string))
            {
                return (string)obj;
            }
            else
            {
                return obj.ToString();
            }
        }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public ICollection<string> Keys => ((IDictionary<string, object>)data).Keys;

        public ICollection<object> Values => ((IDictionary<string, object>)data).Values;

        public bool IsReadOnly => ((ICollection<KeyValuePair<string, object>>)data).IsReadOnly;

        object IDictionary<string,object>.this[string str]
        {
            get
            {
                if (str != null && data.TryGetValue(str, out dynamic? maybeVal))
                {
                    return maybeVal;
                }
                return null;
            }
            set
            {
                if (str != null)
                {
                    data[str] = value;
                }
                else
                {
                    System.Diagnostics.Debug.Write("Ignored write to null property: " + Environment.StackTrace);
                }
            }
        }

        public dynamic? this[object obj]
        {
            get
            {
                string? str = ObjToString(obj);
                if (str != null && data.TryGetValue(str, out dynamic? maybeVal))
                {
                    return maybeVal;
                }
                return null;
            }
            set
            {
                string? str = ObjToString(obj);
                if(str != null)
                {
                    data[str] = value;
                }
                else
                {
                    System.Diagnostics.Debug.Write("Ignored write to null property: " + Environment.StackTrace);
                }
                
            }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            var maybe = data.TryGetValue(binder.Name, out result);
            if (!maybe)
            {
                //so we can debug this
                return false;
            }
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            data[binder.Name] = value;
            return true;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, object>>)data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)data).GetEnumerator();
        }

        public void Add(string key, object value)
        {
            ((IDictionary<string, object>)data).Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return ((IDictionary<string, object>)data).ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return ((IDictionary<string, object>)data).Remove(key);
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out object value)
        {
            return ((IDictionary<string, object>)data).TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            ((ICollection<KeyValuePair<string, object>>)data).Add(item);
        }

        public void Clear()
        {
            ((ICollection<KeyValuePair<string, object>>)data).Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)data).Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, object>>)data).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)data).Remove(item);
        }
    }
}
