package net.vpc.upa.test.context;

import java.lang.reflect.Field;
import java.util.ArrayList;
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
    public void test0(){
        ConnectionProfile connectionProfile = parseConnectionProfile("derby:embedded://localhost/enisoinfodb;structure=create;userName=enisoinfouser;password=myassword;pool=true");
        ConnectionProfileParser parser=new ConnectionProfileParser();

        DefaultConnectionProfileData parsed=null;
        DefaultConnectionProfileData expected=null;

        parsed = parser.parseDefaultConnectionProfileData("derby:embedded://localhost/enisoinfodb;structure=create;userName=enisoinfouser;password=myassword;pool=true");
        expected=new DefaultConnectionProfileData();
        expected.setDatabaseProductName("derby");
        expected.setConnectionDriverName("embedded");
        expected.setServer("localhost");
        expected.setPathAndName("enisoinfodb");
        expected.setParamsString("structure=create;userName=enisoinfouser;password=myassword;pool=true");
        Assert.assertEquals(parsed,expected);

        parsed = parser.parseDefaultConnectionProfileData("derbyAsProduct#v12.5:defaultAsDriver#v8.699://helloAsServer:988AsPort/worldAsPath/anyThing?a=hello&b=titi;a=6;b=8");
        expected=new DefaultConnectionProfileData();
        expected.setDatabaseProductName("derbyAsProduct");
        expected.setDatabaseProductVersion("v12.5");
        expected.setConnectionDriverName("defaultAsDriver");
        expected.setConnectionDriverVersion("v8.699");
        expected.setServer("helloAsServer");
        expected.setPort("988AsPort");
        expected.setPathAndName("worldAsPath/anyThing?a=hello&b=titi");
        expected.setParamsString("a=6;b=8");
        Assert.assertEquals(parsed,expected);

        parsed = parser.parseDefaultConnectionProfileData("derby://localhost/vain;structure=create;userName=vr;password=vr");
        expected=new DefaultConnectionProfileData();
        expected.setDatabaseProductName("derby");
        expected.setServer("localhost");
        expected.setPathAndName("vain");
        expected.setParamsString("structure=create;userName=vr;password=vr");
        Assert.assertEquals(parsed,expected);

    }

    @Test
    public void test1(){
        ConnectionProfile actual = parseConnectionProfile("derby#10.6:default#9://localhost:1521/c:/r/t/y/mydb;n1=v1;n2=v2;structure=mandatory");

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
        ConnectionProfile actual = parseConnectionProfile("derby:default://localhost:1521/c:/r/t/y/mydb;n1=v1;n2=v2;structure=mandatory");

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
        parameters.setString("upa.connection.userName","me");
        parameters.setString("upa.connection.password","password");
        ConnectionProfile actual = parseConnectionProfile("derby:jdbc://;structure=mandatory",parameters);

        DefaultConnectionProfile expected=new DefaultConnectionProfile();
        expected.setStructureStrategy(StructureStrategy.MANDATORY);
        expected.setConnectionDriver("JDBC");
        expected.setDatabaseProduct(DatabaseProduct.DERBY);
        expected.setProperties(new HashMap<String, String>());
        expected.getProperties().put("driver","my.driver");
        expected.getProperties().put("url","jdbc:test:my.url");
        expected.getProperties().put("userName","me");
        expected.getProperties().put("password","password");
        Assert.assertEquals(expected, actual);
    }

    @Test
    public void test4(){
        Properties parameters = new DefaultProperties();
        parameters.setString("upa.connection.driver","my.driver");
        parameters.setString("upa.connection.url","jdbc:test:my.url");
        parameters.setString("upa.connection.userName","me");
        parameters.setString("upa.connection.password","password");
        ConnectionProfile actual = parseConnectionProfile("derby:jdbc://;structure=mandatory",parameters);

        DefaultConnectionProfile expected=new DefaultConnectionProfile();
        expected.setStructureStrategy(StructureStrategy.MANDATORY);
        expected.setConnectionDriver("JDBC");
        expected.setDatabaseProduct(DatabaseProduct.DERBY);
        expected.setProperties(new HashMap<String, String>());
        expected.getProperties().put("driver","my.driver");
        expected.getProperties().put("url","jdbc:test:my.url");
        expected.getProperties().put("userName","me");
        expected.getProperties().put("password","password");
        Assert.assertEquals(expected, actual);
    }

    @Test
    public void test5(){
        Properties parameters = new DefaultProperties();
        parameters.setString("upa.connection.driver","my.driver");
        parameters.setString("upa.connection.url","jdbc:test:my.url");
        parameters.setString("upa.connection.userName","me");
        parameters.setString("upa.connection.password","password");
        ConnectionProfile actual = parseConnectionProfile("derby:jdbc://;"+"\n" +
                "                structure=create;\n" +
                "                userName=myuser;\n" +
                "                password='mypassword';\n" +
                "                pool=true;\n" +
                "                poolMaxSize=200;\n" +
                "                monitor=javamelody",parameters);

        DefaultConnectionProfile expected=new DefaultConnectionProfile();
        expected.setStructureStrategy(StructureStrategy.CREATE);
        expected.setConnectionDriver("JDBC");
        expected.setDatabaseProduct(DatabaseProduct.DERBY);
        expected.setProperties(new HashMap<String, String>());
        expected.getProperties().put("driver", "my.driver");
        expected.getProperties().put("url","jdbc:test:my.url");
        expected.getProperties().put("userName","myuser");
        expected.getProperties().put("password","mypassword");
        expected.getProperties().put("pool","true");
        expected.getProperties().put("poolMaxSize","200");
        expected.getProperties().put("monitor","javamelody");
        Assert.assertEquals(expected, actual);
    }

    private ConnectionProfile parseConnectionProfile(String connectionString){
        return parseConnectionProfile(connectionString,new DefaultProperties());
    }
    private ConnectionProfile parseConnectionProfile(String connectionString,Properties parameters){
        ConnectionProfileParser p = new ConnectionProfileParser();
        parameters.setString(UPA.CONNECTION_STRING, connectionString);
        return p.parse(parameters, UPA.CONNECTION_STRING);
    }
}
