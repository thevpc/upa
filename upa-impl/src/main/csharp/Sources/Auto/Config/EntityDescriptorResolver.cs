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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/29/12 12:08 AM
     */
    public class EntityDescriptorResolver {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Config.EntityDescriptorResolver)).FullName);

        private Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository;

        private Net.Vpc.Upa.Impl.Config.Annotationparser.DecorationEntityDescriptorResolver annotationParser;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        public EntityDescriptorResolver(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository) {
            this.persistenceUnit = persistenceUnit;
            this.decorationRepository = decorationRepository;
            this.annotationParser = new Net.Vpc.Upa.Impl.Config.Annotationparser.DecorationEntityDescriptorResolver(decorationRepository, persistenceUnit.GetFactory());
        }

        public virtual Net.Vpc.Upa.EntityDescriptor Resolve(object source) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (source == null) {
                throw new System.ArgumentException ("null entity descriptor");
            }
            if (source is Net.Vpc.Upa.EntityDescriptor) {
                return (Net.Vpc.Upa.EntityDescriptor) source;
            }
            if (source is System.Type) {
                System.Collections.Generic.List<System.Type> classesColl = new System.Collections.Generic.List<System.Type>();
                classesColl.Add((System.Type) source);
                source = classesColl;
            } else if (source is System.Type[]) {
                System.Collections.Generic.List<System.Type> classesColl = new System.Collections.Generic.List<System.Type>();
                foreach (object o in (System.Type[]) source) {
                    if (o is System.Type) {
                        classesColl.Add((System.Type) o);
                    } else {
                        classesColl = null;
                        break;
                    }
                }
                source = classesColl;
            } else if (IsCollection(source)) {
                System.Collections.Generic.List<System.Type> classesColl = new System.Collections.Generic.List<System.Type>();
                foreach (object o in (System.Collections.Generic.ICollection<object>) source) {
                    if (o is System.Type) {
                        classesColl.Add((System.Type) o);
                    } else {
                        throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("ExpectedEntityDescriptorOrAnnotatedClass"));
                    }
                }
            }
            if (IsCollection(source)) {
                System.Collections.Generic.ICollection<System.Type> classesColl = (System.Collections.Generic.ICollection<System.Type>) source;
                if ((classesColl.Count==0)) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("ExpectedEntityDescriptorOrAnnotatedClass"));
                }
                System.Type[] classes = classesColl.ToArray();
                persistenceUnit.Scan(persistenceUnit.GetPersistenceGroup().GetContext().GetFactory().CreateClassScanSource(classes, true), null, false);
                return annotationParser.Resolve(classes);
            }
            throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("ExpectedEntityDescriptorOrAnnotatedClass"));
        }

        protected internal virtual bool IsCollection(object o) {
            bool ok = false;
            ok=o is System.Collections.ICollection;
            return ok;
        }
    }
}
