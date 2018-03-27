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



namespace Net.Vpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 11:47 AM
     */
    internal class SequenceInfo {

        internal Net.Vpc.Upa.SequenceStrategy strategy;

        internal Net.Vpc.Upa.SequenceType sequenceType = Net.Vpc.Upa.SequenceType.DEFAULT;

        internal int? initialValue;

        internal int? allocationSize;

        internal int? formulaOrder;

        internal string format;

        internal string name;

        internal string group;

        internal int configOrder = System.Int32.MinValue;

        internal bool specified = false;

        internal Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        public SequenceInfo(Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo) {
            this.repo = repo;
        }

        public virtual void Parse(System.Collections.Generic.IList<System.Reflection.FieldInfo> fields) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> persistSequenceFields = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
            foreach (System.Reflection.FieldInfo javaField in fields) {
                Net.Vpc.Upa.Config.Decoration gid = repo.GetFieldDecoration(javaField, typeof(Net.Vpc.Upa.Config.Sequence));
                if (gid != null) {
                    persistSequenceFields.Add(gid);
                }
            }
            if ((persistSequenceFields).Count > 1) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(persistSequenceFields, Net.Vpc.Upa.Impl.Config.Annotationparser.DecorationComparator.INSTANCE);
            }
            foreach (Net.Vpc.Upa.Config.Decoration gid in persistSequenceFields) {
                MergeSequence(gid);
            }
        }

        public virtual void MergeSequence(Net.Vpc.Upa.Config.Decoration gid) {
            specified = true;
            if (gid.GetConfig().GetOrder() >= configOrder) {
                specified = true;
                if (gid.GetInt("allocationSize") != System.Int32.MinValue) {
                    allocationSize = gid.GetInt("allocationSize");
                }
                if (gid.GetInt("initialValue") != System.Int32.MinValue) {
                    initialValue = gid.GetInt("initialValue");
                }
                if ((gid.GetString("format")).Length > 0) {
                    format = gid.GetString("format");
                }
                if ((gid.GetString("group")).Length > 0) {
                    group = gid.GetString("group");
                }
                if (!System.Collections.Generic.EqualityComparer<Net.Vpc.Upa.SequenceType>.Default.Equals(gid.GetEnum<Net.Vpc.Upa.SequenceType>("type", typeof(Net.Vpc.Upa.SequenceType)),Net.Vpc.Upa.SequenceType.DEFAULT)) {
                    sequenceType = gid.GetEnum<Net.Vpc.Upa.SequenceType>("type", typeof(Net.Vpc.Upa.SequenceType));
                }
                if ((gid.GetString("name")).Length > 0) {
                    name = gid.GetString("name");
                }
                if (!System.Collections.Generic.EqualityComparer<Net.Vpc.Upa.SequenceStrategy>.Default.Equals(gid.GetEnum<Net.Vpc.Upa.SequenceStrategy>("strategy", typeof(Net.Vpc.Upa.SequenceStrategy)),Net.Vpc.Upa.SequenceStrategy.UNSPECIFIED)) {
                    strategy = gid.GetEnum<Net.Vpc.Upa.SequenceStrategy>("strategy", typeof(Net.Vpc.Upa.SequenceStrategy));
                }
                if (gid.GetInt("formulaOrder") != System.Int32.MinValue) {
                    formulaOrder = gid.GetInt("formulaOrder");
                }
                if (gid.GetConfig().GetOrder() > configOrder) {
                    configOrder = gid.GetConfig().GetOrder();
                }
            }
        }
    }
}
