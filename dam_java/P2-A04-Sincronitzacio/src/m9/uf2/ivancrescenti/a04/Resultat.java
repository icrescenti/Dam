package m9.uf2.ivancrescenti.a04;

public class Resultat {

	private long resultat;

	/**
	 * Constructor de la classe Resultat. Inicializa l'atribut resultat amb 0
	 */
	public Resultat() {
		resultat = 0;
	}

	/**
	 * Incrementa el valor de l'atribut resultat. �s el m�tode que han de cridar cadascun dels
	 * threads quan acaben la suma de les files que els hi pertoca.
	 * 
	 * @param r
	 *            retorna la suma del valor que ja tenia el resultat m�s el que
	 *            se li passa per par�metre
	 */
	public void incrementaResultat(long r) {
		resultat += r;

	}

	/**
	 * 
	 * @return el resultat
	 */
	public long getResultat() {
		return resultat;
	}

}
