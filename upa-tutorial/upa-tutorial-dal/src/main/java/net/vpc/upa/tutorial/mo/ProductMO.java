/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.mo;

import net.vpc.upa.UserFieldModifier;
import net.vpc.upa.config.*;
import net.vpc.upa.tutorial.model.Product;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Partial(Product.class)
@Entity
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
