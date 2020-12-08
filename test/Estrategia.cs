
using System;
using System.Collections.Generic;
namespace DeepSpace
{

	class Estrategia
	{
		public String Consulta1( ArbolGeneral<Planeta> arbol){//Recorrido por niveles
			Cola<ArbolGeneral<Planeta>> q = new Cola<ArbolGeneral<Planeta>>();
			q.encolar(arbol);
			int nivel = 0;
			while (!q.esVacia()){
				int elementos = q.cantElementos();
				nivel++;
				while (elementos-- > 0){
					ArbolGeneral<Planeta> nodoActual = q.desencolar();
					if (nodoActual.getDatoRaiz().EsPlanetaDeLaIA()){
						nivel--;
						string texto = nivel.ToString();
						return "La distancia entre la raiz y el planeta del bot es de: " + texto;
					}
					foreach (ArbolGeneral<Planeta> hijo in nodoActual.getHijos()){
						q.encolar(hijo);
					}
				}
			}
			return "";
		}
			
		public String Consulta2( ArbolGeneral<Planeta> arbol){//Recorrido por niveles
			Cola<ArbolGeneral<Planeta>> q = new Cola<ArbolGeneral<Planeta>>();
			q.encolar(arbol);
			int nivel = 0;
			String mensaje = "";
			while (!q.esVacia()){
				int elementos = q.cantElementos();
				nivel++;
				int cantidadPorNivel = 0;
				while (elementos-- > 0){
					ArbolGeneral<Planeta> nodoActual = q.desencolar();
					if (nodoActual.getDatoRaiz().Poblacion() > 10){
						cantidadPorNivel++;
					}
					foreach (ArbolGeneral<Planeta> hijo in nodoActual.getHijos()){
						q.encolar(hijo);
					}
				}
				mensaje += "Nivel " + nivel + ": " + cantidadPorNivel + "-----";
			}
			return mensaje; 
		}
		
		public String Consulta3( ArbolGeneral<Planeta> arbol){//Recorrido por niveles
			Cola<ArbolGeneral<Planeta>> q = new Cola<ArbolGeneral<Planeta>>();
			q.encolar(arbol);
			int nivel = 0;
			String mensaje = "";
			while (!q.esVacia()){
				int elementos = q.cantElementos();
				nivel++;
				int cantidadPorNivel = 0;
				int poblacionPorNivel = 0;
				while (elementos-- > 0){
					ArbolGeneral<Planeta> nodoActual = q.desencolar();
					cantidadPorNivel++;
					poblacionPorNivel += nodoActual.getDatoRaiz().Poblacion();
					foreach (ArbolGeneral<Planeta> hijo in nodoActual.getHijos()){
						q.encolar(hijo);
					}
				}
				mensaje += "Nivel " + nivel + ": " + poblacionPorNivel/cantidadPorNivel + "-----";
			}
			return mensaje; 
		}

		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol){
            if (!arbol.getDatoRaiz().EsPlanetaDeLaIA()){//Si la raiz no pertenece al bot
				List<Planeta> caminoIA = new List<Planeta>();//Creo el camino
				caminoIA = this.caminoRaizIa(arbol,caminoIA);
				int count = caminoIA.Count;
				Movimiento ataque = new Movimiento(caminoIA[count - 1], caminoIA[count - 2]);//Realizo el ataque 
				return ataque;
            }else{//Si la raiz le pertenece al bot
				List<Planeta> caminoPlayer = new List<Planeta>();//Creo el camino
				caminoPlayer = this.caminoRaizPlayer(arbol, caminoPlayer);
				for (int count = 0; count < caminoPlayer.Count; count++){
                    if (!caminoPlayer[count].EsPlanetaDeLaIA()){
						count--;
						Movimiento ataque = new Movimiento(caminoPlayer[count], caminoPlayer[count + 1]);//Realizo el ataque 
						return ataque;
					}
                }
				return null;
			}
		}

		//El metodo caminoRaizIa consigue un camino desde la raiz al primer planeta del bot
		private List<Planeta> caminoRaizIa(ArbolGeneral<Planeta> arbol, List<Planeta> camino){
			camino.Add(arbol.getDatoRaiz());//Agrego el planeta al camino
			if (arbol.getDatoRaiz().EsPlanetaDeLaIA()){//Si encuentro el planeta de la IA retorno el camino
				return camino;
            }else{
				foreach (ArbolGeneral<Planeta> hijo in arbol.getHijos()){
					List<Planeta> caminoAux = this.caminoRaizIa(hijo, camino);
                    if (caminoAux!=null){//Si esta condicion es verdadera significa que el metodo encontro el planeta del bot
						return caminoAux; 
                    }
					camino.RemoveAt(camino.Count - 1);//En caso de llegar a un camino equivocado elimino el ultimo elemento 
				}
			}
			return null;
		}

		//El metodo caminoRaizPlayer consigue un camino desde la raiz al primer planeta del bot
		private List<Planeta> caminoRaizPlayer(ArbolGeneral<Planeta> arbol, List<Planeta> camino){
			camino.Add(arbol.getDatoRaiz());//Agrego el planeta al camino
			if (arbol.getDatoRaiz().EsPlanetaDelJugador())
			{//Si encuentro el planeta del jugdor  retorno el camino
				return camino;
			}else{
				foreach (ArbolGeneral<Planeta> hijo in arbol.getHijos()){
					List<Planeta> caminoAux = this.caminoRaizPlayer(hijo, camino);
					if (caminoAux != null){//Si esta condicion es verdadera significa que el metodo encontro el planeta del jugador
						return caminoAux;
					}
					camino.RemoveAt(camino.Count - 1);//En caso de llegar a un camino equivocado elimino el ultimo elemento 
				}
			}
			return null;
		}
	}
}
