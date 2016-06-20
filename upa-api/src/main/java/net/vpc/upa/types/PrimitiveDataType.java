/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.types;

/**
 *
 * @author vpc
 */
public class PrimitiveDataType extends DefaultDataType {

    public PrimitiveDataType(String name, Class platformType) {
        super(name, platformType);
    }

    public PrimitiveDataType(String name, Class platformType, boolean nullable) {
        super(name, platformType, nullable);
    }

    public PrimitiveDataType(String name, Class platformType, int scale, int precision, boolean nullable) {
        super(name, platformType, scale, precision, nullable);
    }

}
