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

    public void startDocument();

    public void startSheet(int sheetIndex);

    /**
     * A row with the (zero based) row number has started
     */
    public void startRow(int rowNum);

    /**
     * A row with the (zero based) row number has ended
     */
    public void endRow();

    /**
     * A cell, with the given formatted value, was encountered
     */
    public void cell(int col, int row, String cellReference, String formattedValue, xssfDataType type, Object value);

    public void picture(int col, int row, XLSXDrawingPicture pic);

    /**
     * A header or footer has been encountered
     */
    public void headerFooter(String text, boolean isHeader, String tagName);

    public void endSheet();

    public void endDocument();
}
