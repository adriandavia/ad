package org.institutoserpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class ArticuloDao {
	public static void main(String[] args) throws SQLException{
		Connection connection = DriverManager.getConnection
				("jdbc:mysql://localhost/dbprueba", "root", "sistemas");
		
		Statement statement = connection.createStatement();
		ResultSet resultSet = statement.executeQuery("select * from articulo");
		
		System.out.printf("%5s %15s %10s %10s \n", "id", "nombre", "precio", "categoria");
		while (resultSet.next()){
			System.out.printf("%5s %15s %10s %10s \n", 
					resultSet.getObject("id"), 
					resultSet.getObject("nombre"), 
					resultSet.getObject("precio"),
					resultSet.getObject("categoria"));
		}
		
		statement.close();
		connection.close();	
		System.out.println("CONEXIÓN CERRADA");
	}
}
