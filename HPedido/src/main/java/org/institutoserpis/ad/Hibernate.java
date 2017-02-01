package org.institutoserpis.ad;

import java.math.BigDecimal;
import java.sql.Date;
import java.util.Calendar;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class Hibernate {
	public static void main(String[] args) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("org.institutoserpis.ad.hpedido");
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		//Insertamos Articulo
		/*Categoria categoria = entityManager.getReference(Categoria.class, 2L);
		Articulo articulo = new Articulo();
		articulo.setNombre("BMX");
		BigDecimal importe = new BigDecimal("120.2");
		articulo.setPrecio(importe);
		articulo.setCategoria(categoria);
		entityManager.persist(articulo);*/
		
		//Insertamos cliente
		Cliente cliente = new Cliente();
		cliente.setNombre("Raul");
		entityManager.persist(cliente);
		
		//Insertamos pedido
		/*Cliente cliente = entityManager.getReference(Cliente.class, 2L);
		
		Pedido pedido = new Pedido();
		pedido.setCliente(cliente);
		Date date = new Date(4,2,2);
		date = (Date)Calendar.getInstance().getTime();
		pedido.setFecha(date);
		BigDecimal importe = new BigDecimal("12.0");
		pedido.setImporte(importe);
		entityManager.persist(pedido);*/
		
		entityManager.getTransaction().commit();
		entityManager.close();
		entityManagerFactory.close();		
	}

}
