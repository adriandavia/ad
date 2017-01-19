package org.institutoserpis.ad;

import java.util.Calendar;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class Hibernate {

	public static void main(String[] args) {
		
		EntityManagerFactory entityManagerFactory = 
				Persistence.createEntityManagerFactory("org.institutoserpis.ad.hmysql");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Categoria categoria = new Categoria();
		categoria.setNombre("nueva " + Calendar.getInstance().getTime());
		entityManager.persist(categoria);
		
		List<Categoria> categorias = 
				entityManager.createQuery("from Categoria", Categoria.class).getResultList();
		for (Categoria item : categorias)
			System.out.printf("%d %s\n", item.getId(), item.getNombre());
		
		entityManager.getTransaction().commit();
		entityManager.close();

		entityManagerFactory.close();
	}

}
