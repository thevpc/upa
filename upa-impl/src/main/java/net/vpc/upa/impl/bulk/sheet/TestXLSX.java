///*
// * To change this template, choose Tools | Templates
// * and open the template in the editor.
// */
//package net.vpc.upa.impl.bulk.sheet;
//
//import java.io.File;
//import net.vpc.upa.PortabilityHint;
//
///**
// *
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// */
//@PortabilityHint(target = "C#",name = "suppress")
//public class TestXLSX {
//
//    public static void main0(String[] args) {
//        try {
//            //        File filePath = new File("/home/vpc/data/work/entities/scsi/mercure/dev/oad/documents/input/OAD - BT/OAD - BT/PUMA/T  BM AH13 PUMA TT_tbs_converted.xlsx");
//            File filePath = new File("/home/vpc/temp/aazip/aa.xlsx");
//            XLSXFile f = new XLSXFile(filePath);
//            for (XLSXSheetPart s : f.getWorkbook().getSheets()) {
//                for (XLSXDrawingPart drawing : s.getDrawings()) {
//                    System.out.println(s.getSheetName() + "\t" + drawing);
//                    for (XLSXDrawingPicture pic : drawing.getPictures()) {
//                        System.out.println(s.getSheetName() + "\t" + pic);
//                    }
//                }
//            }
//        } catch (Exception ex) {
//            ex.printStackTrace();
//        }
//    }
//}
