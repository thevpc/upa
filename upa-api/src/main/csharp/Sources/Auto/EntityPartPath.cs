/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class EntityPartPath {

        private Net.TheVpc.Upa.Entity entity;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> path;

        public EntityPartPath(Net.TheVpc.Upa.Entity entity, System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> path) {
            this.entity = entity;
            if (path == null) {
                this.path = new System.Collections.Generic.List<Net.TheVpc.Upa.EntityPart>(5);
            } else {
                this.path = new System.Collections.Generic.List<Net.TheVpc.Upa.EntityPart>(path);
            }
        }

        public virtual void Add(Net.TheVpc.Upa.EntityPart part) {
            path.Add(part);
        }

        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(entity.GetName());
            foreach (Net.TheVpc.Upa.EntityPart p in path) {
                sb.Append("/");
                sb.Append(p.GetName());
            }
            return sb.ToString();
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.EntityPart> GetPath() {
            return path;
        }
    }
}
