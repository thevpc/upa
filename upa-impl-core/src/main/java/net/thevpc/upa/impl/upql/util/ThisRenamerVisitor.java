/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.util;

import net.thevpc.upa.ExpressionManager;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class ThisRenamerVisitor extends VarRenamerVisitor {

    public ThisRenamerVisitor(ExpressionManager expressionManager, String thisName) {
        super(expressionManager, UPQLUtils.THIS, thisName);
    }
}
