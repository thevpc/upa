using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Vpc.Upa
{
	public sealed partial class FlagSets
    {
        public static FlagSet<E> Of<E>(E first, params E[] others)
        {
            HashSet<E> enumSet2 = new HashSet<E>();
            enumSet2.Add(first);
            foreach (var other in others)
            {
                enumSet2.Add(other);
            }
            return new FlagSet<E>(first.GetType(), enumSet2);
        }

        public static FlagSet<E> OfType<E>()
        {
            return new FlagSet<E>(typeof(E), new HashSet<E>());
        }

        public static FlagSet<E> NoneOf<E>()
        {
            HashSet<E> enumSet2 = new HashSet<E>();
            return new FlagSet<E>(typeof(E), enumSet2);
        }

        public static FlagSet<E> AllOf<E>()
        {
            Array values = Enum.GetValues(typeof(E));
            HashSet<E> enumSet2 = new HashSet<E>();
            foreach (var other in values)
            {
                enumSet2.Add((E)other);
            }
            return new FlagSet<E>(typeof(E), enumSet2);
        }

        public static FlagSet<E> CopyOf<E>(FlagSet<E> s)
        {
            return new FlagSet<E>(s.GetType().GetGenericArguments()[0], new HashSet<E>(s.AsSet()));
        }

    }
}
