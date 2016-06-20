/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import java.util.Comparator;
import net.vpc.upa.PortabilityHint;

/**
 *
 * @author vpc
 */
@PortabilityHint(target = "C#",name = "suppress")
class XLSXSheetPartComparator implements Comparator<XLSXSheetPart> {

    public XLSXSheetPartComparator() {
    }

    public int compare(XLSXSheetPart o1, XLSXSheetPart o2) {
        return o1.sheetIndex - o2.sheetIndex;
    }
    
}
