using System;
using System.Collections.Generic;

namespace Net.Vpc.Upa{

    public interface PropertyChangeListener
    {
        void PropertyChange(PropertyChangeEvent evt);
    }
}
