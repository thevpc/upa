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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/4/13 12:14 AM
     */
    internal class DefaultEntityPrivateChecker {

        private System.Collections.Generic.IList<string> errors = new System.Collections.Generic.List<string>();

        private System.Collections.Generic.IList<string> warnings = new System.Collections.Generic.List<string>();

        private Net.TheVpc.Upa.Impl.DefaultEntity defaultEntity;

        protected internal readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.DefaultEntityPrivateChecker)).FullName);

        public DefaultEntityPrivateChecker(Net.TheVpc.Upa.Impl.DefaultEntity defaultEntity) {
            this.defaultEntity = defaultEntity;
        }

        public virtual void AddError(string error) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            errors.Add(error);
            log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("[ERROR in Entity {0}.{1}] {2}",null,new object[] { defaultEntity.GetPersistenceUnit().GetName(), defaultEntity.GetName(), error }));
        }

        public virtual void AddWarning(string error) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            warnings.Add(error);
            log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("[WARNING in Table {0}.{1}] {2}",null,new object[] { defaultEntity.GetPersistenceUnit().GetName(), defaultEntity.GetName(), error }));
        }

        public virtual void Check() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if ((errors).Count > 0 || (warnings).Count > 0) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Found {0} error(s) and {1} warning(s) when checking {2}.{3} integrity",null,new object[] { (errors).Count, (warnings).Count, defaultEntity.GetPersistenceUnit().GetName(), defaultEntity.GetName() }));
                if ((errors).Count > 0) {
                    throw new Net.TheVpc.Upa.Exceptions.UPAException(errors[0]);
                }
            }
        }
    }
}
