/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import java.io.*;
import java.util.Date;
import net.vpc.upa.PortabilityHint;

import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.DataRow;
import net.vpc.upa.bulk.SheetColumn;
import net.vpc.upa.bulk.SheetFormatter;
import net.vpc.upa.bulk.TextCSVColumn;
import net.vpc.upa.impl.bulk.AbstractDataWriter;
import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.CellStyle;
import org.apache.poi.ss.usermodel.CreationHelper;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.xssf.streaming.SXSSFWorkbook;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultSheetWriter extends AbstractDataWriter {

    private SheetFormatter p;
    private SXSSFWorkbook writer;
    private boolean trimValues;
    private Sheet sheet;
    private Row row;
    private Object stream;
    private CellStyle dateStyle;
    private int columnIndex;

    public DefaultSheetWriter(SheetFormatter p, File file) {
        this(p, (Object) file);
    }

    public DefaultSheetWriter(SheetFormatter p, OutputStream outputStream) {
        this(p, (Object) outputStream);
    }

    private DefaultSheetWriter(SheetFormatter p, Object stream) {
        super(new TextCSVColumn(), p.isWriteHeader(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]));
        this.p = p;
        //prepareHeader(p.isContainsHeader());
        trimValues = p.isTrimValues();
        this.writer = new SXSSFWorkbook(100);
        int r = 0;
        while (p.getSheetIndex() >= 0 && r < p.getSheetIndex()) {
            sheet = this.writer.createSheet();
        }
        sheet = p.getSheetName() == null ? this.writer.createSheet() : this.writer.createSheet(p.getSheetName());
        this.stream = stream;
        final CreationHelper creationHelper = writer.getCreationHelper();
        dateStyle = writer.createCellStyle();
        short dateFormat = creationHelper.createDataFormat().getFormat("d-mmm-yy");
        dateStyle.setDataFormat(dateFormat);
    }

    @Override
    public void startDocument() {
        if (p.getSkipRows() > 0) {
            setRowIndex(getRowIndex() + p.getSkipRows());
        }
        super.startDocument();
    }

    @Override
    protected void startRow(DataRow row) {
        this.row = sheet.createRow((int) getRowIndex());
        this.columnIndex = 0;
    }

    private SheetColumn getColumn(DataColumn[] cols,int i){
        if(cols==null || i>=cols.length){
            return null;
        }
        return (SheetColumn) cols[i];
    }

    @Override
    protected void writeCell(long rowIndex, DataRow row, int cellIndex, Object cell0) {
        SheetColumn cc = getColumn(row.getColumns(),cellIndex);
        if(cc!=null) {
            if (cc.getSkippedColumns() > 0) {
                columnIndex += cc.getSkippedColumns();
            }
        }
        Cell cell = this.row.createCell(columnIndex);
//        String address = new CellReference(cell).formatAsString();
        if (cell0 != null) {
            if (cell0 instanceof Number) {
                cell.setCellValue(((Number) cell0).doubleValue());
            } else if (cell0 instanceof Date) {
                cell.setCellStyle(dateStyle);
                cell.setCellValue(((Date) cell0));
            } else if (cell0 instanceof String) {
                String str = (String) cell0;
                if (trimValues) {
                    str = str.trim();
                }
                cell.setCellValue(str);
            } else {
                String str = cell0.toString();
                if (str != null && trimValues) {
                    str = str.trim();
                }
                cell.setCellValue(str);
            }
        }
        columnIndex++;
    }

    @Override
    protected void endRow(DataRow row) {
        //do nothing
    }

    public void close() {
        try {
            if (stream instanceof File) {
                FileOutputStream s = null;
                try {
                    s = new FileOutputStream((File) stream);
                    writer.write(s);
                } finally {
                    if (s != null) {
                        s.close();
                    }
                }
            } else {
                writer.write((OutputStream) stream);
            }
            writer.dispose();
        } catch (IOException ex) {
            throw new RuntimeException(ex);
        }
    }
}
