/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import net.vpc.upa.PortabilityHint;

/**
 * These are the different kinds of cells we support. We keep track of the
 * current one between the start and end.
 */
@PortabilityHint(target = "C#",name = "suppress")
public enum xssfDataType {
    BOOLEAN, ERROR, FORMULA, INLINE_STRING, SST_STRING, NUMBER
    
}
