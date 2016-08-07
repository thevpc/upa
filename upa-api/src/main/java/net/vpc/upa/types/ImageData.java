/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort 
 * to raise programming language frameworks managing relational data in 
 * applications using Java Platform, Standard Edition and Java Platform, 
 * Enterprise Edition and Dot Net Framework equally to the next level of 
 * handling ORM for mutable data structures. UPA is intended to provide 
 * a solid reflection mechanisms to the mapped data structures while 
 * affording to make changes at runtime of those data structures. 
 * Besides, UPA has learned considerably of the leading ORM 
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few) 
 * failures to satisfy very common even known to be trivial requirement in 
 * enterprise applications. 
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
//package net.vpc.common.types;
//
//
//import javax.swing.*;
//import java.io.File;
//import java.io.IOException;
//import java.io.InputStream;
//import java.net.URL;
//import java.util.HashMap;
//
//public final class ImageData extends FileData {
//    public static final long serialVersionUID = 1L;
//
////    static {
////        final java.util.Properties bug=new Properties();
////        try {
////            bug.load(new FileInputStream("imageSizes.prp"));
////            Log.debug("<<<StreamerBUG>>>> image sizes loaded");
////        } catch (IOException e) {
////
////        }
////        boolean bugActivated="true".equals(bug.getProperty("bug"));
////        if(!bugActivated){//correct
////            Log.debug("<<<StreamerBUG>>>> disactivated");
////            SimpleStream.register(new Processor(ImageData.class,serialVersionUID) {
////                public void write(Output outObj, Object o) throws IOException {
////                    out.writeUTF(((ImageData)o).sourceName);
////                    out.writeInt(((ImageData)o).data.length);
////                    out.write(((ImageData)o).data);
////                }
////
////                public Object read(Input in) throws IOException {
////                    String s=in.readUTF();
////                    int l=in.readInt();
////                    byte[] b=new byte[l];
////                    in.readFully(b);
////                    return new ImageData(s,b);
////                }
////            });
////        }else{
////            //bug workaround
////            SimpleStream.register(new SimpleStream.Processor(ImageData.class,serialVersionUID) {
////                int counter=1;
////                public void write(Output out, Object o) throws IOException {
////                    out.writeUTF(((ImageData)o).sourceName);
////                    out.write(((ImageData)o).data.length);
////                    out.write(((ImageData)o).data);
////                }
////
////                public Object read(Input in) throws IOException {
////                    String s=in.readUTF();
////                    int l=in.read();
////                    String sc=bug.getProperty(String.valueOf(counter));
////                    int x= Integer.valueOf(sc).intValue();
////                    if((x&255)==l){
////                        Log.debug("<<<StreamerBUG>>>> okkay found "+counter);
////                        System.out.println("<<<StreamerBUG>>>> okkay found "+counter);
////                        byte[] b=new byte[l];
////                        in.read(b);
////                        b=new byte[x-l];
////                        in.read(b);
////                    }else{
////                        Log.debug("<<<StreamerBUG>>>> not found "+counter+" expected "+l);
////                        System.out.println("<<<StreamerBUG>>>> not found "+counter+" expected "+l);
////                        byte[] b=new byte[l];
////                        in.read(b);
////                    }
////                    counter++;
////                    return null;
////                }
////            });
////        }
////    }
//
//    public ImageData(String sourceName, byte[] data) {
//        super(sourceName, data);
//    }
//
//    public ImageData(File file)
//            throws IOException {
//        super(file);
//    }
//
//    public ImageData(InputStream inputStream)
//            throws IOException {
//        super(inputStream);
//    }
//
//    public ImageData(String file)
//            throws IOException {
//        super(file);
//    }
//
//    public ImageData(URL url)
//            throws IOException {
//        super(url);
//    }
//
//    public ImageIcon getImage() {
//        if (image == null && data != null)
//            image = new ImageIcon(data);
//        return image;
//    }
//
////    public String getHumanReadableString(HashMap context) {
////        return "image";//todo Swings.getResources().get("image");
////    }
//
//    private transient ImageIcon image;
//}
