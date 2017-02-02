package org.institutoserpis.ad;

import java.math.BigDecimal;
import java.sql.Date;
import java.util.Calendar;
import java.util.List;
import java.util.Scanner;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import org.hibernate.boot.model.source.spi.IdentifierSourceSimple;
import org.hibernate.persister.walking.spi.MetamodelGraphWalker;

public class Hibernate {
	private static EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("org.institutoserpis.ad.hpedido");
	public static void main(String[] args) {
		
		Scanner scanner = new Scanner(System.in);
		int opcion = 0;
		do{
			System.out.println("------------------ MENU -------------------");
			System.out.println("O. Salir");
			System.out.println("1. Nuevo ...");
			System.out.println("2. Modificar");
			System.out.println("3. Eliminar");
			System.out.println("4. Consultar fila");
			System.out.println("5. Listar ...");
			System.out.print("Escoja una opción, por favor: ");
			opcion = scanner.nextInt();
			System.out.println("-------------------------------------------");
			
			switch(opcion){
				case 0: 
					System.out.println("Adios.");
					entityManagerFactory.close();
					break;
					
				case 1:
					int opcion2 = 0;
					do {
						System.out.println("------------------ AÑADIR -------------------");
						System.out.println("O. Volver");
						System.out.println("1. Categoria");
						System.out.println("2. Articulo");
						System.out.println("3. Cliente");
						System.out.println("4. Pedido");
						System.out.println("5. Pedido liena");
						System.out.print("Escoja una opción, por favor: ");
						opcion2 = scanner.nextInt();
						System.out.println("---------------------------------------------");
						
						switch (opcion2) {
						case 0:
							break;

						case 1:
							System.out.print("Escriba un nombre: ");
							String nombre = scanner.next();
							insert_categoria(nombre);
						}
					} while (opcion2 != 0);
					break;
					
				case 2:
					break;
				case 3:
					
				case 4:
					
				case 5:
					int opcion3 = 0;
					do {
						System.out.println("------------------ LISTAR -------------------");
						System.out.println("O. Volver");
						System.out.println("1. Categoria");
						System.out.println("2. Articulo");
						System.out.println("3. Cliente");
						System.out.println("4. Pedido");
						System.out.println("5. Pedido liena");
						System.out.print("Escoja una opción, por favor: ");
						opcion3 = scanner.nextInt();
						System.out.println("----------------------------------------------");
						
						switch (opcion3) {
						case 0:
							break;

						case 1:
							select_categoria();
						}
					} while (opcion3 != 0);
					break;
			}
		} while(opcion!=0);
		
		//Insertamos Articulo
		/*Categoria categoria = entityManager.getReference(Categoria.class, 2L);
		Articulo articulo = new Articulo();
		articulo.setNombre("BMX");
		BigDecimal importe = new BigDecimal("120.2");
		articulo.setPrecio(importe);
		articulo.setCategoria(categoria);
		entityManager.persist(articulo);*/
		
		//Insertamos cliente
		/*Cliente cliente = new Cliente();
		cliente.setNombre("Raul");
		entityManager.persist(cliente);*/
		
		//Insertamos pedido
		/*Cliente cliente = entityManager.getReference(Cliente.class, 1L);
		
		Pedido pedido = new Pedido();
		pedido.setCliente(cliente);
		java.util.Date data = new java.util.Date();
		Date date = new Date(data.getDate());
		pedido.setFecha(date);
		BigDecimal importe = new BigDecimal("12.0");
		pedido.setImporte(importe);
		entityManager.persist(pedido);*/
		
		//Insertamos pedidolinea
		/*Pedido pedido = entityManager.getReference(Pedido.class, 1L);
		Articulo articulo = entityManager.getReference(Articulo.class, 1L);
		
		Pedidolinea pedidolinea = new Pedidolinea();
		pedidolinea.setPedido(pedido);
		pedidolinea.setArticulo(articulo);
		BigDecimal unidades = new BigDecimal("20.0");
		BigDecimal importe = unidades.multiply(articulo.getPrecio());
		pedidolinea.setPrecio(articulo.getPrecio());
		pedidolinea.setUnidades(unidades);
		pedidolinea.setImporte(importe);
		entityManager.persist(pedidolinea);*/
		
			
	}	

	private static void insert_categoria (String nombre){
		//Insertamos Categoria
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = new Categoria();
		categoria.setNombre(nombre);
		entityManager.persist(categoria);
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	private static void select_categoria (){
		//Insertamos Categoria
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		List<Categoria> categorias = 
				entityManager.createQuery("from Categoria", Categoria.class).getResultList();
		for (Categoria item : categorias)
			System.out.printf("%d %s\n", item.getId(), item.getNombre());
		entityManager.getTransaction().commit();
		entityManager.close();
	}

}
