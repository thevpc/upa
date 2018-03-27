package net.vpc.upa.impl.extension;

import net.vpc.upa.Entity;
import net.vpc.upa.EntityModifier;
import net.vpc.upa.FlagSet;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.QueryStatement;
import net.vpc.upa.extensions.EntityExtensionDefinition;
import net.vpc.upa.extensions.ViewEntityExtensionDefinition;
import net.vpc.upa.impl.DefaultEntity;
import net.vpc.upa.impl.ext.EntityExt;
import net.vpc.upa.persistence.EntityOperationManager;
import net.vpc.upa.persistence.ViewEntityExtension;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 12:39 AM
 */
public class DefaultViewEntityExtension extends AbstractEntityExtension implements ViewEntityExtension {

    private QueryStatement viewQuery;

    @Override
    public void install(Entity entity, EntityOperationManager entityOperationManager, EntityExtensionDefinition extension) throws UPAException {
        super.install(entity, entityOperationManager, extension);
    }

    @Override
    public void commitModelChanges() throws UPAException {
        Entity entity = getEntity();
        ViewEntityExtensionDefinition entitySpec = (ViewEntityExtensionDefinition) getDefinition();
        viewQuery = entitySpec.getQuery(entity);
        FlagSet<EntityModifier> modifiers = entity.getUserModifiers();
        FlagSet<EntityModifier> excluded = entity.getUserExcludeModifiers();
        FlagSet<EntityModifier> effectiveModifiers = entity.getModifiers();
        if (!excluded.contains(EntityModifier.TRANSIENT)) {
            effectiveModifiers = effectiveModifiers.add(EntityModifier.TRANSIENT);
        }
        if (!modifiers.contains(EntityModifier.USER_ID)) {
            effectiveModifiers = effectiveModifiers.remove(EntityModifier.USER_ID);
        }
//        if(!modifiers.contains(EntityModifier.GENERATED_ID)){
//            effectiveModifiers=effectiveModifiers.remove(EntityModifier.GENERATED_ID);
//        }
        ((EntityExt)entity).setModifiers(effectiveModifiers);
    }

    @Override
    public QueryStatement getQuery() {
        return viewQuery;
    }
}
