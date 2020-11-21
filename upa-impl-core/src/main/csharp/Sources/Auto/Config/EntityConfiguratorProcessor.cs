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



namespace Net.TheVpc.Upa.Impl.Config
{


    /**
     * @author taha.bensalah@gmail.com
     */
    public sealed class EntityConfiguratorProcessor : Net.TheVpc.Upa.Callbacks.DefinitionListenerAdapter, Net.TheVpc.Upa.Callbacks.EntityDefinitionListener {

        private Net.TheVpc.Upa.Filters.EntityFilter filter;

        private Net.TheVpc.Upa.Impl.Config.EntityConfigurator configurator;

        private bool oneShot;

        private Net.TheVpc.Upa.PersistenceUnit u;

        private System.Collections.Generic.HashSet<string> added = new System.Collections.Generic.HashSet<string>();

        public static void ConfigureTracker(Net.TheVpc.Upa.PersistenceUnit u, Net.TheVpc.Upa.Filters.EntityFilter filter, Net.TheVpc.Upa.Impl.Config.EntityConfigurator configurator) {
            new Net.TheVpc.Upa.Impl.Config.EntityConfiguratorProcessor(false).Process(u, filter, configurator);
        }

        public static void ConfigureOneShot(Net.TheVpc.Upa.PersistenceUnit u, Net.TheVpc.Upa.Filters.EntityFilter filter, Net.TheVpc.Upa.Impl.Config.EntityConfigurator configurator) {
            new Net.TheVpc.Upa.Impl.Config.EntityConfiguratorProcessor(true).Process(u, filter, configurator);
        }

        private EntityConfiguratorProcessor(bool onShot) {
            this.oneShot = onShot;
        }

        private void Process(Net.TheVpc.Upa.PersistenceUnit u, Net.TheVpc.Upa.Filters.EntityFilter filter, Net.TheVpc.Upa.Impl.Config.EntityConfigurator configurator) {
            this.filter = filter;
            this.configurator = configurator;
            System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> f = u.GetEntities(filter);
            foreach (Net.TheVpc.Upa.Entity f1 in f) {
                configurator.Install(f1);
            }
            u.AddDefinitionListener(this);
        }

        public override void OnCreateEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
            Net.TheVpc.Upa.Entity e = @event.GetEntity();
            if (filter.Accept(e)) {
                if (!added.Contains(e.GetName())) {
                    added.Add(e.GetName());
                    configurator.Install(e);
                }
            }
        }

        public override void OnDropEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
            Net.TheVpc.Upa.Entity e = @event.GetEntity();
            if (filter.Accept(e)) {
                added.Add(e.GetName());
                configurator.Uninstall(@event.GetEntity());
                if (oneShot && (added).Count == 0) {
                    u.RemoveDefinitionListener(this);
                }
            }
        }

        public override void OnMoveEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }
    }
}
