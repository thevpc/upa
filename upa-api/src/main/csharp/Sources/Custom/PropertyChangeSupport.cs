using System;
using System.Collections.Generic;

namespace Net.Vpc.Upa{

    public class PropertyChangeSupport
    {
        private Dictionary<String, List<PropertyChangeListener> > listeners=new Dictionary<string, List<PropertyChangeListener>>();
        private Object source ;
        public PropertyChangeSupport(Object source)
        {
            if (source == null)
            {
                throw new Exception("NullPointerException");
            }
            this.source = source;
        }

        virtual public void AddPropertyChangeListener(String key, PropertyChangeListener listener)
        {
            List<PropertyChangeListener> list = null;
            listeners.TryGetValue(key, out list);
            if (list==null)
            {
                list=new List<PropertyChangeListener>();
                listeners[key]=list;
            }
            list.Add(listener);
        }


        virtual public void RemovePropertyChangeListener(String key, PropertyChangeListener listener)
        {
            List<PropertyChangeListener> list = null;
            listeners.TryGetValue(key, out list);
            if (list != null)
            {
                list.Remove(listener);
            }
        }


        virtual public void AddPropertyChangeListener(PropertyChangeListener listener)
        {
            AddPropertyChangeListener(null,listener);
        }


        virtual public void RemovePropertyChangeListener(PropertyChangeListener listener)
        {
            RemovePropertyChangeListener(null,listener);
        }

        virtual public void FirePropertyChange(System.String property, System.Object oldVal, System.Object newVal)
        {
            List<PropertyChangeListener> r =null;
            listeners.TryGetValue(property, out r);
            PropertyChangeEvent evt = null;
            if (r != null)
            {
                foreach (PropertyChangeListener listener in r)
                {
                    if (evt==null)
                    {
                        evt = new PropertyChangeEvent(source,property,oldVal,newVal);
                    }
                    listener.PropertyChange(evt);
                }
            }
            if(property!=null)
            {
                r = null;
                listeners.TryGetValue(null, out r);
                if (r != null)
                {
                    foreach (PropertyChangeListener listener in r)
                    {
                        if (evt == null)
                        {
                            evt = new PropertyChangeEvent(source, property, oldVal, newVal);
                        }
                        listener.PropertyChange(evt);
                    }
                }
            }
        }

        public virtual Net.Vpc.Upa.PropertyChangeListener[] GetPropertyChangeListeners()
        {
            List<Net.Vpc.Upa.PropertyChangeListener> ret = new List<Net.Vpc.Upa.PropertyChangeListener>();
            foreach (var entry in listeners)
            {
                foreach (var item in entry.Value)
                {
                    ret.Add(item);
                }
            }
            return ret.ToArray();
        }


        public virtual Net.Vpc.Upa.PropertyChangeListener[] GetPropertyChangeListeners(string property)
        {
            List<Net.Vpc.Upa.PropertyChangeListener> ret = new List<Net.Vpc.Upa.PropertyChangeListener>();
            List<PropertyChangeListener> r = null;
            listeners.TryGetValue(property, out r);
            if (r != null)
            {
                foreach (PropertyChangeListener listener in r)
                {
                    ret.Add(listener);
                }
            }
            return ret.ToArray();
        }

    }
}
