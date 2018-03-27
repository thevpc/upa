/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import net.vpc.upa.PortabilityHint;

/**
 * You need to implement this to handle the results of the sheet parsing.
 */
@PortabilityHint(target = "C#",name = "suppress")
public interface SheetContentsHandlerExt {

    void startDocument();

    void startSheet(int sheetIndex);

    /**
     * A row with the (zero based) row number has started
     */
    void startRow(int rowNum);

    /**
     * A row with the (zero based) row number has ended
     */
    void endRow();

    /**
     * A cell, with the given formatted value, was encountered
     */
    void cell(int col, int row, String cellReference, String formattedValue, xssfDataType type, Object value);

    void picture(int col, int row, XLSXDrawingPicture pic);

    /**
     * A header or footer has been encountered
     */
    void headerFooter(String text, boolean isHeader, String tagName);

    void endSheet();

    void endDocument();
}
