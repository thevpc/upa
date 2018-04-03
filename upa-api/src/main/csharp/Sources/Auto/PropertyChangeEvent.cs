using System;

namespace Net.Vpc.Upa{

	public partial class PropertyChangeEvent {
        private Object source;
        private String propertyName;
        private Object newValue;
        private Object oldValue;

        public PropertyChangeEvent(Object source, String propertyName, Object oldValue, Object newValue)
        {
            this.source = source;
            this.propertyName = propertyName;
            this.newValue = newValue;
            this.oldValue = oldValue;
        }

        public Object GetSource()
        {
            return source;
        }

        public Object GetNewValue()
        {
            return newValue;
        }

        public Object GetOldValue()
        {
            return oldValue;
        }

        public String GetPropertyName()
        {
            return propertyName;
        }
    }
}
