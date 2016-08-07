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



namespace Net.Vpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class EntityPartPath {

        private Net.Vpc.Upa.Entity entity;

        private System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> path;

        public EntityPartPath(Net.Vpc.Upa.Entity entity, System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> path) {
            this.entity = entity;
            if (path == null) {
                this.path = new System.Collections.Generic.List<Net.Vpc.Upa.EntityPart>();
            } else {
                this.path = new System.Collections.Generic.List<Net.Vpc.Upa.EntityPart>(path);
            }
        }

        public virtual void Add(Net.Vpc.Upa.EntityPart part) {
            path.Add(part);
        }

        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(entity.GetName());
            foreach (Net.Vpc.Upa.EntityPart p in path) {
                sb.Append("/");
                sb.Append(p.GetName());
            }
            return sb.ToString();
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.EntityPart> GetPath() {
            return path;
        }
    }
}
