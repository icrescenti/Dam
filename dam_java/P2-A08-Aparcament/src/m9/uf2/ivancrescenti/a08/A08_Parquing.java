package m9.uf2.ivancrescenti.a08;

public class A08_Parquing {
    int places_lliures = 5;

    public A08_Parquing(int places)
    {
        places_lliures = places;
    }

    void ocuparPlaca()
    {
        if (places_lliures > 0)
            places_lliures--;
    }

    void vuidarPlaca()
    {
        places_lliures++;
    }
}