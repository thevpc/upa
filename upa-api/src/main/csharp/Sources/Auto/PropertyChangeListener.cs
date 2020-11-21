using System;
using System.Collections.Generic;

namespace Net.TheVpc.Upa{

    public interface PropertyChangeListener
    {
        void PropertyChange(PropertyChangeEvent evt);
    }
}
