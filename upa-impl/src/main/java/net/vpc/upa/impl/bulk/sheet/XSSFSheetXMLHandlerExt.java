/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.bulk.sheet.SheetContentsHandlerExt;
import net.vpc.upa.impl.bulk.sheet.XLSXDrawingPicture;
import net.vpc.upa.impl.bulk.sheet.XLSXFile;
import net.vpc.upa.impl.bulk.sheet.XLSXMediaPart;
import net.vpc.upa.impl.bulk.sheet.xssfDataType;
import org.apache.poi.hssf.usermodel.HSSFDateUtil;
import org.apache.poi.ss.usermodel.BuiltinFormats;
import org.apache.poi.ss.usermodel.DataFormatter;
import org.apache.poi.ss.usermodel.DateUtil;
import org.apache.poi.xssf.eventusermodel.ReadOnlySharedStringsTable;
import org.apache.poi.xssf.model.StylesTable;
import org.apache.poi.xssf.usermodel.XSSFCellStyle;
import org.apache.poi.xssf.usermodel.XSSFRichTextString;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

/**
 * class mainly inspired from
 * org.apache.poi.xssf.eventusermodel.XSSFSheetXMLHandler
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#", name = "suppress")
public class XSSFSheetXMLHandlerExt extends DefaultHandler {

    private static final Logger log = Logger.getLogger(XSSFSheetXMLHandlerExt.class.getName());

    /**
     * Table with the styles used for formatting
     */
    private StylesTable stylesTable;
    private ReadOnlySharedStringsTable sharedStringsTable;
    /**
     * Where our text is going
     */
    private final SheetContentsHandlerExt output;
    // Set when V start element is seen
    private boolean vIsOpen;
    // Set when F start element is seen
    private boolean fIsOpen;
    // Set when an Inline String "is" is seen
    private boolean isIsOpen;
    // Set when a header/footer element is seen
    private boolean hfIsOpen;
    // Set when cell start element is seen;
    // used when cell close element is seen.
    private xssfDataType nextDataType;
    // Used to format numeric cell values.
    private short formatIndex;
    private String formatString;
    private final DataFormatter formatter;
    private String cellRef;
    private boolean formulasNotResults;
    // Gathers characters as they are seen.
    private StringBuffer value = new StringBuffer();
    private StringBuffer formula = new StringBuffer();
    private StringBuffer headerFooter = new StringBuffer();
    private XLSXFile xLSXFile;
    private Map<Integer, List<XLSXDrawingPicture>> pictures = new HashMap<Integer, List<XLSXDrawingPicture>>();
    private int lastRowNum;
    private int sheetIndex;

    /**
     * Accepts objects needed while parsing.
     *
     * @param styles Table of styles
     * @param strings Table of shared strings
     */
    public XSSFSheetXMLHandlerExt(
            StylesTable styles,
            ReadOnlySharedStringsTable strings,
            SheetContentsHandlerExt sheetContentsHandler,
            DataFormatter dataFormatter,
            boolean formulasNotResults,
            XLSXFile xLSXFile,
            List<XLSXDrawingPicture> pictures,
            int sheetIndex) {
        this.stylesTable = styles;
        this.sheetIndex = sheetIndex;
        this.sharedStringsTable = strings;
        this.output = sheetContentsHandler;
        this.formulasNotResults = formulasNotResults;
        this.nextDataType = xssfDataType.NUMBER;
        this.formatter = dataFormatter;
        this.xLSXFile = xLSXFile;
        this.pictures = new HashMap<Integer, List<XLSXDrawingPicture>>();
        if (pictures != null) {
            for (XLSXDrawingPicture p : pictures) {
                int r = p.getFromRow();
                List<XLSXDrawingPicture> ll = this.pictures.get(r);
                if (ll == null) {
                    ll = new ArrayList<XLSXDrawingPicture>();
                    this.pictures.put(r, ll);
                }
                ll.add(p);
            }
        }
    }

    /**
     * Accepts objects needed while parsing.
     *
     * @param styles Table of styles
     * @param strings Table of shared strings
     */
    public XSSFSheetXMLHandlerExt(
            StylesTable styles,
            ReadOnlySharedStringsTable strings,
            SheetContentsHandlerExt sheetContentsHandler,
            boolean formulasNotResults,
            int sheetIndex) {
        this(styles, strings, sheetContentsHandler, new DataFormatter(), formulasNotResults, null, null, sheetIndex);
    }

    private boolean isTextTag(String name) {
        if ("v".equals(name)) {
            // Easy, normal v text tag
            return true;
        }
        if ("inlineStr".equals(name)) {
            // Easy inline string
            return true;
        }
        if ("t".equals(name) && isIsOpen) {
            // Inline string <is><t>...</t></is> pair
            return true;
        }
        // It isn't a text tag
        return false;
    }

    @Override
    public void startDocument() throws SAXException {
        super.startDocument();
        output.startSheet(sheetIndex);
    }

    @Override
    public void endDocument() throws SAXException {
        super.endDocument();
        output.endSheet();
    }

    public void startElement(String uri, String localName, String name,
            Attributes attributes) throws SAXException {

        if (isTextTag(name)) {
            vIsOpen = true;
            // Clear contents cache
            value.setLength(0);
        } else if ("is".equals(name)) {
            // Inline string outer tag
            isIsOpen = true;
        } else if ("f".equals(name)) {
            // Clear contents cache
            formula.setLength(0);

            // Mark us as being a formula if not already
            if (nextDataType == xssfDataType.NUMBER) {
                nextDataType = xssfDataType.FORMULA;
            }

            // Decide where to get the formula string from
            String type = attributes.getValue("t");
            if (type != null && type.equals("shared")) {
                // Is it the one that defines the shared, or uses it?
                String ref = attributes.getValue("ref");
                String si = attributes.getValue("si");

                if (ref != null) {
                    // This one defines it
                    // TODO Save it somewhere
                    fIsOpen = true;
                } else {
                    // This one uses a shared formula
                    // TODO Retrieve the shared formula and tweak it to 
                    //  match the current cell
                    if (formulasNotResults) {
                        log.log(Level.WARNING, "Warning - shared formulas not yet supported!");
                    } else {
                        // It's a shared formula, so we can't get at the formula string yet
                        // However, they don't care about the formula string, so that's ok!
                    }
                }
            } else {
                fIsOpen = true;
            }
        } else if ("oddHeader".equals(name) || "evenHeader".equals(name)
                || "firstHeader".equals(name) || "firstFooter".equals(name)
                || "oddFooter".equals(name) || "evenFooter".equals(name)) {
            hfIsOpen = true;
            // Clear contents cache
            headerFooter.setLength(0);
        } else if ("row".equals(name)) {
            int rowNum = Integer.parseInt(attributes.getValue("r")) - 1;
            lastRowNum = rowNum;
            output.startRow(rowNum);
        } // c => cell
        else if ("c".equals(name)) {
            // Set up defaults.
            this.nextDataType = xssfDataType.NUMBER;
            this.formatIndex = -1;
            this.formatString = null;
            cellRef = attributes.getValue("r");
            String cellType = attributes.getValue("t");
            String cellStyleStr = attributes.getValue("s");
            if ("b".equals(cellType)) {
                nextDataType = xssfDataType.BOOLEAN;
            } else if ("e".equals(cellType)) {
                nextDataType = xssfDataType.ERROR;
            } else if ("inlineStr".equals(cellType)) {
                nextDataType = xssfDataType.INLINE_STRING;
            } else if ("s".equals(cellType)) {
                nextDataType = xssfDataType.SST_STRING;
            } else if ("str".equals(cellType)) {
                nextDataType = xssfDataType.FORMULA;
            } else if (cellStyleStr != null) {
                // Number, but almost certainly with a special style or format
                int styleIndex = Integer.parseInt(cellStyleStr);
                XSSFCellStyle style = stylesTable.getStyleAt(styleIndex);
                this.formatIndex = style.getDataFormat();
                this.formatString = style.getDataFormatString();
                if (this.formatString == null) {
                    this.formatString = BuiltinFormats.getBuiltinFormat(this.formatIndex);
                }
            }
        }
    }

    public void endElement(String uri, String localName, String name)
            throws SAXException {
        String thisStr = null;

        // v => contents of a cell
        if (isTextTag(name)) {
            vIsOpen = false;
            Object objValue = null;
            // Process the value contents as required, now we have it all
            switch (nextDataType) {
                case BOOLEAN:
                    char first = value.charAt(0);
                    thisStr = first == '0' ? "FALSE" : "TRUE";
                    objValue = first == '0' ? Boolean.FALSE : Boolean.TRUE;
                    break;

                case ERROR:
                    thisStr = "ERROR:" + value.toString();
                    objValue = new Exception(value.toString());
                    break;

                case FORMULA:
                    if (formulasNotResults) {
                        thisStr = formula.toString();
                    } else {
                        String fv = value.toString();

                        if (this.formatString != null) {
                            try {
                                // Try to use the value as a formattable number
                                double d = Double.parseDouble(fv);
                                thisStr = formatter.formatRawCellContents(d, this.formatIndex, this.formatString);
                                if (DateUtil.isADateFormat(formatIndex, formatString)) {
                                    objValue = HSSFDateUtil.getJavaDate(d);
                                } else {
                                    try {
                                        objValue = Integer.parseInt(thisStr);
                                    } catch (Exception e) {
                                        try {
                                            double dd = Double.parseDouble(thisStr);
                                            objValue = dd;
                                        } catch (Exception notDouble) {
                                            log.log(Level.WARNING, e.toString());
                                            objValue = d;
                                        }
                                    }
                                }
                            } catch (NumberFormatException e) {
                                // Formula is a String result not a Numeric one
                                thisStr = fv;
                                objValue = fv;
                            }
                        } else {
                            // No formating applied, just do raw value in all cases
                            thisStr = fv;
                            try {
                                objValue = Double.parseDouble(thisStr);
                            } catch (Exception e) {
                                objValue = thisStr;
                            }
                        }
                    }
                    break;

                case INLINE_STRING:
                    // TODO: Can these ever have formatting on them?
                    XSSFRichTextString rtsi = new XSSFRichTextString(value.toString());
                    thisStr = rtsi.toString();
                    objValue = thisStr;
                    break;

                case SST_STRING:
                    String sstIndex = value.toString();
                    try {
                        int idx = Integer.parseInt(sstIndex);
                        XSSFRichTextString rtss = new XSSFRichTextString(sharedStringsTable.getEntryAt(idx));
                        thisStr = rtss.toString();
                        objValue = thisStr;
                    } catch (NumberFormatException ex) {
                        log.log(Level.SEVERE, "Failed to parse SST index ''{0}'': {1}", new Object[]{sstIndex, ex.toString()});
                    }
                    break;

                case NUMBER:
                    String n = value.toString();
                    if (this.formatString != null) {
                        double numberValue = Double.parseDouble(n);
                        thisStr = formatter.formatRawCellContents(numberValue, this.formatIndex, this.formatString);
                        if (DateUtil.isADateFormat(formatIndex, formatString)) {
                            objValue = HSSFDateUtil.getJavaDate(numberValue);
                        } else {
                            try {
                                objValue = Integer.parseInt(thisStr);
                            } catch (Exception e) {
                                objValue = Double.parseDouble(n);
                            }
                        }
                    } else {
                        thisStr = n;
                        objValue = Double.parseDouble(n);
                    }
                    break;

                default:
                    objValue = new Exception("(TODO: Unexpected type: " + nextDataType + ")");
                    thisStr = "(TODO: Unexpected type: " + nextDataType + ")";
                    break;
            }
            int[] cr = toColRow(cellRef);
            output.cell(cr[0], cr[1], cellRef, thisStr, nextDataType, objValue);
        } else if ("f".equals(name)) {
            fIsOpen = false;
        } else if ("is".equals(name)) {
            isIsOpen = false;
        } else if ("row".equals(name)) {
            List<XLSXDrawingPicture> allPics = pictures.get(lastRowNum);
            if (allPics != null) {
                for (XLSXDrawingPicture p : allPics) {
                    p.setMedia((XLSXMediaPart) xLSXFile.getEntry(p.getPicturePath()));
                    output.picture(p.getFromCol(), p.getFromRow(), p);
                }
            }
            output.endRow();
        } else if ("oddHeader".equals(name) || "evenHeader".equals(name)
                || "firstHeader".equals(name)) {
            hfIsOpen = false;
            output.headerFooter(headerFooter.toString(), true, name);
        } else if ("oddFooter".equals(name) || "evenFooter".equals(name)
                || "firstFooter".equals(name)) {
            hfIsOpen = false;
            output.headerFooter(headerFooter.toString(), false, name);
        }
    }

    /**
     * Captures characters only if a suitable element is open. Originally was
     * just "v"; extended for inlineStr also.
     */
    public void characters(char[] ch, int start, int length)
            throws SAXException {
        if (vIsOpen) {
            value.append(ch, start, length);
        }
        if (fIsOpen) {
            formula.append(ch, start, length);
        }
        if (hfIsOpen) {
            headerFooter.append(ch, start, length);
        }
    }

    private static int[] toColRow(String cellValue) {
        int c0 = 0;
        StringBuilder row = new StringBuilder();
        for (int i = 0; i < cellValue.length(); i++) {
            char c = cellValue.charAt(i);
            if (Character.isAlphabetic(c)) {
                c0 = c0 * 26 + ((int) c - 'A' + 1);
            } else {
                row.append(c);
            }
        }
        return new int[]{c0 - 1, Integer.parseInt(row.toString()) - 1};
    }
}
