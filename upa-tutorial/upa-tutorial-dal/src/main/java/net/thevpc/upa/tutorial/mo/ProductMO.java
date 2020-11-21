/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.tutorial.mo;

import net.thevpc.upa.config.*;
import net.thevpc.upa.config.*;
import net.thevpc.upa.tutorial.model.Product;

/**
 * This is a partial Class.
 * Partial Classes enable customizing other Entities of MO Classes.
 * Actually, this Partial Class adds new field 'description'
 * and modifies 'name' and 'quantity' fields
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Entity(entityType = Product.class)
public class ProductMO {

    /**
     * change constraints on existing field
     * use FieldDesc not to alter any other information (use existing type)
     */
    @Main
    @Field(min = "3")
    FieldDesc name;

    @Summary
    FieldDesc quantity;

    //add new field
    @Field(defaultValue = "No description")
    String description;
}
