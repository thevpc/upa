package net.thevpc.upa.impl.extension;

import net.thevpc.upa.Entity;
import net.thevpc.upa.EntityModifier;
import net.thevpc.upa.FlagSet;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.QueryStatement;
import net.thevpc.upa.EntityExtensionDefinition;
import net.thevpc.upa.ViewEntityExtensionDefinition;
import net.thevpc.upa.impl.ext.EntityExt;
import net.thevpc.upa.persistence.EntityOperationManager;
import net.thevpc.upa.ViewEntityExtension;

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
