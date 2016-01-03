/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.web.presentation;

import java.sql.Date;
import java.util.ArrayList;
import java.util.List;
import javax.el.MethodExpression;
import javax.el.ValueExpression;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.component.UIComponent;
import javax.faces.component.html.HtmlOutputLabel;
import javax.faces.context.FacesContext;
import javax.faces.event.ActionEvent;
import javax.faces.event.MethodExpressionActionListener;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.FieldModifier;
import net.vpc.upa.FlagSet;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.tutorial.model.Customer;
import org.primefaces.component.column.Column;
import org.primefaces.component.datatable.DataTable;
import org.primefaces.component.dialog.Dialog;
import org.primefaces.component.menuitem.MenuItem;
import org.primefaces.component.submenu.Submenu;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@ManagedBean(name = "UPAController")
@SessionScoped
public class UPAController {

    private UIComponent workspace;

    /**
     * Creates a new instance of UPAController
     */
    public UPAController() {
        final PersistenceUnit pu = UPA.getPersistenceUnit();
        List<Customer> entityList = pu.createQueryBuilder(Customer.class).getEntityList();
        if (entityList.isEmpty()) {
            Customer customer = new Customer();
            customer.setName("Hammadi");
            customer.setBirthDate(new Date(88, 1, 12));
            pu.persist(customer);

            customer = new Customer();
            customer.setName("Alia");
            customer.setBirthDate(new Date(89, 2, 13));
            pu.persist(customer);
        }
    }
    private Submenu entitiesSubmenu;

    public Submenu getEntitiesSubmenu() {
        return entitiesSubmenu;
    }

    public void setEntitiesSubmenu(Submenu submenu) {
        Submenu old = this.entitiesSubmenu;
        this.entitiesSubmenu = submenu;
        if (old == null) {
            updateEntitiesSubmenu();
        }
    }

    public void updateEntitiesSubmenu() {
        for (final Entity entity : getAllEntities()) {
            MenuItem i = new MenuItem();
            i.setId("EntityExplorer" + entity.getName());
            i.setAjax(true);
            i.setUpdate("winform");
//            i.setOncomplete("Dialog"+entity.getName()+".show()");
            i.setTitle("Select " + entity.getName());
            i.setValue(entity.getName());
            i.getAttributes().put("Entity", entity.getName());
            final MethodExpression e = createMethodExpression("#{UPAController.selectEntity}", Void.class, ActionEvent.class);
            i.addActionListener(new MethodExpressionActionListener(e));
            getEntitiesSubmenu().getChildren().add(i);
        }
    }

    public void selectEntity(ActionEvent actionEvent) {
        String entityName = (String) actionEvent.getComponent().getAttributes().get("Entity");
        if (entityName != null) {
            Dialog d = new Dialog();
            d.setWidth("400px");
            d.setHeight("400px");
            Entity entity = UPA.getPersistenceUnit().getEntity(entityName);
            d.setHeader(entity.getName());
            d.setClosable(true);
            d.setPosition("100,100");
            DataTable t = createDataTable(entity);
//            t.setValue(entity.createQuery("Selc"));
            d.getChildren().add(t);
            d.setVisible(true);
            getWorkspace().getChildren().add(d);
        }
    }

    public List<Object> getEntityList(String entityName) {
        if (entityName != null) {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            List<Field> listableFields = new ArrayList<Field>();
            for (Field f : UPA.getPersistenceUnit().getEntity(entityName).getFields()) {
                final FlagSet<FieldModifier> modifs = f.getModifiers();
                if ((modifs.contains(FieldModifier.MAIN))
                        || (modifs.contains(FieldModifier.SUMMARY))
                        || (modifs.contains(FieldModifier.ID))) {
                    listableFields.add(f);
                }
            }

            Select s = new Select();
            s.from(entityName);
            for (Field f : listableFields) {
                s.field(new Var(f.getName()));
            }

            return pu.createQuery(s).getEntityList();
        }
        return new ArrayList<Object>();
    }

    protected DataTable createDataTable(Entity entity) {
        List<Field> listableFields = new ArrayList<Field>();
        for (Field f : entity.getFields()) {
            final FlagSet<FieldModifier> modifs = f.getModifiers();
            if ((modifs.contains(FieldModifier.MAIN))
                    || (modifs.contains(FieldModifier.SUMMARY))
                    || (modifs.contains(FieldModifier.ID))) {
                listableFields.add(f);
            }
        }

        DataTable d = new DataTable();
        d.setValueExpression("value",createValueExpression("#{UPAController.getEntityList('" + entity.getName() + "')}", java.util.List.class));
//        d.setValue(getEntityList(entity.getName()));
        d.setVar("x");
        for (Field field : listableFields) {
            final Column column = new Column();
            column.setHeaderText(field.getName());
            final HtmlOutputLabel label = new HtmlOutputLabel();
            label.setValueExpression("value",createValueExpression("#{x." + field.getName() + "}", field.getDataType().getPlatformType()));
            column.getChildren().add(label);
            d.getColumns().add(column);
        }
        return d;
    }

    public List<Entity> getAllEntities() {
        return UPA.getPersistenceUnit().getEntities();
    }

    public void save() {
    }

    public void delete() {
    }

    public void refresh() {
    }

    public UIComponent getWorkspace() {
        return workspace;
    }

    public void setWorkspace(UIComponent workspace) {
        this.workspace = workspace;
    }

    private MethodExpression createMethodExpression(String expression, Class returnType, Class... expectedParameterTypes) {
        return FacesContext.getCurrentInstance().getApplication().getExpressionFactory().createMethodExpression(FacesContext.getCurrentInstance().getELContext(), expression, returnType, expectedParameterTypes);
    }

    private ValueExpression createValueExpression(String expression, Class returnType) {
        return FacesContext.getCurrentInstance().getApplication().getExpressionFactory().createValueExpression(FacesContext.getCurrentInstance().getELContext(), expression, returnType);
    }
}
