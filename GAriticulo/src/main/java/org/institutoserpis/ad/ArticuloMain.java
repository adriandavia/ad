package org.institutoserpis.ad;

import com.mysql.jdbc.PreparedStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Scanner;

public class ArticuloMain {
	private static Scanner scanner = new Scanner(System.in);
	private static Connection connection;
	
	public static void main(String[] args) throws SQLException{
		connection = DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba", "root", "sistemas");
		
		int opcion = 0;
		do{
			System.out.println("------------------ MENU -------------------");
			System.out.println("O. Salir");
			System.out.println("1. Nuevo");
			System.out.println("2. Modificar");
			System.out.println("3. Eliminar");
			System.out.println("4. Consultar fila");
			System.out.println("5. Listar todos");
			System.out.print("Escoja una opción, por favor: ");
			opcion = scanner.nextInt();
			System.out.println("-------------------------------------------");
			
			switch(opcion){
				case 0: 
					System.out.println("Conexión cerrada. Vuelva pronto.");
					connection.close();
					break;
				case 1:
					NuevoRegistro();
				case 2:
					Modificar();
				case 3:
					Eliminar();
				case 4:
					ConsultarFila();
				case 5:
					Listar();
			}
		} while(opcion!=0);
	}
	
	private static String nombre;
	private static double precio;
	private static int categoria;
	private static int id;
	
	private static String INSERT_SQL = "insert into articulo (nombre, precio, categoria) values (?, ?, ?)";
	private static void NuevoRegistro() throws SQLException{
		//Cuidado con los nombres duplicados
		System.out.print("Nombre: ");
		nombre = scanner.next();
		//Double con coma
		System.out.print("Precio: ");
		precio = scanner.nextDouble();
		System.out.print("Categoria: ");
		categoria = scanner.nextInt();		
		
		java.sql.PreparedStatement preparedStatement = 
				connection.prepareStatement(INSERT_SQL);
		preparedStatement.setString(1, nombre);
		preparedStatement.setDouble(2, precio);
		preparedStatement.setInt(3, categoria);
		preparedStatement.executeUpdate();
		preparedStatement.close();
	}
	
	private static String UPDATE_SQL = "update articulo set nombre = ?, precio = ?, categoria = ? where id = '" + id + "'";
	private static void Modificar() throws SQLException{
		System.out.print("Introduzca id a modificar: ");
		id = scanner.nextInt();
		
		java.sql.PreparedStatement preparedStatement = 
				connection.prepareStatement(UPDATE_SQL);
		
		System.out.print ("Nuevo nombre: ");
		nombre = scanner.next();
		System.out.print("Nuevo precio: ");
		precio = scanner.nextDouble();
		System.out.print("Nueva categoria: ");
		categoria = scanner.nextInt();
		
		preparedStatement.setString(1, nombre);
		preparedStatement.setDouble(2, precio);
		preparedStatement.setInt(3, categoria);
		preparedStatement.executeUpdate();
		preparedStatement.close();
	}
	
	private static String ELIMINAR_SQL = "delete from articulo where id = '" + id + "'"; 
	private static void Eliminar() throws SQLException{
		System.out.print("Introduzca id a eliminar: ");
		id = scanner.nextInt();
		
		java.sql.PreparedStatement preparedStatement = 
				connection.prepareStatement(ELIMINAR_SQL);
		
		preparedStatement.executeUpdate();
		preparedStatement.close();
	}
	
	private static String CONSULTAR_SQL = "select * from articulo where id = '" + id + "'";
	private static void ConsultarFila() throws SQLException{
		System.out.print("Introduzca id a visualizar: ");
		id = scanner.nextInt();
		
		
		java.sql.PreparedStatement preparedStatement = 
				connection.prepareStatement(CONSULTAR_SQL);
		
		ResultSet resultSet = preparedStatement.executeQuery();
		System.out.printf("%5s %-30s %10s %9s\n", "id", "nombre", "precio", "categoria");
		while (resultSet.next()) {
			System.out.printf("%5s %-30s %10s %9s\n", 
					resultSet.getObject("id"), 
					resultSet.getObject("nombre"),
					resultSet.getObject("precio"),
					resultSet.getObject("categoria")
			);
		}
		resultSet.close();
	}
	
	private static String LISTAR_SQL = "select * from articulo";
	private static void Listar() throws SQLException{
		java.sql.PreparedStatement preparedStatement = 
				connection.prepareStatement(LISTAR_SQL);
		
		ResultSet resultSet = preparedStatement.executeQuery();
		System.out.printf("%1s %10s %14s %14s\n", "id", "nombre", "precio", "categoria");
		while (resultSet.next()) {
			System.out.printf("%1s %14s %10s %10s\n", 
					resultSet.getObject("id"), 
					resultSet.getObject("nombre"),
					resultSet.getObject("precio"),
					resultSet.getObject("categoria")
			);
		}
		resultSet.close();
	}
}
