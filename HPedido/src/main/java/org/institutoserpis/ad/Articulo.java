package org.institutoserpis.ad;

import java.math.BigDecimal;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

@Entity
public class Articulo {
	private long id; 
	private String nombre;
	private BigDecimal precio;
	private Categoria categoria;
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	public long getId(){
		return id;
	}
	public void setId(long id){
		this.id = id;
	}
	@ManyToOne
	@JoinColumn(name="categoria")
	public Categoria getCategoria() {
		return categoria;
	}
	public void setCategoria(Categoria categoria) {
		this.categoria = categoria;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public BigDecimal getPrecio() {
		return precio;
	}
	public void setPrecio(BigDecimal precio) {
		this.precio = precio;
	}
	
	public String toString(){
		return String.format("%s %s %s %s", id, nombre, precio, categoria);
	}
	
}
