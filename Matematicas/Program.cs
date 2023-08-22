using System.Linq.Expressions;

namespace Matematicas;

public class Real
{
    //DATOS
    public double Valor { get; }

    //OPERACIONES
    public Real(double valor)
    {
        Valor = valor;
    }
    public static Real operator *(Real a, Real b)
    => new Real(a.Valor * b.Valor);
    public static Real operator +(Real a, Real b)
    => new Real(a.Valor + b.Valor);
    public static Real operator -(Real a)
    => new Real(-a.Valor);
    public override string ToString() => $"{Valor}";
}
public interface IComplejo
{
    //DATOS z = x + yi
    Real Real {get; set;}
    Real Imaginaria {get; set;}

    //OPERACIONES
    //Norma = raíz cuadrada de (x*x + y*y)
    Real Norma();
    //conjugado (z) = x - yi
    Complejo Conjugado ();
}
public class Complejo : IComplejo
{
    //DATOS z = x + yi
    private Real _x;
    private Real _y;

    public Real Real { get => _x; set => _x = value;}
    public Real Imaginaria { get => _y; set => _y = value;}
    //OPERACIONES
    public Complejo(Real x, Real y){this._x = x; this._y = y;}
    // <summary> Norma = raiz cuadrada de (x*x + y*y) <summary>
    public Real Norma(){
       return new Real(Math.Sqrt((_x * _x + _y * _y).Valor)); 
    }
    // <summary> conjugado (z) = x - yi<summary>
    public Complejo Conjugado()
    {
        return new Complejo(_x, -_y);
    }
    public override string ToString() => $"{Real} + {Imaginaria} i";
}
class Programa
{
    static void Main(string[] args)
    {
        var c = new Complejo(new Real(3.0), new Real(-2.5));
        Console.WriteLine(c);
    }
}
