package m9.uf2.ivancrescenti.a06;

public class A06_CompteCompartit {
    double saldo = 55.0000000000000000000000000;

    public boolean retirarDiners(double valorRetirar)
    {
        if (saldo >= valorRetirar)
        {
            saldo -= valorRetirar;
            return true;
        }
        return false;
    }

    double retornarSaldo()
    {
        return saldo;
    }
}