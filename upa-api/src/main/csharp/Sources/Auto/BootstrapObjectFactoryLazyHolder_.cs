using System;
using System.Collections.Generic;
using System.Reflection;

namespace Net.Vpc.Upa
{
    internal partial class BootstrapObjectFactoryLazyHolder
    {
        internal static ObjectFactory Create()
        {
            ObjectFactory factory = null;
            ObjectFactory rootFactory = null;
            var factories = new List<ObjectFactory>();
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type t in a.GetTypes())
                {
                    if (t.FullName.Equals("Net.Vpc.Upa.RootObjectFactory"))
                    {
                        rootFactory = (ObjectFactory) Activator.CreateInstance(t);
                    }
                    else if (t.GetInterface(typeof (ObjectFactory).FullName) != null)
                    {
                        var fact = (ObjectFactory) Activator.CreateInstance(t);
                        factories.Add(fact);
                    }
                }
            }

            factories.Sort(
                delegate(ObjectFactory p1, ObjectFactory p2) { return p1.GetContextSupportLevel().CompareTo(p2.GetContextSupportLevel()); }
                );
            for (int i = factories.Count - 1; i > 1; i--)
            {
                factories[i].SetParentFactory(factories[i - 1]);
            }
            if (factories.Count > 0)
            {
                factory = factories[factories.Count - 1];
            }
            if (factory == null)
            {
            }
            else
            {
                factory.SetParentFactory(rootFactory);
            }
            return factory;
        }
    }
}