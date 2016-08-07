/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import net.vpc.upa.PortabilityHint;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class XLSXDrawingPicture {

    private String rId;
    private String picturePath;
    private XLSXMediaPart media;
    private int fromCol;
    private int fromRow;
    private int toCol;
    private int toRow;

    public XLSXDrawingPicture() {
    }

    public String getPicturePath() {
        return picturePath;
    }

    public void setPicturePath(String picturePath) {
        this.picturePath = picturePath;
    }

    public int getFromCol() {
        return fromCol;
    }

    public void setFromCol(int fromCol) {
        this.fromCol = fromCol;
    }

    public int getFromRow() {
        return fromRow;
    }

    public void setFromRow(int fromRow) {
        this.fromRow = fromRow;
    }

    public int getToCol() {
        return toCol;
    }

    public void setToCol(int toCol) {
        this.toCol = toCol;
    }

    public int getToRow() {
        return toRow;
    }

    public void setToRow(int toRow) {
        this.toRow = toRow;
    }

    public String getrId() {
        return rId;
    }

    public void setrId(String rId) {
        this.rId = rId;
    }

    public XLSXMediaPart getMedia() {
        return media;
    }

    public void setMedia(XLSXMediaPart media) {
        this.media = media;
    }
    

    @Override
    public String toString() {
        return "XLSXDrawingPicture{" + "rId=" + rId + ", picturePath=" + picturePath + ", fromCol=" + fromCol + ", fromRow=" + fromRow + ", toCol=" + toCol + ", toRow=" + toRow + '}';
    }
    
}
