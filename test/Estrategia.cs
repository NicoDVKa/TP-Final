
using System;
using System.Collections.Generic;
namespace DeepSpace
{

	class Estrategia
	{
		
		
		public String Consulta1( ArbolGeneral<Planeta> arbol)
		{
			return "Implementar";
		}


		public String Consulta2( ArbolGeneral<Planeta> arbol)
		{
			Cola<ArbolGeneral<Planeta>> q = new Cola<ArbolGeneral<Planeta>>();
			q.encolar(arbol);
			int nivel = 0;
			String mensaje = "";
			while (!q.esVacia())
			{
				int elementos = q.cantElementos();
				nivel++;
				int cantidadPorNivel = 0;
				while (elementos-- > 0)
				{
					ArbolGeneral<Planeta> nodoActual = q.desencolar();

					if (nodoActual.getDatoRaiz().Poblacion() > 10)
					{
						cantidadPorNivel++;
					}

					foreach (ArbolGeneral<Planeta> hijo in nodoActual.getHijos())
					{
						q.encolar(hijo);
					}
				}
				mensaje += "Nivel " + nivel + ": " + cantidadPorNivel + "\n";
			}
			return mensaje; 
		}


		public String Consulta3( ArbolGeneral<Planeta> arbol)
		{
			Cola<ArbolGeneral<Planeta>> q = new Cola<ArbolGeneral<Planeta>>();
			q.encolar(arbol);
			int nivel = 0;
			
			String mensaje = "";
			while (!q.esVacia())
			{
				int elementos = q.cantElementos();
				nivel++;
				int cantidadPorNivel = 0;
				int poblacionPorNivel = 0;
				while (elementos-- > 0)
				{
					ArbolGeneral<Planeta> nodoActual = q.desencolar();

					cantidadPorNivel++;
					poblacionPorNivel += nodoActual.getDatoRaiz().Poblacion();

					foreach (ArbolGeneral<Planeta> hijo in nodoActual.getHijos())
					{
						q.encolar(hijo);
					}
				}
				mensaje += "Nivel " + nivel + ": " + poblacionPorNivel/cantidadPorNivel + "\n";
			}
			return mensaje; 
		}
		
		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{
			//Implementar
			
			return null;
		}
	}
}
