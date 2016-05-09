package net.vpc.upa.test.connectionstring;

import java.util.HashMap;
import net.vpc.upa.Properties;
import net.vpc.upa.UPA;
import net.vpc.upa.impl.DefaultProperties;
import net.vpc.upa.impl.persistence.connection.ConnectionProfileParser;
import net.vpc.upa.impl.persistence.connection.DefaultConnectionProfile;
import net.vpc.upa.impl.persistence.connection.DefaultConnectionProfileData;
import net.vpc.upa.persistence.*;
import org.junit.Assert;
import org.junit.Test;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/13/12 10:40 PM
 */
public class ConnectionProfileParserTest {
//    public static void main(String[] args) {
////        log.info("\"dd\"".matches("(\"[^\"]*\")"));
////        log.info(";n1=v1".matches("(;(\\p{Alpha}+)(=([^;]+)))"));
////        log.info(";n1=v1".matches("(;([\\p{Alpha}\\p{Digit}_-]+)(=([^;]+)))*"));
////        System.exit(0);
////        log.info("derby#10.6".matches("^([^:#]+)(#([^:]+))?$"));
////        System.exit(0);
//        String[] examples={
////                "derby#10.6:derbyclient#9://localhost:1521/c:/r/t/y/name;n1=v1;n2=v2",
////                "derby:derbyclient://localhost:1521/c:/r/t/y/name;n1=v1;n2=v2",
////                "derby://localhost:1521/c:/r/t/y/name;n1=v1;n2=v2",
//                "derby:jdbc://",
////                "derby:embedded://c:/myFile/h:1521/name;n1=v1;n2=v2",
////                "derby:embedded://localhost:1521/name;value=\"test\";value=\"tes;t\"",
////                "oracle://localhost:1521/name",
////                "oracle://c:/myexample/any/d;",
//        };
//    }

    @Test
    public void test(){
        ConnectionProfileParser cp=new ConnectionProfileParser();
        DefaultConnectionProfileData d = cp.parseDefaultConnectionProfileData("derbyAsProduct#v12.5:defaultAsDriver#v8.699://helloAsServer:988AsPort/worldAsPath/anyThing?a=hello&b=titi;a=6;b=8");
        System.out.println(d);
        d = cp.parseDefaultConnectionProfileData("derby://localhost/vain;structure=create;userName=vr;password=vr");
        System.out.println(d);
        
    }
    @Test
    public void test1(){
        ConnectionProfile actual = parse("derby#10.6:default#9://localhost:1521/c:/r/t/y/mydb;n1=v1;n2=v2;structure=mandatory",new DefaultProperties());

        DefaultConnectionProfile expected=new DefaultConnectionProfile();
        expected.setStructureStrategy(StructureStrategy.MANDATORY);
        expected.setConnectionDriver("DEFAULT");
        expected.setConnectionDriverVersion("9");
        expected.setDatabaseProduct(DatabaseProduct.DERBY);
        expected.setDatabaseProductVersion("10.6");
        expected.setProperties(new HashMap<String, String>());
        expected.getProperties().put("n1", "v1");
        expected.getProperties().put("n2", "v2");
        expected.getProperties().put(ConnectionOption.DATABASE_NAME, "mydb");
        expected.getProperties().put(ConnectionOption.DATABASE_PATH, "c:/r/t/y");
        expected.getProperties().put(ConnectionOption.SERVER_ADDRESS, "localhost");
        expected.getProperties().put(ConnectionOption.SERVER_PORT, "1521");
        Assert.assertEquals(expected, actual);
    }

    @Test
    public void test2(){
        ConnectionProfile actual = parse("derby:default://localhost:1521/c:/r/t/y/mydb;n1=v1;n2=v2;structure=mandatory",new DefaultProperties());

        DefaultConnectionProfile expected=new DefaultConnectionProfile();
        expected.setStructureStrategy(StructureStrategy.MANDATORY);
        expected.setConnectionDriver("DEFAULT");
        expected.setDatabaseProduct(DatabaseProduct.DERBY);
        expected.setProperties(new HashMap<String, String>());
        expected.getProperties().put("n1", "v1");
        expected.getProperties().put("n2", "v2");
        expected.getProperties().put(ConnectionOption.DATABASE_NAME, "mydb");
        expected.getProperties().put(ConnectionOption.DATABASE_PATH, "c:/r/t/y");
        expected.getProperties().put(ConnectionOption.SERVER_ADDRESS, "localhost");
        expected.getProperties().put(ConnectionOption.SERVER_PORT, "1521");
        Assert.assertEquals(expected, actual);
    }

    @Test
    public void test3(){
        Properties parameters = new DefaultProperties();
        parameters.setString("upa.connection.driver","my.driver");
        parameters.setString("upa.connection.url","jdbc:test:my.url");
        parameters.setString("upa.connection.user","me");
        parameters.setString("upa.connection.password","password");
        ConnectionProfile actual = parse("derby:jdbc://;structure=mandatory",parameters);

        DefaultConnectionProfile expected=new DefaultConnectionProfile();
        expected.setStructureStrategy(StructureStrategy.MANDATORY);
        expected.setConnectionDriver("JDBC");
        expected.setDatabaseProduct(DatabaseProduct.DERBY);
        expected.setProperties(new HashMap<String, String>());
        expected.getProperties().put("driver","my.driver");
        expected.getProperties().put("url","jdbc:test:my.url");
        expected.getProperties().put("user","me");
        expected.getProperties().put("password","password");
        Assert.assertEquals(expected, actual);
    }

    @Test
    public void test4(){
        Properties parameters = new DefaultProperties();
        parameters.setString("upa.connection.driver","my.driver");
        parameters.setString("upa.connection.url","jdbc:test:my.url");
        parameters.setString("upa.connection.user","me");
        parameters.setString("upa.connection.password","password");
        ConnectionProfile actual = parse("derby:jdbc://;structure=mandatory",parameters);

        DefaultConnectionProfile expected=new DefaultConnectionProfile();
        expected.setStructureStrategy(StructureStrategy.MANDATORY);
        expected.setConnectionDriver("JDBC");
        expected.setDatabaseProduct(DatabaseProduct.DERBY);
        expected.setProperties(new HashMap<String, String>());
        expected.getProperties().put("driver","my.driver");
        expected.getProperties().put("url","jdbc:test:my.url");
        expected.getProperties().put("user","me");
        expected.getProperties().put("password","password");
        Assert.assertEquals(expected, actual);
    }

    private ConnectionProfile parse(String connectionString,Properties parameters){
        ConnectionProfileParser p = new ConnectionProfileParser();
        parameters.setString(UPA.CONNECTION_STRING, connectionString);
        return p.parse(parameters, UPA.CONNECTION_STRING);
    }
}
