/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk.sheet;

import net.thevpc.upa.PortabilityHint;

/**
 * These are the different kinds of cells we support. We keep track of the
 * current one between the start and end.
 */
@PortabilityHint(target = "C#",name = "suppress")
public enum xssfDataType {
    DEFAULT,
    BOOLEAN, 
    ERROR, 
    FORMULA, 
    INLINE_STRING, 
    SST_STRING, 
    NUMBER
    
}
