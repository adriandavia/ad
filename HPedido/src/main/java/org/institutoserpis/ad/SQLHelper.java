package org.institutoserpis.ad;

import java.math.BigDecimal;
import java.sql.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class SQLHelper {
	protected static void close_EntityManagerFactory(EntityManagerFactory entityManagerFactory){
		entityManagerFactory.close();
	}
	
	protected static void insert_categoria (EntityManagerFactory entityManagerFactory, String nombre){
		//Insertamos Categoria
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = new Categoria();
		categoria.setNombre(nombre);
		entityManager.persist(categoria);
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	protected static void insert_articulo(EntityManagerFactory entityManagerFactory, String nombre, String precio, String idcategoria) {
		//Insertamos Articulo
		Articulo articulo = new Articulo();
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = entityManager.getReference(Categoria.class, Long.parseLong(idcategoria));
		articulo.setCategoria(categoria);
		articulo.setNombre(nombre);
		BigDecimal importe = new BigDecimal(precio);
		articulo.setPrecio(importe);
		entityManager.persist(articulo);
		entityManager.getTransaction().commit();
		entityManager.close();
	}

	protected static void insert_cliente (EntityManagerFactory entityManagerFactory, String nombre){
		//Insertamos cliente
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Cliente cliente = new Cliente();
		cliente.setNombre(nombre);
		entityManager.persist(cliente);
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	protected static void insert_pedido (EntityManagerFactory entityManagerFactory, String idcliente, String precio){
		//Insertamos pedido
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Pedido pedido = new Pedido();
		Cliente cliente = entityManager.getReference(Cliente.class, Long.parseLong(idcliente));
		pedido.setCliente(cliente);
		java.util.Date data = new java.util.Date();
		Date date = new Date(data.getDate());
		pedido.setFecha(date);
		BigDecimal importe = new BigDecimal(precio);
		pedido.setImporte(importe);
		entityManager.persist(pedido);	
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	protected static void insert_pedidoLinea(EntityManagerFactory entityManagerFactory, String pedidoid, String articuloid, String unid) {
		//Insertamos pedidolinea
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Pedido pedido = entityManager.getReference(Pedido.class, Long.parseLong(pedidoid));
		Articulo articulo = entityManager.getReference(Articulo.class, Long.parseLong(articuloid));
		
		Pedidolinea pedidolinea = new Pedidolinea();
		pedidolinea.setPedido(pedido);
		pedidolinea.setArticulo(articulo);
		BigDecimal unidades = new BigDecimal(unid);
		BigDecimal importe = unidades.multiply(articulo.getPrecio());
		pedidolinea.setPrecio(articulo.getPrecio());
		pedidolinea.setUnidades(unidades);
		pedidolinea.setImporte(importe);
		entityManager.persist(pedidolinea);		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	protected static void update_categoria (EntityManagerFactory entityManagerFactory, String idcategoria, String nncategoria){
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = entityManager.getReference(Categoria.class, Long.parseLong(idcategoria));
		categoria.setNombre(nncategoria);
		entityManager.flush();
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	protected static void select_categorias (EntityManagerFactory entityManagerFactory){
		//Seleccionamos todas las categorias
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		List<Categoria> categorias = 
				entityManager.createQuery("from Categoria", Categoria.class).getResultList();
		for (Categoria item : categorias)
			System.out.printf("%d    %s\n", item.getId(), item.getNombre());
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	protected static void select_categoria (EntityManagerFactory entityManagerFactory, String id){
		//Seleccionamos una categoria en concreto 
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		try{
			Categoria categoria = entityManager.getReference(Categoria.class, Long.parseLong(id));
			System.out.printf("%d      %s\n", categoria.getId(), categoria.getNombre());
		}catch (Exception e) {
			System.out.println("El ID insertado no es correcto");
		}	
		entityManager.getTransaction().commit();
		entityManager.close();
	}
}
