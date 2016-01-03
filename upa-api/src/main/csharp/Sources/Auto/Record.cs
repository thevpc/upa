/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    public interface Record {

          T GetObject<T>(string key);

          T GetObject<T>(string key, T defaultValue);

         void SetObject(string key, object @value);

          T GetSingleResult<T>();

         int GetInt(string key);

         int GetInt(string key, int @value);

         void SetInt(string key, int @value);

         int GetInt();

         long GetLong(string key);

         long GetLong(string key, long @value);

         void SetLong(string key, long @value);

         long GetLong();

         double GetDouble(string key);

         double GetDouble(string key, double @value);

         void SetDouble(string key, double @value);

         double GetDouble();

         float GetFloat(string key);

         float GetFloat(string key, float @value);

         void SetFloat(string key, float @value);

         float GetFloat();

         Net.Vpc.Upa.Types.Temporal GetDate(string key);

         Net.Vpc.Upa.Types.Temporal GetDate(string key, Net.Vpc.Upa.Types.Temporal @value);

         void SetDate(string key, Net.Vpc.Upa.Types.Temporal @value);

         Net.Vpc.Upa.Types.Temporal GetDate();

         string GetString(string key);

         string GetString(string key, string @value);

         void SetString(string key, string @value);

         string GetString();

         bool GetBoolean(string key);

         bool GetBoolean(string key, bool @value);

         void SetBoolean(string key, bool @value);

         bool GetBoolean();

         void SetNumber(string key, object @value);

         object GetNumber(string key, object @value);

         object GetNumber(string key);

         object GetNumber();









         void SetBigInteger(string key, System.Numerics.BigInteger? @value);

         System.Numerics.BigInteger? GetBigInteger(string key, System.Numerics.BigInteger? @value);

         System.Numerics.BigInteger? GetBigInteger(string key);

         System.Numerics.BigInteger? GetBigInteger();

         System.Collections.Generic.ISet<string> KeySet();

         int Size();

         System.Collections.Generic.IDictionary<string , object> ToMap();

         void SetAll(System.Collections.Generic.IDictionary<string , object> other, params string [] keys);

         void SetAll(Net.Vpc.Upa.Record other, params string [] keys);

         bool IsSet(string key);

         void Remove(string key);

         bool RetainAll(System.Collections.Generic.ISet<string> keys);

         void AddPropertyChangeListener(string key, Net.Vpc.Upa.PropertyChangeListener listener);

         void RemovePropertyChangeListener(string key, Net.Vpc.Upa.PropertyChangeListener listener);

         void AddPropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener);

         void RemovePropertyChangeListener(Net.Vpc.Upa.PropertyChangeListener listener);

         bool IsEmpty();
    }
}
